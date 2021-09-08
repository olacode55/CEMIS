using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class coursesoffered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "CourseOffered",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CourseOffered",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "CourseOffered",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseOffered",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseOffered",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "CourseOffered",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CourseOffered");
        }
    }
}
