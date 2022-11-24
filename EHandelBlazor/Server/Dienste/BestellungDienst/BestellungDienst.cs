namespace EHandelBlazor.Server.Dienste.BestellungDienst
{
    public class BestellungDienst : IBestellungDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IWarenKorbDienst _warenKorbDienst;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BestellungDienst(DatenKontext kontext, IWarenKorbDienst warenKorbDienst,
            IHttpContextAccessor httpContextAccessor)
        {
            _kontext = kontext;
            _warenKorbDienst = warenKorbDienst;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GeheZurBenutzerID() =>
            int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<DienstAntwort<bool>> BestellungAufgebenAsync()
        {
            var produkte = (await _warenKorbDienst.GeheZurDbWarenKorbProdukteAsync()).Daten;
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
                BenutzerID = GeheZurBenutzerID(),
                BestellDatum = DateTime.Now,
                GesamtPreis = gesamtPreis,
                BestellungsArtikel = bestellungArtikel
            };
            _kontext.Bestellungen.Add(bestellung);
            await _kontext.SaveChangesAsync();

            return new DienstAntwort<bool>
            {
                Daten = true
            };
        }
    }
}
