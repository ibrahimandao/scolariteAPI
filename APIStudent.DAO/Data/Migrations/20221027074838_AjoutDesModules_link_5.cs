using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    public partial class AjoutDesModules_link_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FormationModules_FormationId",
                table: "FormationModules",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationModules_ModuleId",
                table: "FormationModules",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormationModules_Formations_FormationId",
                table: "FormationModules",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormationModules_Modules_ModuleId",
                table: "FormationModules",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormationModules_Formations_FormationId",
                table: "FormationModules");

            migrationBuilder.DropForeignKey(
                name: "FK_FormationModules_Modules_ModuleId",
                table: "FormationModules");

            migrationBuilder.DropIndex(
                name: "IX_FormationModules_FormationId",
                table: "FormationModules");

            migrationBuilder.DropIndex(
                name: "IX_FormationModules_ModuleId",
                table: "FormationModules");
        }
    }
}
