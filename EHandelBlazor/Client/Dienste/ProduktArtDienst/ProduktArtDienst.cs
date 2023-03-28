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

        public async Task GeheZurAlleProduktArten()
        {
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<List<ProduktArt>>>("api/produktart");
            ProduktArten = resultat.Daten;
        }
    }
}
