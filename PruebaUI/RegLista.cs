using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaUI
{
    [Serializable]
    public class Registro
    {
        
        //los que uso para graficar
        public DateTime _fecha { get; set; }
        public double _DosisCentral { get; set; }
        public double _PlanicidadX { get; set; }
        public double _SimetriaX { get; set; }
        public double _TamCampoXNominal { get; set; }
        public double _TamCampoXMed { get; set; }
        public double _TamCampoXDif { get; set; }
        public double _PlanicidadY { get; set; }
        public double _SimetriaY { get; set; }
        public double _TamCampoYNominal { get; set; }
        public double _TamCampoYMed { get; set; }
        public double _TamCampoYDif { get; set; }
        public double _Gantry { get; set; }
        public double _Colimador { get; set; }
        
        
        
        
    }
}
