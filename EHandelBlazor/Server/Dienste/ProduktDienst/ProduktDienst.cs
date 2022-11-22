using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Server.Dienste.ProduktDienst
{
    public class ProduktDienst : IProduktDienst
    {
        private readonly DatenKontext _kontext;

        public ProduktDienst(DatenKontext kontext)
        {
            _kontext = kontext;
        }

        public async Task<DienstAntwort<List<string>>> GeheAnregungenZurProduktSucheAsync(string suchText)
        {
            var produkte = await FindeProdukteNachSuchTextAsync(suchText);
            List<string> resultat = new List<string>();
            foreach (var produkt in produkte)
            {
                if(produkt.Title.Contains(suchText,StringComparison.OrdinalIgnoreCase))
                {
                    resultat.Add(produkt.Title);
                }
                if(produkt.Bezeichnung != null)
                {
                    var interpunktion = produkt.Bezeichnung.Where(char.IsPunctuation).Distinct().ToArray();
                    var wörter = produkt.Bezeichnung.Split().Select(s => s.Trim(interpunktion));
                    foreach(var wort in wörter)
                    {
                        if(wort.Contains(suchText, StringComparison.OrdinalIgnoreCase) && !resultat.Contains(wort))
                        {
                            resultat.Add(wort);
                        }
                    }
                }
            }
            return new DienstAntwort<List<string>> { Daten = resultat };
        }

        public async Task<DienstAntwort<Produkt>> GeheZumProduktAsync(int produktID)
        {
            var antwort = new DienstAntwort<Produkt>();
            var produkt = await _kontext.Produkte.Include(p => p.ProduktVarianten).ThenInclude(v => v.ProduktArt)
                .FirstOrDefaultAsync(p => p.ID == produktID);
            if(produkt == null)
            {
                antwort.Erfolg = false;
                antwort.Nachricht = "Entschuldigung, aber dieses Produkt existiert nicht.";
            }
            else
            {
                antwort.Daten = produkt;
            }
            return antwort;
        }

        public async Task<DienstAntwort<List<Produkt>>> GeheZurProdukteAsync()
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Include(p=>p.ProduktVarianten).ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<List<Produkt>>> GeheZurProdukteNachKategorieAsync(string kategorieUrl)
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Where(p => p.Kategorie.Url.ToLower().Equals(kategorieUrl.ToLower())).
                Include(p=>p.ProduktVarianten).ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<List<Produkt>>> GeheZurVorgestellteProdukteAsync()
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Where(p => p.Vorgestellt).Include(p => p.ProduktVarianten).ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<ResultatProduktSuche>> SucheProdukteAsync(string suchText, int seite)
        {
            var seiteResultate = 2f;
            var seitenZahl = Math.Ceiling((await FindeProdukteNachSuchTextAsync(suchText)).Count / seiteResultate);
            var produkte = await _kontext.Produkte.Where(p => p.Title.ToLower().Contains(suchText.ToLower())
                            ||
                            p.Bezeichnung.ToLower().Contains(suchText.ToLower())).Include(p => p.ProduktVarianten)
                            .Skip((seite - 1) * (int)seiteResultate)
                            .Take((int)seiteResultate).ToListAsync();
            var antwort = new DienstAntwort<ResultatProduktSuche>
            {
                Daten = new ResultatProduktSuche
                {
                    Produkte = produkte,
                    AktuelleSeite = seite,
                    Seiten = (int)seitenZahl
                }
            };
            return antwort;
        }

        private async Task<List<Produkt>> FindeProdukteNachSuchTextAsync(string suchText)
        {
            return await _kontext.Produkte.Where(p => p.Title.ToLower().Contains(suchText.ToLower())
                            || p.Bezeichnung.ToLower().Contains(suchText.ToLower())).Include(p => p.ProduktVarianten).ToListAsync();
        }
    }
}
