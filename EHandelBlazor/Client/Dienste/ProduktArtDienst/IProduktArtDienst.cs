namespace EHandelBlazor.Client.Dienste.ProduktArtDienst
{
    public interface IProduktArtDienst
    {
        event Action BeiÄnderung;
        public List<ProduktArt> ProduktArten { get; set; }
        Task GeheZurAlleProduktArten();
        Task ErstelleProduktArt(ProduktArt produktArt);
        Task AktualisiereProduktArt(ProduktArt produktArt);
        ProduktArt ErstelleNeueProduktArt();

    }
}
