namespace EHandelBlazor.Server.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WarenKorbDienst(DatenKontext kontext, IHttpContextAccessor httpContextAccessor)
        {
            _kontext = kontext;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GeheZurBenutzerID() => 
            int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
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
            warenKorbArtikel.ForEach(warenKorbArtikel => warenKorbArtikel.BenutzerID = GeheZurBenutzerID());
            _kontext.WarenKorbArtikel.AddRange(warenKorbArtikel);
            await _kontext.SaveChangesAsync();

            return await GeheZurAntwortDerWarenKorbProdukteAsync
                (await _kontext.WarenKorbArtikel.Where(wk => wk.BenutzerID == GeheZurBenutzerID()).ToListAsync());
        }

        public async Task<DienstAntwort<int>> GeheZurWarenKorbArtikelAnzahlAsync()
        {
            var anzahl=(await _kontext.WarenKorbArtikel.Where(wk=>wk.BenutzerID==GeheZurBenutzerID()).ToListAsync()).Count;
            return new DienstAntwort<int>
            {
                Daten = anzahl
            };
        }
    }
}
