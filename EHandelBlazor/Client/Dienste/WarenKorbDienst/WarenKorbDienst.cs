namespace EHandelBlazor.Client.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly IAuthDienst _authDienst;

        public WarenKorbDienst(ILocalStorageService localStorageService, HttpClient httpClient,IAuthDienst authDienst)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            _authDienst = authDienst;
        }
        public event Action BeiÄnderung;

        public async Task EntfernenProduktAusWarenKorbAsync(int produktID, int produktArtID)
        {
            if (await _authDienst.IsUserAuthenticated())
            {
                await _httpClient.DeleteAsync($"api/warenkorb/{produktID}/{produktArtID}");
            }
            else
            {
                var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
                if (warenKorb == null)
                {
                    return;
                }
                var warenKorbArtikel = warenKorb.Find(a => a.ProduktID == produktID && a.ProduktArtID == produktArtID);
                if (warenKorbArtikel != null)
                {
                    warenKorb.Remove(warenKorbArtikel);
                    await _localStorageService.SetItemAsync("warenkorb", warenKorb);
                    
                }
            }
        }

        public async Task GeheZurWarenKorbArtikelAnzahlAsync()
        {
            if (await _authDienst.IsUserAuthenticated())
            {
                var resultat = await _httpClient.GetFromJsonAsync<DienstAntwort<int>>("api/warenkorb/anzahl");
                var anzahl = resultat.Daten;

                await _localStorageService.SetItemAsync<int>("warenKorbArtikelAnzahl", anzahl);
            }
            else
            {
                var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
                await _localStorageService.SetItemAsync<int>("warenKorbArtikelAnzahl", warenKorb != null ? warenKorb.Count : 0);
            }
            BeiÄnderung.Invoke();
        }

        public async Task<List<AntwortDesWarenKorbProduktes>> GeheZurWarenKorbProdukteAsync()
        {
            if (await _authDienst.IsUserAuthenticated())
            {
                var antwort = await _httpClient.GetFromJsonAsync<DienstAntwort<List<AntwortDesWarenKorbProduktes>>>("api/warenkorb");
                return antwort.Daten;

            }
            else
            {
                var warenKorbArtikel = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
                if (warenKorbArtikel == null)
                    return new List<AntwortDesWarenKorbProduktes>();
                var antwort = await _httpClient.PostAsJsonAsync("api/warenkorb/produkte", warenKorbArtikel);
                var warenKorbProdukte =
                    await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<AntwortDesWarenKorbProduktes>>>();
                return warenKorbProdukte.Daten;
            }
        }

        public async Task InWarenKorbLegen(WarenKorbArtikel warenKorbArtikel)
        {
            if (await _authDienst.IsUserAuthenticated())
            {
                await _httpClient.PostAsJsonAsync("api/warenkorb/addieren", warenKorbArtikel);
            }
            else
            {

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
            }
            await GeheZurWarenKorbArtikelAnzahlAsync();
        }
        public async Task MengeAktualisierenAsync(AntwortDesWarenKorbProduktes produkt)
        {
            if (await _authDienst.IsUserAuthenticated())
            {
                var anfrage = new WarenKorbArtikel
                {
                    ProduktID = produkt.ProduktID,
                    Menge = produkt.Menge,
                    ProduktArtID = produkt.ProduktArtID
                };
                await _httpClient.PutAsJsonAsync("api/warenkorb/menge-aktualisieren", anfrage);
            }
            else
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

        }

        public async Task WarenKorbArtikelSpeichernAsync(bool leerWarenKorb = false)
        {
            var speichernWarenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if (speichernWarenKorb == null)
            {
                return;
            }
            await _httpClient.PostAsJsonAsync("api/warenkorb", speichernWarenKorb);
            if (leerWarenKorb)
            {
                await _localStorageService.RemoveItemAsync("warenkorb");
            }
        }
    }
}
