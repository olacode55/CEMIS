using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class centralupdatexxxxxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "TeachingStaff");

            migrationBuilder.AlterColumn<byte>(
                name: "TeachingType",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "SourceOfSalary",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeLevelPromotion",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StepPromotion",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BasicSalary",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BasicsalaryPromotion",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BicycleMaintenancePromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BooksPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CarMaintenancePromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticServantPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EntertainmentPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HouseholdSuppliesPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPremiumPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MotorBikeMaintenancePromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OthersPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ResearchPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ResponsibilityPromotionAllowance",
                table: "Allowance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeLevelPromotion",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StepPromotion",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BasicsalaryPromotion",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BicycleMaintenancePromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BooksPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "CarMaintenancePromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "DomesticServantPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "EntertainmentPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "HouseholdSuppliesPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "MarketPremiumPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "MotorBikeMaintenancePromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "OthersPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "ResearchPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "ResponsibilityPromotionAllowance",
                table: "Allowance");

            migrationBuilder.AlterColumn<string>(
                name: "TeachingType",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<string>(
                name: "SourceOfSalary",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<decimal>(
                name: "BasicSalary",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
