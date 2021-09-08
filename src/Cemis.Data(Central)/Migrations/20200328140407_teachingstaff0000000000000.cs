using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemis.Data.Central.Migrations
{
    public partial class teachingstaff0000000000000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollegeID",
                table: "TeachingStaffAdminRoles");

            migrationBuilder.DropColumn(
                name: "SourceID",
                table: "TeachingStaffAdminRoles");


            migrationBuilder.AddColumn<decimal>(
                name: "BasicSalary",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: 0m);


            migrationBuilder.AddColumn<bool>(
                name: "DueForPromotion",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RetiredDate",
                table: "TeachingStaff",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StaffCategory",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffRank",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffType",
                table: "TeachingStaff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Step",
                table: "TeachingStaff",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeLeadership");

            migrationBuilder.DropTable(
                name: "PreviousEducation");

            migrationBuilder.DropTable(
                name: "StaffGradeLevel");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "usersPasswordHists");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TeachingStaffAdminRoles");

            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "DueForPromotion",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "RetiredDate",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StaffCategory",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StaffRank",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "StaffType",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "TeachingStaff");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "ServiceOffered");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "emailTemplates");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "CourseOffered");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "coreUsersPasswords");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "CollegeFacility");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "CollegeClassRoomInfo");

            migrationBuilder.DropColumn(
                name: "DateFetched",
                table: "CollegeClassRoomData");

            migrationBuilder.AddColumn<long>(
                name: "CollegeID",
                table: "TeachingStaffAdminRoles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SourceID",
                table: "TeachingStaffAdminRoles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "MainAdminRole",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "LecturerGrade",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "GradeLevel",
                table: "TeachingStaff",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "TeachingStaff",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<bool>(
                name: "IsClassHeldOutside",
                table: "CollegeClassRoomData",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
