namespace EHandelBlazor.Server.Dienste.AdresseDienst
{
    public interface IAdresseDienst
    {
        Task<DienstAntwort<Adresse>> GeheZurAdresseAsync();
        Task<DienstAntwort<Adresse>> AdresseAktualisierenOderAddierenAsync(Adresse adresse);

    }
}
