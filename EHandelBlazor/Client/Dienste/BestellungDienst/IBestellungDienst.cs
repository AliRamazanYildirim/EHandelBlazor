namespace EHandelBlazor.Client.Dienste.BestellungDienst
{
    public interface IBestellungDienst
    {
        Task<string> BestellungAufgebenAsync();
        Task<List<BestellÜbersichtDüo>> GeheZurBestellungenAsync();
        Task<BestellDetailsDüo> GeheZurBestellDetailsAsync(int bestellID);
    }
}
