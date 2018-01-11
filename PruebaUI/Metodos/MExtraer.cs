using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Statistics;


namespace PruebaUI.Metodos
{
    static class MExtraer
    {
        public static double extraerlinea(string[] fid, int linea)
        {
            string aux = fid[linea]; string[] aux2 = aux.Split('='); double salida = Convert.ToDouble(aux2[1]);
            return salida;
        }
        public static double[] extraercolumnaD(string[] reg, int columna)
        {
            double[] Columna = new double[reg.Length-1];
            for (int i=1; i < reg.Length; i++)
            {
                string aux = reg[i]; string[] aux2 = aux.Split(','); Columna[i - 1] = Convert.ToDouble(aux2[columna]);
            }
            return Columna;
        }

        public static string[] extraercolumnaS(string[] reg, int columna)
        {
            string[] Columna = new string[reg.Length-1];
            for (int i = 1; i < reg.Length; i++)
            {
                string aux = reg[i]; string[] aux2 = aux.Split(','); Columna[i - 1] = aux2[columna];
            }
            return Columna;
        }

        public static DateTime[] extraercolumnaDT(string[] reg, int columna)
        {
            DateTime[] Columna = new DateTime[reg.Length - 1];
            for (int i = 1; i < reg.Length; i++)
            {
                string aux = reg[i]; string[] aux2 = aux.Split(','); Columna[i - 1] = Convert.ToDateTime(aux2[columna], System.Globalization.CultureInfo.InvariantCulture);
            }
            return Columna;
        }

        public static string extraerstring(string[] fid, int linea)
        {
            string aux = fid[linea]; string[] aux2 = aux.Split('='); string salida = aux2[1];
            return salida;
        }
        public static Matrix<double> extraermatriz(string[] fid, int lineaI, int lineaF, int Tam1, int Tam2)
        {
            double[,] M = new double[Tam1, Tam2];
            for (int i = 0; i < Tam2; i++)
            {
                double[] aux1 = Array.ConvertAll(fid[lineaI + i].Split('\t'), new Converter<string, double>(Double.Parse));
                for (int j = 0; j < Tam1; j++)
                {
                    M[j, i] = aux1[j];
                }
            }
            Matrix<double> m = Matrix<double>.Build.DenseOfArray(M); //convierto a matriz de Mathdotnet
            return m;
        }
        
        
        
    }
}
