namespace EHandelBlazor.Server.Dienste.KategorieDienst
{
    public class KategorieDienst : IKategorieDienst
    {
        private readonly DatenKontext _kontext;

        public KategorieDienst(DatenKontext kontext)
        {
            _kontext = kontext;
        }
        public async Task<DienstAntwort<List<Kategorie>>> GeheZurAlleKategorienAsync()
        {
            var kategorien = await _kontext.Kategorien.ToListAsync();
            return new DienstAntwort<List<Kategorie>>
            {
                Daten = kategorien
            };
        }
    }
}
