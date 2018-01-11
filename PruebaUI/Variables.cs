using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;

namespace PruebaUI
{
    public class Variables
    {
        //direcciones
        public string pathLB = (Convert.ToString(Directory.GetCurrentDirectory()) + @"\LB.txt");
        public string pathTol = (Convert.ToString(Directory.GetCurrentDirectory()) + @"\Tolerancia.txt");
        public string pathReg = (Convert.ToString(Directory.GetCurrentDirectory()) + @"\Registro.txt");
        public string pathConfig = (Convert.ToString(Directory.GetCurrentDirectory()) + @"\Config.txt");

        //variables
        public string[] fid, LBs,Tols,Config;
        public double[] LB, DifLB, Tol;
        public string Registro;
        public int Tam1, Tam2, TamROI, AnchoPerfil;
        public double Res1, Res2, Gantry, Colimador, ColX1, ColX2, ColY1, ColY2, CX, CY, DosisCentral, TamX, TamY, PlanicidadX, PlanicidadY, SimetriaX, SimetriaY;
        public Vector<double> EjeX, EjeY, PerfilX, PerfilY, PerfilX80, PerfilY80;
        public Matrix<double> m;
        public Tuple<double, double> Coinc50X, Coinc50Y;
        public bool seaplico;
        public int contadorticks;
        public DateTime fecha;

        //registro
        public string[] Regs, RegFecha;
        public double[] Reg, RegdFecha, RegDosisCentral, RegPlanicidadX, RegSimetriaX, RegTamX, RegPlanicidadY, RegSimetriaY, RegTamY;
        public DateTime[] RegDTFecha;
        public double[][] RegVariables;

    }
}
