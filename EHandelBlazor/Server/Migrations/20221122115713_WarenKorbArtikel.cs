using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class WarenKorbArtikel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarenKorbArtikel",
                columns: table => new
                {
                    BenutzerID = table.Column<int>(type: "int", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    ProduktArtID = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarenKorbArtikel", x => new { x.BenutzerID, x.ProduktID, x.ProduktArtID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarenKorbArtikel");
        }
    }
}
