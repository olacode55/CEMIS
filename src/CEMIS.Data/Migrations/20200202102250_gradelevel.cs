using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class gradelevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TeachingStaffAdminRoles",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradeLevel",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "TeachingStaffAdminRoles");

            migrationBuilder.AlterColumn<string>(
                name: "GradeLevel",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
