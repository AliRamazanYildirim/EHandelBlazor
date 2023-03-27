using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class Kategorie
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool Sichtbar { get; set; } = true;
        public bool Gelöscht { get; set; } = false;
        public bool Bearbeitung { get; set; } = false;
        public bool IstNeu { get; set; } = false;


    }
}
