using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Client.Dienste.KategorieDienst
{
    public interface IKategorieDienst
    {
        List<Kategorie> Kategorien { get; set; }
        Task GeheZurAlleKategorienAsync();
    }
}
