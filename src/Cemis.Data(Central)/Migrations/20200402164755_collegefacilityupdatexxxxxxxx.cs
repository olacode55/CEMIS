using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class collegefacilityupdatexxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "CollegeFacility",
                newName: "Seatings");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CollegeFacility",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityAccess",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FacilityType",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FloorMaterial",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LengthInMeters",
                table: "CollegeFacility",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PresentCondition",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoofMaterial",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "WidthInMeters",
                table: "CollegeFacility",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "YearOfConstruction",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "DisabilityAccess",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "FacilityType",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "FloorMaterial",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "LengthInMeters",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "PresentCondition",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "RoofMaterial",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "WidthInMeters",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "YearOfConstruction",
                table: "CollegeFacility");

            migrationBuilder.RenameColumn(
                name: "Seatings",
                table: "CollegeFacility",
                newName: "Number");
        }
    }
}
