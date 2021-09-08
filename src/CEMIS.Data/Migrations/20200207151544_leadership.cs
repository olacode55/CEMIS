using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class leadership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouncilMemberSponsorCommunity",
                table: "CollegeLeadership");

            migrationBuilder.DropColumn(
                name: "CouncilMemberSponsorGovernment",
                table: "CollegeLeadership");

            migrationBuilder.AddColumn<byte>(
                name: "CouncilMemberSponsor",
                table: "CollegeLeadership",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouncilMemberSponsor",
                table: "CollegeLeadership");

            migrationBuilder.AddColumn<string>(
                name: "CouncilMemberSponsorCommunity",
                table: "CollegeLeadership",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CouncilMemberSponsorGovernment",
                table: "CollegeLeadership",
                nullable: true);
        }
    }
}
