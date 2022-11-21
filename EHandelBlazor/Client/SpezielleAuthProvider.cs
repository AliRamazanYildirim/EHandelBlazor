using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace EHandelBlazor.Client
{
    public class SpezielleAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public SpezielleAuthProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken=await _localStorageService.GetItemAsStringAsync("authToken");

            var identität = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if(!string.IsNullOrEmpty(authToken))
            {
                try 
                {
                    identität = new ClaimsIdentity(ParseClaimsVonJwt(authToken), "jwt");
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authToken.Replace("\"",""));
                }
                catch 
                {
                    await _localStorageService.RemoveItemAsync("authToken");
                    identität = new ClaimsIdentity();
                }
            }
            var benutzer = new ClaimsPrincipal(identität);
            var state = new AuthenticationState(benutzer);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
        private byte[] ParseBase64OhneAuffüllen(string base64)
        {
            switch(base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;

            }
            return Convert.FromBase64String(base64);
        }
        private IEnumerable<Claim> ParseClaimsVonJwt(string jwt)
        {
            var nutzlast = jwt.Split('.')[1];
            var jsonBytes = ParseBase64OhneAuffüllen(nutzlast);
            var schlüsselWertPaar = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            var claims = schlüsselWertPaar.Select(swp => new Claim(swp.Key, swp.Value.ToString()));

            return claims;
        }
    }
}
