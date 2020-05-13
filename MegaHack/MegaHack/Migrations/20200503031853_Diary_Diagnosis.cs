using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaHack.Migrations
{
    public partial class Diary_Diagnosis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diary_User_PatientId",
                table: "Diary");

            migrationBuilder.DropForeignKey(
                name: "FK_Diary_User_ProfessionalId",
                table: "Diary");

            migrationBuilder.DropIndex(
                name: "IX_Diary_PatientId",
                table: "Diary");

            migrationBuilder.DropIndex(
                name: "IX_Diary_ProfessionalId",
                table: "Diary");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Diary");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "Diary");

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_User_PatientId",
                        column: x => x.PatientId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosis_User_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_PatientId",
                table: "Diagnosis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_ProfessionalId",
                table: "Diagnosis",
                column: "ProfessionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Diary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "Diary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diary_PatientId",
                table: "Diary",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_ProfessionalId",
                table: "Diary",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diary_User_PatientId",
                table: "Diary",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diary_User_ProfessionalId",
                table: "Diary",
                column: "ProfessionalId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
