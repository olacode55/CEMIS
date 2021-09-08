using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class RemoveWallMaterialColumnFromCollegeFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WallMaterial",
                table: "CollegeFacility");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WallMaterial",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: 0);
        }
    }
}
