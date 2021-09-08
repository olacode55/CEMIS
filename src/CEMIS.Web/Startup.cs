using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Repository;
using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Business.Repository;
using CEMIS.Business.Services;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.Utilities;
using CEMIS.Utility.Util;
using CEMIS.Web.AuthenticationUtility;
using CEMIS.Web.Utilities;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CEMIS.Web
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
            services.AddDbContext<appContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<appContext>()
               .AddUserManager<UserManager<User>>()
               .AddRoleManager<RoleManager<Role>>()
               .AddSignInManager<SignInManager<User>>()
               .AddPasswordValidator<UsernameAsPasswordValidator<User>>()
               .AddPasswordValidator<EmailAsPasswordValidator<User>>()
               .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@";
                options.User.RequireUniqueEmail = false;
            });
            //Adding Logging
            services.AddLogging(options =>
            {
                options.AddConfiguration(Configuration.GetSection("Logging"));
            });


            services.AddAuthentication().AddCookie(options =>
            {
                options.Cookie.Name = "Cemis";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });

            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add Hangfire services.
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
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


            // Add the processing server as IHostedService IRepositoryUtility
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddHangfireServer();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IStaff), typeof(StaffRepository));
            services.AddScoped(typeof(IFacility), typeof(FacilityRepository));
            services.AddScoped(typeof(Business.ISession), typeof(SessionRepository));
            services.AddScoped(typeof(IAcademicSession), typeof(AcademicSessionRepository));
            services.AddScoped(typeof(IRevenueFixedAsset), typeof(RevenueFixedAsset));
            services.AddScoped(typeof(IRepositoryUtility), typeof(RepositoryUtility));
            services.AddScoped(typeof(IFacilityType), typeof(FacilityTypeRepository));
            services.AddScoped(typeof(IUnit), typeof(UnitRepository));
            services.AddScoped(typeof(IDepartment), typeof(DepartmentRepository));
            services.AddScoped(typeof(IMainAdminRole), typeof(MainAdminRoleRepository));
            services.AddScoped(typeof(IRoomFacility), typeof(RoomFacilityRepository));
            services.AddScoped(typeof(IRevenueExpenditure), typeof(RevenueExpenditureRepository));
            services.AddScoped(typeof(ICollegeLeadership), typeof(CollegeLeadershipRepository));
            services.AddScoped(typeof(IHandFireJobHandler), typeof(HandFireJobHandler));
            services.AddScoped(typeof(IRevenueEstimate), typeof(RevenueEstimateRepository));
            services.AddScoped(typeof(IGoodsAndServices), typeof(GoodsAndServicesRepository));
            services.AddScoped(typeof(IStaffGradeLevel), typeof(StaffGradeLevelRepository));
            services.AddScoped(typeof(IStaffType), typeof(StaffTypeRepostory));
            services.AddScoped(typeof(IStaffCategory), typeof(StaffCategoryRepository));
            services.AddScoped(typeof(IStaffRank), typeof(StaffRankRepostory));
            services.AddScoped(typeof(ICertificate), typeof(CertificateRepository));
            services.AddScoped(typeof(IGradeLevel), typeof(GradeLevelRepository));
            services.AddScoped(typeof(ISelectFactory), typeof(SelectListFactory));
            services.AddScoped(typeof(ICouncilMembers), typeof(CouncilMembersRepository));
            services.AddScoped(typeof(IBasicSalary), typeof(BasicSalaryRepository));
            services.AddScoped(typeof(IAllowance), typeof(AllowanceRepository));
            services.AddScoped(typeof(IStaffAllowance), typeof(StaffAllowanceRepository));
            services.AddScoped(typeof(ICompensationReport), typeof(CompensationReportRepository));
            services.AddScoped(typeof(IStaffDueForPromotionAllowance), typeof(StaffDueForPromotionRepository));
            services.AddScoped(typeof(ICouncilSession), typeof(CouncilSessionRepository));
            services.AddScoped(typeof(ICommittee), typeof(CommitteRepository));
            services.AddScoped(typeof(ICommitteMembers), typeof(CommitteMembersRepository));
            services.AddScoped(typeof(IStaffCPDAssesment), typeof(StaffCPDAssesmentRepository));
            services.AddScoped(typeof(ICollegeCPDAssesment), typeof(CollegeCPDAssesmentRepository));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserManagementServices, UserManagementServices>();
            services.AddTransient<IMessageManagementService, MessageManagementService>();
            services.AddTransient<ICollege, CollegeRepository>();
            services.AddTransient<ISeedingManagementService, SeedingManagementService>();
            services.AddTransient<IMailManagementService, MailManagementService>();
            services.AddTransient<IReport, ReportRepository>();
            services.AddTransient<IPasswordService, PasswordManangementServices>();
            services.AddTransient<IAppConnection, AppConnection>();
            services.AddSingleton<IAuthUser, AuthUser>();
            services.AddTransient<IStudent, StudentRepository>();
            services.AddTransient<IProgram, ProgramRepostory>();
            services.AddTransient<ILevel, LevelRepository>();
            services.AddTransient<ICourse, CourseRepository>();
            services.AddTransient<IResult, ResultRepository>();
            services.AddTransient<IPartnerSchool, PartnerSchoolRepository>();
            services.AddTransient<IPartnerSchoolCPDAssesment, PartnerSchoolCPDAssesmentRepository>();


            //services.AddScoped(typeof(Job));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IHandFireJobHandler handFireJob
            )
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
            //app.UseDeveloperExceptionPage(); 

            app.UseAuthentication();
            //app.UseCookiePolicy();
            app.UseSession();

            //app.UseHttpsRedirection();

            app.UseStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            ////Do Hangfirehere
            app.UseHangfireDashboard();

            handFireJob.ReccuringJob();
        }
    }
}
