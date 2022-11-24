using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Bestellung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellungen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerID = table.Column<int>(type: "int", nullable: false),
                    BestellDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GesamtPreis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellungen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BestellungsArtikel",
                columns: table => new
                {
                    BestellungID = table.Column<int>(type: "int", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    ProduktArtID = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    GesamtPreis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellungsArtikel", x => new { x.BestellungID, x.ProduktID, x.ProduktArtID });
                    table.ForeignKey(
                        name: "FK_BestellungsArtikel_Bestellungen_BestellungID",
                        column: x => x.BestellungID,
                        principalTable: "Bestellungen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellungsArtikel_ProduktArten_ProduktArtID",
                        column: x => x.ProduktArtID,
                        principalTable: "ProduktArten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellungsArtikel_Produkte_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestellungsArtikel_ProduktArtID",
                table: "BestellungsArtikel",
                column: "ProduktArtID");

            migrationBuilder.CreateIndex(
                name: "IX_BestellungsArtikel_ProduktID",
                table: "BestellungsArtikel",
                column: "ProduktID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellungsArtikel");

            migrationBuilder.DropTable(
                name: "Bestellungen");
        }
    }
}
