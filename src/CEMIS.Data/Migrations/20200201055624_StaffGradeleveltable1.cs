using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class StaffGradeleveltable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "staffGradeLevel",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "API_Key",
                table: "staffGradeLevel",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CollegeID",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "staffGradeLevel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "staffGradeLevel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "staffGradeLevel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "API_Key",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "CollegeID",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "staffGradeLevel");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "staffGradeLevel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "staffGradeLevel",
                newName: "ID");
        }
    }
}
