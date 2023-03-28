namespace EHandelBlazor.Client.Dienste.ProduktArtDienst
{
    public class ProduktArtDienst : IProduktArtDienst
    {
        private readonly HttpClient _httpClient;

        public ProduktArtDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<ProduktArt> ProduktArten { get; set; } = new List<ProduktArt>();

        public event Action BeiÄnderung;

        public async Task AktualisiereProduktArt(ProduktArt produktArt)
        {
            var antwort = await _httpClient.PutAsJsonAsync("api/produktart", produktArt);
            ProduktArten = (await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<ProduktArt>>>()).Daten;
            BeiÄnderung.Invoke(); ;
        }

        public ProduktArt ErstelleNeueProduktArt()
        {
            var neueProduktArt = new ProduktArt { IstNeu = true, Bearbeitung = true };
            ProduktArten.Add(neueProduktArt);
            BeiÄnderung.Invoke();
            return neueProduktArt;
        }

        public async Task ErstelleProduktArt(ProduktArt produktArt)
        {
            var antwort = await _httpClient.PostAsJsonAsync("api/produktart", produktArt);
            ProduktArten = (await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<ProduktArt>>>()).Daten;
            BeiÄnderung.Invoke();
        }

        public async Task GeheZurAlleProduktArten()
        {
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<List<ProduktArt>>>("api/produktart");
            ProduktArten = resultat.Daten;
        }
    }
}
