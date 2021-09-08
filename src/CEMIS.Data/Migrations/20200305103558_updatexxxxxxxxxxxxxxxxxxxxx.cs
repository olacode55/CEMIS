using Microsoft.EntityFrameworkCore.Migrations;

namespace CEMIS.Data.Migrations
{
    public partial class updatexxxxxxxxxxxxxxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GoodsAndServicesSettingSubItems_SettingId",
                table: "GoodsAndServicesSettingSubItems",
                column: "SettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsAndServicesSettingSubItems_GoodsAndServicesSettings_SettingId",
                table: "GoodsAndServicesSettingSubItems",
                column: "SettingId",
                principalTable: "GoodsAndServicesSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsAndServicesSettingSubItems_GoodsAndServicesSettings_SettingId",
                table: "GoodsAndServicesSettingSubItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodsAndServicesSettingSubItems_SettingId",
                table: "GoodsAndServicesSettingSubItems");
        }
    }
}
