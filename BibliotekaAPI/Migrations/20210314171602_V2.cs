using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaAPI.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Polica_PolicaID",
                table: "Knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_Polica_Biblioteke_BibliotekaID",
                table: "Polica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Polica",
                table: "Polica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knjiga",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "Polica",
                table: "Knjiga");

            migrationBuilder.RenameTable(
                name: "Polica",
                newName: "Police");

            migrationBuilder.RenameTable(
                name: "Knjiga",
                newName: "Knjige");

            migrationBuilder.RenameIndex(
                name: "IX_Polica_BibliotekaID",
                table: "Police",
                newName: "IX_Police_BibliotekaID");

            migrationBuilder.RenameIndex(
                name: "IX_Knjiga_PolicaID",
                table: "Knjige",
                newName: "IX_Knjige_PolicaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Police",
                table: "Police",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knjige",
                table: "Knjige",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Police_PolicaID",
                table: "Knjige",
                column: "PolicaID",
                principalTable: "Police",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Police_Biblioteke_BibliotekaID",
                table: "Police",
                column: "BibliotekaID",
                principalTable: "Biblioteke",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Police_PolicaID",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_Police_Biblioteke_BibliotekaID",
                table: "Police");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Police",
                table: "Police");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knjige",
                table: "Knjige");

            migrationBuilder.RenameTable(
                name: "Police",
                newName: "Polica");

            migrationBuilder.RenameTable(
                name: "Knjige",
                newName: "Knjiga");

            migrationBuilder.RenameIndex(
                name: "IX_Police_BibliotekaID",
                table: "Polica",
                newName: "IX_Polica_BibliotekaID");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_PolicaID",
                table: "Knjiga",
                newName: "IX_Knjiga_PolicaID");

            migrationBuilder.AddColumn<int>(
                name: "Polica",
                table: "Knjiga",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polica",
                table: "Polica",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knjiga",
                table: "Knjiga",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Polica_PolicaID",
                table: "Knjiga",
                column: "PolicaID",
                principalTable: "Polica",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Polica_Biblioteke_BibliotekaID",
                table: "Polica",
                column: "BibliotekaID",
                principalTable: "Biblioteke",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
