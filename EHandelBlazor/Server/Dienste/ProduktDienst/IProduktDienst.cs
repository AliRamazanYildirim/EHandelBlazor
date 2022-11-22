using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Server.Dienste.ProduktDienst
{
    public interface IProduktDienst
    {
        Task<DienstAntwort<List<Produkt>>> GeheZurProdukteAsync();
        Task<DienstAntwort<Produkt>> GeheZumProduktAsync(int produktID);
        Task<DienstAntwort<List<Produkt>>> GeheZurProdukteNachKategorieAsync(string kategorieUrl);
        Task<DienstAntwort<ResultatProduktSuche>> SucheProdukteAsync(string suchText, int seite);
        Task<DienstAntwort<List<string>>> GeheAnregungenZurProduktSucheAsync(string suchText);
        Task<DienstAntwort<List<Produkt>>> GeheZurVorgestellteProdukteAsync();
    }
}
