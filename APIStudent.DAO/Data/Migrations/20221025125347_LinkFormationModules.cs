using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    public partial class LinkFormationModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormationId",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_FormationId",
                table: "Modules",
                column: "FormationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Formations_FormationId",
                table: "Modules",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Formations_FormationId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_FormationId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "Modules");
        }
    }
}
