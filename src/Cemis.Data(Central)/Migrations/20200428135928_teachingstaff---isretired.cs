using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class teachingstaffisretired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<bool>(
                name: "IsRetired",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StaffCategoryCode",
                table: "TeachingStaff",
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRetired",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StaffCategoryCode",
                table: "TeachingStaff");
        }
    }
}
