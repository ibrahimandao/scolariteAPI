using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    public partial class AjoutDesModules_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Formateurs_formateurId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Formations_FormationId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_FormationId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "formateurId",
                table: "Modules",
                newName: "FormateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_formateurId",
                table: "Modules",
                newName: "IX_Modules_FormateurId");

            migrationBuilder.AlterColumn<int>(
                name: "FormateurId",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Formateurs_FormateurId",
                table: "Modules",
                column: "FormateurId",
                principalTable: "Formateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Formateurs_FormateurId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "FormateurId",
                table: "Modules",
                newName: "formateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_FormateurId",
                table: "Modules",
                newName: "IX_Modules_formateurId");

            migrationBuilder.AlterColumn<int>(
                name: "formateurId",
                table: "Modules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_Modules_Formateurs_formateurId",
                table: "Modules",
                column: "formateurId",
                principalTable: "Formateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Formations_FormationId",
                table: "Modules",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");
        }
    }
}
