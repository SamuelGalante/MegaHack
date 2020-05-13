using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaHack.Migrations
{
    public partial class update_Professional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfessionalId",
                table: "User",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ProfessionalId",
                table: "User",
                column: "ProfessionalId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ProfessionalId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfessionalId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "User");

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
    }
}
