using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class ResultatProduktSuche
    {
        public int Seiten { get; set; }
        public int AktuelleSeite { get; set; }
        public List<Produkt> Produkte { get; set; } = new List<Produkt>();
    }
}
