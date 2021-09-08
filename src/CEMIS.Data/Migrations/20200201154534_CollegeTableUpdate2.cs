using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class CollegeTableUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSynched",
                table: "CollegeFacility",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSynched",
                table: "CollegeClassRoomInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "IsClassHeldOutside",
                table: "CollegeClassRoomData",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<bool>(
                name: "IsSynched",
                table: "CollegeClassRoomData",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSynched",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "IsSynched",
                table: "CollegeClassRoomInfo");

            migrationBuilder.DropColumn(
                name: "IsSynched",
                table: "CollegeClassRoomData");

            migrationBuilder.AlterColumn<bool>(
                name: "IsClassHeldOutside",
                table: "CollegeClassRoomData",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
