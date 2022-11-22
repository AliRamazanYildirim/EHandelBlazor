using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class DienstAntwort<T>
    {
        public T? Daten { get; set; }
        public bool Erfolg { get; set; } = true;
        public string Nachricht { get; set; } = string.Empty;
    }
}
