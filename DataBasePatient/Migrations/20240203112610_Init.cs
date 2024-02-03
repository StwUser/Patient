using System;
using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBasePatient.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<bool>(type: "bit", nullable: false),
                    ActiveName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actives", x => x.Id);
                });

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
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
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

            migrationBuilder.InsertData(
               table: "Actives",
               columns: new[] { nameof(Active.Id), nameof(Active.Value), nameof(Active.ActiveName) },
               values: new object[,]
               {
                                { (int)ActiveId.True, true, nameof(ActiveId.True)},
                                { (int)ActiveId.False, false, nameof(ActiveId.False)}
               });

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
                name: "Actives");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Givens");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
