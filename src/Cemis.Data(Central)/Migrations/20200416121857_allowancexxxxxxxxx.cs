using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class allowancexxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowance_TeachingStaff_StaffId",
                table: "Allowance");

            migrationBuilder.DropIndex(
                name: "IX_Allowance_StaffId",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BasicsalaryPromotion",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BicycleMaintenance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BicycleMaintenancePromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "Books",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "BooksPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "CarMaintenance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "CarMaintenancePromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "DomesticServant",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "DomesticServantPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "Entertainment",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "EntertainmentPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "HouseholdSupplies",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "HouseholdSuppliesPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "MarketPremium",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "MarketPremiumPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "MotorBikeMaintenance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "MotorBikeMaintenancePromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "OthersPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "Research",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "ResearchPromotionAllowance",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "Responsibility",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "ResponsibilityPromotionAllowance",
                table: "Allowance");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Allowance",
                newName: "SourceID");

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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Allowance",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffAllowance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    DateFetched = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    StaffId = table.Column<long>(nullable: false),
                    SourceStaffId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAllowance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffDueForPromotionallowance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CollegeID = table.Column<long>(nullable: false),
                    SourceID = table.Column<long>(nullable: false),
                    DateFetched = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    StaffId = table.Column<long>(nullable: false),
                    SourceStaffId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffDueForPromotionallowance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffAllowance");

            migrationBuilder.DropTable(
                name: "StaffDueForPromotionallowance");

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
                name: "Name",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Allowance");

            migrationBuilder.RenameColumn(
                name: "SourceID",
                table: "Allowance",
                newName: "StaffId");

            migrationBuilder.AddColumn<decimal>(
                name: "BasicSalary",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BasicsalaryPromotion",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BicycleMaintenance",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BicycleMaintenancePromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Books",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BooksPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CarMaintenance",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CarMaintenancePromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticServant",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticServantPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Entertainment",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EntertainmentPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HouseholdSupplies",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HouseholdSuppliesPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPremium",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPremiumPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MotorBikeMaintenance",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MotorBikeMaintenancePromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Others",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OthersPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Research",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ResearchPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Responsibility",
                table: "Allowance",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ResponsibilityPromotionAllowance",
                table: "Allowance",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_StaffId",
                table: "Allowance",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowance_TeachingStaff_StaffId",
                table: "Allowance",
                column: "StaffId",
                principalTable: "TeachingStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
