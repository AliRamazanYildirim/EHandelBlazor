using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class Benutzer
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswortHash { get; set; }
        public byte[] PasswortSalz { get; set; }
        public DateTime DatumErstellt { get; set; } = DateTime.Now;
    }
}
