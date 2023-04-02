using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Bilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bilder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Daten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bilder_Produkte_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkte",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilder_ProduktID",
                table: "Bilder",
                column: "ProduktID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilder");
        }
    }
}
