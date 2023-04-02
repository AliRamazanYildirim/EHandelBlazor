namespace EHandelBlazor.Server.Daten
{
    public class DatenKontext:DbContext
    {
        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<ProduktArt> ProduktArten { get; set; }
        public DbSet<ProduktVariante> ProduktVarianten { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<WarenKorbArtikel> WarenKorbArtikel { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<BestellungsArtikel> BestellungsArtikel { get; set; }
        public DbSet<Adresse> Adressen{ get; set; }
        public DbSet<Bild> Bilder { get; set; }


        public DatenKontext(DbContextOptions<DatenKontext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProduktVariante>().Property(p => p.Preis).HasPrecision(18, 2);
            modelBuilder.Entity<ProduktVariante>().Property(p => p.OriginalPreis).HasPrecision(18, 2);
            modelBuilder.Entity<BestellungsArtikel>().Property(p => p.GesamtPreis).HasPrecision(18, 2);
            modelBuilder.Entity<Bestellung>().Property(p => p.GesamtPreis).HasPrecision(18, 2);

            modelBuilder.Entity<ProduktVariante>().HasKey(p => new { p.ProduktID, p.ProduktArtID });
            modelBuilder.Entity<WarenKorbArtikel>().HasKey(wk => new {wk.BenutzerID, wk.ProduktID, wk.ProduktArtID });
            modelBuilder.Entity<BestellungsArtikel>().HasKey(ba => new { ba.BestellungID, ba.ProduktID, ba.ProduktArtID });
            
            modelBuilder.Entity<Kategorie>().Ignore(k => k.Bearbeitung);
            modelBuilder.Entity<Kategorie>().Ignore(k => k.IstNeu);

            modelBuilder.Entity<ProduktArt>().Ignore(pa => pa.Bearbeitung);
            modelBuilder.Entity<ProduktArt>().Ignore(pa => pa.IstNeu);

            modelBuilder.Entity<Produkt>().Ignore(pa => pa.Bearbeitung);
            modelBuilder.Entity<Produkt>().Ignore(pa => pa.IstNeu);

            modelBuilder.Entity<ProduktVariante>().Ignore(pa => pa.Bearbeitung);
            modelBuilder.Entity<ProduktVariante>().Ignore(pa => pa.IstNeu);

            modelBuilder.Entity<ProduktArt>().HasData(
                    new ProduktArt { ID = 1, Name = "Default" },
                    new ProduktArt { ID = 2, Name = "Taschenbuch" },
                    new ProduktArt { ID = 3, Name = "E-Book" },
                    new ProduktArt { ID = 4, Name = "Hörbuch" },
                    new ProduktArt { ID = 5, Name = "Strom" },
                    new ProduktArt { ID = 6, Name = "Blu-ray" },
                    new ProduktArt { ID = 7, Name = "VHS" },
                    new ProduktArt { ID = 8, Name = "PC" },
                    new ProduktArt { ID = 9, Name = "PlayStation" },
                    new ProduktArt { ID = 10, Name = "Xbox" }
                );

            modelBuilder.Entity<Kategorie>().HasData(
                new Kategorie
                {
                    ID = 1,
                    Name = "Bücher",
                    Url = "bücher"
                },
                new Kategorie
                {
                    ID = 2,
                    Name = "Filme",
                    Url = "filme"
                },
                new Kategorie
                {
                    ID = 3,
                    Name = "Videospiele",
                    Url = "videospiele"
                }
                );
            //modelBuilder.Entity<Produkt>().Property(p => p.Preis).HasPrecision(18, 2);

            modelBuilder.Entity<Produkt>().HasData(
                    new Produkt
                    {
                        ID = 1,
                        Title = "Deutsch als Fremdsprache (DaF) Aspekte 1 (B1+)",
                        Bezeichnung = "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene. Jeder Teilband der 6-bändigen Ausgabe enthält jeweils 5 Kapitel.",
                        BildUrl = "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856187/klett/cover/9783126060080.jpg",
                        KategorieID = 1,
                        Vorgestellt = true
                    },
                    new Produkt
                    {
                        ID = 2,
                        Title = "Deutsch als Fremdsprache (DaF) Aspekte 2 (B2)",
                        Bezeichnung = "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene.",
                        BildUrl = "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856201/klett/cover/9783126060127.jpg",
                        KategorieID = 1
                    },
                    new Produkt
                    {
                        ID = 3,
                        Title = "Deutsch als Fremdsprache (DaF) Aspekte 3 (C1)",
                        Bezeichnung = "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene.",
                        BildUrl = "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856242/klett/cover/9783126060233.jpg",
                        KategorieID = 1

                    },
                    new Produkt
                    {
                         ID = 4,
                         Title = "A beautiful Mind - Genie und Wahnsinn",
                         Bezeichnung = "Im Jahr 1947 wird der junge Mathematiker Josh Nash (Russell Crowe) an der Princeton University angenommen. Dies wird ihm durch das angesehene Carnegie-Stipendium ermöglicht, das jedoch auch seine Pflichten mit sich bringt. So ist Nash dazu verpflichtet Artikel zu veröffentlichen. Diesem enormen Druck zum Trotz, will er unbedingt eigene Ideen entwickeln, jedoch fehlt ihm dazu die nötige Inspiration. Einen Geistesblitz hat der Außenseiter erst, als er mit einigen anderen Studenten nachts diskutiert, welche Methode am besten geeignet ist, um die Frauen an der Bar erfolgreich anzusprechen. Während sein Kommilitone meint, jeder solle für sich selbst vorgehen, ist Nash davon überzeugt, dass Zusammenarbeit die höheren Erfolgsaussichten mit sich bringen würde. Basierend auf dieser Grundlage entwickelt er einen zentralen Begriff der Spieltheorie, was ihn auf einen Schlag berühmt macht und eine Stelle am MIT verschafft. Dort nimmt der geheimnisvolle William Parcher (Ed Harris) Kontakt zu ihm auf. Parcher ist Agent des amerikanischen Verteidigungsministeriums, der Nashs Hilfe braucht, um eine mögliche sowjetische Verschwörung aufzudecken. Denn Nash kann zum Erstaunen von anderen Kryptologen die Codes entschlüsseln, die der Feind bei seiner Kommunikation verwendet. Da ihn seine Arbeit im MIT ohnehin langweilt, stürzt sich der Mathematiker in seine neue Aufgabe und sucht in Zeitungen nach Mustern. Zunehmend verfällt Nash jedoch in eine Obsession, die ihn in Gefahr bringt und ein weitreichendes Geheimnis offenbart.",
                         BildUrl = "https://i0.wp.com/jatko.me/wp-content/uploads/2019/06/mind.jpg?w=1280&ssl=1",
                         KategorieID = 2,
                        Vorgestellt = true
                    },
                    new Produkt
                    {
                        ID = 5,
                        Title = "Léon: The Professional - Der Profi",
                        Bezeichnung = "FBI-Agent Nelville Flynn (Samuel L. Jackson) glaubt an einen Routineauftrag, als er mit einem wichtigen Zeugen auf Hawaii in eine Linienmaschine steigt, um den Herren zur Anhörung im Rahmen eines Mafiaprozesses nach Los Angeles zu überführen. Leider ging auch ein unbekannter Killer mit an Bord, und der setzt nun, knapp 10.000 Meter über dem Meeresspiegel, zur geringen Begeisterung von Cop, Crew und Passagieren ein paar hundert tödliche Giftschlangen im Flieger frei.",
                        BildUrl = "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/b000fa8918b7fa1e1b1df1c161f60b224857c8294bdc10d088b26f716167db60._RI_V_TTW_.jpg",
                        KategorieID = 2
                    },
                    new Produkt
                    {
                        ID = 6,
                        Title = "Upgrade",
                        Bezeichnung = "Viele Jahre in der Zukunft: Grey (Logan Marshall-Green) und seine Frau Asha (Melanie Vallejo) haben erst einen Autounfall und werden dann Opfer eines Gewaltverbrechens, bei dem sie stirbt und er nach einem Schuss in die Wirbelsäule in den Rollstuhl kommt. Grey denkt, dass es das nun war für ihn. Dann aber bekommt er von seinem Klienten Eron Keen (Harrison Gilbertson) das Angebot, ihm den Computerchip STEN einzupflanzen, der die Medizin revolutionieren könnte. Denn nach der Operation kann sich Grey wieder so bewegen wie vorher! Doch er hat nun nicht nur einen digitalen Unterstützer im Körper, sondern eine künstliche Superintelligenz, die auf Wunsch die komplette Kontrolle des Körpers übernimmt. Grey willigt ein, damit so die Mörder seiner Frau gefunden werden können und blutige Rache genommen wird…",
                        BildUrl = "https://m.media-amazon.com/images/M/MV5BZGRhMTE0MzgtMjZlZS00MTUxLTljMzUtYTFkZWIwZWE1MTg4XkEyXkFqcGdeQXVyMTQyMTMwOTk0._V1_.jpg",
                        KategorieID = 2
                    },
                    new Produkt
                    {
                        ID = 7,
                        Title = "Chivalry 2",
                        Bezeichnung = "Chivalry 2 ist ein Multiplayer-First-Person-Slasher, der von den epischen Schlachten bekannter Mittelalter-Filme inspiriert wurde. Spieler erleben zahlreiche ikonische Momente - von aneinander klirrenden Schwertern zu wahren Stürmen aus flammenden Pfeilen, Belagerungen riesiger Festungen und vieles mehr. Sie dominieren die Weiten der Schlachtfelder, Katapulte bringen die Erde zum Beben, während Schlösser belagert, Dörfer in Brand gesteckt und üble Bauernheere ausgemerzt werden, bei der Rückkehr der \"Team Objective\" Maps.",
                        BildUrl = "https://chivalry2.com/wp-content/uploads/2021/07/Chivalry2_Galencourt_EGS_1920x1080-3-1536x864.jpg",
                        KategorieID = 3,
                        Vorgestellt = true
                    },
                    new Produkt
                    {
                        ID = 8,
                        Title = "Fifa 23",
                        Bezeichnung = "EA SPORTS™ FIFA 23 präsentiert The World's Game. Die HyperMotion2-Technologie sorgt für noch größeren Gameplay-Realismus, Post-Launch-Updates bringen den FIFA World Cup™ der Männer und der Frauen ins Spiel, es gibt neue Frauen-Vereinsmannschaften, Cross-Play-Features* und mehr. Erlebe absolute Authentizität mit über 19.000 Profis, 700+ Teams, 100 Stadien und über 30 Ligen in FIFA 23.",
                        BildUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202207/0515/BOwvC0Q9dfw6QhGvX9dd13Sr.jpg",
                        KategorieID = 3
                    },
                    new Produkt
                    {
                        ID = 9,
                        Title = "Mount & Blade II: Bannerlord",
                        Bezeichnung = "Man spielt eine Figur, mit der man in dem fiktiven Land Calradia eine Armee aus Soldaten unterschiedlicher Waffengattungen zusammenstellen kann. Mit dieser Armee kämpft man für eine beliebige Fraktion gegen verschiedene andere Fraktionen innerhalb der Spielwelt.",
                        BildUrl = "https://www.donanimhaber.com/images/images/haber/152008/src_340x191mount-blade-ii-bannerlord-un-tam-surum-cikis-tarihi-aciklandi.jpg",
                        KategorieID = 3
                    });
            modelBuilder.Entity<ProduktVariante>().HasData(
                new ProduktVariante
                {
                    ProduktID = 1,
                    ProduktArtID = 2,
                    Preis = 9.99m,
                    OriginalPreis = 28.99m
                },
                new ProduktVariante
                {
                    ProduktID = 2,
                    ProduktArtID = 3,
                    Preis = 19.99m,
                    OriginalPreis = 29.99m
                },
                new ProduktVariante
                {
                    ProduktID = 3,
                    ProduktArtID = 1,
                    Preis = 7.99m,
                    OriginalPreis = 14.99m
                },
                new ProduktVariante
                {
                    ProduktID = 4,
                    ProduktArtID = 6,
                    Preis = 19.99m,
                    OriginalPreis = 29.99m
                },
                new ProduktVariante
                {
                    ProduktID = 5,
                    ProduktArtID = 6,
                    Preis = 49.99m,
                    OriginalPreis = 59.99m
                },
                new ProduktVariante
                {
                    ProduktID = 6,
                    ProduktArtID = 5,
                    Preis = 9.99m,
                    OriginalPreis = 24.99m,
                },
                new ProduktVariante
                {
                    ProduktID = 7,
                    ProduktArtID = 9,
                    Preis = 9.99m,
                    OriginalPreis = 24.99m,
                },
                new ProduktVariante
                {
                    ProduktID = 8,
                    ProduktArtID = 10,
                    Preis = 39.99m,
                    OriginalPreis = 70.99m,
                },
                new ProduktVariante
                {
                    ProduktID = 9,
                    ProduktArtID = 10,
                    Preis = 49.99m,
                    OriginalPreis = 85.99m,
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
