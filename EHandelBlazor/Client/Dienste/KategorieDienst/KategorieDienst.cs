namespace EHandelBlazor.Client.Dienste.KategorieDienst
{
    public class KategorieDienst : IKategorieDienst
    {
        private readonly HttpClient _httpClient;

        public KategorieDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Kategorie> Kategorien { get; set; } = new List<Kategorie>();
        public List<Kategorie> AdminKategorien { get; set; } = new List<Kategorie>();

        public event Action BeiÄnderung;

        public async Task AktualisierenKategorieAsync(Kategorie kategorie)
        {
            var antwort = await _httpClient.PutAsJsonAsync("api/Kategorie/admin", kategorie);
            AdminKategorien = (await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<Kategorie>>>()).Daten;
            await GeheZurAlleKategorienAsync();
            BeiÄnderung.Invoke();
        }

        public Kategorie ErstelleNeueKategorie()
        {
            var neueKategorie = new Kategorie { IstNeu = true, Bearbeitung = true };
            AdminKategorien.Add(neueKategorie);
            BeiÄnderung.Invoke();
            return neueKategorie; 
        }

        public async Task GeheZurAdminKategorienAsync()
        {
            var antwort = await _httpClient.GetFromJsonAsync<DienstAntwort<List<Kategorie>>>("api/Kategorie/admin");
            if (antwort != null && antwort.Daten != null)
            AdminKategorien = antwort.Daten;
        }

        public async Task GeheZurAlleKategorienAsync()
        {
            var antwort = await _httpClient.GetFromJsonAsync<DienstAntwort<List<Kategorie>>>("api/Kategorie");
            if(antwort != null && antwort.Daten !=null)
            Kategorien = antwort.Daten;
        }

        public async Task HinzufügenKategorieAsync(Kategorie kategorie)
        {
            var antwort = await _httpClient.PostAsJsonAsync("api/Kategorie/admin", kategorie);
            AdminKategorien = (await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<Kategorie>>>()).Daten;
            await GeheZurAlleKategorienAsync();
            BeiÄnderung.Invoke();
        }

        public async Task LöschenKategorieAsync(int kategorieID)
        {
            var antwort = await _httpClient.DeleteAsync($"api/Kategorie/admin/{kategorieID}");
            AdminKategorien = (await antwort.Content.ReadFromJsonAsync<DienstAntwort<List<Kategorie>>>()).Daten;
            await GeheZurAlleKategorienAsync();
            BeiÄnderung.Invoke();
        }
    }
}
