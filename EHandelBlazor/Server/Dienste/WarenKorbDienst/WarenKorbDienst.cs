namespace EHandelBlazor.Server.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IAuthDienst _authDienst;

        public WarenKorbDienst(DatenKontext kontext, IAuthDienst authDienst)
        {
            _kontext = kontext;
            _authDienst = authDienst;
        }
        public async Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> GeheZurAntwortDerWarenKorbProdukteAsync(List<WarenKorbArtikel> warenKorbArtikel)
        {
            var resultat = new DienstAntwort<List<AntwortDesWarenKorbProduktes>>
            {
                Daten = new List<AntwortDesWarenKorbProduktes>()
            };
            foreach (var artikel in warenKorbArtikel)
            {
                var produkt = await _kontext.Produkte.Where(p => p.ID == artikel.ProduktID).FirstOrDefaultAsync();
                if(produkt == null)
                {
                    continue;
                }

                var produktVariante = await _kontext.ProduktVarianten
                    .Where(v => v.ProduktID == artikel.ProduktID && v.ProduktArtID == artikel.ProduktArtID)
                    .Include(v => v.ProduktArt).FirstOrDefaultAsync();
                if (produktVariante == null)
                {
                    continue;
                }

                var warenKorbProdukt = new AntwortDesWarenKorbProduktes
                {
                    ProduktID = produkt.ID,
                    Title = produkt.Title,
                    BildUrl = produkt.BildUrl,
                    Preis = produktVariante.Preis,
                    ProduktArt = produktVariante.ProduktArt.Name,
                    ProduktArtID = produktVariante.ProduktArtID,
                    Menge=artikel.Menge
                };

                resultat.Daten.Add(warenKorbProdukt);
            }
            return resultat;
        }

        public async Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> WarenKorbArtikelSpeichernAsync(List<WarenKorbArtikel> warenKorbArtikel)
        {
            warenKorbArtikel.ForEach(warenKorbArtikel => warenKorbArtikel.BenutzerID = _authDienst.GeheZurBenutzerID());
            _kontext.WarenKorbArtikel.AddRange(warenKorbArtikel);
            await _kontext.SaveChangesAsync();

            return await GeheZurDbWarenKorbProdukteAsync();
        }

        public async Task<DienstAntwort<int>> GeheZurWarenKorbArtikelAnzahlAsync()
        {
            var anzahl=(await _kontext.WarenKorbArtikel.Where(wk=>wk.BenutzerID==_authDienst.GeheZurBenutzerID()).ToListAsync()).Count;
            return new DienstAntwort<int>
            {
                Daten = anzahl
            };
        }

        public async Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> GeheZurDbWarenKorbProdukteAsync()
        {
            return await GeheZurAntwortDerWarenKorbProdukteAsync(await _kontext.WarenKorbArtikel
                .Where(wk => wk.BenutzerID == _authDienst.GeheZurBenutzerID()).ToListAsync());
        }

        public async Task<DienstAntwort<bool>> InWarenKorbLegenAsync(WarenKorbArtikel warenKorbArtikel)
        {
            warenKorbArtikel.BenutzerID = _authDienst.GeheZurBenutzerID();
            var dasselbeArtikel = await _kontext.WarenKorbArtikel
                .FirstOrDefaultAsync(wk => wk.ProduktID == warenKorbArtikel.ProduktID && wk.ProduktArtID == warenKorbArtikel.ProduktArtID
                && wk.BenutzerID == warenKorbArtikel.BenutzerID);
            if(dasselbeArtikel == null)
            {
                _kontext.WarenKorbArtikel.Add(warenKorbArtikel);
            }
            else
            {
                dasselbeArtikel.Menge += warenKorbArtikel.Menge;
            }
            await _kontext.SaveChangesAsync();
            return new DienstAntwort<bool>
            {
                Daten = true
            };
        }

        public async Task<DienstAntwort<bool>> MengeAktualisierenAsync(WarenKorbArtikel warenKorbArtikel)
        {
            var warenKorbDbArtikel = await _kontext.WarenKorbArtikel
                .FirstOrDefaultAsync(wk => wk.ProduktID == warenKorbArtikel.ProduktID && wk.ProduktArtID == warenKorbArtikel.ProduktArtID
                && wk.BenutzerID == _authDienst.GeheZurBenutzerID());
            if(warenKorbArtikel == null)
            {
                return new DienstAntwort<bool>
                {
                    Daten = false,
                    Erfolg = false,
                    Nachricht = "Warenkorb-Artikel existiert nicht."
                };
            }
            warenKorbDbArtikel.Menge = warenKorbArtikel.Menge;
            await _kontext.SaveChangesAsync();

            return  new DienstAntwort<bool>
            {
                Daten = true
            };
        }

        public async Task<DienstAntwort<bool>> ArtikelAusWarenKorbEntfernenAsync(int produktID, int produktArtID)
        {
            var warenKorbDbArtikel = await _kontext.WarenKorbArtikel
                .FirstOrDefaultAsync(wk => wk.ProduktID == produktID && wk.ProduktArtID == produktArtID
                && wk.BenutzerID == _authDienst.GeheZurBenutzerID());
            if (warenKorbDbArtikel == null)
            {
                return new DienstAntwort<bool>
                {
                    Daten = false,
                    Erfolg = false,
                    Nachricht = "Warenkorb-Artikel existiert nicht."
                };
            }
            _kontext.WarenKorbArtikel.Remove(warenKorbDbArtikel);
            await _kontext.SaveChangesAsync();

            return new DienstAntwort<bool>
            {
                Daten = true
            };
        }
    }
}
