using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class jj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RevenueFixedAssetitems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Revenueitemlogs",
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
                    RevEpenditureId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Accounttitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ApproveBudget = table.Column<decimal>(nullable: false),
                    AmountExpendedcurrentYear = table.Column<decimal>(nullable: false),
                    CumulativeAmt = table.Column<decimal>(nullable: false),
                    TotalAmtexpendedtilldate = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenueitemlogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revenueitemlogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RevenueFixedAssetitems");
        }
    }
}
