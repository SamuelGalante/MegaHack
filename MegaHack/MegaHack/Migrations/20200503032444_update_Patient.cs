using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaHack.Migrations
{
    public partial class update_Patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PatientId",
                table: "User",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_PatientId",
                table: "User",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_PatientId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PatientId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "User");
        }
    }
}
