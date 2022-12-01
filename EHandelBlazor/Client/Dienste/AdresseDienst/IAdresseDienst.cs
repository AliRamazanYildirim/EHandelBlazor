namespace EHandelBlazor.Client.Dienste.AdresseDienst
{
    public interface IAdresseDienst
    {
        Task<Adresse> GeheZurAdresseAsync();
        Task<Adresse> AdresseAktualisierenOderAddierenAsync(Adresse adresse);

    }
}
