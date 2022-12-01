using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class BenutzerAdresse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerID = table.Column<int>(type: "int", nullable: false),
                    VorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NachName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straße = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stadt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostleitZahl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adressen_Benutzer_BenutzerID",
                        column: x => x.BenutzerID,
                        principalTable: "Benutzer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_BenutzerID",
                table: "Adressen",
                column: "BenutzerID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adressen");
        }
    }
}
