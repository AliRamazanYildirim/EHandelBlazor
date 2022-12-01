using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class Adresse
    {
        public int ID { get; set; }
        public int BenutzerID { get; set; }
        public string VorName { get; set; } = string.Empty;
        public string NachName { get; set; } = string.Empty;

        public string Straße { get; set; } = string.Empty;

        public string Stadt { get; set; } = string.Empty;

        public string Staat { get; set; } = string.Empty;

        public string PostleitZahl { get; set; } = string.Empty;

        public string Land { get; set; } = string.Empty;


    }
}
