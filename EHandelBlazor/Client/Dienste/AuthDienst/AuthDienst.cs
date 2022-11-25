namespace EHandelBlazor.Client.Dienste.AuthDienst
{
    public class AuthDienst : IAuthDienst
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthDienst(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<DienstAntwort<string>> AnmeldungAsync(BenutzerAnmeldung anfrage)
        {
            var resultat = await _httpClient.PostAsJsonAsync("api/auth/anmeldung", anfrage);
            return await resultat.Content.ReadFromJsonAsync<DienstAntwort<string>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<DienstAntwort<bool>> PasswortÄndernAsync(BenutzerPasswortÄndern anfrage)
        {
            var resultat = await _httpClient.PostAsJsonAsync("api/auth/ändere-passwort", anfrage.Passwort);
            return await resultat.Content.ReadFromJsonAsync<DienstAntwort<bool>>();
        }

        public async Task<DienstAntwort<int>> RegistrierungAsync(BenutzerRegistrieren anfrage)
        {
            var resultat = await _httpClient.PostAsJsonAsync("api/auth/registrierung", anfrage);
            return await resultat.Content.ReadFromJsonAsync<DienstAntwort<int>>();
        }
    }
}
