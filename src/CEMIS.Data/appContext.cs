using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CEMIS.Data
{
    public class appContext : IdentityDbContext<User, Role, long>//DbContext
    {


        public appContext(DbContextOptions<appContext> options) : base(options)
        {

        }
        public DbSet<CompensationReport> CompensationReport { get; set; }
        public DbSet<StaffCPDAssesment> StaffCPDAssesment { get; set; }
        public DbSet<CollegeCPDAssesment> CollegeCPDAssesment { get; set; }
        public DbSet<Committee> Committee { get; set; }
        public DbSet<CommitteMembers> CommitteMembers { get; set; }
        public DbSet<CouncilSession> CouncilSession { get; set; }
        public DbSet<StaffGradeLevel> staffGradeLevel { get; set; }
        public DbSet<StaffAllowance> StaffAllowance { get; set; }
        public DbSet<StaffDueForPromotionAllowance> StaffDueForPromotionAllowance { get; set; }
        public DbSet<GradeLevel> gradeLevels { get; set; }
        public DbSet<StaffGradeStep> staffGradeSteps { get; set; }
        public DbSet<Step> steps { get; set; }
        public DbSet<Allowance> allowances { get; set; }
        public DbSet<StaffType> staffTypes { get; set; }
        public DbSet<BasicSalary> BasicSalary { get; set; }
        public DbSet<TeachingStaff> TeachingStaff { get; set; }
        public DbSet<TeachingStaffAdminRole> TeachingStaffAdminRoles { get; set; }
        public DbSet<APIRequestLog> APIRequestLog { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistory { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UsersPasswordHist> usersPasswordHists { get; set; }
        public DbSet<UsersPassword> coreUsersPasswords { get; set; }
        public DbSet<EmailTemplate> emailTemplates { get; set; }
        public DbSet<EmailLog> emailLogs { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeFacility> CollegeFacility { get; set; }
        public DbSet<GoodsAndServicesSettings> GoodsAndServicesSettings { get; set; }
        public DbSet<GoodsAndServicesSettingSubItems> GoodsAndServicesSettingSubItems { get; set; }
        public DbSet<RevenueCompensationHead> RevenueCompensationHeads { get; set; }
        public DbSet<RevenueCompesationItem> RevenueCompesationItems { get; set; }
        public DbSet<RevenueEstimateHead> RevenueEstimateHeads { get; set; }
        public DbSet<RevenueestimateItem> RevenueestimateItems { get; set; }
        public DbSet<RevenueEstimateTypeCode> RevenueEstimateTypeCode { get; set; }
        public DbSet<RevenueExpenditureHead> RevenueExpenditureHead { get; set; }
        public DbSet<RevenueExpenditureItem> RevenueExpenditureItems { get; set; }
        public DbSet<RevenueFixedAssetHead> RevenueFixedAssetHead { get; set; }
        public DbSet<RevenueFixedAssetitem> RevenueFixedAssetitems { get; set; }
        public DbSet<Revenueitemlog> Revenueitemlogs { get; set; }
        public DbSet<RevenueGoodandServiceHead> RevenueGoodandServiceHead { get; set; }
        public DbSet<RevenueGoodsandServiceitem> RevenueGoodsandServiceitems { get; set; }
        public DbSet<RevenueSummaryPerCollegeHead> RevenueSummaryPerCollegeHead { get; set; }
        public DbSet<RevenueSummaryPerCollegeItem> RevenueSummaryPerCollegeItems { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AcademicSession> AcademicSessions { get; set; }
        public DbSet<CouncilMember> CouncilMembers { get; set; }
        public DbSet<CollegeClassRoomData> CollegeClassRoomData { get; set; }
        public DbSet<CollegeClassRoomInfo> CollegeClassRoomInfo { get; set; }
        public DbSet<CollegeLeadership> CollegeLeadership { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Student> PreviousEducation { get; set; }
        public DbSet<CourseOffered> CourseOffered { get; set; }
        public DbSet<ServiceOffered> ServiceOffered { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<StaffCategory> StaffCategories { get; set; }
        public DbSet<StaffPosition> StaffPositions { get; set; }
        public DbSet<StaffRank> StaffRanks { get; set; }
        public DbSet<RevenueExpenditureTypeCode> revenueExpenditureTypeCodes { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<StudentLog> StudentLogs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TrackCollegeChanges> TrackCollegeChanges { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<PartnerSchool> PartnerSchools { get; set; }
        public DbSet<PartnerSchoolCPDAssesment> PartnerSchoolCPDAssesments { get; set; }

    }
    //public class appContextFactory : IDesignTimeDbContextFactory<appContext>
    //{
    //    //public IConfiguration Configuration { get; }
    //    //public appContextFactory(IConfiguration configuration)
    //    //{
    //    //    Configuration = configuration;
    //    //}
    //    public appContext CreateDbContext(string[] args)
    //    {

    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //        .SetBasePath(Directory.GetCurrentDirectory())
    //        .AddJsonFile("appsettings.json")
    //        .Build();

    //        var builder = new DbContextOptionsBuilder<appContext>();

    //        var connectionString = configuration.GetConnectionString("DefaultConnection");

    //        builder.UseSqlServer(connectionString);

    //        return new appContext(builder.Options);
    //        //var optionsBuilder = new DbContextOptionsBuilder<appContext>();
    //        //optionsBuilder.UseSqlServer("Server=FLEETTFSSRV001\\APPSDB;Database=CEMIS;persist security info=True;user id=development;password=password;MultipleActiveResultSets=true");
    //        //optionsBuilder.UseSqlServer("Data Source=L-OABAYOMI;Database=CEMIS;Trusted_Connection=True");
    //        //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    //        //  return new appContext(optionsBuilder.Options);
    //    }
    //}
}
