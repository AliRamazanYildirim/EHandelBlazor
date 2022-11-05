namespace EHandelBlazor.Server.Dienste.KategorieDienst
{
    public interface IKategorieDienst
    {
        Task<DienstAntwort<List<Kategorie>>> GeheZurAlleKategorienAsync();
    }
}
