using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class EdificiDocentiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NominativoDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MateriaInsegnata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residenza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceDipartimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostoOrario_Amount = table.Column<float>(type: "float", nullable: true),
                    CostoOrario_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edifici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEdificio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceDipartimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edifici", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropTable(
                name: "Edifici");
        }
    }
}
