namespace SepaTools
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FindFileButton = new System.Windows.Forms.Button();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NifCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.messageid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ccc = new System.Windows.Forms.TextBox();
            this.dc = new System.Windows.Forms.TextBox();
            this.office = new System.Windows.Forms.TextBox();
            this.bank = new System.Windows.Forms.TextBox();
            this.Iban = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NIF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.creditorName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarListaDeRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirNuevaEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarEntradaSeleccionadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1910, 1606);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FindFileButton);
            this.groupBox1.Controls.Add(this.filenameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1910, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Abrir archivo";
            // 
            // FindFileButton
            // 
            this.FindFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindFileButton.Location = new System.Drawing.Point(1810, 37);
            this.FindFileButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.FindFileButton.Name = "FindFileButton";
            this.FindFileButton.Size = new System.Drawing.Size(72, 38);
            this.FindFileButton.TabIndex = 5;
            this.FindFileButton.Text = "...";
            this.FindFileButton.UseVisualStyleBackColor = true;
            this.FindFileButton.Click += new System.EventHandler(this.FindFileButton_Click);
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTextBox.Enabled = false;
            this.filenameTextBox.Location = new System.Drawing.Point(166, 37);
            this.filenameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(1628, 31);
            this.filenameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Archivo N19";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(1910, 1500);
            this.splitContainer2.SplitterDistance = 188;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NifCode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.messageid);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.ccc);
            this.groupBox2.Controls.Add(this.dc);
            this.groupBox2.Controls.Add(this.office);
            this.groupBox2.Controls.Add(this.bank);
            this.groupBox2.Controls.Add(this.Iban);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.bic);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.NIF);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.creditorName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(1910, 188);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del presentador / resumen de archivo";
            // 
            // NifCode
            // 
            this.NifCode.AutoSize = true;
            this.NifCode.Location = new System.Drawing.Point(1460, 142);
            this.NifCode.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NifCode.Name = "NifCode";
            this.NifCode.Size = new System.Drawing.Size(188, 25);
            this.NifCode.TabIndex = 18;
            this.NifCode.Text = "N.I.F./C.I.F. SEPA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(271, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Identifficador de la remesa:";
            // 
            // messageid
            // 
            this.messageid.Location = new System.Drawing.Point(304, 137);
            this.messageid.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.messageid.Name = "messageid";
            this.messageid.Size = new System.Drawing.Size(418, 31);
            this.messageid.TabIndex = 16;
            this.messageid.TextChanged += new System.EventHandler(this.messageid_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1460, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Registros / Importe: 0 /0 €";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(782, 87);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 31);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha de cobro:";
            // 
            // button1
            // 
            this.button1.Image = global::SepaTools.Properties.Resources._1480788634_Gnome_Edit_Paste_64;
            this.button1.Location = new System.Drawing.Point(516, 87);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 38);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ccc
            // 
            this.ccc.Location = new System.Drawing.Point(368, 87);
            this.ccc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ccc.MaxLength = 10;
            this.ccc.Name = "ccc";
            this.ccc.Size = new System.Drawing.Size(132, 31);
            this.ccc.TabIndex = 11;
            this.ccc.Text = "0000000000";
            // 
            // dc
            // 
            this.dc.Location = new System.Drawing.Point(316, 87);
            this.dc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dc.MaxLength = 2;
            this.dc.Name = "dc";
            this.dc.Size = new System.Drawing.Size(36, 31);
            this.dc.TabIndex = 10;
            this.dc.Text = "00";
            // 
            // office
            // 
            this.office.Location = new System.Drawing.Point(244, 87);
            this.office.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.office.MaxLength = 4;
            this.office.Name = "office";
            this.office.Size = new System.Drawing.Size(56, 31);
            this.office.TabIndex = 9;
            this.office.Text = "0000";
            // 
            // bank
            // 
            this.bank.Location = new System.Drawing.Point(172, 87);
            this.bank.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bank.MaxLength = 4;
            this.bank.Name = "bank";
            this.bank.Size = new System.Drawing.Size(56, 31);
            this.bank.TabIndex = 8;
            this.bank.Text = "0000";
            // 
            // Iban
            // 
            this.Iban.Location = new System.Drawing.Point(100, 87);
            this.Iban.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Iban.MaxLength = 4;
            this.Iban.Name = "Iban";
            this.Iban.Size = new System.Drawing.Size(56, 31);
            this.Iban.TabIndex = 7;
            this.Iban.Text = "0000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "IBAN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1030, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Identificador bancario único:";
            // 
            // bic
            // 
            this.bic.Location = new System.Drawing.Point(1324, 87);
            this.bic.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bic.Name = "bic";
            this.bic.Size = new System.Drawing.Size(88, 31);
            this.bic.TabIndex = 4;
            this.bic.TextChanged += new System.EventHandler(this.bic_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1380, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "N.I.F./C.I.F.:";
            // 
            // NIF
            // 
            this.NIF.Location = new System.Drawing.Point(1524, 37);
            this.NIF.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.NIF.Name = "NIF";
            this.NIF.Size = new System.Drawing.Size(354, 31);
            this.NIF.TabIndex = 2;
            this.NIF.TextChanged += new System.EventHandler(this.NIF_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del presentador";
            // 
            // creditorName
            // 
            this.creditorName.Location = new System.Drawing.Point(276, 37);
            this.creditorName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.creditorName.Name = "creditorName";
            this.creditorName.Size = new System.Drawing.Size(1048, 31);
            this.creditorName.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1910, 1260);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.registrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1910, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarXMLToolStripMenuItem,
            this.exportarListaDeRegistrosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(107, 36);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // generarXMLToolStripMenuItem
            // 
            this.generarXMLToolStripMenuItem.Name = "generarXMLToolStripMenuItem";
            this.generarXMLToolStripMenuItem.Size = new System.Drawing.Size(388, 38);
            this.generarXMLToolStripMenuItem.Text = "Generar XML";
            this.generarXMLToolStripMenuItem.Click += new System.EventHandler(this.generarXMLToolStripMenuItem_Click);
            // 
            // exportarListaDeRegistrosToolStripMenuItem
            // 
            this.exportarListaDeRegistrosToolStripMenuItem.Name = "exportarListaDeRegistrosToolStripMenuItem";
            this.exportarListaDeRegistrosToolStripMenuItem.Size = new System.Drawing.Size(388, 38);
            this.exportarListaDeRegistrosToolStripMenuItem.Text = "Exportar Lista de registros";
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevaEntradaToolStripMenuItem,
            this.eliminarEntradaSeleccionadaToolStripMenuItem});
            this.registrosToolStripMenuItem.Enabled = false;
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(123, 36);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // añadirNuevaEntradaToolStripMenuItem
            // 
            this.añadirNuevaEntradaToolStripMenuItem.Name = "añadirNuevaEntradaToolStripMenuItem";
            this.añadirNuevaEntradaToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.añadirNuevaEntradaToolStripMenuItem.Text = "Añadir nueva entrada";
            // 
            // eliminarEntradaSeleccionadaToolStripMenuItem
            // 
            this.eliminarEntradaSeleccionadaToolStripMenuItem.Name = "eliminarEntradaSeleccionadaToolStripMenuItem";
            this.eliminarEntradaSeleccionadaToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.eliminarEntradaSeleccionadaToolStripMenuItem.Text = "Eliminar entrada seleccionada";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 1606);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Herramientas de remesas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FindFileButton;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox creditorName;
        private System.Windows.Forms.TextBox ccc;
        private System.Windows.Forms.TextBox dc;
        private System.Windows.Forms.TextBox office;
        private System.Windows.Forms.TextBox bank;
        private System.Windows.Forms.TextBox Iban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevaEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarEntradaSeleccionadaToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox messageid;
        private System.Windows.Forms.Label NifCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NIF;
        private System.Windows.Forms.ToolStripMenuItem exportarListaDeRegistrosToolStripMenuItem;
    }
}

