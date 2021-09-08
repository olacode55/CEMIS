using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PermissionsInRole = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<long>(nullable: false),
                    IsSuperUser = table.Column<bool>(nullable: false),
                    RoleDesc = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Middlename = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModeified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<long>(nullable: true),
                    Isdeleted = table.Column<bool>(nullable: false),
                    ForcePwdChange = table.Column<bool>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    PwdChangedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PwdExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollegeLeadership",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CouncilMember = table.Column<string>(nullable: true),
                    CouncilMemberPhone1 = table.Column<string>(nullable: true),
                    CouncilMemberPhone2 = table.Column<string>(nullable: true),
                    CouncilMemberEmail = table.Column<string>(nullable: true),
                    CouncilMemberPostalAddress = table.Column<string>(nullable: true),
                    CouncilMemberSponsorGovernment = table.Column<string>(nullable: true),
                    CouncilMemberSponsorCommunity = table.Column<string>(nullable: true),
                    DateAppointed = table.Column<DateTime>(nullable: false),
                    DateLeft = table.Column<DateTime>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeLeadership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PrincipalName = table.Column<string>(nullable: true),
                    PrincipalEmail = table.Column<string>(nullable: true),
                    PrincipalPhone = table.Column<string>(nullable: true),
                    VicePrincipalName = table.Column<string>(nullable: true),
                    VicePrincipalEmail = table.Column<string>(nullable: true),
                    VicePrincipalPhone = table.Column<string>(nullable: true),
                    ICTSystemName = table.Column<string>(nullable: true),
                    ICTSystemEmail = table.Column<string>(nullable: true),
                    ICTSystemPhone = table.Column<string>(nullable: true),
                    AdminOfficerName = table.Column<string>(nullable: true),
                    AdminOfficerEmail = table.Column<string>(nullable: true),
                    AdminOfficerPhone = table.Column<string>(nullable: true),
                    GIS = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ServiceOfferedId = table.Column<long>(nullable: false),
                    SecretaryCount = table.Column<int>(nullable: false),
                    DriversCount = table.Column<int>(nullable: false),
                    HandymenCount = table.Column<int>(nullable: false),
                    SecurityGuardCount = table.Column<int>(nullable: false),
                    CleanerCount = table.Column<int>(nullable: false),
                    APIKey = table.Column<string>(nullable: true),
                    CourseOfferedId = table.Column<long>(nullable: false),
                    CollegeFacilityId = table.Column<long>(nullable: false),
                    CollegeClassRoomDataId = table.Column<long>(nullable: false),
                    CollegeClassRoomInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emailLogs",
                columns: table => new
                {
                    EmaillogId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EmailCc = table.Column<string>(nullable: true),
                    EmailBcc = table.Column<string>(nullable: true),
                    Sent = table.Column<bool>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Createddate = table.Column<DateTime>(nullable: false),
                    Createdby = table.Column<string>(nullable: true),
                    Lastmodified = table.Column<DateTime>(nullable: true),
                    Modifiedby = table.Column<string>(nullable: true),
                    CanSend = table.Column<bool>(nullable: true),
                    FailedSending = table.Column<bool>(nullable: true),
                    LastFailed = table.Column<DateTime>(nullable: true),
                    HasAttachment = table.Column<bool>(nullable: false),
                    AttachmentLoc = table.Column<string>(nullable: true),
                    Datetosend = table.Column<DateTime>(nullable: false),
                    Sendimmediately = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailLogs", x => x.EmaillogId);
                });

            migrationBuilder.CreateTable(
                name: "emailTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    etemplate_id = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachingStaff",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LecturerGrade = table.Column<int>(nullable: false),
                    MainAdminRole = table.Column<int>(nullable: false),
                    DateOfFirstAppointment = table.Column<DateTime>(nullable: false),
                    DateOfCurrentAppointment = table.Column<DateTime>(nullable: false),
                    AcademicQualification = table.Column<string>(nullable: true),
                    AcademicQualificationCertNo = table.Column<string>(nullable: true),
                    TeachingQualification = table.Column<string>(nullable: true),
                    TeachingQualificationCertNo = table.Column<string>(nullable: true),
                    StaffFileNo = table.Column<string>(nullable: true),
                    SourceOfSalary = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    YearOfFirstAppointment = table.Column<string>(nullable: true),
                    YearOfPresentAppointment = table.Column<string>(nullable: true),
                    YearOfPostingToCollege = table.Column<string>(nullable: true),
                    GradeLevel = table.Column<string>(nullable: true),
                    SubjectOfQualification = table.Column<string>(nullable: true),
                    AreaOfSpecialization = table.Column<string>(nullable: true),
                    MainSubjectTaught = table.Column<string>(nullable: true),
                    TeachingType = table.Column<string>(nullable: true),
                    InServiceTraining = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingStaff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachingStaffAdminRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingStaffAdminRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    SessionDate = table.Column<DateTime>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usersPasswordHists",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    CoreUserId = table.Column<long>(nullable: false),
                    PwdCount = table.Column<int>(nullable: false),
                    PwdEncrypt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersPasswordHists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Id = table.Column<long>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coreUsersPasswords",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    PwdEncrypt = table.Column<string>(nullable: true),
                    PwdChangedDate = table.Column<DateTime>(nullable: true),
                    PwdExpiryDate = table.Column<DateTime>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    CumulativeLogins = table.Column<int>(nullable: false),
                    SuccessfulLogins = table.Column<int>(nullable: false),
                    InvalidLogins = table.Column<int>(nullable: false),
                    ForcePwdChange = table.Column<bool>(nullable: true),
                    LockedOut = table.Column<bool>(nullable: true),
                    LockoutDate = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coreUsersPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_coreUsersPasswords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeClassRoomData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassRoomCount = table.Column<int>(nullable: false),
                    StaffRoomCount = table.Column<int>(nullable: false),
                    OfficeCount = table.Column<int>(nullable: false),
                    LibraryCount = table.Column<int>(nullable: false),
                    LaboratoryCount = table.Column<int>(nullable: false),
                    StoreRoomCount = table.Column<int>(nullable: false),
                    OthersCount = table.Column<int>(nullable: false),
                    IsClassHeldOutside = table.Column<bool>(nullable: false),
                    CollegeId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeClassRoomData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeClassRoomData_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeClassRoomInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YearOfConstruction = table.Column<string>(nullable: true),
                    PresentCondition = table.Column<int>(nullable: false),
                    LengthInMeters = table.Column<decimal>(nullable: false),
                    WidthInMeters = table.Column<decimal>(nullable: false),
                    FloorMaterial = table.Column<int>(nullable: false),
                    WallMaterial = table.Column<int>(nullable: false),
                    RoofMaterial = table.Column<int>(nullable: false),
                    Seatings = table.Column<int>(nullable: false),
                    DisabilityAccess = table.Column<int>(nullable: false),
                    CollegeId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeClassRoomInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeClassRoomInfo_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeFacility",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeFacility_Colleges_CollegeID",
                        column: x => x.CollegeID,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOffered",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOffered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseOffered_Colleges_CollegeID",
                        column: x => x.CollegeID,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOffered",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOffered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOffered_Colleges_CollegeID",
                        column: x => x.CollegeID,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeClassRoomData_CollegeId",
                table: "CollegeClassRoomData",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeClassRoomInfo_CollegeId",
                table: "CollegeClassRoomInfo",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeFacility_CollegeID",
                table: "CollegeFacility",
                column: "CollegeID");

            migrationBuilder.CreateIndex(
                name: "IX_coreUsersPasswords_UserId",
                table: "coreUsersPasswords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOffered_CollegeID",
                table: "CourseOffered",
                column: "CollegeID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffered_CollegeID",
                table: "ServiceOffered",
                column: "CollegeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CollegeClassRoomData");

            migrationBuilder.DropTable(
                name: "CollegeClassRoomInfo");

            migrationBuilder.DropTable(
                name: "CollegeFacility");

            migrationBuilder.DropTable(
                name: "CollegeLeadership");

            migrationBuilder.DropTable(
                name: "coreUsersPasswords");

            migrationBuilder.DropTable(
                name: "CourseOffered");

            migrationBuilder.DropTable(
                name: "emailLogs");

            migrationBuilder.DropTable(
                name: "emailTemplates");

            migrationBuilder.DropTable(
                name: "ServiceOffered");

            migrationBuilder.DropTable(
                name: "TeachingStaff");

            migrationBuilder.DropTable(
                name: "TeachingStaffAdminRoles");

            migrationBuilder.DropTable(
                name: "UserLoginHistory");

            migrationBuilder.DropTable(
                name: "usersPasswordHists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Colleges");
        }
    }
}
