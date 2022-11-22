namespace EHandelBlazor.Shared.Modelle
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Bezeichnung { get; set; } = string.Empty;
        public string BildUrl { get; set; } = string.Empty;
        public int KategorieID { get; set; }
        public bool Vorgestellt { get; set; } = false;
        public Kategorie? Kategorie { get; set; }
        public List<ProduktVariante> ProduktVarianten { get; set; } = new List<ProduktVariante>();
    }
}
