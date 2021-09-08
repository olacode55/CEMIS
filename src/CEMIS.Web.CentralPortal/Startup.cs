using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CEMIS.Data.Central;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using CEMIS.Business.Central.Interface;
using CEMIS.Business.Central.Repository;
using CEMIS.Business.Central.Services;
using AutoMapper;
using Cemis.Business.Central.Repository;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Cemis.Business.Central.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Cemis.Business.Central.Services;
using Hangfire;
using Hangfire.SqlServer;
using CEMIS.Web.CentralPortal.Utilities;

namespace CEMIS.Web.CentralPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<appContextCentral>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services
               .AddIdentity<User, Role>()
               .AddEntityFrameworkStores<appContextCentral>()
               .AddUserManager<UserManager<User>>()
               .AddRoleManager<RoleManager<Role>>()
               .AddSignInManager<SignInManager<User>>()
               .AddDefaultTokenProviders()
               .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactory>();

            services.AddLogging(options =>
            {
                options.AddConfiguration(Configuration.GetSection("Logging"));
            });


            services.AddAuthentication().AddCookie(options =>
            {
                options.Cookie.Name = "CemisCentral";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });

            services.AddHangfire(configuration => configuration
              .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
              .UseSimpleAssemblyNameTypeSerializer()
              .UseRecommendedSerializerSettings()
              .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
              {
                  CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                  SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                  QueuePollInterval = TimeSpan.Zero,
                  UseRecommendedIsolationLevel = true,
                  UsePageLocksOnDequeue = true,
                  DisableGlobalLocks = true
              }));



            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.IsEssential = true;
            });
         
            // Add the processing server as IHostedService
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IStaff), typeof(StaffRepository));
            services.AddScoped(typeof(ICollegeLeadership), typeof(CollegeLeadershipRepository));
            services.AddScoped(typeof(ICollege), typeof(CollegeRepository));
            services.AddScoped(typeof(IStudent), typeof(StudentRepository));
            services.AddScoped(typeof(ICourse), typeof(CourseRepository));
            services.AddScoped(typeof(IReport), typeof(ReportRepository));
            services.AddScoped(typeof(IBasicSalary), typeof(BasicSalaryRepository));
            services.AddScoped(typeof(IProgram), typeof(ProgramRepository)); 
            services.AddScoped(typeof(IAnalytics), typeof(AnalyticsRepository));
            services.AddScoped(typeof(IAllowance), typeof(AllowanceRepository));
            services.AddScoped(typeof(ICouncilSession), typeof(CouncilSessionRepository));
            services.AddScoped(typeof(IResult), typeof(ResultRepository));
            services.AddScoped(typeof(IAcademicSession), typeof(AcademicSessionRepository));
            services.AddScoped(typeof(IActivityLog), typeof(ActivityLogRepository));
            services.AddScoped(typeof(ISystemsReport), typeof(SystemsReportRepository));
            services.AddScoped(typeof(IEmailHanfireHandler), typeof(EmailHanfireHandler));

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserManagementServices, UserManagementServices>();
            services.AddTransient<IMessageManagementService, MessageManagementService>();
            services.AddTransient<ISeedingManagementService, SeedingManagementService>();
            services.AddTransient<IMailManagementService, MailManagementService>();
            services.AddTransient<IPasswordService, PasswordManangementServices>();
            services.AddSingleton<IAuthUser, AuthUser>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CEMIS API", Version = "v1" });
            });
            //services.AddControllers();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
           

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



            //services.AddAutoMapper();
            //  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , IEmailHanfireHandler emailService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CEMIS API V1");
            });

      
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseHangfireDashboard();

            emailService.Email();
        }
    }
}
