using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class BenutzerRegistrieren
    {
        public string Email { get; set; } = string.Empty;
        public string Passwort { get; set; } = string.Empty;
        public string PasswortBestätigen { get; set; } = string.Empty;

    }
}
