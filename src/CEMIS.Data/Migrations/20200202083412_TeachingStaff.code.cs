using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class TeachingStaffcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TeachingStaffAdminRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "TeachingStaffAdminRoles");
        }
    }
}
