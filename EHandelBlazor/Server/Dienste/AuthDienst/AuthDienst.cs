using System.Security.Cryptography;

namespace EHandelBlazor.Server.Dienste.AuthDienst
{
    public class AuthDienst : IAuthDienst
    {
        private readonly DatenKontext _kontext;

        public AuthDienst(DatenKontext kontext)
        {
            _kontext = kontext;
        }

        public async Task<bool> BenutzerExistiertAsync(string email)
        {
            if(await _kontext.Benutzer.AnyAsync(benutzer=>benutzer.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }
        private void ErstellenPasswortHash(string passwort, out byte[] passwortHash, out byte[] passwortSalz) 
        {
            using(var hashHersteller=new HMACSHA512())
            {
                passwortSalz = hashHersteller.Key;
                passwortHash = hashHersteller.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwort));
            }
        }

        public async Task<DienstAntwort<int>> RegistrierenAsync(Benutzer benutzer, string passwort)
        {
            if(await BenutzerExistiertAsync(benutzer.Email))
            {
                return new DienstAntwort<int> 
                {
                    Erfolg = false, 
                    Nachricht = "Benutzer existiert bereits." 
                };
            }
            ErstellenPasswortHash(passwort, out byte[] passwortHash, out byte[] passwortSalz);
            benutzer.PasswortHash = passwortHash;
            benutzer.PasswortSalz = passwortSalz;

            _kontext.Benutzer.Add(benutzer);
            await _kontext.SaveChangesAsync();

            return new DienstAntwort<int>
            {
                Daten = benutzer.ID,
                Nachricht= "Die Registrierung ist erfolgreich :)"
            };
        }
    }
}
