using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class updatexxxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accounttitle",
                table: "RevenueGoodsandServiceitems");

            migrationBuilder.DropColumn(
                name: "ReportingPeriod",
                table: "RevenueGoodandServiceHead");

            migrationBuilder.RenameColumn(
                name: "RevEpenditureId",
                table: "RevenueGoodsandServiceitems",
                newName: "SubSettingsId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "RevenueGoodsandServiceitems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ReportingYear",
                table: "RevenueGoodandServiceHead",
                newName: "ReturnsOn");

            migrationBuilder.RenameColumn(
                name: "CostCentre",
                table: "RevenueGoodandServiceHead",
                newName: "FundType");

            migrationBuilder.AddColumn<long>(
                name: "RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SettingsId",
                table: "RevenueGoodsandServiceitems",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsSynced",
                table: "RevenueGoodandServiceHead",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PeriodMonth",
                table: "RevenueGoodandServiceHead",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodYear",
                table: "RevenueGoodandServiceHead",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoodsAndServicesSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    AccountTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TotalApproveBudget = table.Column<decimal>(nullable: false),
                    TotalAmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    TotalCumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    HasSubCategory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAndServicesSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsAndServicesSettingSubItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SettingId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalApproveBudget = table.Column<decimal>(nullable: false),
                    TotalAmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    TotalCumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    HasSubCategory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAndServicesSettingSubItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RevenueGoodsandServiceitems_RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems",
                column: "RevenueGoodandServiceHeadID");

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueGoodsandServiceitems_RevenueGoodandServiceHead_RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems",
                column: "RevenueGoodandServiceHeadID",
                principalTable: "RevenueGoodandServiceHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RevenueGoodsandServiceitems_RevenueGoodandServiceHead_RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems");

            migrationBuilder.DropTable(
                name: "GoodsAndServicesSettings");

            migrationBuilder.DropTable(
                name: "GoodsAndServicesSettingSubItems");

            migrationBuilder.DropIndex(
                name: "IX_RevenueGoodsandServiceitems_RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems");

            migrationBuilder.DropColumn(
                name: "RevenueGoodandServiceHeadID",
                table: "RevenueGoodsandServiceitems");

            migrationBuilder.DropColumn(
                name: "SettingsId",
                table: "RevenueGoodsandServiceitems");

            migrationBuilder.DropColumn(
                name: "IsSynced",
                table: "RevenueGoodandServiceHead");

            migrationBuilder.DropColumn(
                name: "PeriodMonth",
                table: "RevenueGoodandServiceHead");

            migrationBuilder.DropColumn(
                name: "PeriodYear",
                table: "RevenueGoodandServiceHead");

            migrationBuilder.RenameColumn(
                name: "SubSettingsId",
                table: "RevenueGoodsandServiceitems",
                newName: "RevEpenditureId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RevenueGoodsandServiceitems",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ReturnsOn",
                table: "RevenueGoodandServiceHead",
                newName: "ReportingYear");

            migrationBuilder.RenameColumn(
                name: "FundType",
                table: "RevenueGoodandServiceHead",
                newName: "CostCentre");

            migrationBuilder.AddColumn<string>(
                name: "Accounttitle",
                table: "RevenueGoodsandServiceitems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportingPeriod",
                table: "RevenueGoodandServiceHead",
                nullable: false,
                defaultValue: "");
        }
    }
}
