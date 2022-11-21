namespace EHandelBlazor.Server.Dienste.AuthDienst
{
    public interface IAuthDienst
    {
        Task<DienstAntwort<int>> RegistrierenAsync(Benutzer benutzer, string passwort);
        Task<bool> BenutzerExistiertAsync(string email);
        Task<DienstAntwort<string>> AnmeldungAsync(string email, string passwort);
    }
}
