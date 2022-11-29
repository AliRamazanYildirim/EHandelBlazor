namespace EHandelBlazor.Server.Dienste.AuthDienst
{
    public interface IAuthDienst
    {
        Task<DienstAntwort<int>> RegistrierenAsync(Benutzer benutzer, string passwort);
        Task<bool> BenutzerExistiertAsync(string email);
        Task<DienstAntwort<string>> AnmeldungAsync(string email, string passwort);
        Task<DienstAntwort<bool>> PasswortÄndernAsync(int benutzerID, string neuesPasswort);
        int GeheZurBenutzerID();
        string GeheZurBenutzerEmail();
        Task<Benutzer> GeheZurBenutzerNachEmailAsync(string email);
    }
}
