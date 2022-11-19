namespace EHandelBlazor.Server.Dienste.AuthDienst
{
    public class AuthDienst : IAuthDienst
    {
        public Task<bool> BenutzerExistiertAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<DienstAntwort<int>> RegistrierenAsync(Benutzer benutzer, string passwort)
        {
            throw new NotImplementedException();
        }
    }
}
