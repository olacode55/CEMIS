using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class resultxxxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Result",
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
                    AppRefNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Score = table.Column<string>(maxLength: 10, nullable: false),
                    Grade = table.Column<string>(maxLength: 10, nullable: false),
                    CourseSourceId = table.Column<long>(nullable: false),
                    AcademicSessionSourceId = table.Column<long>(nullable: false),
                    ProgramSourceId = table.Column<long>(nullable: false),
                    Level = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");
        }
    }
}
