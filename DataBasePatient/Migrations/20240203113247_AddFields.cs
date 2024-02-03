using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBasePatient.Migrations
{
    public partial class AddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patients_ActiveId",
                table: "Patients",
                column: "ActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Actives_ActiveId",
                table: "Patients",
                column: "ActiveId",
                principalTable: "Actives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Actives_ActiveId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ActiveId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_GenderId",
                table: "Patients");
        }
    }
}
