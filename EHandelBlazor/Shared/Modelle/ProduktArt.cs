﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Modelle
{
    public class ProduktArt
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Bearbeitung { get; set; } = false;
        public bool IstNeu { get; set; } = false;

    }
}
