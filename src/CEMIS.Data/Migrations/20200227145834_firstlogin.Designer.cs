﻿// <auto-generated />
using System;
using CEMIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CEMIS.Data.Migrations
{
    [DbContext(typeof(appContext))]
    [Migration("20200227145834_firstlogin")]
    partial class firstlogin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CEMIS.Data.Entities.APIRequestLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data");

                    b.Property<byte>("RequestType");

                    b.Property<bool>("Synched");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("APIRequestLog");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.College", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("AdminOfficerEmail");

                    b.Property<string>("AdminOfficerName");

                    b.Property<string>("AdminOfficerPhone");

                    b.Property<int>("CleanerCount");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int>("DriversCount");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("GIS");

                    b.Property<int>("HandymenCount");

                    b.Property<string>("ICTSystemEmail");

                    b.Property<string>("ICTSystemName");

                    b.Property<string>("ICTSystemPhone");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSynched");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("PrincipalEmail");

                    b.Property<string>("PrincipalName");

                    b.Property<string>("PrincipalPhone");

                    b.Property<int>("SecretaryCount");

                    b.Property<int>("SecurityGuardCount");

                    b.Property<long>("ServiceOfferedId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<string>("VicePrincipalEmail");

                    b.Property<string>("VicePrincipalName");

                    b.Property<string>("VicePrincipalPhone");

                    b.HasKey("Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.CollegeClassRoomData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassRoomCount");

                    b.Property<long>("CollegeId");

                    b.Property<int>("IsClassHeldOutside");

                    b.Property<bool>("IsSynched");

                    b.Property<int>("LaboratoryCount");

                    b.Property<int>("LibraryCount");

                    b.Property<int>("OfficeCount");

                    b.Property<int>("OthersCount");

                    b.Property<int>("StaffRoomCount");

                    b.Property<int>("StoreRoomCount");

                    b.HasKey("Id");

                    b.ToTable("CollegeClassRoomData");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.CollegeClassRoomInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeId");

                    b.Property<int>("DisabilityAccess");

                    b.Property<int>("FloorMaterial");

                    b.Property<bool>("IsSynched");

                    b.Property<decimal>("LengthInMeters");

                    b.Property<int>("PresentCondition");

                    b.Property<int>("RoofMaterial");

                    b.Property<int>("Seatings");

                    b.Property<int>("WallMaterial");

                    b.Property<decimal>("WidthInMeters");

                    b.Property<string>("YearOfConstruction");

                    b.HasKey("Id");

                    b.ToTable("CollegeClassRoomInfo");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.CollegeFacility", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSynched");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Number");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("CollegeFacility");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.CollegeLeadership", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CouncilMember");

                    b.Property<string>("CouncilMemberEmail")
                        .HasMaxLength(50);

                    b.Property<string>("CouncilMemberPhone1")
                        .HasMaxLength(20);

                    b.Property<string>("CouncilMemberPhone2")
                        .HasMaxLength(20);

                    b.Property<string>("CouncilMemberPostalAddress");

                    b.Property<byte>("CouncilMemberSponsor");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateAppointed");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateLeft");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<byte>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSynched");

                    b.Property<string>("Name");

                    b.Property<int>("Role");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("CollegeLeadership");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.CourseOffered", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CourseOffered");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.EmailLog", b =>
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

            modelBuilder.Entity("CEMIS.Data.Entities.EmailTemplate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("API_Key");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<long?>("UpdatedBy");

                    b.Property<string>("body");

                    b.Property<string>("code");

                    b.Property<int>("etemplate_id");

                    b.Property<string>("name");

                    b.Property<string>("subject");

                    b.HasKey("Id");

                    b.ToTable("emailTemplates");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.Role", b =>
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

            modelBuilder.Entity("CEMIS.Data.Entities.ServiceOffered", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CollegeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ServiceOffered");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.StaffGradeLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("API_Key");

                    b.Property<string>("Code");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("staffGradeLevel");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.TeachingStaff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicQualification");

                    b.Property<string>("AcademicQualificationCertNo");

                    b.Property<string>("AreaOfSpecialization");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("DateOfCurrentAppointment");

                    b.Property<DateTime>("DateOfFirstAppointment");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<byte>("Gender");

                    b.Property<int>("GradeLevel");

                    b.Property<string>("InServiceTraining");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSynched");

                    b.Property<int>("LecturerGrade");

                    b.Property<int>("MainAdminRole");

                    b.Property<string>("MainSubjectTaught");

                    b.Property<string>("Name");

                    b.Property<string>("SourceOfSalary");

                    b.Property<string>("StaffFileNo");

                    b.Property<string>("SubjectOfQualification");

                    b.Property<string>("TeachingQualification");

                    b.Property<string>("TeachingQualificationCertNo");

                    b.Property<string>("TeachingType");

                    b.Property<long?>("UpdatedBy");

                    b.Property<string>("YearOfFirstAppointment");

                    b.Property<string>("YearOfPostingToCollege");

                    b.Property<string>("YearOfPresentAppointment");

                    b.HasKey("Id");

                    b.ToTable("TeachingStaff");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.TeachingStaffAdminRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("API_Key");

                    b.Property<string>("Code");

                    b.Property<long>("CollegeID");

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

            modelBuilder.Entity("CEMIS.Data.Entities.User", b =>
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

                    b.Property<bool>("IsFirstLogin");

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

            modelBuilder.Entity("CEMIS.Data.Entities.UsersPassword", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("API_Key");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CreatedBy");

                    b.Property<int>("CumulativeLogins");

                    b.Property<DateTime>("DateCreated");

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

                    b.Property<int>("SuccessfulLogins");

                    b.Property<long?>("UpdatedBy");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("coreUsersPasswords");
                });

            modelBuilder.Entity("CEMIS.Data.UserLoginHistory", b =>
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

            modelBuilder.Entity("CEMIS.Data.UsersPasswordHist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("API_Key");

                    b.Property<long>("CollegeID");

                    b.Property<long>("CoreUserId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PwdCount");

                    b.Property<string>("PwdEncrypt");

                    b.Property<long?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("usersPasswordHists");
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

            modelBuilder.Entity("CEMIS.Data.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<long>");

                    b.Property<long>("Id");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("ModifiedBy");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("CEMIS.Data.Entities.UsersPassword", b =>
                {
                    b.HasOne("CEMIS.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CEMIS.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("CEMIS.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
