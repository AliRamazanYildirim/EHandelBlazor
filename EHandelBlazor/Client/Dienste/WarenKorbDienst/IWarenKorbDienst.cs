using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Client.Dienste.WarenKorbDienst
{
    public interface IWarenKorbDienst
    {
        event Action BeiÄnderung;
        Task InWarenKorbLegen(WarenKorbArtikel warenKorbArtikel);
        Task<List<WarenKorbArtikel>> GeheZurWarenKorbArtikelAsync();
        Task<List<AntwortDesWarenKorbProduktes>> GeheZurWarenKorbProdukteAsync();
        Task EntfernenProduktAusWarenKorbAsync(int produktID, int produktArtID);
        Task MengeAktualisierenAsync(AntwortDesWarenKorbProduktes produkt);
        Task WarenKorbArtikelSpeichernAsync(bool leerWarenKorb);

    }
}
