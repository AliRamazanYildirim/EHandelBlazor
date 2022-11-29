namespace EHandelBlazor.Server.Dienste.BestellungDienst
{
    public interface IBestellungDienst
    {
        Task<DienstAntwort<bool>> BestellungAufgebenAsync(int benutzerID);
        Task<DienstAntwort<List<BestellÜbersichtDüo>>> GeheZurBestellungenAsync();
        Task<DienstAntwort<BestellDetailsDüo>> GeheZurBestellDetailsAsync(int bestellID);
    }
}
