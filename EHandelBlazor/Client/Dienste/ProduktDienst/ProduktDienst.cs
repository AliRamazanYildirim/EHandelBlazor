namespace EHandelBlazor.Client.Dienste.ProduktDienst
{
    public class ProduktDienst : IProduktDienst
    {
        private readonly HttpClient _httpClient;

        public ProduktDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Produkt> Produkte { get; set; } = new List<Produkt>();
        public string Nachricht { get; set; } = "Produkte werden geladen...";
        public int AktuelleSeite { get; set; } = 1;
        public int SeitenZahl { get; set; } = 0;
        public string LetzterSuchText { get; set; } = string.Empty;

        public event Action ProdukteGeändert;

        public async Task<List<string>> GeheAnregungenZurProduktSucheAsync(string suchText)
        {
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<List<string>>>($"api/produkt/sucheAnregungen/{suchText}");
            return resultat.Daten;
        }

        public async Task<DienstAntwort<Produkt>> GeheZumProduktAsync(int produktID)
        {
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<Produkt>>($"api/produkt/{produktID}");
            return resultat;
        }

        public async Task GeheZurProdukteAsync(string? kategorieUrl = null)
        {
            var resultat = kategorieUrl == null?
            await _httpClient.GetFromJsonAsync<DienstAntwort<List<Produkt>>>("api/produkt/vorgestellt"):
            await _httpClient.GetFromJsonAsync<DienstAntwort<List<Produkt>>>($"api/produkt/kategorie/{kategorieUrl}");
            if (resultat != null && resultat.Daten != null)
                Produkte = resultat.Daten;

            AktuelleSeite = 1;
            SeitenZahl = 0;
            if (Produkte.Count == 0)
                Nachricht = "Kein Produkt wurde gefunden!";

            ProdukteGeändert.Invoke();
        }

        public async Task SucheProdukteAsync(string suchText,int seite)
        {
            LetzterSuchText=suchText;
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<ResultatProduktSuche>>($"api/produkt/suche/{suchText}/{seite}");
            if(resultat != null && resultat.Daten != null)
            {
                Produkte = resultat.Daten.Produkte;
                AktuelleSeite = resultat.Daten.AktuelleSeite;
                SeitenZahl = resultat.Daten.Seiten;
            }
            if (Produkte.Count == 0) Nachricht = "Kein Produkt wurde gefunden.";
            ProdukteGeändert?.Invoke();
        }
    }
}
