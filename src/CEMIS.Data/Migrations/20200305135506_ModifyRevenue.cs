using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class ModifyRevenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RevenueId",
                table: "RevenueEstimateTypeCode");

            migrationBuilder.DropColumn(
                name: "RevenueType",
                table: "RevenueestimateItems");

            migrationBuilder.RenameColumn(
                name: "RevenueType",
                table: "RevenueEstimateTypeCode",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RevenueCode",
                table: "RevenueEstimateTypeCode",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "RevenueId",
                table: "RevenueestimateItems",
                newName: "RevenueHeadId");

            migrationBuilder.RenameColumn(
                name: "ReportingPeriod",
                table: "RevenueEstimateHeads",
                newName: "ReportingMonth");

            migrationBuilder.AlterColumn<string>(
                name: "ReportingYear",
                table: "RevenueEstimateHeads",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LodgementAccNo",
                table: "RevenueEstimateHeads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetentionAccNo",
                table: "RevenueEstimateHeads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LodgementAccNo",
                table: "RevenueEstimateHeads");

            migrationBuilder.DropColumn(
                name: "RetentionAccNo",
                table: "RevenueEstimateHeads");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RevenueEstimateTypeCode",
                newName: "RevenueType");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "RevenueEstimateTypeCode",
                newName: "RevenueCode");

            migrationBuilder.RenameColumn(
                name: "RevenueHeadId",
                table: "RevenueestimateItems",
                newName: "RevenueId");

            migrationBuilder.RenameColumn(
                name: "ReportingMonth",
                table: "RevenueEstimateHeads",
                newName: "ReportingPeriod");

            migrationBuilder.AddColumn<long>(
                name: "RevenueId",
                table: "RevenueEstimateTypeCode",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "RevenueType",
                table: "RevenueestimateItems",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportingYear",
                table: "RevenueEstimateHeads",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
