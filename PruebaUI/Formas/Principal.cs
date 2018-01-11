using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;




namespace PruebaUI.Formas
{


    public partial class Principal : Form
    {
        List<Registro> regEscribir = new List<Registro>();
        Configurar cf;
        Registros rg;
        public static Variables vr = new Variables();
        public static Principal inst = null;

        NumberFormatInfo nfi = new CultureInfo("en-US",false).NumberFormat;
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargaLBTolyConfig();
            //cargar registros en Lista
            var outputJSON = File.ReadAllText(vr.pathReg);
            if (outputJSON.Length != 0)
            {
                regEscribir = JsonConvert.DeserializeObject<List<Registro>>(outputJSON);
            }
        }

        //Carga de valores de Linea Base y Tolerancia a partir de lo guardado en txt. PASAR A JSON
        public static void cargaLBTolyConfig()
        {
            vr.LBs = File.ReadAllLines(vr.pathLB);
            vr.Tols = File.ReadAllLines(vr.pathTol);
            vr.LB = new double[vr.LBs.Length];
            vr.DifLB = new double[vr.LBs.Length];
            vr.Tol = new double[vr.Tols.Length];
            
            for (int i = 0; i < 7; i++)
            {
                vr.LB[i] = Metodos.MExtraer.extraerlinea(vr.LBs, i);
                vr.Tol[i] = Metodos.MExtraer.extraerlinea(vr.Tols, i);
            }
            vr.Config = File.ReadAllLines(vr.pathConfig);
            vr.TamROI = Convert.ToInt32(Metodos.MExtraer.extraerlinea(vr.Config, 0));
            vr.AnchoPerfil = Convert.ToInt32(Metodos.MExtraer.extraerlinea(vr.Config, 1));

        }

        //Extrae valores y vectores de fid y realiza cálculos
        public void calculos(string[] fid)
        {
            vr.Tam1 = Convert.ToInt32(Metodos.MExtraer.extraerlinea(fid, 8));
            vr.Res1 = Metodos.MExtraer.extraerlinea(fid, 9) / 10; //paso a cm
            vr.Tam2 = Convert.ToInt32(Metodos.MExtraer.extraerlinea(fid, 14));
            vr.Res2 = Metodos.MExtraer.extraerlinea(fid, 15) / 10; //paso a cm
            vr.Gantry = Metodos.MExtraer.extraerlinea(fid, 38);
            vr.Colimador = Metodos.MExtraer.extraerlinea(fid, 39);
            vr.ColX1 = Metodos.MExtraer.extraerlinea(fid, 40);
            vr.ColX2 = Metodos.MExtraer.extraerlinea(fid, 41);
            vr.ColY1 = Metodos.MExtraer.extraerlinea(fid, 42);
            vr.ColY2 = Metodos.MExtraer.extraerlinea(fid, 43);
            vr.CX = -vr.ColX1 + vr.ColX2;
            vr.CY = -vr.ColY1 + vr.ColY2;
            vr.LB[3] = vr.CX; vr.LB[6] = vr.CY;
            //calculos
            string aux1 = Metodos.MExtraer.extraerstring(fid, 46); string[] aux2 = aux1.Split(','); vr.fecha = DateTime.Parse(aux1, System.Globalization.CultureInfo.InvariantCulture);
            vr.m = Metodos.MExtraer.extraermatriz(fid, 48, 48 + vr.Tam2, vr.Tam1, vr.Tam2);
            vr.DosisCentral = Metodos.MCalculos.dosiscentral(vr.m, vr.Tam1, vr.Tam2, vr.TamROI);
            vr.EjeX = Metodos.MCalculos.eje(vr.CX, vr.Tam1, vr.Res1);
            vr.EjeY = Metodos.MCalculos.eje(vr.CY, vr.Tam2, vr.Res2);
            vr.PerfilX = Metodos.MCalculos.perfilX(vr.m, vr.Tam1, vr.Tam2, vr.Res1, vr.CX, vr.DosisCentral, 1.4,vr.AnchoPerfil);
            vr.PerfilY = Metodos.MCalculos.perfilY(vr.m, vr.Tam1, vr.Tam2, vr.Res2, vr.CY, vr.DosisCentral, 1.4, vr.AnchoPerfil);
            vr.PerfilX80 = Metodos.MCalculos.perfilX(vr.m, vr.Tam1, vr.Tam2, vr.Res1, vr.CX, vr.DosisCentral, 0.8,vr.AnchoPerfil);
            vr.PerfilY80 = Metodos.MCalculos.perfilY(vr.m, vr.Tam1, vr.Tam2, vr.Res2, vr.CY, vr.DosisCentral, 0.8,vr.AnchoPerfil);
            vr.Coinc50X = Metodos.MCalculos.coinc50(vr.PerfilX, vr.EjeX);
            vr.TamX = -vr.Coinc50X.Item1 + vr.Coinc50X.Item2;
            vr.Coinc50Y = Metodos.MCalculos.coinc50(vr.PerfilY, vr.EjeY);
            vr.TamY = -vr.Coinc50Y.Item1 + vr.Coinc50Y.Item2;
            vr.PlanicidadX = Metodos.MCalculos.planicidad(vr.PerfilX80);
            vr.PlanicidadY = Metodos.MCalculos.planicidad(vr.PerfilY80);
            vr.SimetriaX = Metodos.MCalculos.simetria(vr.PerfilX80);
            vr.SimetriaY = Metodos.MCalculos.simetria(vr.PerfilY80);

            //copiar datos a lista para registro
            regEscribir.Add(new Registro()
            {
            _Colimador = vr.Colimador,
            _Gantry = vr.Gantry,
            _DosisCentral = vr.DosisCentral,
            _fecha = vr.fecha,
            _PlanicidadX = vr.PlanicidadX,
            _PlanicidadY = vr.PlanicidadY,
            _SimetriaX = vr.SimetriaX,
            _SimetriaY = vr.SimetriaY,
            _TamCampoXMed = Math.Round(vr.TamX, 2),
            _TamCampoXNominal = vr.CX,
            _TamCampoXDif = Math.Round(vr.TamX - vr.CX, 2),
            _TamCampoYMed = Math.Round(vr.TamY, 2),
            _TamCampoYNominal = vr.CY,
            _TamCampoYDif = Math.Round(vr.TamY - vr.CY, 2),
            });

            //llenar valores y carga linea base y tolerancia
            Label[] llenarposiciones = { label24, label5, label7, label9, label15, label13, label11 };
            Label[] llenarposicionesDif = { label23, label4, label6, label8, label14, label12, label10 };
            double[] llenarvalores = { vr.DosisCentral, vr.PlanicidadX, vr.SimetriaX, vr.TamX, vr.PlanicidadY, vr.SimetriaY, vr.TamY };
            string[] llenarunidades = { "CU", "%", "%", "cm", "%", "%", "cm" };
            vr.DifLB[0] = (vr.DosisCentral - vr.LB[0]) / vr.LB[0] * 100;

            for (int i = 0; i < llenarvalores.Length; i++)
            {
                vr.DifLB[i] = i == 0 ? (llenarvalores[i] - vr.LB[i]) / vr.LB[i] * 100 : llenarvalores[i] - vr.LB[i];
                vr.DifLB[i] = Math.Round(vr.DifLB[i], 2);
                llenarlabel(llenarposiciones[i], llenarvalores[i], llenarunidades[i]);
                llenarunidades[0] = "%";
                llenarlabel(llenarposicionesDif[i], vr.DifLB[i], llenarunidades[i]);
                llenarposicionesDif[i].BackColor = vr.DifLB[i] > vr.Tol[i] ? Color.OrangeRed : Color.LightGreen;
                vr.DifLB[i] = Math.Round(vr.DifLB[i], 2);
        }
            //llenar datos
            label28.Text = (vr.fecha).ToShortDateString(); label28.Visible = true;
            label18.Text = Convert.ToString(vr.Gantry); label18.Visible = true;
            label16.Text = Convert.ToString(vr.Colimador); label16.Visible = true;
            label30.Text = (Convert.ToString(vr.CX) + "x" + Convert.ToString(vr.CY)); label30.Visible = true;

            //Registro
         //   double[] llenarvaloresReg = llenarvalores; //para que registre diferencia entre tamaños de campo y no los tamaños en sí
          //  llenarvaloresReg[3] = vr.DifLB[3]; llenarvaloresReg[6] = vr.DifLB[6];
           // vr.Registro = (vr.fecha + "," + string.Join(",", llenarvaloresReg.Select(p => p.ToString()).ToArray()));

            //graficar
            Metodos.MGraficos.graficarperfil("PerfilX", "Perfil Eje X", vr.EjeX, vr.PerfilX, GraficoX, vr.TamX);
            Metodos.MGraficos.graficarperfil("PerfilY", "Perfil Eje Y", vr.EjeY, vr.PerfilY, GraficoY, vr.TamY);
                      
        }

        //carga valores en labels
        public static void llenarlabel(Label label, double valor, string unidad)
        {
            label.Text = (Convert.ToString(valor) + " " + unidad);
            label.Visible = true;
        }

        
        //Botones
        private void BtCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos dxf(.dxf)|*.dxf|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                vr.fid = File.ReadAllLines(openFileDialog1.FileName);
                label32.Visible = false;
                calculos(vr.fid);
            }
        }

        private void BtRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (vr.fid != null)
                {
                    string outputJSON2 = JsonConvert.SerializeObject(regEscribir);
                    File.WriteAllText(vr.pathReg, outputJSON2);
                    label32.Visible = true;
                }
                else { MessageBox.Show("No se cargó el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo escribir el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtConfigurar_Click(object sender, EventArgs e)
        {
            inst = this;
            if (cf==null)
            {
                cf = new Configurar();
            }
            vr.seaplico = false;
            cf.ShowDialog();
        }

        private void BtAnalizarRegistros_Click(object sender, EventArgs e)
        {
            if (regEscribir.Count() == 0) { MessageBox.Show("No hay registros");}
            else
            {
                inst = this;
                if (rg == null)
                {
                    rg = new Registros();
                }
                rg.ShowDialog();
            }
        }
    }
}
