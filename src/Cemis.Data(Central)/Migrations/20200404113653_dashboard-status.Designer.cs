﻿// <auto-generated />
using System;
using CEMIS.Data.Central;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cemis.Data.Central.Migrations
{
    [DbContext(typeof(appContextCentral))]
    [Migration("20200404113653_dashboard-status")]
    partial class dashboardstatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CEMIS.Data.Central.College", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("APIKey");

                    b.Property<string>("Address");

                    b.Property<string>("AdminOfficerEmail");

                    b.Property<string>("AdminOfficerName");

                    b.Property<string>("AdminOfficerPhone");

                    b.Property<int>("CleanerCount");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int>("DriversCount");

                    b.Property<string>("Email");

                    b.Property<string>("GIS");

                    b.Property<int>("HandymenCount");

                    b.Property<string>("ICTSystemEmail");

                    b.Property<string>("ICTSystemName");

                    b.Property<string>("ICTSystemPhone");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("PrincipalEmail");

                    b.Property<string>("PrincipalName");

                    b.Property<string>("PrincipalPhone");

                    b.Property<int>("SecretaryCount");

                    b.Property<int>("SecurityGuardCount");

                    b.Property<long>("ServiceOfferedId");

                    b.Property<long>("SourceID");

                    b.Property<long?>("UpdatedBy");

                    b.Property<string>("VicePrincipalEmail");

                    b.Property<string>("VicePrincipalName");

                    b.Property<string>("VicePrincipalPhone");

                    b.HasKey("Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("CEMIS.Data.Central.CollegeClassRoomData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassRoomCount");

                    b.Property<long>("CollegeId");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<int>("IsClassHeldOutside");

                    b.Property<int>("LaboratoryCount");

                    b.Property<int>("LibraryCount");

                    b.Property<int>("OfficeCount");

                    b.Property<int>("OthersCount");

                    b.Property<long>("SourceId");

                    b.Property<int>("StaffRoomCount");

                    b.Property<int>("StoreRoomCount");

                    b.HasKey("Id");

                    b.ToTable("CollegeClassRoomData");
                });

            modelBuilder.Entity("CEMIS.Data.Central.CollegeClassRoomInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeId");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<int>("DisabilityAccess");

                    b.Property<int>("FloorMaterial");

                    b.Property<decimal>("LengthInMeters");

                    b.Property<int>("PresentCondition");

                    b.Property<int>("RoofMaterial");

                    b.Property<int>("Seatings");

                    b.Property<long>("SourceId");

                    b.Property<int>("WallMaterial");

                    b.Property<decimal>("WidthInMeters");

                    b.Property<string>("YearOfConstruction");

                    b.HasKey("Id");

                    b.ToTable("CollegeClassRoomInfo");
                });

            modelBuilder.Entity("CEMIS.Data.Central.CollegeFacility", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<int>("DisabilityAccess");

                    b.Property<string>("FacilityType")
                        .IsRequired();

                    b.Property<int>("FloorMaterial");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("LengthInMeters")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PresentCondition");

                    b.Property<int>("RoofMaterial");

                    b.Property<int>("Seatings");

                    b.Property<long>("SourceID");

                    b.Property<long?>("UpdatedBy");

                    b.Property<decimal>("WidthInMeters")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("YearOfConstruction")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CollegeFacility");
                });

            modelBuilder.Entity("CEMIS.Data.Central.CollegeLeadership", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<string>("CouncilMember");

                    b.Property<string>("CouncilMemberEmail");

                    b.Property<string>("CouncilMemberPhone1");

                    b.Property<string>("CouncilMemberPhone2");

                    b.Property<string>("CouncilMemberPostalAddress");

                    b.Property<byte>("CouncilMemberSponsor");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateAppointed");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateLeft");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<byte>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<long>("Role");

                    b.Property<long>("SourceID");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CollegeID");

                    b.ToTable("CollegeLeadership");
                });

            modelBuilder.Entity("CEMIS.Data.Central.CourseOffered", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("SourceID");

                    b.HasKey("Id");

                    b.ToTable("CourseOffered");
                });

            modelBuilder.Entity("CEMIS.Data.Central.EmailLog", b =>
                {
                    b.Property<long>("EmaillogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentLoc");

                    b.Property<string>("Body");

                    b.Property<bool?>("CanSend");

                    b.Property<string>("Createdby");

                    b.Property<DateTime>("Createddate");

                    b.Property<DateTime>("Datetosend");

                    b.Property<string>("EmailBcc");

                    b.Property<string>("EmailCc");

                    b.Property<bool?>("FailedSending");

                    b.Property<string>("From");

                    b.Property<bool>("HasAttachment");

                    b.Property<DateTime?>("LastFailed");

                    b.Property<DateTime?>("Lastmodified");

                    b.Property<string>("Modifiedby");

                    b.Property<string>("Name");

                    b.Property<bool>("Sendimmediately");

                    b.Property<bool>("Sent");

                    b.Property<string>("Subject");

                    b.Property<string>("To");

                    b.HasKey("EmaillogId");

                    b.ToTable("emailLogs");
                });

            modelBuilder.Entity("CEMIS.Data.Central.EmailTemplate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("SourceID");

                    b.Property<long?>("UpdatedBy");

                    b.Property<string>("body");

                    b.Property<string>("code");

                    b.Property<int>("etemplate_id");

                    b.Property<string>("name");

                    b.Property<string>("subject");

                    b.HasKey("Id");

                    b.ToTable("emailTemplates");
                });

            modelBuilder.Entity("CEMIS.Data.Central.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsSuperUser");

                    b.Property<DateTime?>("LastModified");

                    b.Property<long>("ModifiedBy");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("PermissionsInRole");

                    b.Property<string>("RoleDesc");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CEMIS.Data.Central.ServiceOffered", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("SourceID");

                    b.HasKey("Id");

                    b.ToTable("ServiceOffered");
                });

            modelBuilder.Entity("CEMIS.Data.Central.TeachingStaff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicQualification");

                    b.Property<string>("AcademicQualificationCertNo");

                    b.Property<string>("AreaOfSpecialization");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("DateOfCurrentAppointment");

                    b.Property<DateTime>("DateOfFirstAppointment");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("DueForPromotion");

                    b.Property<byte>("Gender");

                    b.Property<long>("GradeLevel");

                    b.Property<int?>("GradeLevelPromotion");

                    b.Property<string>("InServiceTraining");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("LecturerGrade");

                    b.Property<long>("MainAdminRole");

                    b.Property<string>("MainSubjectTaught");

                    b.Property<string>("Name");

                    b.Property<DateTime>("RetiredDate");

                    b.Property<long>("SourceID");

                    b.Property<byte>("SourceOfSalary");

                    b.Property<string>("StaffCategory");

                    b.Property<string>("StaffFileNo");

                    b.Property<string>("StaffRank");

                    b.Property<string>("StaffType");

                    b.Property<string>("Step");

                    b.Property<int?>("StepPromotion");

                    b.Property<string>("SubjectOfQualification");

                    b.Property<string>("TeachingQualification");

                    b.Property<string>("TeachingQualificationCertNo");

                    b.Property<byte>("TeachingType");

                    b.Property<long?>("UpdatedBy");

                    b.Property<string>("YearOfFirstAppointment");

                    b.Property<string>("YearOfPostingToCollege");

                    b.Property<string>("YearOfPresentAppointment");

                    b.HasKey("Id");

                    b.ToTable("TeachingStaff");
                });

            modelBuilder.Entity("CEMIS.Data.Central.TeachingStaffAdminRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("TeachingStaffAdminRoles");
                });

            modelBuilder.Entity("CEMIS.Data.Central.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModeified");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname");

                    b.Property<bool>("ForcePwdChange");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("Isdeleted");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<string>("Lastname");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Middlename");

                    b.Property<long?>("ModifiedBy");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime?>("PwdChangedDate");

                    b.Property<DateTime>("PwdExpiryDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CEMIS.Data.Central.UserLoginHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser");

                    b.Property<long>("CreatedBy");

                    b.Property<string>("IpAddress");

                    b.Property<string>("Operation");

                    b.Property<DateTime>("SessionDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserLoginHistory");
                });

            modelBuilder.Entity("CEMIS.Data.Central.UsersPassword", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<int>("CumulativeLogins");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool?>("ForcePwdChange");

                    b.Property<int>("InvalidLogins");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<DateTime?>("LastModified");

                    b.Property<bool?>("LockedOut");

                    b.Property<DateTime?>("LockoutDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("PwdChangedDate");

                    b.Property<string>("PwdEncrypt");

                    b.Property<DateTime?>("PwdExpiryDate");

                    b.Property<long>("SourceID");

                    b.Property<int>("SuccessfulLogins");

                    b.Property<long?>("UpdatedBy");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("coreUsersPasswords");
                });

            modelBuilder.Entity("CEMIS.Data.Central.UsersPasswordHist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<long>("CoreUserId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PwdCount");

                    b.Property<string>("PwdEncrypt");

                    b.Property<long>("SourceID");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("usersPasswordHists");
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.Allowance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BasicSalary");

                    b.Property<decimal?>("BasicsalaryPromotion");

                    b.Property<decimal>("BicycleMaintenance");

                    b.Property<decimal?>("BicycleMaintenancePromotionAllowance");

                    b.Property<decimal>("Books");

                    b.Property<decimal?>("BooksPromotionAllowance");

                    b.Property<decimal>("CarMaintenance");

                    b.Property<decimal?>("CarMaintenancePromotionAllowance");

                    b.Property<long>("CollegeID");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<decimal>("DomesticServant");

                    b.Property<decimal?>("DomesticServantPromotionAllowance");

                    b.Property<decimal>("Entertainment");

                    b.Property<decimal?>("EntertainmentPromotionAllowance");

                    b.Property<decimal>("HouseholdSupplies");

                    b.Property<decimal?>("HouseholdSuppliesPromotionAllowance");

                    b.Property<decimal>("MarketPremium");

                    b.Property<decimal?>("MarketPremiumPromotionAllowance");

                    b.Property<decimal>("MotorBikeMaintenance");

                    b.Property<decimal?>("MotorBikeMaintenancePromotionAllowance");

                    b.Property<decimal>("Others");

                    b.Property<decimal?>("OthersPromotionAllowance");

                    b.Property<decimal>("Research");

                    b.Property<decimal?>("ResearchPromotionAllowance");

                    b.Property<decimal>("Responsibility");

                    b.Property<decimal?>("ResponsibilityPromotionAllowance");

                    b.Property<long>("StaffId");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Allowance");
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.Certificate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<string>("Name");

                    b.Property<long>("StaffId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.DashboardHistory", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClassRoomCount");

                    b.Property<long>("CollegeCount");

                    b.Property<long>("CollegeLeadershipCount");

                    b.Property<long>("FacilityCount");

                    b.Property<long>("TeachingStaffCOunt");

                    b.Property<long>("UserID");

                    b.HasKey("ID");

                    b.ToTable("DashboardHistory");
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.PreviousEducation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("FromDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("OfficeHeld");

                    b.Property<string>("School");

                    b.Property<long>("SourceID");

                    b.Property<long>("StudentID");

                    b.Property<string>("ToDate");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("StudentID");

                    b.ToTable("PreviousEducation");
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.StaffGradeLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("Name");

                    b.Property<long>("SourceID");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("StaffGradeLevel");
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppRefNumber");

                    b.Property<long>("CollegeID");

                    b.Property<string>("ContactAddress");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DOB");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateFetched");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Disability");

                    b.Property<string>("District");

                    b.Property<string>("FirstChoiceCollege");

                    b.Property<string>("FirstChoiceProgram");

                    b.Property<byte>("Gender");

                    b.Property<string>("HomeTown");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LanguagesSpoken");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("OtherNames");

                    b.Property<string>("POB");

                    b.Property<string>("ParentParticulars");

                    b.Property<string>("Passport");

                    b.Property<string>("Region");

                    b.Property<string>("Religion");

                    b.Property<string>("Result");

                    b.Property<string>("SecondChoiceCollege");

                    b.Property<string>("SecondChoiceProgram");

                    b.Property<long>("SourceID");

                    b.Property<string>("Surname");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("ThirdChoiceCollege");

                    b.Property<string>("ThreeChoiceProgram");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CEMIS.Data.Central.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<long>");

                    b.Property<long>("Id");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("ModifiedBy");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("CEMIS.Data.Central.CollegeLeadership", b =>
                {
                    b.HasOne("CEMIS.Data.Central.College", "College")
                        .WithMany()
                        .HasForeignKey("CollegeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CEMIS.Data.Central.UsersPassword", b =>
                {
                    b.HasOne("CEMIS.Data.Central.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.Allowance", b =>
                {
                    b.HasOne("CEMIS.Data.Central.TeachingStaff", "teachingStaff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.Certificate", b =>
                {
                    b.HasOne("CEMIS.Data.Central.TeachingStaff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cemis.Data.Central.Entities.PreviousEducation", b =>
                {
                    b.HasOne("Cemis.Data.Central.Entities.Student", "Student")
                        .WithMany("previousEducations")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Central.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Central.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Central.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Central.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CEMIS.Data.Central.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Central.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
