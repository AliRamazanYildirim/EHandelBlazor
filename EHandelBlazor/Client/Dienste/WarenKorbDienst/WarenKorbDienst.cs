using Blazored.LocalStorage;
using EHandelBlazor.Client.Pages;
using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Client.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public WarenKorbDienst(ILocalStorageService localStorageService, HttpClient httpClient, 
            AuthenticationStateProvider authenticationStateProvider)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public event Action BeiÄnderung;

        public async Task EntfernenProduktAusWarenKorbAsync(int produktID, int produktArtID)
        {
            var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if(warenKorb == null)
            {
                return;
            }
            var warenKorbArtikel = warenKorb.Find(a => a.ProduktID == produktID && a.ProduktArtID == produktArtID);
            if(warenKorbArtikel != null)
            {
                warenKorb.Remove(warenKorbArtikel);
                await _localStorageService.SetItemAsync("warenkorb", warenKorb);
                BeiÄnderung.Invoke();
            }
        }

        public async Task<List<WarenKorbArtikel>> GeheZurWarenKorbArtikelAsync()
        {
            var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if (warenKorb == null)
            {
                warenKorb = new List<WarenKorbArtikel>();
            }
            return warenKorb;
        }

        public async Task<List<AntwortDesWarenKorbProduktes>> GeheZurWarenKorbProdukteAsync()
        {
            var warenKorbArtikel = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            var antwort = await _httpClient.PostAsJsonAsync("api/warenkorb/produkte", warenKorbArtikel);
            var warenKorbProdukte = 
                await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<AntwortDesWarenKorbProduktes>>>();
            return warenKorbProdukte.Daten;

        }

        public async Task InWarenKorbLegen(WarenKorbArtikel warenKorbArtikel)
        {
            if (await IsUserAuthenticated())
            {
                Console.WriteLine("Benutzer ist authentifiziert.");
            }
            else
            {
                Console.WriteLine("Benutzer ist nicht authentifiziert");
            }

            var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if (warenKorb == null)
            {
                warenKorb = new List<WarenKorbArtikel>();
            }

            var gleicherArtikel = warenKorb.Find(a => a.ProduktID == warenKorbArtikel.ProduktID
            && a.ProduktArtID == warenKorbArtikel.ProduktArtID);
            if (gleicherArtikel == null)
            {
                warenKorb.Add(warenKorbArtikel);
            }
            else
            {
                gleicherArtikel.Menge += warenKorbArtikel.Menge;
            }

            await _localStorageService.SetItemAsync("warenkorb", warenKorb);
            BeiÄnderung.Invoke();
        }
        public async Task MengeAktualisierenAsync(AntwortDesWarenKorbProduktes produkt)
        {
            var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if (warenKorb == null)
            {
                return;
            }
            var warenKorbArtikel = warenKorb.Find(a => a.ProduktID == produkt.ProduktID 
            && a.ProduktArtID == produkt.ProduktArtID);
            if (warenKorbArtikel != null)
            {
                warenKorbArtikel.Menge = produkt.Menge;
                await _localStorageService.SetItemAsync("warenkorb", warenKorb);
            }
        }

        public async Task WarenKorbArtikelSpeichernAsync(bool leerWarenKorb = false)
        {
            var speichernWarenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if (speichernWarenKorb == null)
            {
                return;
            }
            await _httpClient.PostAsJsonAsync("api/warenkorb", speichernWarenKorb);
            if(leerWarenKorb)
            {
                await _localStorageService.RemoveItemAsync("warenkorb");
            }
        }
        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
