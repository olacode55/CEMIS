using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class serviceoffered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "ServiceOffered",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ServiceOffered",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ServiceOffered",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ServiceOffered",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServiceOffered",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ServiceOffered",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ServiceOffered");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ServiceOffered");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ServiceOffered");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ServiceOffered");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServiceOffered");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ServiceOffered");
        }
    }
}
