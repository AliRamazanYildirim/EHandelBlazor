
namespace EHandelBlazor.Client.Dienste.BestellungDienst
{
    public class BestellungDienst : IBestellungDienst
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        public BestellungDienst(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,
            NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task<string> BestellungAufgebenAsync()
        {
            if(await IsUserAuthenticated())
            {
                var resultat = await _httpClient.PostAsync("api/payment/kasse", null);
                var url = await resultat.Content.ReadAsStringAsync();
                return url;
            }
            else
            {
                return "anmeldung";
            }
        }

        public async Task<BestellDetailsDüo> GeheZurBestellDetailsAsync(int bestellID)
        {
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<BestellDetailsDüo>>($"api/bestellung/{bestellID}");
            return resultat.Daten;
        }

        public async Task<List<BestellÜbersichtDüo>> GeheZurBestellungenAsync()
        {
            var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<List<BestellÜbersichtDüo>>>("api/bestellung");
            return resultat.Daten;
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
