using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class finacetablelog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ReportingYear = table.Column<string>(nullable: true),
                    ReportingPeriod = table.Column<string>(nullable: false)
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
                    RevenueId = table.Column<long>(nullable: false),
                    RevenueTypeId = table.Column<long>(nullable: false),
                    RevenueType = table.Column<string>(nullable: true),
                    MonthlyTargetAmt = table.Column<decimal>(nullable: false),
                    MonthlyAmtCollected = table.Column<decimal>(nullable: false),
                    MonthlyAmountCollectedToDate = table.Column<decimal>(nullable: false),
                    MonthlyAmtPayIntoConsol = table.Column<decimal>(nullable: false),
                    PaidIntoConsol = table.Column<decimal>(nullable: false),
                    MonthlyAmtRetained = table.Column<decimal>(nullable: false),
                    CumulativeAmtRetained = table.Column<string>(nullable: true)
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
                    RevenueId = table.Column<long>(nullable: false),
                    RevenueCode = table.Column<string>(nullable: true),
                    RevenueType = table.Column<string>(nullable: true)
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
                    MDA = table.Column<string>(nullable: true),
                    ReportingYear = table.Column<string>(nullable: true),
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
                    RevEpenditureId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Accounttitle = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueExpenditureItems", x => x.Id);
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
                    Balance = table.Column<decimal>(nullable: false)
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
                    CostCentre = table.Column<string>(nullable: true),
                    MDA = table.Column<string>(nullable: true),
                    ReportingYear = table.Column<string>(nullable: true),
                    ReportingPeriod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueGoodandServiceHead", x => x.Id);
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
                    RevEpenditureId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Accounttitle = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueGoodsandServiceitems", x => x.Id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "RevenueFixedAssetHead");

            migrationBuilder.DropTable(
                name: "RevenueFixedAssetitems");

            migrationBuilder.DropTable(
                name: "RevenueGoodandServiceHead");

            migrationBuilder.DropTable(
                name: "RevenueGoodsandServiceitems");

            migrationBuilder.DropTable(
                name: "RevenueSummaryPerCollegeHead");

            migrationBuilder.DropTable(
                name: "RevenueSummaryPerCollegeItems");
        }
    }
}
