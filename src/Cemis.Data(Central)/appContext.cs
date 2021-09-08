
using Cemis.Data.Central.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public class appContextCentral : IdentityDbContext<User, Role, long>//DbContext
    {


        //public EnrouteContext() : base() { }

        public appContextCentral(DbContextOptions<appContextCentral> options) : base(options)
        {

        }
        public DbSet<TeachingStaff> TeachingStaff { get; set; }
        public DbSet<TeachingStaffAdminRole> TeachingStaffAdminRoles { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistory { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UsersPasswordHist> usersPasswordHists { get; set; }
        public DbSet<UsersPassword> coreUsersPasswords { get; set; }
        public DbSet<EmailTemplate> emailTemplates { get; set; }
        public DbSet<EmailLog> emailLogs { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeFacility> CollegeFacility { get; set; }

        public DbSet<CollegeClassRoomData> CollegeClassRoomData { get; set; }
        public DbSet<CollegeClassRoomInfo> CollegeClassRoomInfo { get; set; }
        public DbSet<CollegeLeadership> CollegeLeadership { get; set; }

        public DbSet<CourseOffered> CourseOffered { get; set; }
        public DbSet<ServiceOffered> ServiceOffered { get; set; }
        public DbSet<StaffGradeLevel> StaffGradeLevel { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<PreviousEducation> PreviousEducation { get; set; }
        public DbSet<Allowance> Allowance { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<DashboardHistory> DashboardHistory { get; set; }
        public DbSet<AcademicSession> AcademicSessions { get; set; }
        public DbSet<CouncilMember> CouncilMember { get; set; }
        public DbSet<BasicSalary> BasicSalary { get; set; }
        public DbSet<StaffAllowance> StaffAllowance { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<CouncilSession> CouncilSession { get; set; }
        public DbSet<Commitee> Commitee { get; set; }
        public DbSet<CommitteeMembers> CommitteeMembers { get; set; }
        public DbSet<StudentLog> StudentLog { get; set; }
        public DbSet<StaffDueForPromotionallowance> StaffDueForPromotionallowance { get; set; }

    }




    public class appContextFactory : IDesignTimeDbContextFactory<appContextCentral>
    {
        //public IConfiguration Configuration { get; }
        //public appContextFactory(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public appContextCentral CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<appContextCentral>();
            optionsBuilder.UseSqlServer("Server=L-AOLATUNJI;Database=CEMISCENTRAL(NEW);persist security info=True;user id=development;password=password;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer("Data Source=L-OABAYOMI;Database=CEMIS;Trusted_Connection=True");
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            return new appContextCentral(optionsBuilder.Options);
        }
    }
}
