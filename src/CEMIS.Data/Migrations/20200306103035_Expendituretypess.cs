using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class Expendituretypess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportingYear",
                table: "RevenueExpenditureHead",
                newName: "ReturnOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnOn",
                table: "RevenueExpenditureHead",
                newName: "ReportingYear");
        }
    }
}
