namespace EHandelBlazor.Server.Dienste.ProduktArtDienst
{
    public interface IProduktArtDienst
    {
        Task<DienstAntwort<List<ProduktArt>>> GeheZurAlleProduktArtenAsync();
    }
}
