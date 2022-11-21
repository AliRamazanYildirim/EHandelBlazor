namespace EHandelBlazor.Client.Dienste.AuthDienst
{
    public class AuthDienst : IAuthDienst
    {
        private readonly HttpClient _httpClient;

        public AuthDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DienstAntwort<string>> AnmeldungAsync(BenutzerAnmeldung anfrage)
        {
            var resultat = await _httpClient.PostAsJsonAsync("api/auth/anmeldung", anfrage);
            return await resultat.Content.ReadFromJsonAsync<DienstAntwort<string>>();
        }

        public async Task<DienstAntwort<int>> RegistrierungAsync(BenutzerRegistrieren anfrage)
        {
            var resultat = await _httpClient.PostAsJsonAsync("api/auth/registrierung", anfrage);
            return await resultat.Content.ReadFromJsonAsync<DienstAntwort<int>>();
        }
    }
}
