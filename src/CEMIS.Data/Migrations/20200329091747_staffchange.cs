using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class staffchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffType",
                table: "TeachingStaff",
                newName: "Stafftype");

            migrationBuilder.RenameColumn(
                name: "StaffRank",
                table: "TeachingStaff",
                newName: "Staffrank");

            migrationBuilder.RenameColumn(
                name: "StaffCategory",
                table: "TeachingStaff",
                newName: "Staffcategory");

            migrationBuilder.RenameColumn(
                name: "BasicSalary",
                table: "TeachingStaff",
                newName: "Basicsalary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stafftype",
                table: "TeachingStaff",
                newName: "StaffType");

            migrationBuilder.RenameColumn(
                name: "Staffrank",
                table: "TeachingStaff",
                newName: "StaffRank");

            migrationBuilder.RenameColumn(
                name: "Staffcategory",
                table: "TeachingStaff",
                newName: "StaffCategory");

            migrationBuilder.RenameColumn(
                name: "Basicsalary",
                table: "TeachingStaff",
                newName: "BasicSalary");
        }
    }
}
