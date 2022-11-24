
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

        public async Task BestellungAufgebenAsync()
        {
            if(await IsUserAuthenticated())
            {
                await _httpClient.PostAsync("api/bestellung", null);
            }
            else
            {
                _navigationManager.NavigateTo("anmeldung");
            }
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
