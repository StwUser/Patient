using System;
using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBasePatient.Migrations
{
    public partial class AddPatientGenderGiven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Givens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Givens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Givens_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Givens_PatientId",
                table: "Givens",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.InsertData(
                           table: "Genders",
                           columns: new[] { nameof(Gender.Id), nameof(Gender.GenderName) },
                           values: new object[,]
                           {
                                { (int)GenderId.Male, nameof(GenderId.Male) },
                                { (int)GenderId.Female, nameof(GenderId.Female) },
                                { (int)GenderId.Other, nameof(GenderId.Other) },
                                { (int)GenderId.Unknown, nameof(GenderId.Unknown) }
                           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Givens");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
