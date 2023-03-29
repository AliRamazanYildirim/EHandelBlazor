using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class ProduktVariante
    {
        [JsonIgnore]
        public Produkt Produkt { get; set; }
        public int ProduktID { get; set; }
        public ProduktArt ProduktArt { get; set; }
        public int ProduktArtID { get; set; }
        public decimal Preis { get; set; }
        public decimal OriginalPreis { get; set; }
        public bool Sichtbar { get; set; } = true;
        public bool Gelöscht { get; set; } = false;
        public bool Bearbeitung { get; set; } = false;
        public bool IstNeu { get; set; } = false;
    }
}
