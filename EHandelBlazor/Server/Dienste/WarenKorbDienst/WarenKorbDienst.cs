using EHandelBlazor.Shared.Modelle;
using Microsoft.EntityFrameworkCore;

namespace EHandelBlazor.Server.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly DatenKontext _kontext;

        public WarenKorbDienst(DatenKontext kontext)
        {
            _kontext = kontext;
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

        public async Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> WarenKorbArtikelSpeichernAsync(List<WarenKorbArtikel> warenKorbArtikel, int benutzerID)
        {
            warenKorbArtikel.ForEach(warenKorbArtikel => warenKorbArtikel.BenutzerID = benutzerID);
            _kontext.WarenKorbArtikel.AddRange(warenKorbArtikel);
            await _kontext.SaveChangesAsync();

            return await GeheZurAntwortDerWarenKorbProdukteAsync
                (await _kontext.WarenKorbArtikel.Where(wk => wk.BenutzerID == benutzerID).ToListAsync());
        }
    }
}
