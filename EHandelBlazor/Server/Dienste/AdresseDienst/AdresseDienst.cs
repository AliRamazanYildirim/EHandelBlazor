namespace EHandelBlazor.Server.Dienste.AdresseDienst
{
    public class AdresseDienst : IAdresseDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IAuthDienst _authDienst;

        public AdresseDienst(DatenKontext kontext,IAuthDienst authDienst)
        {
            _kontext = kontext;
            _authDienst = authDienst;
        }
        public async Task<DienstAntwort<Adresse>> AdresseAktualisierenOderAddierenAsync(Adresse adresse)
        {
            var antwort = new DienstAntwort<Adresse>();
            var dbAdresse = (await GeheZurAdresseAsync()).Daten;
            if(dbAdresse == null)
            {
                adresse.BenutzerID = _authDienst.GeheZurBenutzerID();
                _kontext.Adressen.Add(adresse);
                antwort.Daten = adresse;
            }
            else
            {
                dbAdresse.VorName = adresse.VorName;
                dbAdresse.NachName = adresse.NachName;
                dbAdresse.Straße = adresse.Straße;
                dbAdresse.Land = adresse.Land;
                dbAdresse.Stadt= adresse.Stadt;
                dbAdresse.Staat = adresse.Staat;
                dbAdresse.PostleitZahl = adresse.PostleitZahl;
            }
            await _kontext.SaveChangesAsync();
            return antwort;
        }

        public async Task<DienstAntwort<Adresse>> GeheZurAdresseAsync()
        {
            int benutzerID = _authDienst.GeheZurBenutzerID();
            var adresse = await _kontext.Adressen.FirstOrDefaultAsync(a => a.BenutzerID == benutzerID);
            return new DienstAntwort<Adresse>
            {
                Daten = adresse
            };
        }
    }
}
