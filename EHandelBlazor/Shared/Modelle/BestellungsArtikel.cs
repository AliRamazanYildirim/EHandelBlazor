using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class BestellungsArtikel
    {
        public Bestellung Bestellung { get; set; }
        public int BestellungID { get; set; }
        public Produkt Produkt { get; set; }
        public int ProduktID { get; set; }
        public ProduktArt ProduktArt { get; set; }
        public int ProduktArtID { get; set; }
        public int Menge { get; set; }
        public decimal GesamtPreis { get; set; }
    }
}
