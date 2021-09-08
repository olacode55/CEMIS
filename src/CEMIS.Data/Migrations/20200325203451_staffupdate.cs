using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class staffupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIRequestLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    RequestType = table.Column<byte>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Synched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIRequestLog", x => x.Id);
                });

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
                    StaffID = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModeified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<long>(nullable: true),
                    Isdeleted = table.Column<bool>(nullable: false),
                    ForcePwdChange = table.Column<bool>(nullable: false),
                    IsFirstLogin = table.Column<bool>(nullable: false),
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
                    IsClassHeldOutside = table.Column<int>(nullable: false),
                    CollegeId = table.Column<long>(nullable: false),
                    IsSynched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeClassRoomData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollegeClassRoomInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YearOfConstruction = table.Column<string>(nullable: true),
                    PresentCondition = table.Column<int>(nullable: false),
                    LengthInMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WidthInMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FloorMaterial = table.Column<int>(nullable: false),
                    WallMaterial = table.Column<int>(nullable: false),
                    RoofMaterial = table.Column<int>(nullable: false),
                    Seatings = table.Column<int>(nullable: false),
                    DisabilityAccess = table.Column<int>(nullable: false),
                    CollegeId = table.Column<long>(nullable: false),
                    IsSynched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeClassRoomInfo", x => x.Id);
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
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CollegeId = table.Column<long>(nullable: false),
                    FacilityType = table.Column<int>(nullable: false),
                    YearOfConstruction = table.Column<string>(nullable: false),
                    PresentCondition = table.Column<int>(nullable: false),
                    LengthInMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WidthInMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FloorMaterial = table.Column<int>(nullable: false),
                    RoofMaterial = table.Column<int>(nullable: false),
                    Seatings = table.Column<int>(nullable: false),
                    DisabilityAccess = table.Column<int>(nullable: false),
                    IsSynched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeFacility", x => x.Id);
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
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    CouncilMember = table.Column<string>(nullable: true),
                    CouncilMemberPhone1 = table.Column<string>(maxLength: 20, nullable: true),
                    CouncilMemberPhone2 = table.Column<string>(maxLength: 20, nullable: true),
                    CouncilMemberEmail = table.Column<string>(maxLength: 50, nullable: true),
                    CouncilMemberPostalAddress = table.Column<string>(nullable: true),
                    CouncilMemberSponsor = table.Column<byte>(nullable: false),
                    DateAppointed = table.Column<DateTime>(nullable: false),
                    DateLeft = table.Column<DateTime>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IsSynched = table.Column<bool>(nullable: false)
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
                    IsSynched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouncilMembers",
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
                    SessionName = table.Column<string>(nullable: false),
                    CouncilMemberName = table.Column<string>(nullable: false),
                    CouncilMemberPosition = table.Column<string>(nullable: false),
                    SessionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouncilSessions",
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
                    SessionName = table.Column<string>(nullable: false),
                    StartDate = table.Column<string>(nullable: false),
                    EndDate = table.Column<string>(nullable: false),
                    PositionName = table.Column<string>(nullable: true),
                    MembershipName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseOffered",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CollegeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOffered", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
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
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
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
                    API_Key = table.Column<string>(nullable: true),
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
                name: "FacilityTypes",
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
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsAndServicesSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    AccountTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TotalApproveBudget = table.Column<decimal>(nullable: true),
                    TotalAmountExpendedcurrentYear = table.Column<decimal>(nullable: true),
                    TotalCumulativeAmt = table.Column<decimal>(nullable: true),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: true),
                    HasSubCategory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAndServicesSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueCompensationHeads",
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
                    CostCentre = table.Column<string>(nullable: false),
                    MDA = table.Column<string>(nullable: false),
                    ReportingYear = table.Column<string>(nullable: true),
                    ReportingPeriod = table.Column<string>(nullable: false),
                    ReturnOn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueCompensationHeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueCompesationItems",
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
                    RevcompesationId = table.Column<long>(nullable: false),
                    WagesId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    WagesandSalary = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmtExpended = table.Column<decimal>(nullable: false),
                    CumAmt = table.Column<decimal>(nullable: false),
                    TotaExpendinture = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueCompesationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueEstimateHeads",
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
                    CostCentre = table.Column<string>(nullable: false),
                    MDA = table.Column<string>(nullable: false),
                    ReportingYear = table.Column<string>(nullable: false),
                    ReportingMonth = table.Column<int>(nullable: false),
                    LodgementAccNo = table.Column<string>(nullable: true),
                    RetentionAccNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueEstimateHeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueestimateItems",
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
                    RevenueHeadId = table.Column<long>(nullable: false),
                    RevenueTypeId = table.Column<long>(nullable: false),
                    MonthlyTargetAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyAmtCollected = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyAmountCollectedToDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyAmtPayIntoConsol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidIntoConsol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyAmtRetained = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CumulativeAmtRetained = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Variance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueestimateItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueEstimateTypeCode",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueEstimateTypeCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueExpenditureHead",
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
                    CostCentre = table.Column<string>(nullable: true),
                    FundType = table.Column<string>(nullable: true),
                    MDA = table.Column<string>(nullable: true),
                    ReturnOn = table.Column<string>(nullable: true),
                    ReportingPeriod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueExpenditureHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueExpenditureItems",
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
                    RevenueCompensationHeadId = table.Column<long>(nullable: false),
                    RevEpenditureId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    WageandSalary = table.Column<decimal>(nullable: false),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentMonth = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueExpenditureItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "revenueExpenditureTypeCodes",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenueExpenditureTypeCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueFixedAssetHead",
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
                    CostCentre = table.Column<string>(nullable: false),
                    MDA = table.Column<string>(nullable: false),
                    ReportingYear = table.Column<string>(nullable: true),
                    ReportingPeriod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueFixedAssetHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueFixedAssetitems",
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
                    RevEpenditureId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Accounttitle = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueFixedAssetitems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueGoodandServiceHead",
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
                    MDA = table.Column<string>(nullable: true),
                    PeriodYear = table.Column<int>(nullable: false),
                    PeriodMonth = table.Column<int>(nullable: false),
                    ReturnsOn = table.Column<string>(nullable: true),
                    FundType = table.Column<string>(nullable: true),
                    IsSynced = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueGoodandServiceHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revenueitemlogs",
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
                    RevEpenditureId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Accounttitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenueitemlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueSummaryPerCollegeHead",
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
                    CostCentre = table.Column<string>(nullable: false),
                    CollegeId = table.Column<long>(nullable: false),
                    MDA = table.Column<string>(nullable: true),
                    ReportingYear = table.Column<string>(nullable: true),
                    ReportingPeriod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueSummaryPerCollegeHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueSummaryPerCollegeItems",
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
                    RevEpenditureId = table.Column<long>(nullable: false),
                    PayitemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueSummaryPerCollegeItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOffered",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CollegeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOffered", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffCategories",
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
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    StaffTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "staffGradeLevel",
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
                    API_Key = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffGradeLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffPositions",
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
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    StaffCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffRanks",
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
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    StaffCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
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
                    API_Key = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    OtherNames = table.Column<string>(nullable: true),
                    AppRefNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    POB = table.Column<string>(nullable: true),
                    HomeTown = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    LanguagesSpoken = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true),
                    FirstChoiceProgram = table.Column<string>(nullable: true),
                    SecondChoiceProgram = table.Column<string>(nullable: true),
                    ThreeChoiceProgram = table.Column<string>(nullable: true),
                    FirstChoiceCollege = table.Column<string>(nullable: true),
                    SecondChoiceCollege = table.Column<string>(nullable: true),
                    ThirdChoiceCollege = table.Column<string>(nullable: true),
                    ParentParticulars = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    IsSynched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
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
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
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
                    GradeLevel = table.Column<int>(nullable: false),
                    SubjectOfQualification = table.Column<string>(nullable: true),
                    AreaOfSpecialization = table.Column<string>(nullable: true),
                    MainSubjectTaught = table.Column<string>(nullable: true),
                    TeachingType = table.Column<string>(nullable: true),
                    RetiredDate = table.Column<DateTime>(nullable: false),
                    StaffType = table.Column<int>(nullable: false),
                    StaffCategory = table.Column<int>(nullable: false),
                    StaffRank = table.Column<int>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    DueForPromotion = table.Column<bool>(nullable: false),
                    InServiceTraining = table.Column<string>(nullable: true),
                    IsSynched = table.Column<bool>(nullable: false)
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
                    API_Key = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingStaffAdminRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
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
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
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
                    API_Key = table.Column<string>(nullable: true),
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
                    API_Key = table.Column<string>(nullable: true),
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
                name: "GoodsAndServicesSettingSubItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SettingId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalApproveBudget = table.Column<decimal>(nullable: true),
                    TotalAmountExpendedcurrentYear = table.Column<decimal>(nullable: true),
                    TotalCumulativeAmt = table.Column<decimal>(nullable: true),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: true),
                    HasSubCategory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAndServicesSettingSubItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsAndServicesSettingSubItems_GoodsAndServicesSettings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "GoodsAndServicesSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevenueGoodsandServiceitems",
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
                    Description = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    SettingsId = table.Column<long>(nullable: false),
                    SubSettingsId = table.Column<long>(nullable: false),
                    RevenueGoodandServiceHeadID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueGoodsandServiceitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueGoodsandServiceitems_RevenueGoodandServiceHead_RevenueGoodandServiceHeadID",
                        column: x => x.RevenueGoodandServiceHeadID,
                        principalTable: "RevenueGoodandServiceHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreviousEducation",
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
                    API_Key = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    FromDate = table.Column<string>(nullable: true),
                    ToDate = table.Column<string>(nullable: true),
                    OfficeHeld = table.Column<string>(nullable: true),
                    StudentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousEducation_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allowance",
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
                    StaffId = table.Column<long>(nullable: false),
                    teachingStaffId = table.Column<long>(nullable: true),
                    MarketPremium = table.Column<decimal>(nullable: false),
                    Books = table.Column<decimal>(nullable: false),
                    Research = table.Column<decimal>(nullable: false),
                    Responsibility = table.Column<decimal>(nullable: false),
                    CarMaintenance = table.Column<decimal>(nullable: false),
                    MotorBikeMaintenance = table.Column<decimal>(nullable: false),
                    BicycleMaintenance = table.Column<decimal>(nullable: false),
                    DomesticServant = table.Column<decimal>(nullable: false),
                    HouseholdSupplies = table.Column<decimal>(nullable: false),
                    Entertainment = table.Column<decimal>(nullable: false),
                    Others = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allowance_TeachingStaff_teachingStaffId",
                        column: x => x.teachingStaffId,
                        principalTable: "TeachingStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
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
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StaffId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_TeachingStaff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "TeachingStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_teachingStaffId",
                table: "Allowance",
                column: "teachingStaffId");

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
                name: "IX_Certificate_StaffId",
                table: "Certificate",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_coreUsersPasswords_UserId",
                table: "coreUsersPasswords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsAndServicesSettingSubItems_SettingId",
                table: "GoodsAndServicesSettingSubItems",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEducation_StudentID",
                table: "PreviousEducation",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueGoodsandServiceitems_RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems",
                column: "RevenueGoodandServiceHeadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.DropTable(
                name: "APIRequestLog");

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
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "CollegeClassRoomData");

            migrationBuilder.DropTable(
                name: "CollegeClassRoomInfo");

            migrationBuilder.DropTable(
                name: "CollegeFacility");

            migrationBuilder.DropTable(
                name: "CollegeLeadership");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "coreUsersPasswords");

            migrationBuilder.DropTable(
                name: "CouncilMembers");

            migrationBuilder.DropTable(
                name: "CouncilSessions");

            migrationBuilder.DropTable(
                name: "CourseOffered");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "emailLogs");

            migrationBuilder.DropTable(
                name: "emailTemplates");

            migrationBuilder.DropTable(
                name: "FacilityTypes");

            migrationBuilder.DropTable(
                name: "GoodsAndServicesSettingSubItems");

            migrationBuilder.DropTable(
                name: "PreviousEducation");

            migrationBuilder.DropTable(
                name: "RevenueCompensationHeads");

            migrationBuilder.DropTable(
                name: "RevenueCompesationItems");

            migrationBuilder.DropTable(
                name: "RevenueEstimateHeads");

            migrationBuilder.DropTable(
                name: "RevenueestimateItems");

            migrationBuilder.DropTable(
                name: "RevenueEstimateTypeCode");

            migrationBuilder.DropTable(
                name: "RevenueExpenditureHead");

            migrationBuilder.DropTable(
                name: "RevenueExpenditureItems");

            migrationBuilder.DropTable(
                name: "revenueExpenditureTypeCodes");

            migrationBuilder.DropTable(
                name: "RevenueFixedAssetHead");

            migrationBuilder.DropTable(
                name: "RevenueFixedAssetitems");

            migrationBuilder.DropTable(
                name: "RevenueGoodsandServiceitems");

            migrationBuilder.DropTable(
                name: "Revenueitemlogs");

            migrationBuilder.DropTable(
                name: "RevenueSummaryPerCollegeHead");

            migrationBuilder.DropTable(
                name: "RevenueSummaryPerCollegeItems");

            migrationBuilder.DropTable(
                name: "ServiceOffered");

            migrationBuilder.DropTable(
                name: "StaffCategories");

            migrationBuilder.DropTable(
                name: "staffGradeLevel");

            migrationBuilder.DropTable(
                name: "StaffPositions");

            migrationBuilder.DropTable(
                name: "StaffRanks");

            migrationBuilder.DropTable(
                name: "TeachingStaffAdminRoles");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "UserLoginHistory");

            migrationBuilder.DropTable(
                name: "usersPasswordHists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TeachingStaff");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GoodsAndServicesSettings");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "RevenueGoodandServiceHead");
        }
    }
}
