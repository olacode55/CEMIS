using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class StaffChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "TeachingType",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "SourceOfSalary",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwardingInstitutionforHighestQualification",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwardingInstitutionforHighestTeachingQualification",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "TeachingStaff",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardingInstitutionforHighestQualification",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "AwardingInstitutionforHighestTeachingQualification",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "TeachingStaff");

            migrationBuilder.AlterColumn<string>(
                name: "TeachingType",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<string>(
                name: "SourceOfSalary",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(byte));
        }
    }
}
