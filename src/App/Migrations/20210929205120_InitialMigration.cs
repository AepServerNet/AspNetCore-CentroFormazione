using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceDipartimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdizioneCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInizioCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFineCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OreCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lezioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorsoId = table.Column<int>(type: "int", nullable: false),
                    IdLezione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceCorso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceAula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInizioLezione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFineLezione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lezioni_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_CorsoId",
                table: "Lezioni",
                column: "CorsoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezioni");

            migrationBuilder.DropTable(
                name: "Corsi");
        }
    }
}
