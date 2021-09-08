using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class AddStaffAllowance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BicycleMaintenance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Books",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CarMaintenance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticServant",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Entertainment",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HouseholdSupplies",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPremium",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MotorBikeMaintenance",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "OfficerStatus",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Others",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Research",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Responsibility",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BicycleMaintenance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Books",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "CarMaintenance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "DomesticServant",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Entertainment",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "HouseholdSupplies",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "MarketPremium",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "MotorBikeMaintenance",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "OfficerStatus",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Research",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Responsibility",
                table: "TeachingStaff");
        }
    }
}
