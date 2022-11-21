namespace EHandelBlazor.Client.Dienste.AuthDienst
{
    public interface IAuthDienst
    {
        Task<DienstAntwort<int>> RegistrierungAsync(BenutzerRegistrieren anfrage);
        Task<DienstAntwort<string>> AnmeldungAsync(BenutzerAnmeldung anfrage);
    }
}
