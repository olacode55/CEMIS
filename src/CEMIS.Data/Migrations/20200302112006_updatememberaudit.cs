using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class updatememberaudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MembershipName",
                table: "CouncilSessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "CouncilSessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipName",
                table: "CouncilSessions");

            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "CouncilSessions");
        }
    }
}
