using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class studentAppli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionName",
                table: "CollegeLeadership",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SessionSourceID",
                table: "CollegeLeadership",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionName",
                table: "CollegeLeadership");

            migrationBuilder.DropColumn(
                name: "SessionSourceID",
                table: "CollegeLeadership");
        }
    }
}
