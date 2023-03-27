namespace EHandelBlazor.Server.Dienste.KategorieDienst
{
    public interface IKategorieDienst
    {
        Task<DienstAntwort<List<Kategorie>>> GeheZurAlleKategorienAsync();
        Task<DienstAntwort<List<Kategorie>>> GeheZurAdminKategorienAsync();
        Task<DienstAntwort<List<Kategorie>>> HinzufügenKategorieAsync(Kategorie kategorie);
        Task<DienstAntwort<List<Kategorie>>> AktualisierenKategorieAsync(Kategorie kategorie);
        Task<DienstAntwort<List<Kategorie>>> LöschenKategorieAsync(int ID);


    }
}
