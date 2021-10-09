using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class RelationDocenteLezione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Lezioni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_DocenteId",
                table: "Lezioni",
                column: "DocenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lezioni_Docenti_DocenteId",
                table: "Lezioni",
                column: "DocenteId",
                principalTable: "Docenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lezioni_Docenti_DocenteId",
                table: "Lezioni");

            migrationBuilder.DropIndex(
                name: "IX_Lezioni_DocenteId",
                table: "Lezioni");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Lezioni");
        }
    }
}
