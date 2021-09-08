using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class updatexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "RevenueGoodsandServiceitems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCumulativeAmt",
                table: "GoodsAndServicesSettingSubItems",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalApproveBudget",
                table: "GoodsAndServicesSettingSubItems",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmtexpendedtilldate",
                table: "GoodsAndServicesSettingSubItems",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmountExpendedcurrentYear",
                table: "GoodsAndServicesSettingSubItems",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCumulativeAmt",
                table: "GoodsAndServicesSettings",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalApproveBudget",
                table: "GoodsAndServicesSettings",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmtexpendedtilldate",
                table: "GoodsAndServicesSettings",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmountExpendedcurrentYear",
                table: "GoodsAndServicesSettings",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "RevenueGoodsandServiceitems");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCumulativeAmt",
                table: "GoodsAndServicesSettingSubItems",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalApproveBudget",
                table: "GoodsAndServicesSettingSubItems",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmtexpendedtilldate",
                table: "GoodsAndServicesSettingSubItems",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmountExpendedcurrentYear",
                table: "GoodsAndServicesSettingSubItems",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCumulativeAmt",
                table: "GoodsAndServicesSettings",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalApproveBudget",
                table: "GoodsAndServicesSettings",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmtexpendedtilldate",
                table: "GoodsAndServicesSettings",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmountExpendedcurrentYear",
                table: "GoodsAndServicesSettings",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
