using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class teachingstaffDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BasicSalaryPromotion",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BasicSalary",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "TeachingStaff",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "TeachingStaff");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasicSalaryPromotion",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BasicSalary",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
