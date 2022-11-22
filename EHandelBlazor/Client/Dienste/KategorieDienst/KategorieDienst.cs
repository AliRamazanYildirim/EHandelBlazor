namespace EHandelBlazor.Client.Dienste.KategorieDienst
{
    public class KategorieDienst : IKategorieDienst
    {
        private readonly HttpClient _httpClient;

        public KategorieDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Kategorie> Kategorien { get; set; } = new List<Kategorie>();

        public async Task GeheZurAlleKategorienAsync()
        {
            var antwort = await _httpClient.GetFromJsonAsync<DienstAntwort<List<Kategorie>>>("api/Kategorie");
            if(antwort != null && antwort.Daten !=null)
            {

            }
            Kategorien = antwort.Daten;
        }
    }
}
