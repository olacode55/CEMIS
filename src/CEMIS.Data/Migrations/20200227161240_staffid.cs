using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class staffid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TeachingStaff",
                newName: "MiddleName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "TeachingStaff",
                newName: "Name");
        }
    }
}
