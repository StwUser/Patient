using System;
using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBasePatient.Migrations
{
    public partial class AddActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Active",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ActiveId",
                table: "Patients",
                column: "ActiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Active_ActiveId",
                table: "Patients",
                column: "ActiveId",
                principalTable: "Active",
                principalColumn: "Id");

            migrationBuilder.InsertData(
               table: "Active",
               columns: new[] { "Id", "Value" },
               values: new object[,]
               {
                                { 1, true },
                                { 2, false }
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Active_ActiveId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Active");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ActiveId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ActiveId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Patients");
        }
    }
}
