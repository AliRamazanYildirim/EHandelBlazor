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

        public Task<DienstAntwort<int>> RegistrierenAsync(Benutzer benutzer, string passwort)
        {
            throw new NotImplementedException();
        }
    }
}
