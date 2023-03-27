namespace EHandelBlazor.Server.Dienste.KategorieDienst
{
    public class KategorieDienst : IKategorieDienst
    {
        private readonly DatenKontext _kontext;

        public KategorieDienst(DatenKontext kontext)
        {
            _kontext = kontext;
        }

        public async Task<DienstAntwort<List<Kategorie>>> AktualisierenKategorieAsync(Kategorie kategorie)
        {
            var dbKategorie = await GeheZurKategorieNachID(kategorie.ID);
            if(dbKategorie==null)
            {
                return new DienstAntwort<List<Kategorie>>
                {
                    Erfolg = false,
                    Nachricht = "Kategorie wurde nicht gefunden."
                };
            }
            dbKategorie.Name = kategorie.Name;
            dbKategorie.Url = kategorie.Url;
            dbKategorie.Sichtbar = kategorie.Sichtbar;

            await _kontext.SaveChangesAsync();

            return await GeheZurAdminKategorienAsync();
        }

        public async Task<DienstAntwort<List<Kategorie>>> GeheZurAdminKategorienAsync()
        {
            var kategorien = await _kontext.Kategorien.Where(k => k.Gelöscht).ToListAsync();
            return new DienstAntwort<List<Kategorie>>
            {
                Daten = kategorien
            };
        }

        public async Task<DienstAntwort<List<Kategorie>>> GeheZurAlleKategorienAsync()
        {
            var kategorien = await _kontext.Kategorien.Where(k => !k.Gelöscht && k.IstNeu).ToListAsync();
            return new DienstAntwort<List<Kategorie>>
            {
                Daten = kategorien
            };
        }

        public async Task<DienstAntwort<List<Kategorie>>> HinzufügenKategorieAsync(Kategorie kategorie)
        {
            kategorie.Bearbeitung = kategorie.IstNeu = false;
            _kontext.Kategorien.Add(kategorie);
            await _kontext.SaveChangesAsync();
            return await GeheZurAdminKategorienAsync();
        }

        public async Task<DienstAntwort<List<Kategorie>>> LöschenKategorieAsync(int ID)
        {
            Kategorie kategorie = await GeheZurKategorieNachID(ID);
            if(kategorie==null)
            {
                return new DienstAntwort<List<Kategorie>>
                {
                    Erfolg = false,
                    Nachricht = "Kategorie wurde nicht gefunden."
                };
                
            }
            kategorie.Gelöscht = true;
            await _kontext.SaveChangesAsync();

            return await GeheZurAdminKategorienAsync();
        }

        private async Task<Kategorie> GeheZurKategorieNachID(int ID)
        {
            return await _kontext.Kategorien.FirstOrDefaultAsync(k => k.ID == ID);
        }
    }
}
