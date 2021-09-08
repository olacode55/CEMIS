using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class studentcourseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "CourseOffered");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "CourseOffered",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "CourseOffered");

            migrationBuilder.AddColumn<long>(
                name: "LevelId",
                table: "CourseOffered",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
