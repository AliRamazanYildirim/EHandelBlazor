using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class Bestellung
    {
        public int ID { get; set; }
        public int BenutzerID { get; set; }
        public DateTime BestellDatum { get; set; } = DateTime.Now;
        public decimal GesamtPreis { get; set; }
        public List<BestellungsArtikel> BestellungsArtikel { get; set; }
    }
}
