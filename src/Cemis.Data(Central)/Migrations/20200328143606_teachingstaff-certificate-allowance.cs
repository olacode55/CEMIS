using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class teachingstaffcertificateallowance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allowance",
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
                    StaffId = table.Column<long>(nullable: false),
                    MarketPremium = table.Column<decimal>(nullable: false),
                    Books = table.Column<decimal>(nullable: false),
                    Research = table.Column<decimal>(nullable: false),
                    Responsibility = table.Column<decimal>(nullable: false),
                    CarMaintenance = table.Column<decimal>(nullable: false),
                    MotorBikeMaintenance = table.Column<decimal>(nullable: false),
                    BicycleMaintenance = table.Column<decimal>(nullable: false),
                    DomesticServant = table.Column<decimal>(nullable: false),
                    HouseholdSupplies = table.Column<decimal>(nullable: false),
                    Entertainment = table.Column<decimal>(nullable: false),
                    Others = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allowance_TeachingStaff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "TeachingStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
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
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StaffId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_TeachingStaff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "TeachingStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_StaffId",
                table: "Allowance",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_StaffId",
                table: "Certificates",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
