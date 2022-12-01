namespace EHandelBlazor.Client.Dienste.AdresseDienst
{
    public class AdresseDienst : IAdresseDienst
    {
        private readonly HttpClient _httpClient;

        public AdresseDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Adresse> AdresseAktualisierenOderAddierenAsync(Adresse adresse)
        {
            var antwort = await _httpClient.PostAsJsonAsync("api/adresse", adresse);
            return antwort.Content.ReadFromJsonAsync<DienstAntwort<Adresse>>().Result.Daten;
        }

        public async Task<Adresse> GeheZurAdresseAsync()
        {
            var antwort = await _httpClient.GetFromJsonAsync<DienstAntwort<Adresse>>("api/adresse");
            return antwort.Daten;
        }
    }
}
