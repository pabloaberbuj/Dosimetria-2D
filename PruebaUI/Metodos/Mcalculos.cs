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
    class MCalculos
    {
        public static double dosiscentral(Matrix<double> m, int Tam1, int Tam2, int TamROI)
        {
            double DosisCentral = Math.Round(m.SubMatrix(Tam1 / 2 - TamROI / 2, TamROI, Tam2 / 2 - TamROI, TamROI).Enumerate().Mean(), 2);
            //MessageBox.Show(Convert.ToString(DosisCentral));
            return DosisCentral;
        }

        public static Vector<double> redondearvector(Vector<double> entrada)
        {
            Vector<double> salida = Vector<double>.Build.Dense(entrada.Count());
            for (int i = 0; i < entrada.Count(); i++)
            {
                salida[i] = Math.Round(entrada[i], 2);
            }
            return salida;
        }

        public static Vector<double> eje(double C, double Tam, double Res)
        {
            Vector<double> aux = Vector<double>.Build.Dense(Convert.ToInt32(C * 1.4 / Res) + 1, i => -C * .7 + i * Res);
            Vector<double> Eje = redondearvector(aux);
            return Eje;
        }
        public static Vector<double> perfilX(Matrix<double> m, int Tam1, int Tam2, double Res, double C, double DosisCentral, double ancho, int AnchoPerfil) //promedia sobre una franja de ancho = AnchoPerfil
        {
            Vector<double> aux = (m.SubMatrix(Convert.ToInt32(Tam1 / 2 - ancho / 2 * C / Res), Convert.ToInt32(ancho * C / Res) + 1, Tam2 / 2 - AnchoPerfil / 2, AnchoPerfil) / DosisCentral * 100).RowSums() / AnchoPerfil;
            Vector<double> PerfilX = redondearvector(aux);
            return PerfilX;
        }
        public static Vector<double> perfilY(Matrix<double> m, int Tam1, int Tam2, double Res, double C, double DosisCentral, double ancho, int AnchoPerfil) //promedia sobre una franja de ancho = AnchoPerfil
        {
            Vector<double> aux = (m.SubMatrix(Tam1 / 2 - AnchoPerfil / 2, AnchoPerfil, Convert.ToInt32(Tam2 / 2 - ancho / 2 * C / Res), Convert.ToInt32(ancho * C / Res) + 1) / DosisCentral * 100).ColumnSums() / AnchoPerfil;
            Vector<double> PerfilY = redondearvector(aux);
            return PerfilY;
        }
        public static Tuple<double, double> coinc50(Vector<double> Perfil, Vector<double> Eje)
        {
            var aux = Enumerable.Range(0, Perfil.Count).Where(i => Perfil[i] > 50);
            return new Tuple<double, double>(Eje[aux.Min()], Eje[aux.Max()]);
        }
        public static double planicidad(Vector<double> perfil80)
        {
            return Math.Round(((perfil80.Max() - perfil80.Min()) / (perfil80.Max() + perfil80.Min()) * 100), 2);
        }
        public static double simetria(Vector<double> perfil80)
        {
            double aux = perfil80.Count / 2;
            int mitadf = Convert.ToInt32(Math.Floor(aux)); int mitadc = Convert.ToInt32(Math.Ceiling(aux));
            Vector<double> area1 = Vector<double>.Build.Dense(mitadf);
            Vector<double> area2 = Vector<double>.Build.Dense(mitadf);
            perfil80.CopySubVectorTo(area1, 0, 0, mitadf - 1);
            perfil80.CopySubVectorTo(area2, mitadc, 0, area1.Count);
            return Math.Round(((area1.Sum() - area2.Sum()) / (area1.Sum() + area2.Sum()) * 100), 2);
        }

    }
}
