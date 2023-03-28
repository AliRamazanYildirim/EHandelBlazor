namespace EHandelBlazor.Server.Dienste.ProduktArtDienst
{
    public class ProduktArtDienst : IProduktArtDienst
    {
        private readonly DatenKontext _kontext;

        public ProduktArtDienst(DatenKontext kontext)
        {
            _kontext = kontext;
        }

        public async Task<DienstAntwort<List<ProduktArt>>> AktualisiereProduktArtAsync(ProduktArt produktArt)
        {
            var dbProduktArt = await _kontext.ProduktArten.FindAsync(produktArt.ID);
            if(dbProduktArt==null)
            {
                return new DienstAntwort<List<ProduktArt>>
                {
                    Erfolg = false,
                    Nachricht = "Produktart wurde nicht gefunden."
                };
            }
            dbProduktArt.Name = produktArt.Name;
            await _kontext.SaveChangesAsync();
            return await GeheZurAlleProduktArtenAsync();
        }

        public async Task<DienstAntwort<List<ProduktArt>>> GeheZurAlleProduktArtenAsync()
        {
            var produktArten = await _kontext.ProduktArten.ToListAsync();
            return new DienstAntwort<List<ProduktArt>>
            {
                Daten = produktArten
            };
        }

        public async Task<DienstAntwort<List<ProduktArt>>> HinzufügeProduktArtAsync(ProduktArt produktArt)
        {
            _kontext.ProduktArten.Add(produktArt);
            await _kontext.SaveChangesAsync();
            return await GeheZurAlleProduktArtenAsync();
        }
    }
}
