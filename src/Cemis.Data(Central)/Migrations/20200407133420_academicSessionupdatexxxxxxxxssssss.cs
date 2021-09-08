using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class academicSessionupdatexxxxxxxxssssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicSessions",
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
                    AcademicPeriod = table.Column<string>(nullable: true),
                    FirstSemesterStartDate = table.Column<string>(nullable: true),
                    FirstSemesterEndDate = table.Column<string>(nullable: true),
                    SecondSemesterStartDate = table.Column<string>(nullable: true),
                    SecondSemesterEndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicSessions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicSessions");
        }
    }
}
