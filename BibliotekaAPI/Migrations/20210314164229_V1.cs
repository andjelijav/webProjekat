using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblioteke",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteke", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zanr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrKnjiga = table.Column<int>(type: "int", nullable: false),
                    BibliotekaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polica_Biblioteke_BibliotekaID",
                        column: x => x.BibliotekaID,
                        principalTable: "Biblioteke",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrStrana = table.Column<int>(type: "int", nullable: false),
                    Polica = table.Column<int>(type: "int", nullable: false),
                    PolicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Knjiga_Polica_PolicaID",
                        column: x => x.PolicaID,
                        principalTable: "Polica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_PolicaID",
                table: "Knjiga",
                column: "PolicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Polica_BibliotekaID",
                table: "Polica",
                column: "BibliotekaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Polica");

            migrationBuilder.DropTable(
                name: "Biblioteke");
        }
    }
}
