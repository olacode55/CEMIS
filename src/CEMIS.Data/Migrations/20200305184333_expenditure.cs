using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class expenditure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accounttitle",
                table: "RevenueExpenditureItems");

            //migrationBuilder.RenameColumn(
            //    name: "Name",
            //    table: "TeachingStaff",
            //    newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "AmountExpendedcurrentYear",
                table: "RevenueExpenditureItems",
                newName: "WageandSalary");

            //migrationBuilder.AddColumn<string>(
            //    name: "FirstName",
            //    table: "TeachingStaff",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LastName",
            //    table: "TeachingStaff",
            //    nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountExpendedcurrentMonth",
                table: "RevenueExpenditureItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "RevenueExpenditureItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FundType",
                table: "RevenueExpenditureHead",
                nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsFirstLogin",
            //    table: "AspNetUsers",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "StaffID",
            //    table: "AspNetUsers",
            //    nullable: true);

        //    migrationBuilder.CreateTable(
        //        name: "Certificate",
        //        columns: table => new
        //        {
        //            Id = table.Column<long>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            IsDeleted = table.Column<bool>(nullable: false),
        //            IsActive = table.Column<bool>(nullable: false),
        //            CreatedBy = table.Column<long>(nullable: false),
        //            UpdatedBy = table.Column<long>(nullable: true),
        //            DateCreated = table.Column<DateTime>(nullable: false),
        //            DateUpdated = table.Column<DateTime>(nullable: true),
        //            Url = table.Column<string>(nullable: true),
        //            Name = table.Column<string>(nullable: true),
        //            StaffId = table.Column<long>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Certificate", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Certificate_TeachingStaff_StaffId",
        //                column: x => x.StaffId,
        //                principalTable: "TeachingStaff",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Certificate_StaffId",
        //        table: "Certificate",
        //        column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificate");

            //migrationBuilder.DropColumn(
            //    name: "FirstName",
            //    table: "TeachingStaff");

            //migrationBuilder.DropColumn(
            //    name: "LastName",
            //    table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "AmountExpendedcurrentMonth",
                table: "RevenueExpenditureItems");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "RevenueExpenditureItems");

            migrationBuilder.DropColumn(
                name: "FundType",
                table: "RevenueExpenditureHead");

            //migrationBuilder.DropColumn(
            //    name: "IsFirstLogin",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "StaffID",
            //    table: "AspNetUsers");

            //migrationBuilder.RenameColumn(
            //    name: "MiddleName",
            //    table: "TeachingStaff",
            //    newName: "Name");

            migrationBuilder.RenameColumn(
                name: "WageandSalary",
                table: "RevenueExpenditureItems",
                newName: "AmountExpendedcurrentYear");

            migrationBuilder.AddColumn<string>(
                name: "Accounttitle",
                table: "RevenueExpenditureItems",
                nullable: true);
        }
    }
}
