using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIStudent.DAO.Data.Migrations
{
    public partial class AjoutChamp_IsOneline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOneline",
                table: "Modules",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOneline",
                table: "Modules");
        }
    }
}
