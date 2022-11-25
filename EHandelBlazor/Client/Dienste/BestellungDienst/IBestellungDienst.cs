namespace EHandelBlazor.Client.Dienste.BestellungDienst
{
    public interface IBestellungDienst
    {
        Task BestellungAufgebenAsync();
        Task<List<BestellÜbersichtDüo>> GeheZurBestellungenAsync();
        Task<BestellDetailsDüo> GeheZurBestellDetailsAsync(int bestellID);
    }
}
