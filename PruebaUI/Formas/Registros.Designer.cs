namespace PruebaUI.Formas
{
    partial class Registros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registros));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtGraficar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ChBRegRango = new System.Windows.Forms.CheckBox();
            this.DTPRegDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPRegHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtActualizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GraficoReg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.chbTodas = new System.Windows.Forms.CheckBox();
            this.BtnVistaPrevia = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.GBConfiguracionReporte = new System.Windows.Forms.GroupBox();
            this.ChBGenerarReporte = new System.Windows.Forms.CheckBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.GBGrafReg = new System.Windows.Forms.GroupBox();
            this.DGVAnalisis = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVRegistros = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoReg)).BeginInit();
            this.GBConfiguracionReporte.SuspendLayout();
            this.GBGrafReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAnalisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // BtGraficar
            // 
            this.BtGraficar.Location = new System.Drawing.Point(8, 200);
            this.BtGraficar.Name = "BtGraficar";
            this.BtGraficar.Size = new System.Drawing.Size(106, 30);
            this.BtGraficar.TabIndex = 7;
            this.BtGraficar.Text = "Graficar";
            this.BtGraficar.UseVisualStyleBackColor = true;
            this.BtGraficar.Click += new System.EventHandler(this.BtGraficar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Dosis Central",
            "Planicidad X",
            "Simetría X",
            "Tamaño X Dif",
            "Planicidad Y",
            "Simetría Y",
            "Tamaño Y Dif"});
            this.listBox1.Location = new System.Drawing.Point(8, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(106, 108);
            this.listBox1.TabIndex = 37;
            // 
            // ChBRegRango
            // 
            this.ChBRegRango.AutoSize = true;
            this.ChBRegRango.Location = new System.Drawing.Point(6, 19);
            this.ChBRegRango.Name = "ChBRegRango";
            this.ChBRegRango.Size = new System.Drawing.Size(147, 17);
            this.ChBRegRango.TabIndex = 39;
            this.ChBRegRango.Text = "Elegir un rango de fechas";
            this.ChBRegRango.UseVisualStyleBackColor = true;
            this.ChBRegRango.CheckedChanged += new System.EventHandler(this.ChBFechasRegistro_CheckedChanged);
            // 
            // DTPRegDesde
            // 
            this.DTPRegDesde.Enabled = false;
            this.DTPRegDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPRegDesde.Location = new System.Drawing.Point(56, 42);
            this.DTPRegDesde.Name = "DTPRegDesde";
            this.DTPRegDesde.Size = new System.Drawing.Size(84, 20);
            this.DTPRegDesde.TabIndex = 40;
            // 
            // DTPRegHasta
            // 
            this.DTPRegHasta.Enabled = false;
            this.DTPRegHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPRegHasta.Location = new System.Drawing.Point(56, 68);
            this.DTPRegHasta.Name = "DTPRegHasta";
            this.DTPRegHasta.Size = new System.Drawing.Size(84, 20);
            this.DTPRegHasta.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Hasta";
            // 
            // BtActualizar
            // 
            this.BtActualizar.Location = new System.Drawing.Point(15, 94);
            this.BtActualizar.Name = "BtActualizar";
            this.BtActualizar.Size = new System.Drawing.Size(125, 21);
            this.BtActualizar.TabIndex = 44;
            this.BtActualizar.Text = "Actualizar";
            this.BtActualizar.UseVisualStyleBackColor = true;
            this.BtActualizar.Click += new System.EventHandler(this.BtActualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtActualizar);
            this.groupBox1.Controls.Add(this.ChBRegRango);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTPRegHasta);
            this.groupBox1.Controls.Add(this.DTPRegDesde);
            this.groupBox1.Location = new System.Drawing.Point(717, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 126);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar fechas";
            // 
            // GraficoReg
            // 
            this.GraficoReg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GraficoReg.Location = new System.Drawing.Point(120, 19);
            this.GraficoReg.Name = "GraficoReg";
            this.GraficoReg.Size = new System.Drawing.Size(535, 204);
            this.GraficoReg.TabIndex = 46;
            this.GraficoReg.Text = "chart1";
            this.GraficoReg.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Dosis Central",
            "Planicidad X",
            "Simetría X",
            "Tamaño de Campo X",
            "Planicidad Y",
            "Simetría Y",
            "Tamaño de campo Y"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 29);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(134, 124);
            this.checkedListBox1.TabIndex = 48;
            // 
            // chbTodas
            // 
            this.chbTodas.AutoSize = true;
            this.chbTodas.Location = new System.Drawing.Point(9, 159);
            this.chbTodas.Name = "chbTodas";
            this.chbTodas.Size = new System.Drawing.Size(115, 17);
            this.chbTodas.TabIndex = 52;
            this.chbTodas.Text = "Seleccionar Todas";
            this.chbTodas.UseVisualStyleBackColor = true;
            this.chbTodas.CheckedChanged += new System.EventHandler(this.chbTodas_CheckedChanged);
            // 
            // BtnVistaPrevia
            // 
            this.BtnVistaPrevia.Location = new System.Drawing.Point(15, 177);
            this.BtnVistaPrevia.Name = "BtnVistaPrevia";
            this.BtnVistaPrevia.Size = new System.Drawing.Size(125, 23);
            this.BtnVistaPrevia.TabIndex = 53;
            this.BtnVistaPrevia.Text = "Vista Previa";
            this.BtnVistaPrevia.UseVisualStyleBackColor = true;
            this.BtnVistaPrevia.Click += new System.EventHandler(this.BtnVistaPrevia_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(15, 206);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(125, 23);
            this.BtnImprimir.TabIndex = 54;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // GBConfiguracionReporte
            // 
            this.GBConfiguracionReporte.Controls.Add(this.BtnImprimir);
            this.GBConfiguracionReporte.Controls.Add(this.BtnVistaPrevia);
            this.GBConfiguracionReporte.Controls.Add(this.chbTodas);
            this.GBConfiguracionReporte.Controls.Add(this.checkedListBox1);
            this.GBConfiguracionReporte.Enabled = false;
            this.GBConfiguracionReporte.Location = new System.Drawing.Point(717, 280);
            this.GBConfiguracionReporte.Name = "GBConfiguracionReporte";
            this.GBConfiguracionReporte.Size = new System.Drawing.Size(159, 238);
            this.GBConfiguracionReporte.TabIndex = 55;
            this.GBConfiguracionReporte.TabStop = false;
            this.GBConfiguracionReporte.Text = "Configuración Reporte";
            // 
            // ChBGenerarReporte
            // 
            this.ChBGenerarReporte.AutoSize = true;
            this.ChBGenerarReporte.Location = new System.Drawing.Point(717, 257);
            this.ChBGenerarReporte.Name = "ChBGenerarReporte";
            this.ChBGenerarReporte.Size = new System.Drawing.Size(105, 17);
            this.ChBGenerarReporte.TabIndex = 56;
            this.ChBGenerarReporte.Text = "Generar Reporte";
            this.ChBGenerarReporte.UseVisualStyleBackColor = true;
            this.ChBGenerarReporte.CheckedChanged += new System.EventHandler(this.ChBGenerarReporte_CheckedChanged);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // GBGrafReg
            // 
            this.GBGrafReg.Controls.Add(this.GraficoReg);
            this.GBGrafReg.Controls.Add(this.BtGraficar);
            this.GBGrafReg.Controls.Add(this.listBox1);
            this.GBGrafReg.Location = new System.Drawing.Point(20, 257);
            this.GBGrafReg.Name = "GBGrafReg";
            this.GBGrafReg.Size = new System.Drawing.Size(668, 236);
            this.GBGrafReg.TabIndex = 58;
            this.GBGrafReg.TabStop = false;
            this.GBGrafReg.Text = "Graficos";
            // 
            // DGVAnalisis
            // 
            this.DGVAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAnalisis.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAnalisis.Location = new System.Drawing.Point(20, 521);
            this.DGVAnalisis.Name = "DGVAnalisis";
            this.DGVAnalisis.Size = new System.Drawing.Size(668, 180);
            this.DGVAnalisis.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Analisis";
            // 
            // DGVRegistros
            // 
            this.DGVRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVRegistros.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVRegistros.Location = new System.Drawing.Point(20, 12);
            this.DGVRegistros.Name = "DGVRegistros";
            this.DGVRegistros.Size = new System.Drawing.Size(668, 239);
            this.DGVRegistros.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(701, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 39);
            this.label4.TabIndex = 61;
            this.label4.Text = "El rango de fechas elegido afectará a \r\nla visualización de registros, el gráfico" +
    ",\r\nel análisis y al reporte.";
            // 
            // Registros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 713);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVAnalisis);
            this.Controls.Add(this.GBGrafReg);
            this.Controls.Add(this.DGVRegistros);
            this.Controls.Add(this.ChBGenerarReporte);
            this.Controls.Add(this.GBConfiguracionReporte);
            this.Name = "Registros";
            this.Text = "Registros y Reportes";
            this.Load += new System.EventHandler(this.Registros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoReg)).EndInit();
            this.GBConfiguracionReporte.ResumeLayout(false);
            this.GBConfiguracionReporte.PerformLayout();
            this.GBGrafReg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAnalisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtGraficar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox ChBRegRango;
        private System.Windows.Forms.DateTimePicker DTPRegDesde;
        private System.Windows.Forms.DateTimePicker DTPRegHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtActualizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoReg;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox chbTodas;
        private System.Windows.Forms.Button BtnVistaPrevia;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.GroupBox GBConfiguracionReporte;
        private System.Windows.Forms.CheckBox ChBGenerarReporte;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox GBGrafReg;
        private System.Windows.Forms.DataGridView DGVAnalisis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVRegistros;
        private System.Windows.Forms.Label label4;
    }
}