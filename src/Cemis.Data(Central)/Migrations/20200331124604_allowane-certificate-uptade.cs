using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class allowanecertificateuptade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "SourceID",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "SourceID",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Allowance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Certificates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Certificates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Certificates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Certificates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "SourceID",
                table: "Certificates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Allowance",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Allowance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Allowance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Allowance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "SourceID",
                table: "Allowance",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Allowance",
                nullable: true);
        }
    }
}
