namespace EHandelBlazor.Server.Dienste.BestellungDienst
{
    public class BestellungDienst : IBestellungDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IWarenKorbDienst _warenKorbDienst;
        private readonly IAuthDienst _authDienst;

        public BestellungDienst(DatenKontext kontext, IWarenKorbDienst warenKorbDienst, IAuthDienst authDienst)
        {
            _kontext = kontext;
            _warenKorbDienst = warenKorbDienst;
            _authDienst = authDienst;
        }
        public async Task<DienstAntwort<bool>> BestellungAufgebenAsync(int benutzerID)
        {
            var produkte = (await _warenKorbDienst.GeheZurDbWarenKorbProdukteAsync(benutzerID)).Daten;
            decimal gesamtPreis = 0;
            produkte.ForEach(produkt => gesamtPreis += produkt.Preis * produkt.Menge);

            var bestellungArtikel = new List<BestellungsArtikel>();
            produkte.ForEach(produkt => bestellungArtikel.Add(new BestellungsArtikel
            {
                ProduktID = produkt.ProduktID,
                ProduktArtID = produkt.ProduktArtID,
                Menge = produkt.Menge,
                GesamtPreis = produkt.Preis * produkt.Menge
            }));

            var bestellung = new Bestellung
            {
                BenutzerID = benutzerID,
                BestellDatum = DateTime.Now,
                GesamtPreis = gesamtPreis,
                BestellungsArtikel = bestellungArtikel
            };
            _kontext.Bestellungen.Add(bestellung);

            _kontext.WarenKorbArtikel.RemoveRange(_kontext.WarenKorbArtikel
                .Where(wka => wka.BenutzerID == benutzerID));
            await _kontext.SaveChangesAsync();

            return new DienstAntwort<bool>
            {
                Daten = true
            };
        }

        public async Task<DienstAntwort<BestellDetailsDüo>> GeheZurBestellDetailsAsync(int bestellID)
        {
            var antwort = new DienstAntwort<BestellDetailsDüo>();
            var bestellung = await _kontext.Bestellungen.Include(b => b.BestellungsArtikel)
                .ThenInclude(ba => ba.Produkt).Include(b => b.BestellungsArtikel)
                .ThenInclude(ba => ba.ProduktArt).Where(b => b.BenutzerID == _authDienst.GeheZurBenutzerID() && b.ID == bestellID)
                .OrderByDescending(b => b.BestellDatum).FirstOrDefaultAsync();

            if (bestellung == null)
            {
                antwort.Erfolg = false;
                antwort.Nachricht = "Keine Bestellung wurde gefunden";
                return antwort;
            }

            var bestellDetailsDüo = new BestellDetailsDüo
            {
                BestellDatum = bestellung.BestellDatum,
                GesamtPreis = bestellung.GesamtPreis,
                Produkte = new List<BestellProduktDetailsDüo>()
            };
            bestellung.BestellungsArtikel.ForEach(artikel=>
                bestellDetailsDüo.Produkte.Add(new BestellProduktDetailsDüo
                { 
                    ProduktID = artikel.ProduktID,
                    BildUrl = artikel.Produkt.BildUrl,
                    ProduktArt = artikel.ProduktArt.Name,
                    Menge = artikel.Menge,
                    Title = artikel.Produkt.Title,
                    GesamtPreis = artikel.GesamtPreis
                }));
            antwort.Daten = bestellDetailsDüo;
            return antwort;
        }

        public async Task<DienstAntwort<List<BestellÜbersichtDüo>>> GeheZurBestellungenAsync()
        {
            var antwort = new DienstAntwort<List<BestellÜbersichtDüo>>();
            var bestellungen = await _kontext.Bestellungen
                .Include(b => b.BestellungsArtikel).ThenInclude(ba => ba.Produkt)
                .Where(b => b.BenutzerID == _authDienst.GeheZurBenutzerID()).OrderByDescending(b => b.BestellDatum)
                .ToListAsync();

            var bestellungAntwort = new List<BestellÜbersichtDüo>();
            bestellungen.ForEach(b => bestellungAntwort.Add(new BestellÜbersichtDüo
            {
                ID = b.ID,
                Bestelldatum = b.BestellDatum,
                GesamtPreis = b.GesamtPreis,
                Produkt = b.BestellungsArtikel.Count > 1 ? $"{b.BestellungsArtikel.First().Produkt.Title} und" +
                $"{b.BestellungsArtikel.Count - 1} mehr.." :
                b.BestellungsArtikel.First().Produkt.Title,
                ProduktBildUrl = b.BestellungsArtikel.First().Produkt.BildUrl
            }));

            antwort.Daten = bestellungAntwort;
            return antwort;
        }
    }
}
