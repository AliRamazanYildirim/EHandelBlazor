using Blazored.LocalStorage;

namespace EHandelBlazor.Client.Dienste.WarenKorbDienst
{
    public class WarenKorbDienst : IWarenKorbDienst
    {
        private readonly ILocalStorageService _localStorageService;

        public WarenKorbDienst(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
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

        public async Task InWarenKorbLegen(WarenKorbArtikel warenKorbArtikel)
        {
            var warenKorb = await _localStorageService.GetItemAsync<List<WarenKorbArtikel>>("warenkorb");
            if(warenKorb == null)
            {
                warenKorb = new List<WarenKorbArtikel>();
            }
            warenKorb.Add(warenKorbArtikel);
            await _localStorageService.SetItemAsync("warenkorb", warenKorb);
        }
    }
}
