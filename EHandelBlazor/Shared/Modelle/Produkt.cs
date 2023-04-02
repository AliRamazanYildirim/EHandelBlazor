namespace EHandelBlazor.Shared.Modelle
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Bezeichnung { get; set; } = string.Empty;
        public string BildUrl { get; set; } = string.Empty;
        public List<Bild> Bilder { get; set; } = new List<Bild>();
        public int KategorieID { get; set; }
        public bool Vorgestellt { get; set; } = false;
        public Kategorie? Kategorie { get; set; }
        public List<ProduktVariante> ProduktVarianten { get; set; } = new List<ProduktVariante>();
        public bool Sichtbar { get; set; } = true;
        public bool Gelöscht { get; set; } = false;
        public bool Bearbeitung { get; set; } = false;
        public bool IstNeu { get; set; } = false;
    }
}
