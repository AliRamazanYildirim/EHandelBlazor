using EHandelBlazor.Shared.Modelle;

namespace EHandelBlazor.Server.Dienste.WarenKorbDienst
{
    public interface IWarenKorbDienst
    {
        Task<DienstAntwort<List<AntwortDesWarenKorbProduktes>>> GeheZurAntwortDerWarenKorbProdukteAsync(List<WarenKorbArtikel> warenKorbArtikel);

     
    }
}
