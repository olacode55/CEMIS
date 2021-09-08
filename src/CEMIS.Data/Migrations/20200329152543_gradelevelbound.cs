using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class gradelevelbound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowerBoundStep",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "UpperBoundStep",
                table: "staffGradeLevel");

            migrationBuilder.AddColumn<int>(
                name: "LowerBoundStep",
                table: "gradeLevels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperBoundStep",
                table: "gradeLevels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowerBoundStep",
                table: "gradeLevels");

            migrationBuilder.DropColumn(
                name: "UpperBoundStep",
                table: "gradeLevels");

            migrationBuilder.AddColumn<int>(
                name: "LowerBoundStep",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperBoundStep",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: 0);
        }
    }
}
