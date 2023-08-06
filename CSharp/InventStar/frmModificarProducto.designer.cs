namespace InventStar
{
    partial class frmModificarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarProducto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTamanho = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nuTiempo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInstrucciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nuCalorias = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.rbBebida = new System.Windows.Forms.RadioButton();
            this.rbComida = new System.Windows.Forms.RadioButton();
            this.cbFrio = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPanel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuCalorias)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(44)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 67);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(211, 119);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(443, 29);
            this.cbTipo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo:";
            // 
            // cbTamanho
            // 
            this.cbTamanho.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTamanho.FormattingEnabled = true;
            this.cbTamanho.Location = new System.Drawing.Point(211, 172);
            this.cbTamanho.Name = "cbTamanho";
            this.cbTamanho.Size = new System.Drawing.Size(443, 29);
            this.cbTamanho.TabIndex = 6;
            this.cbTamanho.SelectedIndexChanged += new System.EventHandler(this.cbTamanho_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tamaño:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nuTiempo
            // 
            this.nuTiempo.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuTiempo.Location = new System.Drawing.Point(574, 226);
            this.nuTiempo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuTiempo.Name = "nuTiempo";
            this.nuTiempo.Size = new System.Drawing.Size(80, 28);
            this.nuTiempo.TabIndex = 9;
            this.nuTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nuTiempo.ValueChanged += new System.EventHandler(this.nuTiempo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tiempo de preparación:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Temperatura:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtInstrucciones
            // 
            this.txtInstrucciones.Location = new System.Drawing.Point(33, 128);
            this.txtInstrucciones.Multiline = true;
            this.txtInstrucciones.Name = "txtInstrucciones";
            this.txtInstrucciones.Size = new System.Drawing.Size(420, 116);
            this.txtInstrucciones.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Instrucciones:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(211, 68);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(443, 28);
            this.txtNombre.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(98, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nombre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(99, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "Calorías:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(33, 49);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(420, 46);
            this.txtDescripcion.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Descripción:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(420, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 57);
            this.button2.TabIndex = 23;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(617, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 55);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(540, 278);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(114, 28);
            this.txtPrecio.TabIndex = 24;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(457, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Precio:";
            // 
            // nuCalorias
            // 
            this.nuCalorias.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuCalorias.Location = new System.Drawing.Point(210, 226);
            this.nuCalorias.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuCalorias.Name = "nuCalorias";
            this.nuCalorias.Size = new System.Drawing.Size(80, 28);
            this.nuCalorias.TabIndex = 26;
            this.nuCalorias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nuCalorias.ValueChanged += new System.EventHandler(this.nuCalorias_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 21);
            this.label10.TabIndex = 27;
            this.label10.Text = "Tipo de Producto:";
            // 
            // rbBebida
            // 
            this.rbBebida.AutoSize = true;
            this.rbBebida.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBebida.Location = new System.Drawing.Point(211, 26);
            this.rbBebida.Name = "rbBebida";
            this.rbBebida.Size = new System.Drawing.Size(81, 25);
            this.rbBebida.TabIndex = 28;
            this.rbBebida.TabStop = true;
            this.rbBebida.Text = "Bebida";
            this.rbBebida.UseVisualStyleBackColor = true;
            // 
            // rbComida
            // 
            this.rbComida.AutoSize = true;
            this.rbComida.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbComida.Location = new System.Drawing.Point(334, 26);
            this.rbComida.Name = "rbComida";
            this.rbComida.Size = new System.Drawing.Size(88, 25);
            this.rbComida.TabIndex = 29;
            this.rbComida.TabStop = true;
            this.rbComida.Text = "Comida";
            this.rbComida.UseVisualStyleBackColor = true;
            // 
            // cbFrio
            // 
            this.cbFrio.AutoSize = true;
            this.cbFrio.Font = new System.Drawing.Font("SoDo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFrio.Location = new System.Drawing.Point(210, 280);
            this.cbFrio.Name = "cbFrio";
            this.cbFrio.Size = new System.Drawing.Size(75, 25);
            this.cbFrio.TabIndex = 30;
            this.cbFrio.Text = "Es fría";
            this.cbFrio.UseVisualStyleBackColor = true;
            this.cbFrio.CheckedChanged += new System.EventHandler(this.cbFrio_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("SoDo Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(47, 167);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 360);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.nuCalorias);
            this.tabPage1.Controls.Add(this.txtPrecio);
            this.tabPage1.Controls.Add(this.cbFrio);
            this.tabPage1.Controls.Add(this.cbTipo);
            this.tabPage1.Controls.Add(this.rbComida);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.rbBebida);
            this.tabPage1.Controls.Add(this.cbTamanho);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.nuTiempo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Font = new System.Drawing.Font("SoDo Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(703, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtInstrucciones);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtDescripcion);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(703, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.pnlHeader.Controls.Add(this.lblPanel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 67);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 39);
            this.pnlHeader.TabIndex = 65;
            // 
            // lblPanel
            // 
            this.lblPanel.AutoSize = true;
            this.lblPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanel.Location = new System.Drawing.Point(299, 7);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(192, 30);
            this.lblPanel.TabIndex = 0;
            this.lblPanel.Text = "P R O D U C T O S";
            this.lblPanel.UseCompatibleTextRendering = true;
            // 
            // frmModificarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmModificarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarProducto";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuCalorias)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTamanho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuTiempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInstrucciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nuCalorias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbBebida;
        private System.Windows.Forms.RadioButton rbComida;
        private System.Windows.Forms.CheckBox cbFrio;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPanel;
    }
}