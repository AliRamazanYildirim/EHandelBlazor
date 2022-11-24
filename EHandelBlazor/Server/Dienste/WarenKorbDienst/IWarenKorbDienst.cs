namespace EHandelBlazor.Server.Dienste.WarenKorbDienst
{
    public interface IWarenKorbDienst
    {
        Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> GeheZurAntwortDerWarenKorbProdukteAsync(List<WarenKorbArtikel> warenKorbArtikel);
        Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> WarenKorbArtikelSpeichernAsync(List<WarenKorbArtikel> warenKorbArtikel);
        Task<DienstAntwort<int>> GeheZurWarenKorbArtikelAnzahlAsync();
        Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> GeheZurDbWarenKorbProdukteAsync();
        Task<DienstAntwort<bool>> InWarenKorbLegenAsync(WarenKorbArtikel warenKorbArtikel);
        Task<DienstAntwort<bool>> MengeAktualisierenAsync(WarenKorbArtikel warenKorbArtikel);
        Task<DienstAntwort<bool>> ArtikelAusWarenKorbEntfernenAsync(int produktID, int produktArtID);
    }
}
