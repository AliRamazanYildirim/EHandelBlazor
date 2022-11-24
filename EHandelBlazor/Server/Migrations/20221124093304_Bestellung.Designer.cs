﻿// <auto-generated />
using System;
using EHandelBlazor.Server.Daten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    [DbContext(typeof(DatenKontext))]
    [Migration("20221124093304_Bestellung")]
    partial class Bestellung
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Benutzer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumErstellt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswortHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswortSalz")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.ToTable("Benutzer");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Bestellung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BenutzerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BestellDatum")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GesamtPreis")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Bestellungen");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.BestellungsArtikel", b =>
                {
                    b.Property<int>("BestellungID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktArtID")
                        .HasColumnType("int");

                    b.Property<decimal>("GesamtPreis")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Menge")
                        .HasColumnType("int");

                    b.HasKey("BestellungID", "ProduktID", "ProduktArtID");

                    b.HasIndex("ProduktArtID");

                    b.HasIndex("ProduktID");

                    b.ToTable("BestellungsArtikel");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Kategorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kategorien");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Bücher",
                            Url = "bücher"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Filme",
                            Url = "filme"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Videospiele",
                            Url = "videospiele"
                        });
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Produkt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BildUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategorieID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vorgestellt")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("KategorieID");

                    b.ToTable("Produkte");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Bezeichnung = "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene. Jeder Teilband der 6-bändigen Ausgabe enthält jeweils 5 Kapitel.",
                            BildUrl = "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856187/klett/cover/9783126060080.jpg",
                            KategorieID = 1,
                            Title = "Deutsch als Fremdsprache (DaF) Aspekte 1 (B1+)",
                            Vorgestellt = true
                        },
                        new
                        {
                            ID = 2,
                            Bezeichnung = "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene.",
                            BildUrl = "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856201/klett/cover/9783126060127.jpg",
                            KategorieID = 1,
                            Title = "Deutsch als Fremdsprache (DaF) Aspekte 2 (B2)",
                            Vorgestellt = false
                        },
                        new
                        {
                            ID = 3,
                            Bezeichnung = "Aspekte orientiert sich an den Niveaustufen des Europäischen Referenzrahmens und bereitet in den Bänden 2 und 3 auch auf die Prüfungen im Niveau B2 und C1 vor. Das Lehrwerk richtet sich an (junge) Erwachsene.",
                            BildUrl = "https://res.cloudinary.com/pim-red/image/upload/q_auto,f_auto,w_360/v1571856242/klett/cover/9783126060233.jpg",
                            KategorieID = 1,
                            Title = "Deutsch als Fremdsprache (DaF) Aspekte 3 (C1)",
                            Vorgestellt = false
                        },
                        new
                        {
                            ID = 4,
                            Bezeichnung = "Im Jahr 1947 wird der junge Mathematiker Josh Nash (Russell Crowe) an der Princeton University angenommen. Dies wird ihm durch das angesehene Carnegie-Stipendium ermöglicht, das jedoch auch seine Pflichten mit sich bringt. So ist Nash dazu verpflichtet Artikel zu veröffentlichen. Diesem enormen Druck zum Trotz, will er unbedingt eigene Ideen entwickeln, jedoch fehlt ihm dazu die nötige Inspiration. Einen Geistesblitz hat der Außenseiter erst, als er mit einigen anderen Studenten nachts diskutiert, welche Methode am besten geeignet ist, um die Frauen an der Bar erfolgreich anzusprechen. Während sein Kommilitone meint, jeder solle für sich selbst vorgehen, ist Nash davon überzeugt, dass Zusammenarbeit die höheren Erfolgsaussichten mit sich bringen würde. Basierend auf dieser Grundlage entwickelt er einen zentralen Begriff der Spieltheorie, was ihn auf einen Schlag berühmt macht und eine Stelle am MIT verschafft. Dort nimmt der geheimnisvolle William Parcher (Ed Harris) Kontakt zu ihm auf. Parcher ist Agent des amerikanischen Verteidigungsministeriums, der Nashs Hilfe braucht, um eine mögliche sowjetische Verschwörung aufzudecken. Denn Nash kann zum Erstaunen von anderen Kryptologen die Codes entschlüsseln, die der Feind bei seiner Kommunikation verwendet. Da ihn seine Arbeit im MIT ohnehin langweilt, stürzt sich der Mathematiker in seine neue Aufgabe und sucht in Zeitungen nach Mustern. Zunehmend verfällt Nash jedoch in eine Obsession, die ihn in Gefahr bringt und ein weitreichendes Geheimnis offenbart.",
                            BildUrl = "https://i0.wp.com/jatko.me/wp-content/uploads/2019/06/mind.jpg?w=1280&ssl=1",
                            KategorieID = 2,
                            Title = "A beautiful Mind - Genie und Wahnsinn",
                            Vorgestellt = true
                        },
                        new
                        {
                            ID = 5,
                            Bezeichnung = "FBI-Agent Nelville Flynn (Samuel L. Jackson) glaubt an einen Routineauftrag, als er mit einem wichtigen Zeugen auf Hawaii in eine Linienmaschine steigt, um den Herren zur Anhörung im Rahmen eines Mafiaprozesses nach Los Angeles zu überführen. Leider ging auch ein unbekannter Killer mit an Bord, und der setzt nun, knapp 10.000 Meter über dem Meeresspiegel, zur geringen Begeisterung von Cop, Crew und Passagieren ein paar hundert tödliche Giftschlangen im Flieger frei.",
                            BildUrl = "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/b000fa8918b7fa1e1b1df1c161f60b224857c8294bdc10d088b26f716167db60._RI_V_TTW_.jpg",
                            KategorieID = 2,
                            Title = "Léon: The Professional - Der Profi",
                            Vorgestellt = false
                        },
                        new
                        {
                            ID = 6,
                            Bezeichnung = "Viele Jahre in der Zukunft: Grey (Logan Marshall-Green) und seine Frau Asha (Melanie Vallejo) haben erst einen Autounfall und werden dann Opfer eines Gewaltverbrechens, bei dem sie stirbt und er nach einem Schuss in die Wirbelsäule in den Rollstuhl kommt. Grey denkt, dass es das nun war für ihn. Dann aber bekommt er von seinem Klienten Eron Keen (Harrison Gilbertson) das Angebot, ihm den Computerchip STEN einzupflanzen, der die Medizin revolutionieren könnte. Denn nach der Operation kann sich Grey wieder so bewegen wie vorher! Doch er hat nun nicht nur einen digitalen Unterstützer im Körper, sondern eine künstliche Superintelligenz, die auf Wunsch die komplette Kontrolle des Körpers übernimmt. Grey willigt ein, damit so die Mörder seiner Frau gefunden werden können und blutige Rache genommen wird…",
                            BildUrl = "https://m.media-amazon.com/images/M/MV5BZGRhMTE0MzgtMjZlZS00MTUxLTljMzUtYTFkZWIwZWE1MTg4XkEyXkFqcGdeQXVyMTQyMTMwOTk0._V1_.jpg",
                            KategorieID = 2,
                            Title = "Upgrade",
                            Vorgestellt = false
                        },
                        new
                        {
                            ID = 7,
                            Bezeichnung = "Chivalry 2 ist ein Multiplayer-First-Person-Slasher, der von den epischen Schlachten bekannter Mittelalter-Filme inspiriert wurde. Spieler erleben zahlreiche ikonische Momente - von aneinander klirrenden Schwertern zu wahren Stürmen aus flammenden Pfeilen, Belagerungen riesiger Festungen und vieles mehr. Sie dominieren die Weiten der Schlachtfelder, Katapulte bringen die Erde zum Beben, während Schlösser belagert, Dörfer in Brand gesteckt und üble Bauernheere ausgemerzt werden, bei der Rückkehr der \"Team Objective\" Maps.",
                            BildUrl = "https://chivalry2.com/wp-content/uploads/2021/07/Chivalry2_Galencourt_EGS_1920x1080-3-1536x864.jpg",
                            KategorieID = 3,
                            Title = "Chivalry 2",
                            Vorgestellt = true
                        },
                        new
                        {
                            ID = 8,
                            Bezeichnung = "EA SPORTS™ FIFA 23 präsentiert The World's Game. Die HyperMotion2-Technologie sorgt für noch größeren Gameplay-Realismus, Post-Launch-Updates bringen den FIFA World Cup™ der Männer und der Frauen ins Spiel, es gibt neue Frauen-Vereinsmannschaften, Cross-Play-Features* und mehr. Erlebe absolute Authentizität mit über 19.000 Profis, 700+ Teams, 100 Stadien und über 30 Ligen in FIFA 23.",
                            BildUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202207/0515/BOwvC0Q9dfw6QhGvX9dd13Sr.jpg",
                            KategorieID = 3,
                            Title = "Fifa 23",
                            Vorgestellt = false
                        },
                        new
                        {
                            ID = 9,
                            Bezeichnung = "Man spielt eine Figur, mit der man in dem fiktiven Land Calradia eine Armee aus Soldaten unterschiedlicher Waffengattungen zusammenstellen kann. Mit dieser Armee kämpft man für eine beliebige Fraktion gegen verschiedene andere Fraktionen innerhalb der Spielwelt.",
                            BildUrl = "https://www.donanimhaber.com/images/images/haber/152008/src_340x191mount-blade-ii-bannerlord-un-tam-surum-cikis-tarihi-aciklandi.jpg",
                            KategorieID = 3,
                            Title = "Mount & Blade II: Bannerlord",
                            Vorgestellt = false
                        });
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.ProduktArt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ProduktArten");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Default"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Taschenbuch"
                        },
                        new
                        {
                            ID = 3,
                            Name = "E-Book"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Hörbuch"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Strom"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Blu-ray"
                        },
                        new
                        {
                            ID = 7,
                            Name = "VHS"
                        },
                        new
                        {
                            ID = 8,
                            Name = "PC"
                        },
                        new
                        {
                            ID = 9,
                            Name = "PlayStation"
                        },
                        new
                        {
                            ID = 10,
                            Name = "Xbox"
                        });
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.ProduktVariante", b =>
                {
                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktArtID")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPreis")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Preis")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProduktID", "ProduktArtID");

                    b.HasIndex("ProduktArtID");

                    b.ToTable("ProduktVarianten");

                    b.HasData(
                        new
                        {
                            ProduktID = 1,
                            ProduktArtID = 2,
                            OriginalPreis = 28.99m,
                            Preis = 9.99m
                        },
                        new
                        {
                            ProduktID = 2,
                            ProduktArtID = 3,
                            OriginalPreis = 29.99m,
                            Preis = 19.99m
                        },
                        new
                        {
                            ProduktID = 3,
                            ProduktArtID = 1,
                            OriginalPreis = 14.99m,
                            Preis = 7.99m
                        },
                        new
                        {
                            ProduktID = 4,
                            ProduktArtID = 6,
                            OriginalPreis = 29.99m,
                            Preis = 19.99m
                        },
                        new
                        {
                            ProduktID = 5,
                            ProduktArtID = 6,
                            OriginalPreis = 59.99m,
                            Preis = 49.99m
                        },
                        new
                        {
                            ProduktID = 6,
                            ProduktArtID = 5,
                            OriginalPreis = 24.99m,
                            Preis = 9.99m
                        },
                        new
                        {
                            ProduktID = 7,
                            ProduktArtID = 9,
                            OriginalPreis = 24.99m,
                            Preis = 9.99m
                        },
                        new
                        {
                            ProduktID = 8,
                            ProduktArtID = 10,
                            OriginalPreis = 70.99m,
                            Preis = 39.99m
                        },
                        new
                        {
                            ProduktID = 9,
                            ProduktArtID = 10,
                            OriginalPreis = 85.99m,
                            Preis = 49.99m
                        });
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.WarenKorbArtikel", b =>
                {
                    b.Property<int>("BenutzerID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktArtID")
                        .HasColumnType("int");

                    b.Property<int>("Menge")
                        .HasColumnType("int");

                    b.HasKey("BenutzerID", "ProduktID", "ProduktArtID");

                    b.ToTable("WarenKorbArtikel");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.BestellungsArtikel", b =>
                {
                    b.HasOne("EHandelBlazor.Shared.Modelle.Bestellung", "Bestellung")
                        .WithMany("BestellungsArtikel")
                        .HasForeignKey("BestellungID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHandelBlazor.Shared.Modelle.ProduktArt", "ProduktArt")
                        .WithMany()
                        .HasForeignKey("ProduktArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHandelBlazor.Shared.Modelle.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bestellung");

                    b.Navigation("Produkt");

                    b.Navigation("ProduktArt");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Produkt", b =>
                {
                    b.HasOne("EHandelBlazor.Shared.Modelle.Kategorie", "Kategorie")
                        .WithMany()
                        .HasForeignKey("KategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorie");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.ProduktVariante", b =>
                {
                    b.HasOne("EHandelBlazor.Shared.Modelle.ProduktArt", "ProduktArt")
                        .WithMany()
                        .HasForeignKey("ProduktArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHandelBlazor.Shared.Modelle.Produkt", "Produkt")
                        .WithMany("ProduktVarianten")
                        .HasForeignKey("ProduktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("ProduktArt");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Bestellung", b =>
                {
                    b.Navigation("BestellungsArtikel");
                });

            modelBuilder.Entity("EHandelBlazor.Shared.Modelle.Produkt", b =>
                {
                    b.Navigation("ProduktVarianten");
                });
#pragma warning restore 612, 618
        }
    }
}
