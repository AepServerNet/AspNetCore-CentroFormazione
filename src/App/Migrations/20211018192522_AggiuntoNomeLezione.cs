using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AggiuntoNomeLezione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeLezione",
                table: "Lezioni",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeLezione",
                table: "Lezioni");
        }
    }
}
