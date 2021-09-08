using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class studentdropout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppRefNumber",
                table: "Result",
                newName: "StudentId");

            migrationBuilder.AddColumn<string>(
                name: "DropOutComment",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProgramSourceId",
                table: "Student",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationPin",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOutComment",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ProgramSourceId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "RegistrationPin",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Result",
                newName: "AppRefNumber");
        }
    }
}
