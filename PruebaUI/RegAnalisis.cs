using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaUI
{
    [Serializable]
    public class RegAnalisis
    {
        public string variable { get; set; }
        public double LineaBase { get; set; }
        public double promedio { get; set; }
        public double maximo { get; set; }
        public string fecha_max { get; set; }
        public double minimo { get; set; }
        public string fecha_min { get; set; }
    }
}
