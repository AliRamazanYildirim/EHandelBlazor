using Microsoft.EntityFrameworkCore;

namespace EHandelBlazor.Server.Dienste.ProduktDienst
{
    public class ProduktDienst : IProduktDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProduktDienst(DatenKontext kontext, IHttpContextAccessor httpContextAccessor)
        {
            _kontext = kontext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DienstAntwort<Produkt>> AktualisiereProduktAsync(Produkt produkt)
        {
            var dbProdukt = await _kontext.Produkte.FindAsync(produkt.ID);
            if (dbProdukt == null)
            {
                return new DienstAntwort<Produkt>
                {
                    Erfolg = false,
                    Nachricht = "Das Produkt wurde nicht gefunden"
                };
            }
            dbProdukt.Title = produkt.Title;
            dbProdukt.Bezeichnung = produkt.Bezeichnung;
            dbProdukt.BildUrl = produkt.BildUrl;
            dbProdukt.KategorieID = produkt.KategorieID;
            dbProdukt.Sichtbar = produkt.Sichtbar;
            dbProdukt.Vorgestellt = produkt.Vorgestellt;

            foreach(var variante in produkt.ProduktVarianten)
            {
                var dbVariante = await _kontext.ProduktVarianten.SingleOrDefaultAsync(v => v.ProduktID == variante.ProduktID
                && v.ProduktArtID == variante.ProduktArtID);
                if(dbVariante==null)
                {
                    variante.ProduktArt = null;
                    _kontext.ProduktVarianten.Add(variante);
                }
                else
                {
                    dbVariante.ProduktArtID = variante.ProduktArtID;
                    dbVariante.Preis = variante.Preis;
                    dbVariante.OriginalPreis = variante.OriginalPreis;
                    dbVariante.Sichtbar = variante.Sichtbar;
                    dbVariante.Gelöscht = variante.Gelöscht;

                }
            }
            await _kontext.SaveChangesAsync();
            return new DienstAntwort<Produkt>
            {
                Daten = produkt
            };
        }

        public async Task<DienstAntwort<Produkt>> ErstelleProduktAsync(Produkt produkt)
        {
            foreach(var variante in produkt.ProduktVarianten)
            {
                variante.ProduktArt = null;
            }
            _kontext.Produkte.Add(produkt);
            await _kontext.SaveChangesAsync();
            return new DienstAntwort<Produkt>
            {
                Daten = produkt
            };
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
            Produkt produkt = null;
            if(_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                produkt = await _kontext.Produkte.Include(p => p.ProduktVarianten.Where(pv => !pv.Gelöscht))
                .ThenInclude(v => v.ProduktArt)
                .FirstOrDefaultAsync(p => p.ID == produktID && !p.Gelöscht);
            }
            else
            {
                produkt = await _kontext.Produkte.Include(p => p.ProduktVarianten.Where(pv => pv.Sichtbar && !pv.Gelöscht))
                .ThenInclude(v => v.ProduktArt)
                .FirstOrDefaultAsync(p => p.ID == produktID && !p.Gelöscht && p.Sichtbar);
            }
            
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

        public async Task<DienstAntwort<List<Produkt>>> GeheZurAdminProdukteAsync()
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Where(p => !p.Gelöscht)
               .Include(p => p.ProduktVarianten.Where(v => !v.Gelöscht))
               .ThenInclude(v => v.ProduktArt).ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<List<Produkt>>> GeheZurProdukteAsync()
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Where(p => p.Sichtbar && !p.Gelöscht)
                .Include(p => p.ProduktVarianten.Where(v => v.Sichtbar && !v.Gelöscht)).ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<List<Produkt>>> GeheZurProdukteNachKategorieAsync(string kategorieUrl)
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Where(p => p.Kategorie.Url.ToLower().Equals(kategorieUrl.ToLower())
                && p.Sichtbar && !p.Gelöscht).Include(p => p.ProduktVarianten.Where(v => v.Sichtbar && !v.Gelöscht))
                .ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<List<Produkt>>> GeheZurVorgestellteProdukteAsync()
        {
            var antwort = new DienstAntwort<List<Produkt>>
            {
                Daten = await _kontext.Produkte.Where(p => p.Vorgestellt && p.Sichtbar && !p.Gelöscht)
                .Include(p => p.ProduktVarianten.Where(v => v.Sichtbar && !v.Gelöscht)).ToListAsync()
            };
            return antwort;
        }

        public async Task<DienstAntwort<bool>> LöscheProduktAsync(int produktID)
        {
            var dbProdukt = await _kontext.Produkte.FindAsync(produktID);
            if(dbProdukt==null)
            {
                return new DienstAntwort<bool>
                {
                    Erfolg = false,
                    Daten = false,
                    Nachricht = "Das Produkt wurde nicht gefunden"
                };
            }
            dbProdukt.Gelöscht = true;
            await _kontext.SaveChangesAsync();
            return new DienstAntwort<bool>
            {
                Daten = true
            };
        }

        public async Task<DienstAntwort<ResultatProduktSuche>> SucheProdukteAsync(string suchText, int seite)
        {
            var seiteResultate = 2f;
            var seitenZahl = Math.Ceiling((await FindeProdukteNachSuchTextAsync(suchText)).Count / seiteResultate);
            var produkte = await _kontext.Produkte.Where(p => p.Title.ToLower().Contains(suchText.ToLower()) ||
                            p.Bezeichnung.ToLower().Contains(suchText.ToLower()) && p.Sichtbar && !p.Gelöscht)
                            .Include(p => p.ProduktVarianten).Skip((seite - 1) * (int)seiteResultate)
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
                            || p.Bezeichnung.ToLower().Contains(suchText.ToLower()) && p.Sichtbar && !p.Gelöscht)
                .Include(p => p.ProduktVarianten).ToListAsync();
        }
    }
}
