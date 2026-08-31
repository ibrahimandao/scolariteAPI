using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    public partial class Gestion_users_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilId",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ProfilId",
                table: "Utilisateurs",
                column: "ProfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Profils_ProfilId",
                table: "Utilisateurs",
                column: "ProfilId",
                principalTable: "Profils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Profils_ProfilId",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_ProfilId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "ProfilId",
                table: "Utilisateurs");
        }
    }
}
