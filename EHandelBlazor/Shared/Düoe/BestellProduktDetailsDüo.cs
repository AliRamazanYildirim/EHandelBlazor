using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Düoe
{
    public class BestellProduktDetailsDüo
    {
        public int ProduktID { get; set; }
        public string Title { get; set; }
        public string ProduktArt { get; set; }
        public string BildUrl { get; set; }
        public int Menge { get; set; }
        public decimal GesamtPreis { get; set; }

    }
}
