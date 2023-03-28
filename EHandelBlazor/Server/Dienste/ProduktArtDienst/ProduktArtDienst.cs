namespace EHandelBlazor.Server.Dienste.ProduktArtDienst
{
    public class ProduktArtDienst : IProduktArtDienst
    {
        private readonly DatenKontext _kontext;

        public ProduktArtDienst(DatenKontext kontext)
        {
            _kontext = kontext;
        }
        public async Task<DienstAntwort<List<ProduktArt>>> GeheZurAlleProduktArtenAsync()
        {
            var produktArten = await _kontext.ProduktArten.ToListAsync();
            return new DienstAntwort<List<ProduktArt>>
            {
                Daten = produktArten
            };
        }
    }
}
