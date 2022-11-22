using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Client.Dienste.ProduktDienst
{
    public interface IProduktDienst
    {
        event Action ProdukteGeändert;
        List<Produkt> Produkte { get; set; }
        Task GeheZurProdukteAsync(string? kategorieUrl = null);
        Task<DienstAntwort<Produkt>> GeheZumProduktAsync(int produktID);
        string Nachricht { get; set; }
        int AktuelleSeite { get; set; }
        int SeitenZahl { get; set; }
        string LetzterSuchText { get; set; }
        Task SucheProdukteAsync(string suchText,int seite);
        Task<List<string>> GeheAnregungenZurProduktSucheAsync(string suchText);
    }
}
