using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdateTabellaDocenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodiceCorso",
                table: "Docenti");

            migrationBuilder.DropColumn(
                name: "CodiceDipartimento",
                table: "Docenti");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodiceCorso",
                table: "Docenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodiceDipartimento",
                table: "Docenti",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
