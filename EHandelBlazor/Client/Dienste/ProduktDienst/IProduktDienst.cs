namespace EHandelBlazor.Client.Dienste.ProduktDienst
{
    public interface IProduktDienst
    {
        event Action ProdukteGeändert;
        string Nachricht { get; set; }
        int AktuelleSeite { get; set; }
        int SeitenZahl { get; set; }
        string LetzterSuchText { get; set; }
        List<Produkt> Produkte { get; set; }
        List<Produkt> AdminProdukte { get; set; }
        Task SucheProdukteAsync(string suchText,int seite);
        Task<List<string>> GeheAnregungenZurProduktSucheAsync(string suchText);
        Task GeheZurProdukteAsync(string? kategorieUrl = null);
        Task<DienstAntwort<Produkt>> GeheZumProduktAsync(int produktID);
        Task GeheZurAdminProdukteAsync();
    }
}
