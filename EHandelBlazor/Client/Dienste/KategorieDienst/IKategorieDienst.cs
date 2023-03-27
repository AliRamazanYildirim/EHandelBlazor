namespace EHandelBlazor.Client.Dienste.KategorieDienst
{
    public interface IKategorieDienst
    {
        event Action BeiÄnderung;
        List<Kategorie> Kategorien { get; set; }
        List<Kategorie> AdminKategorien { get; set; }
        Task GeheZurAlleKategorienAsync();
        Task GeheZurAdminKategorienAsync();
        Task HinzufügenKategorieAsync(Kategorie kategorie);
        Task AktualisierenKategorieAsync(Kategorie kategorie);
        Task LöschenKategorieAsync(int kategorieID);
        Kategorie ErstelleNeueKategorie();




    }
}
