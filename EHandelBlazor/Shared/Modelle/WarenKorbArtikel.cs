using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class WarenKorbArtikel
    {
        public int ProduktID { get; set; }
        public int ProduktArtID { get; set; }
        public int Menge { get; set; } = 1;
    }
}
