using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;

namespace PruebaUI.Formas
{
    public partial class Registros : Form
    {
        List<Registro> regLeer = new List<Registro>();
        List<Registro> regReducido = new List<Registro>();
        List<RegAnalisis> reganalisis = new List<RegAnalisis>();
        string[] etiquetas = { "Dosis Central", "Planicidad X", "Simetría X", "Tamaño X Dif", "Planicidad Y", "Simetría Y", "Tamaño Y Dif" };

        public Registros()
        {
            InitializeComponent();
        }

        private void Registros_Load(object sender, EventArgs e)
        {
            label2.Enabled = false; label3.Enabled = false;
            ChBRegRango.Checked = false; ChBGenerarReporte.Checked = false;
            leerregistros();
            cargaregistros(regLeer);
            resetearDTP();
            DGV(regLeer);
            DTPRegDesde.Enabled = false; DTPRegHasta.Enabled = false;
            GBConfiguracionReporte.Enabled = false;
            GraficoReg.Visible = false;
            chbTodas.Checked = false;
            listBox1.ClearSelected();
        }

        public void leerregistros()
        {
            var outputJSON = File.ReadAllText(Principal.vr.pathReg);
            regLeer = JsonConvert.DeserializeObject<List<Registro>>(outputJSON);
        }
        public void registroreducido(DateTime fechaInic, DateTime fechaFinal)
        {
            regReducido.Clear();
            foreach (Registro reg in regLeer)
            {
                if (reg._fecha >= fechaInic & reg._fecha <= fechaFinal)
                { regReducido.Add(reg); }
            }
        }
        public void cargaregistros(List<Registro> Lista)
        {
            Principal.vr.RegDTFecha = new DateTime[Lista.Count()];
            Principal.vr.RegdFecha = new double[Principal.vr.RegDTFecha.Count()];
            Principal.vr.RegDosisCentral = new double[Lista.Count()];
            Principal.vr.RegPlanicidadX = new double[Lista.Count()];
            Principal.vr.RegSimetriaX = new double[Lista.Count()];
            Principal.vr.RegTamX = new double[Lista.Count()];
            Principal.vr.RegPlanicidadY = new double[Lista.Count()];
            Principal.vr.RegSimetriaY = new double[Lista.Count()];
            Principal.vr.RegTamY = new double[Lista.Count()];

            int i = 0;
            foreach (Registro reg in Lista)
            {
                Principal.vr.RegDTFecha[i] = reg._fecha;
                Principal.vr.RegdFecha[i] = Principal.vr.RegDTFecha[i].ToOADate();
                Principal.vr.RegDosisCentral[i] = reg._DosisCentral;
                Principal.vr.RegPlanicidadX[i] = reg._PlanicidadX;
                Principal.vr.RegSimetriaX[i] = reg._SimetriaX;
                Principal.vr.RegTamX[i] = reg._TamCampoXDif;
                Principal.vr.RegPlanicidadY[i] = reg._PlanicidadY;
                Principal.vr.RegSimetriaY[i] = reg._SimetriaY;
                Principal.vr.RegTamY[i] = reg._TamCampoYDif;
                i++;
            }

            Principal.vr.RegVariables = new[]
            {
                Principal.vr.RegDosisCentral,
                Principal.vr.RegPlanicidadX,
                Principal.vr.RegSimetriaX,
                Principal.vr.RegTamX,
                Principal.vr.RegPlanicidadY,
                Principal.vr.RegSimetriaY,
                Principal.vr.RegTamY
            };

        }
        private void resetearDTP()
        {
            DTPRegDesde.Value = Principal.vr.RegDTFecha.Min();
            DTPRegHasta.Value = Principal.vr.RegDTFecha.Max();
        }

        //generar DGV
        private void DGV(List<Registro> lista)
        {
            DGVRegistros.DataSource = null; DGVRegistros.DataSource = lista;
            DGVRegistros.Columns[0].HeaderText = "Fecha";
            DGVRegistros.Columns[1].HeaderText = "Dosis Central";
            DGVRegistros.Columns[2].HeaderText = "PlaniX";
            DGVRegistros.Columns[3].HeaderText = "SimX";
            DGVRegistros.Columns[4].HeaderText = "TamX \nNominal";
            DGVRegistros.Columns[5].HeaderText = "TamX \nMedido";
            DGVRegistros.Columns[6].HeaderText = "TamX \nDif";
            DGVRegistros.Columns[7].HeaderText = "PlaniY";
            DGVRegistros.Columns[8].HeaderText = "SimY";
            DGVRegistros.Columns[9].HeaderText = "TamY \nNominal";
            DGVRegistros.Columns[10].HeaderText = "TamY \nMedido";
            DGVRegistros.Columns[11].HeaderText = "TamY \nDif";
            DGVRegistros.Columns[12].HeaderText = "Gantry";
            DGVRegistros.Columns[13].HeaderText = "Col";
            for (int i=1; i<DGVRegistros.Columns.Count; i++)
            {
                DGVRegistros.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            

            DGVRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            reganalisis.Clear();
            for (int i = 0; i < etiquetas.Count(); i++)
            {
                reganalisis.Add(new RegAnalisis()
                {
                    LineaBase = Principal.vr.LB[i],
                    variable = etiquetas[i],
                    promedio = Math.Round(Principal.vr.RegVariables[i].Average(), 2),
                    maximo = Math.Round(Principal.vr.RegVariables[i].Max(), 2),
                    fecha_max = Principal.vr.RegDTFecha[Array.IndexOf(Principal.vr.RegVariables[i], Principal.vr.RegVariables[i].Max())].ToShortDateString(),
                    minimo = Math.Round(Principal.vr.RegVariables[i].Min(), 2),
                    fecha_min = Principal.vr.RegDTFecha[Array.IndexOf(Principal.vr.RegVariables[i], Principal.vr.RegVariables[i].Min())].ToShortDateString(),
                });
            }
            DGVAnalisis.DataSource = null; DGVAnalisis.DataSource = reganalisis;
            for (int i = 1; i < DGVAnalisis.Columns.Count; i++)
            {
                DGVAnalisis.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            DGVAnalisis.Columns[0].HeaderText = "Variable";
            DGVAnalisis.Columns[1].HeaderText = "Linea Base";
            DGVAnalisis.Columns[2].HeaderText = "Promedio";
            DGVAnalisis.Columns[3].HeaderText = "Máximo";
            DGVAnalisis.Columns[4].HeaderText = "Fecha Máx";
            DGVAnalisis.Columns[5].HeaderText = "Mínimo";
            DGVAnalisis.Columns[6].HeaderText = "Fecha Mín";
            DGVAnalisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DGVAnalisis.Height = DGVAnalisis.Rows.GetRowsHeight(DataGridViewElementStates.None) + DGVAnalisis.ColumnHeadersHeight + 2;
            DGVAnalisis.Width = DGVAnalisis.Columns.GetColumnsWidth(DataGridViewElementStates.None) + DGVAnalisis.RowHeadersWidth + 2;

        }
        private void ChBFechasRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBRegRango.Checked == true)
            {
                label2.Enabled = true; label3.Enabled = true;
                DTPRegDesde.Enabled = true; DTPRegHasta.Enabled = true;
            }
            else if (ChBRegRango.Checked == false)
            {
                label2.Enabled = false; label3.Enabled = false;
                DTPRegDesde.Enabled = false; DTPRegHasta.Enabled = false;
                resetearDTP();
            }
        }

        private void BtGraficar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int indice = listBox1.SelectedIndex;
                double[] RegVariable = Principal.vr.RegVariables[indice];
                Metodos.MGraficos.graficarregistros(etiquetas[indice], Principal.vr.RegDTFecha, Principal.vr.RegdFecha, RegVariable, Principal.vr.LB[indice], GraficoReg, Principal.vr.Tol[indice],95,100,0,10);
                //setea rango de fechas en grafico
                double Xmin = DTPRegDesde.Value.ToOADate();
                double Xmax = DTPRegHasta.Value.ToOADate();
                GraficoReg.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax - Xmin) / 50;
                GraficoReg.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax - Xmin) / 50;
            }
        }

        private void BtActualizar_Click(object sender, EventArgs e)
        {
            double Xmin = DTPRegDesde.Value.ToOADate();
            double Xmax = DTPRegHasta.Value.ToOADate();
            if (GraficoReg.Visible == true)
            {
                GraficoReg.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax - Xmin) / 50;
                GraficoReg.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax - Xmin) / 50;
            }
            registroreducido(DTPRegDesde.Value, DTPRegHasta.Value);
            cargaregistros(regReducido);
            DGV(regReducido);
        }

        //Generación de reporte

        private void ChBGenerarReporte_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBGenerarReporte.Checked == true) { GBConfiguracionReporte.Enabled = true; }
            else { GBConfiguracionReporte.Enabled = false; }
        }

        private void chbTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodas.Checked == true)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.Enabled = false;
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else if (chbTodas.Checked == false)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.Enabled = true;
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }





        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font texto = new Font("Arial", 10, FontStyle.Regular);
            Font tabla = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            Font tablaHeader = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            Font textoNeg = new Font("Arial", 10, FontStyle.Bold);
            Font titulo = new Font("Arial", 18, FontStyle.Bold);
            Font subtitulo = new Font("Arial", 12, FontStyle.Bold);
            StringFormat centro = new StringFormat(); centro.Alignment = StringAlignment.Center;
            StringFormat izquierda = new StringFormat(); izquierda.Alignment = StringAlignment.Near;
            SolidBrush negro = new SolidBrush(Color.Black);
            int altoLtexto = texto.Height;
            int altoLtitulo = titulo.Height;
            int altoLsubtitulo = subtitulo.Height;

            printDocument1.OriginAtMargins = true;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);


            int anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            int altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;

            int x = 0;
            int y = 0;
            string[] etiquetas = { "Dosis Central", "Planicidad X", "Simetría X", "Tamaño X", "Planicidad Y", "Simetría Y", "Tamaño Y" };

            Metodos.MImprimir.imprimirTitulo(e, "Reporte Dosimetría 2D con EPID", anchoTotal, y, titulo, centro, negro);
            y = y + Convert.ToInt32(altoLtitulo * 1.5);
            Metodos.MImprimir.imprimirTitulo(e, "Desde: " + DTPRegDesde.Value.ToShortDateString() + "   Hasta: " + DTPRegHasta.Value.ToShortDateString(), anchoTotal, y, subtitulo, centro, negro);
            y = y + altoLsubtitulo;

            y += Metodos.MImprimir.imprimirtabla(e, DGVAnalisis, anchoTotal, y, tablaHeader, tabla, centro, negro)-40;
            x = 10;

            int col = 0; //(cuenta numero de graficos para poner en columnas)
            for (int k = 0; k < checkedListBox1.Items.Count; k++)
            {
                int grafs= checkedListBox1.CheckedItems.Count; //cuenta total de gráficos. Por ahora no lo uso, pero puede servir
                if (checkedListBox1.GetItemCheckState(k) == CheckState.Checked)
                {
                    double[] RegVariable = Principal.vr.RegVariables[k];

                    Metodos.MImprimir.imprimirTexto(e, etiquetas[k], anchoTotal / 2, y, 1, textoNeg, centro, negro,x+10);
                    y += altoLtexto-3;
                    Metodos.MGraficos.graficarregistros(etiquetas[k], Principal.vr.RegDTFecha, Principal.vr.RegdFecha, RegVariable, Principal.vr.LB[k], GraficoReg, Principal.vr.Tol[k],100,100,0,10);
                    GraficoReg.Titles.Clear();
                    if (k == 3 | k == 6) { Principal.vr.LB[k] = 0; }
                    double Xmin = DTPRegDesde.Value.ToOADate();
                    double Xmax = DTPRegHasta.Value.ToOADate();
                    GraficoReg.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax - Xmin) / 50;
                    GraficoReg.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax - Xmin) / 50;
                    GraficoReg.Series[3].MarkerSize = 1;
                    foreach (Series ser in GraficoReg.Series) { ser.IsVisibleInLegend = false; }
                    
                    GraficoReg.ChartAreas[0].AxisX.LabelStyle.Interval *= 3;
                    GraficoReg.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 6, FontStyle.Regular);
                    GraficoReg.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 6, FontStyle.Regular);
                    GraficoReg.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
                    GraficoReg.ChartAreas[0].AxisY.LabelStyle.Interval *= 2;
                    int ancho = Convert.ToInt32(anchoTotal/2.2);
                    int alto = Convert.ToInt32(GraficoReg.Height/1.4);
                    Metodos.MImprimir.imprimirGraficoChico(e, GraficoReg, x, y, ancho, alto); 
                    if (col % 2 == 0)
                    { x += ancho +3; y -= altoLtexto; }
                    else { y += alto+15; x = 10; }
                    col++;
                }
                

            }
            GraficoReg.Titles.Clear(); GraficoReg.ChartAreas.Clear(); GraficoReg.Series.Clear(); GraficoReg.Legends.Clear();
            BtGraficar_Click(sender, e);
            if (listBox1.SelectedIndex == -1)
            {
                GraficoReg.Visible = false;
            }
            y = 0; x = 0;
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)

            { printDocument1.Print(); }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            if (printDialog1.ShowDialog() == DialogResult.OK)

            { printDocument1.Print(); }
        }
    }
}


