using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace PruebaUI.Formas
{
    public partial class Configurar : Form
    {
        public Configurar()
        {
            InitializeComponent();
            
            //Linea Base
            textBox1.Text = Convert.ToString(Formas.Principal.vr.LB[0]);
            textBox2.Text = Convert.ToString(Formas.Principal.vr.LB[1]);
            textBox3.Text = Convert.ToString(Formas.Principal.vr.LB[2]);
            textBox4.Text = Convert.ToString(Formas.Principal.vr.LB[3]);
            textBox5.Text = Convert.ToString(Formas.Principal.vr.LB[4]);

            //Tolerancia
            textBox10.Text = Convert.ToString(Formas.Principal.vr.Tol[0]);
            textBox9.Text = Convert.ToString(Formas.Principal.vr.Tol[1]);
            textBox8.Text = Convert.ToString(Formas.Principal.vr.Tol[2]);
            textBox11.Text = Convert.ToString(Formas.Principal.vr.Tol[3]);

            //Config
            textBox7.Text = Convert.ToString(Formas.Principal.vr.AnchoPerfil);
            textBox6.Text = Convert.ToString(Formas.Principal.vr.TamROI);


        }

        private void Configurar_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] LB = { "LBDosisCentral =" + textBox1.Text, "LBPlaniX=" + textBox2.Text, "LBSimX=" + textBox3.Text, "LBTamX=0", "LBPlaniY=" + textBox4.Text, "LBSimY=" + textBox5.Text, "LBTamY=0", "Ultima modificación: " + System.DateTime.Today.Date.ToString("d") };
            try
            {
                File.WriteAllLines(Principal.vr.pathLB, LB);
                MessageBox.Show("Valores de linea base actualizados","Linea Base",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Principal.vr.seaplico = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo escribir el archivo","Linea Base",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] Tol = { "TolDosisCentral=" + textBox10.Text, "TolplaniX=" + textBox9.Text, "TolSimX=" + textBox8.Text, "TolTamX=" + textBox11.Text, "TolPlaniY=" + textBox9.Text, "TolSimY=" + textBox8.Text, "TolTamY=" + textBox11.Text, "Ultima modificación: " + System.DateTime.Today.Date.ToString("d") };
            try
            {
                File.WriteAllLines(Principal.vr.pathTol, Tol);
                MessageBox.Show("Valores de tolerancia actualizados", "Tolerancia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Principal.vr.seaplico = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo escribir el archivo", "Tolerancia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string[] Config = { "TamROI=" + textBox6.Text, "AnchoPerfil=" + textBox7.Text, "Ultima modificación: " + System.DateTime.Today.Date.ToString("d") };
            try
            {
                File.WriteAllLines(Principal.vr.pathConfig, Config);
                MessageBox.Show("Valores de configuración actualizados", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Principal.vr.seaplico = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo escribir el archivo", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void Configurar_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Principal.vr.seaplico == true && Principal.vr.fecha!=null)
            {
                DialogResult recalcular = MessageBox.Show("¿Desea recalcular con los nuevos valores de configuración?", "Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (recalcular == DialogResult.Yes)
                {
                    Principal.cargaLBTolyConfig();
                    Principal.inst.calculos(Principal.vr.fid);
                }
            }
        }

        private void hubocambiosp1(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void hubocambiosp2(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void hubocambiosp3(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }


    }
}
