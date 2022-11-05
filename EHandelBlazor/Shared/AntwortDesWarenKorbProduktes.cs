using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared
{
    public class AntwortDesWarenKorbProduktes
    {
        public int ProduktID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProduktArtID { get; set; }
        public string ProduktArt { get; set; } = string.Empty;
        public string BildUrl { get; set; } = string.Empty;
        public decimal Preis { get; set; }
        public int Menge { get; set; }
    }
}
