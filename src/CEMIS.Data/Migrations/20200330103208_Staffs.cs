using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class Staffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BasicsalaryPromotion",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BicycleMaintenancePromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BooksPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CarMaintenancePromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticServantPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EntertainmentPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "GradeLevelPromotion",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "HouseholdSuppliesPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPremiumPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MotorBikeMaintenancePromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OthersPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ResearchPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ResponsibilityPromotionAllowance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "StepPromotion",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicsalaryPromotion",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "BicycleMaintenancePromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "BooksPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "CarMaintenancePromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "DomesticServantPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "EntertainmentPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "GradeLevelPromotion",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "HouseholdSuppliesPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "MarketPremiumPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "MotorBikeMaintenancePromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "OthersPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "ResearchPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "ResponsibilityPromotionAllowance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StepPromotion",
                table: "TeachingStaff");
        }
    }
}
