using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Düoe
{
    public  class BestellÜbersichtDüo
    {
        public int ID { get; set; }
        public DateTime Bestelldatum { get; set; }
        public decimal GesamtPreis { get; set; }
        public string Produkt { get; set; }
        public string ProduktBildUrl { get; set; }
    }
}
