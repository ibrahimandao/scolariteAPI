using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    public partial class Gestion_planning_des_modules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreneauHoraireDebut",
                table: "FormationModules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreneauHoraireFin",
                table: "FormationModules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebut",
                table: "FormationModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "FormationModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JourSemaine",
                table: "FormationModules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Periodicite",
                table: "FormationModules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreneauHoraireDebut",
                table: "FormationModules");

            migrationBuilder.DropColumn(
                name: "CreneauHoraireFin",
                table: "FormationModules");

            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "FormationModules");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "FormationModules");

            migrationBuilder.DropColumn(
                name: "JourSemaine",
                table: "FormationModules");

            migrationBuilder.DropColumn(
                name: "Periodicite",
                table: "FormationModules");
        }
    }
}
