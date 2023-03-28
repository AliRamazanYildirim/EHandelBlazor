namespace EHandelBlazor.Server.Dienste.ProduktArtDienst
{
    public interface IProduktArtDienst
    {
        Task<DienstAntwort<List<ProduktArt>>> GeheZurAlleProduktArtenAsync();
        Task<DienstAntwort<List<ProduktArt>>> HinzufügeProduktArtAsync(ProduktArt produktArt);
        Task<DienstAntwort<List<ProduktArt>>> AktualisiereProduktArtAsync(ProduktArt produktArt);


    }
}
