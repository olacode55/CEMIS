using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class academicSessionupdatexxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CourseOffered");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CourseOffered",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseTitle",
                table: "CourseOffered",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Credit",
                table: "CourseOffered",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "LevelId",
                table: "CourseOffered",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte>(
                name: "Option",
                table: "CourseOffered",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "ProgramId",
                table: "CourseOffered",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte>(
                name: "Semester",
                table: "CourseOffered",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "CourseTitle",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "Option",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "CourseOffered");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CourseOffered",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
