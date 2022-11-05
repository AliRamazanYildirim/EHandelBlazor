using Blazored.LocalStorage;

namespace EHandelBlazor.Client.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public WarenKorbDienst(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }
        public event Action BeiÄnderung;

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
            var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if(warenKorb == null)
            {
                warenKorb = new List<WarenKorbArtikel>();
            }
            warenKorb.Add(warenKorbArtikel);
            await _localStorageService.SetItemAsync("warenkorb", warenKorb);
            BeiÄnderung.Invoke();
        }
    }
}
