using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class Collegechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollegeClassRoomData_Colleges_CollegeId",
                table: "CollegeClassRoomData");

            migrationBuilder.DropForeignKey(
                name: "FK_CollegeClassRoomInfo_Colleges_CollegeId",
                table: "CollegeClassRoomInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CollegeFacility_Colleges_CollegeId",
                table: "CollegeFacility");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffered_Colleges_CollegeId",
                table: "CourseOffered");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOffered_Colleges_CollegeId",
                table: "ServiceOffered");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOffered_CollegeId",
                table: "ServiceOffered");

            migrationBuilder.DropIndex(
                name: "IX_CourseOffered_CollegeId",
                table: "CourseOffered");

            migrationBuilder.DropIndex(
                name: "IX_CollegeFacility_CollegeId",
                table: "CollegeFacility");

            migrationBuilder.DropIndex(
                name: "IX_CollegeClassRoomInfo_CollegeId",
                table: "CollegeClassRoomInfo");

            migrationBuilder.DropIndex(
                name: "IX_CollegeClassRoomData_CollegeId",
                table: "CollegeClassRoomData");

            migrationBuilder.DropColumn(
                name: "CollegeClassRoomDataId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "CollegeClassRoomInfoId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "CollegeFacilityId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "CourseOfferedId",
                table: "Colleges");

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "ServiceOffered",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CourseOffered",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CouncilMemberPhone2",
                table: "CollegeLeadership",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CouncilMemberPhone1",
                table: "CollegeLeadership",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CouncilMemberEmail",
                table: "CollegeLeadership",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CollegeFacility",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CollegeClassRoomInfo",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CollegeClassRoomData",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "ServiceOffered",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CourseOffered",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "CollegeClassRoomDataId",
                table: "Colleges",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CollegeClassRoomInfoId",
                table: "Colleges",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CollegeFacilityId",
                table: "Colleges",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CourseOfferedId",
                table: "Colleges",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CouncilMemberPhone2",
                table: "CollegeLeadership",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CouncilMemberPhone1",
                table: "CollegeLeadership",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CouncilMemberEmail",
                table: "CollegeLeadership",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CollegeFacility",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CollegeClassRoomInfo",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CollegeId",
                table: "CollegeClassRoomData",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffered_CollegeId",
                table: "ServiceOffered",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOffered_CollegeId",
                table: "CourseOffered",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeFacility_CollegeId",
                table: "CollegeFacility",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeClassRoomInfo_CollegeId",
                table: "CollegeClassRoomInfo",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeClassRoomData_CollegeId",
                table: "CollegeClassRoomData",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollegeClassRoomData_Colleges_CollegeId",
                table: "CollegeClassRoomData",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollegeClassRoomInfo_Colleges_CollegeId",
                table: "CollegeClassRoomInfo",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollegeFacility_Colleges_CollegeId",
                table: "CollegeFacility",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffered_Colleges_CollegeId",
                table: "CourseOffered",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOffered_Colleges_CollegeId",
                table: "ServiceOffered",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
