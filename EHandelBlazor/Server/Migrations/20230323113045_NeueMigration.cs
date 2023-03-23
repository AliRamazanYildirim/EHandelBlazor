using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class NeueMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswortHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswortSalz = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DatumErstellt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.ID);
                });

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
                name: "Kategorien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProduktArten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktArten", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BildUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorieID = table.Column<int>(type: "int", nullable: false),
                    Vorgestellt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produkte_Kategorien_KategorieID",
                        column: x => x.KategorieID,
                        principalTable: "Kategorien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "ProduktVarianten",
                columns: table => new
                {
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    ProduktArtID = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OriginalPreis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktVarianten", x => new { x.ProduktID, x.ProduktArtID });
                    table.ForeignKey(
                        name: "FK_ProduktVarianten_ProduktArten_ProduktArtID",
                        column: x => x.ProduktArtID,
                        principalTable: "ProduktArten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktVarianten_Produkte_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorien",
                columns: new[] { "ID", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Bücher", "bücher" },
                    { 2, "Filme", "filme" },
                    { 3, "Videospiele", "videospiele" }
                });

            migrationBuilder.InsertData(
                table: "ProduktArten",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Taschenbuch" },
                    { 3, "E-Book" },
                    { 4, "Hörbuch" },
                    { 5, "Strom" },
                    { 6, "Blu-ray" },
                    { 7, "VHS" },
                    { 8, "PC" },
                    { 9, "PlayStation" },
                    { 10, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "Produkte",
                columns: new[] { "ID", "Bezeichnung", "BildUrl", "KategorieID", "Title", "Vorgestellt" },
                values: new object[,]
                {
                    { 1, "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene. Jeder Teilband der 6-bändigen Ausgabe enthält jeweils 5 Kapitel.", "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856187/klett/cover/9783126060080.jpg", 1, "Deutsch als Fremdsprache (DaF) Aspekte 1 (B1+)", true },
                    { 2, "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene.", "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856201/klett/cover/9783126060127.jpg", 1, "Deutsch als Fremdsprache (DaF) Aspekte 2 (B2)", false },
                    { 3, "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene.", "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856242/klett/cover/9783126060233.jpg", 1, "Deutsch als Fremdsprache (DaF) Aspekte 3 (C1)", false },
                    { 4, "Im Jahr 1947 wird der junge Mathematiker Josh Nash (Russell Crowe) an der Princeton University angenommen. Dies wird ihm durch das angesehene Carnegie-Stipendium ermöglicht, das jedoch auch seine Pflichten mit sich bringt. So ist Nash dazu verpflichtet Artikel zu veröffentlichen. Diesem enormen Druck zum Trotz, will er unbedingt eigene Ideen entwickeln, jedoch fehlt ihm dazu die nötige Inspiration. Einen Geistesblitz hat der Außenseiter erst, als er mit einigen anderen Studenten nachts diskutiert, welche Methode am besten geeignet ist, um die Frauen an der Bar erfolgreich anzusprechen. Während sein Kommilitone meint, jeder solle für sich selbst vorgehen, ist Nash davon überzeugt, dass Zusammenarbeit die höheren Erfolgsaussichten mit sich bringen würde. Basierend auf dieser Grundlage entwickelt er einen zentralen Begriff der Spieltheorie, was ihn auf einen Schlag berühmt macht und eine Stelle am MIT verschafft. Dort nimmt der geheimnisvolle William Parcher (Ed Harris) Kontakt zu ihm auf. Parcher ist Agent des amerikanischen Verteidigungsministeriums, der Nashs Hilfe braucht, um eine mögliche sowjetische Verschwörung aufzudecken. Denn Nash kann zum Erstaunen von anderen Kryptologen die Codes entschlüsseln, die der Feind bei seiner Kommunikation verwendet. Da ihn seine Arbeit im MIT ohnehin langweilt, stürzt sich der Mathematiker in seine neue Aufgabe und sucht in Zeitungen nach Mustern. Zunehmend verfällt Nash jedoch in eine Obsession, die ihn in Gefahr bringt und ein weitreichendes Geheimnis offenbart.", "https://i0.wp.com/jatko.me/wp-content/uploads/2019/06/mind.jpg?w=1280&ssl=1", 2, "A beautiful Mind - Genie und Wahnsinn", true },
                    { 5, "FBI-Agent Nelville Flynn (Samuel L. Jackson) glaubt an einen Routineauftrag, als er mit einem wichtigen Zeugen auf Hawaii in eine Linienmaschine steigt, um den Herren zur Anhörung im Rahmen eines Mafiaprozesses nach Los Angeles zu überführen. Leider ging auch ein unbekannter Killer mit an Bord, und der setzt nun, knapp 10.000 Meter über dem Meeresspiegel, zur geringen Begeisterung von Cop, Crew und Passagieren ein paar hundert tödliche Giftschlangen im Flieger frei.", "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/b000fa8918b7fa1e1b1df1c161f60b224857c8294bdc10d088b26f716167db60._RI_V_TTW_.jpg", 2, "Léon: The Professional - Der Profi", false },
                    { 6, "Viele Jahre in der Zukunft: Grey (Logan Marshall-Green) und seine Frau Asha (Melanie Vallejo) haben erst einen Autounfall und werden dann Opfer eines Gewaltverbrechens, bei dem sie stirbt und er nach einem Schuss in die Wirbelsäule in den Rollstuhl kommt. Grey denkt, dass es das nun war für ihn. Dann aber bekommt er von seinem Klienten Eron Keen (Harrison Gilbertson) das Angebot, ihm den Computerchip STEN einzupflanzen, der die Medizin revolutionieren könnte. Denn nach der Operation kann sich Grey wieder so bewegen wie vorher! Doch er hat nun nicht nur einen digitalen Unterstützer im Körper, sondern eine künstliche Superintelligenz, die auf Wunsch die komplette Kontrolle des Körpers übernimmt. Grey willigt ein, damit so die Mörder seiner Frau gefunden werden können und blutige Rache genommen wird…", "https://m.media-amazon.com/images/M/MV5BZGRhMTE0MzgtMjZlZS00MTUxLTljMzUtYTFkZWIwZWE1MTg4XkEyXkFqcGdeQXVyMTQyMTMwOTk0._V1_.jpg", 2, "Upgrade", false },
                    { 7, "Chivalry 2 ist ein Multiplayer-First-Person-Slasher, der von den epischen Schlachten bekannter Mittelalter-Filme inspiriert wurde. Spieler erleben zahlreiche ikonische Momente - von aneinander klirrenden Schwertern zu wahren Stürmen aus flammenden Pfeilen, Belagerungen riesiger Festungen und vieles mehr. Sie dominieren die Weiten der Schlachtfelder, Katapulte bringen die Erde zum Beben, während Schlösser belagert, Dörfer in Brand gesteckt und üble Bauernheere ausgemerzt werden, bei der Rückkehr der \"Team Objective\" Maps.", "https://chivalry2.com/wp-content/uploads/2021/07/Chivalry2_Galencourt_EGS_1920x1080-3-1536x864.jpg", 3, "Chivalry 2", true },
                    { 8, "EA SPORTS™ FIFA 23 präsentiert The World's Game. Die HyperMotion2-Technologie sorgt für noch größeren Gameplay-Realismus, Post-Launch-Updates bringen den FIFA World Cup™ der Männer und der Frauen ins Spiel, es gibt neue Frauen-Vereinsmannschaften, Cross-Play-Features* und mehr. Erlebe absolute Authentizität mit über 19.000 Profis, 700+ Teams, 100 Stadien und über 30 Ligen in FIFA 23.", "https://image.api.playstation.com/vulcan/ap/rnd/202207/0515/BOwvC0Q9dfw6QhGvX9dd13Sr.jpg", 3, "Fifa 23", false },
                    { 9, "Man spielt eine Figur, mit der man in dem fiktiven Land Calradia eine Armee aus Soldaten unterschiedlicher Waffengattungen zusammenstellen kann. Mit dieser Armee kämpft man für eine beliebige Fraktion gegen verschiedene andere Fraktionen innerhalb der Spielwelt.", "https://www.donanimhaber.com/images/images/haber/152008/src_340x191mount-blade-ii-bannerlord-un-tam-surum-cikis-tarihi-aciklandi.jpg", 3, "Mount & Blade II: Bannerlord", false }
                });

            migrationBuilder.InsertData(
                table: "ProduktVarianten",
                columns: new[] { "ProduktArtID", "ProduktID", "OriginalPreis", "Preis" },
                values: new object[,]
                {
                    { 2, 1, 28.99m, 9.99m },
                    { 3, 2, 29.99m, 19.99m },
                    { 1, 3, 14.99m, 7.99m },
                    { 6, 4, 29.99m, 19.99m },
                    { 6, 5, 59.99m, 49.99m },
                    { 5, 6, 24.99m, 9.99m },
                    { 9, 7, 24.99m, 9.99m },
                    { 10, 8, 70.99m, 39.99m },
                    { 10, 9, 85.99m, 49.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_BenutzerID",
                table: "Adressen",
                column: "BenutzerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BestellungsArtikel_ProduktArtID",
                table: "BestellungsArtikel",
                column: "ProduktArtID");

            migrationBuilder.CreateIndex(
                name: "IX_BestellungsArtikel_ProduktID",
                table: "BestellungsArtikel",
                column: "ProduktID");

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_KategorieID",
                table: "Produkte",
                column: "KategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktVarianten_ProduktArtID",
                table: "ProduktVarianten",
                column: "ProduktArtID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "BestellungsArtikel");

            migrationBuilder.DropTable(
                name: "ProduktVarianten");

            migrationBuilder.DropTable(
                name: "WarenKorbArtikel");

            migrationBuilder.DropTable(
                name: "Benutzer");

            migrationBuilder.DropTable(
                name: "Bestellungen");

            migrationBuilder.DropTable(
                name: "ProduktArten");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorien");
        }
    }
}
