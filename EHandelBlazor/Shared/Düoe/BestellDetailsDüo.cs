using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Düoe
{
    public class BestellDetailsDüo
    {
        public DateTime BestellDatum { get; set; }
        public decimal GesamtPreis { get; set; }
        public List<BestellProduktDetailsDüo> Produkte { get; set; }

    }
}
