using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class IsSynched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSynched",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSynched",
                table: "Colleges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSynched",
                table: "CollegeLeadership",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSynched",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "IsSynched",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "IsSynched",
                table: "CollegeLeadership");
        }
    }
}
