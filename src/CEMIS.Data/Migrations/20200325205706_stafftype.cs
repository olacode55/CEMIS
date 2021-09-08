using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class stafftype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowance_TeachingStaff_teachingStaffId",
                table: "Allowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allowance",
                table: "Allowance");

            migrationBuilder.RenameTable(
                name: "Allowance",
                newName: "allowances");

            migrationBuilder.RenameIndex(
                name: "IX_Allowance_teachingStaffId",
                table: "allowances",
                newName: "IX_allowances_teachingStaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_allowances",
                table: "allowances",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "staffTypes",
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
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_allowances_TeachingStaff_teachingStaffId",
                table: "allowances",
                column: "teachingStaffId",
                principalTable: "TeachingStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_allowances_TeachingStaff_teachingStaffId",
                table: "allowances");

            migrationBuilder.DropTable(
                name: "staffTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_allowances",
                table: "allowances");

            migrationBuilder.RenameTable(
                name: "allowances",
                newName: "Allowance");

            migrationBuilder.RenameIndex(
                name: "IX_allowances_teachingStaffId",
                table: "Allowance",
                newName: "IX_Allowance_teachingStaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allowance",
                table: "Allowance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowance_TeachingStaff_teachingStaffId",
                table: "Allowance",
                column: "teachingStaffId",
                principalTable: "TeachingStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
