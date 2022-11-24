namespace EHandelBlazor.Server.Dienste.BestellungDienst
{
    public interface IBestellungDienst
    {
        Task<DienstAntwort<bool>> BestellungAufgebenAsync();
        Task<DienstAntwort<List<BestellÜbersichtDüo>>> GeheZurBestellungenAsync();
    }
}
