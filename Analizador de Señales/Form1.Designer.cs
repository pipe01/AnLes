namespace Analizador_de_Señales
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gbOpciones = new System.Windows.Forms.GroupBox();
            this.btnAvanzarFinal = new System.Windows.Forms.Button();
            this.chkLowUse = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudUpdateDelay = new System.Windows.Forms.NumericUpDown();
            this.lblRend = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnConsola = new System.Windows.Forms.Button();
            this.chkAnimChart = new System.Windows.Forms.CheckBox();
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAbrirArchivo = new System.Windows.Forms.Button();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.gbPuerto = new System.Windows.Forms.GroupBox();
            this.btnActSerie = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gbReproduccion = new System.Windows.Forms.GroupBox();
            this.btnAvanzar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btnParar = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llblVersion = new System.Windows.Forms.LinkLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.gbOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateDelay)).BeginInit();
            this.gbPuerto.SuspendLayout();
            this.gbReproduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOpciones
            // 
            this.gbOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpciones.Controls.Add(this.btnAvanzarFinal);
            this.gbOpciones.Controls.Add(this.chkLowUse);
            this.gbOpciones.Controls.Add(this.label6);
            this.gbOpciones.Controls.Add(this.label5);
            this.gbOpciones.Controls.Add(this.nudUpdateDelay);
            this.gbOpciones.Controls.Add(this.lblRend);
            this.gbOpciones.Controls.Add(this.label2);
            this.gbOpciones.Controls.Add(this.btnLimpiar);
            this.gbOpciones.Controls.Add(this.btnConsola);
            this.gbOpciones.Controls.Add(this.chkAnimChart);
            this.gbOpciones.Location = new System.Drawing.Point(131, 267);
            this.gbOpciones.Name = "gbOpciones";
            this.gbOpciones.Size = new System.Drawing.Size(231, 116);
            this.gbOpciones.TabIndex = 1;
            this.gbOpciones.TabStop = false;
            this.gbOpciones.Text = "Opciones";
            this.gbOpciones.Enter += new System.EventHandler(this.gbOpciones_Enter);
            // 
            // btnAvanzarFinal
            // 
            this.btnAvanzarFinal.Enabled = false;
            this.btnAvanzarFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvanzarFinal.Location = new System.Drawing.Point(120, 75);
            this.btnAvanzarFinal.Name = "btnAvanzarFinal";
            this.btnAvanzarFinal.Size = new System.Drawing.Size(101, 34);
            this.btnAvanzarFinal.TabIndex = 14;
            this.btnAvanzarFinal.Text = "Avanzar hasta el final";
            this.btnAvanzarFinal.UseVisualStyleBackColor = true;
            this.btnAvanzarFinal.Click += new System.EventHandler(this.btnAvanzarFinal_Click);
            // 
            // chkLowUse
            // 
            this.chkLowUse.AutoSize = true;
            this.chkLowUse.Location = new System.Drawing.Point(108, 54);
            this.chkLowUse.Name = "chkLowUse";
            this.chkLowUse.Size = new System.Drawing.Size(122, 17);
            this.chkLowUse.TabIndex = 13;
            this.chkLowUse.Text = "Modo bajo consumo";
            this.chkLowUse.UseVisualStyleBackColor = true;
            this.chkLowUse.CheckedChanged += new System.EventHandler(this.chkLowUse_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "ms";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Actualizar cada:";
            // 
            // nudUpdateDelay
            // 
            this.nudUpdateDelay.Location = new System.Drawing.Point(125, 27);
            this.nudUpdateDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudUpdateDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudUpdateDelay.Name = "nudUpdateDelay";
            this.nudUpdateDelay.Size = new System.Drawing.Size(73, 20);
            this.nudUpdateDelay.TabIndex = 12;
            this.nudUpdateDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudUpdateDelay.ValueChanged += new System.EventHandler(this.nudUpdateDelay_ValueChanged);
            // 
            // lblRend
            // 
            this.lblRend.AutoSize = true;
            this.lblRend.Location = new System.Drawing.Point(70, 36);
            this.lblRend.Name = "lblRend";
            this.lblRend.Size = new System.Drawing.Size(30, 13);
            this.lblRend.TabIndex = 11;
            this.lblRend.Text = "0 fps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rendimiento:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(6, 82);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnConsola
            // 
            this.btnConsola.Location = new System.Drawing.Point(6, 51);
            this.btnConsola.Name = "btnConsola";
            this.btnConsola.Size = new System.Drawing.Size(101, 23);
            this.btnConsola.TabIndex = 4;
            this.btnConsola.Text = "Consola";
            this.btnConsola.UseVisualStyleBackColor = true;
            this.btnConsola.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkAnimChart
            // 
            this.chkAnimChart.AutoSize = true;
            this.chkAnimChart.Checked = true;
            this.chkAnimChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnimChart.Location = new System.Drawing.Point(6, 19);
            this.chkAnimChart.Name = "chkAnimChart";
            this.chkAnimChart.Size = new System.Drawing.Size(93, 17);
            this.chkAnimChart.TabIndex = 0;
            this.chkAnimChart.Text = "Animar gráfica";
            this.chkAnimChart.UseVisualStyleBackColor = true;
            this.chkAnimChart.CheckedChanged += new System.EventHandler(this.chkAnimChart_CheckedChanged);
            // 
            // chkTest
            // 
            this.chkTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTest.AutoSize = true;
            this.chkTest.Location = new System.Drawing.Point(0, 378);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(47, 17);
            this.chkTest.TabIndex = 10;
            this.chkTest.Text = "Test";
            this.chkTest.UseVisualStyleBackColor = true;
            this.chkTest.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(6, 44);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar a archivo";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAbrirArchivo
            // 
            this.btnAbrirArchivo.Location = new System.Drawing.Point(6, 19);
            this.btnAbrirArchivo.Name = "btnAbrirArchivo";
            this.btnAbrirArchivo.Size = new System.Drawing.Size(101, 23);
            this.btnAbrirArchivo.TabIndex = 7;
            this.btnAbrirArchivo.Text = "Abrir archivo";
            this.btnAbrirArchivo.UseVisualStyleBackColor = true;
            this.btnAbrirArchivo.Click += new System.EventHandler(this.btnAbrirArchivo_Click);
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(6, 19);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(68, 21);
            this.cbPort.TabIndex = 2;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // gbPuerto
            // 
            this.gbPuerto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPuerto.Controls.Add(this.btnActSerie);
            this.gbPuerto.Controls.Add(this.btnCerrar);
            this.gbPuerto.Controls.Add(this.btnAbrir);
            this.gbPuerto.Controls.Add(this.cbPort);
            this.gbPuerto.Location = new System.Drawing.Point(12, 267);
            this.gbPuerto.Name = "gbPuerto";
            this.gbPuerto.Size = new System.Drawing.Size(113, 116);
            this.gbPuerto.TabIndex = 3;
            this.gbPuerto.TabStop = false;
            this.gbPuerto.Text = "Puerto serie";
            // 
            // btnActSerie
            // 
            this.btnActSerie.Location = new System.Drawing.Point(76, 18);
            this.btnActSerie.Name = "btnActSerie";
            this.btnActSerie.Size = new System.Drawing.Size(31, 23);
            this.btnActSerie.TabIndex = 5;
            this.btnActSerie.Text = "Act";
            this.btnActSerie.UseVisualStyleBackColor = true;
            this.btnActSerie.Click += new System.EventHandler(this.btnActSerie_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Enabled = false;
            this.btnCerrar.Location = new System.Drawing.Point(6, 82);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(6, 51);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(101, 23);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(671, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "por pipe01";
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gbReproduccion
            // 
            this.gbReproduccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbReproduccion.Controls.Add(this.btnAvanzar);
            this.gbReproduccion.Controls.Add(this.label4);
            this.gbReproduccion.Controls.Add(this.trackBar1);
            this.gbReproduccion.Controls.Add(this.label3);
            this.gbReproduccion.Controls.Add(this.lblTiempo);
            this.gbReproduccion.Controls.Add(this.btnParar);
            this.gbReproduccion.Controls.Add(this.btnPlayPause);
            this.gbReproduccion.Controls.Add(this.btnGuardar);
            this.gbReproduccion.Controls.Add(this.btnAbrirArchivo);
            this.gbReproduccion.Location = new System.Drawing.Point(368, 267);
            this.gbReproduccion.Name = "gbReproduccion";
            this.gbReproduccion.Size = new System.Drawing.Size(225, 116);
            this.gbReproduccion.TabIndex = 6;
            this.gbReproduccion.TabStop = false;
            this.gbReproduccion.Text = "Reproduccion";
            // 
            // btnAvanzar
            // 
            this.btnAvanzar.Enabled = false;
            this.btnAvanzar.Location = new System.Drawing.Point(113, 70);
            this.btnAvanzar.Name = "btnAvanzar";
            this.btnAvanzar.Size = new System.Drawing.Size(101, 23);
            this.btnAvanzar.TabIndex = 13;
            this.btnAvanzar.Text = "Avanzar...";
            this.btnAvanzar.UseVisualStyleBackColor = true;
            this.btnAvanzar.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "(x1)";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(6, 86);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 23);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Escala de repro.";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(110, 96);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(49, 13);
            this.lblTiempo.TabIndex = 9;
            this.lblTiempo.Text = "00:00:00";
            // 
            // btnParar
            // 
            this.btnParar.Enabled = false;
            this.btnParar.Location = new System.Drawing.Point(113, 44);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(101, 23);
            this.btnParar.TabIndex = 1;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Enabled = false;
            this.btnPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayPause.Location = new System.Drawing.Point(113, 19);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(101, 23);
            this.btnPlayPause.TabIndex = 0;
            this.btnPlayPause.Text = "Reproducir/Pausar";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(701, 247);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // llblVersion
            // 
            this.llblVersion.ActiveLinkColor = System.Drawing.Color.Red;
            this.llblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llblVersion.AutoSize = true;
            this.llblVersion.Enabled = false;
            this.llblVersion.LinkColor = System.Drawing.Color.Blue;
            this.llblVersion.Location = new System.Drawing.Point(648, 365);
            this.llblVersion.Name = "llblVersion";
            this.llblVersion.Size = new System.Drawing.Size(78, 13);
            this.llblVersion.TabIndex = 15;
            this.llblVersion.TabStop = true;
            this.llblVersion.Text = "Versión 1.0.0.0";
            this.llblVersion.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llblVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblVersion_LinkClicked);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(611, 288);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 392);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.llblVersion);
            this.Controls.Add(this.chkTest);
            this.Controls.Add(this.gbReproduccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbPuerto);
            this.Controls.Add(this.gbOpciones);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.Name = "Form1";
            this.Text = "Analizador de Señales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.gbOpciones.ResumeLayout(false);
            this.gbOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateDelay)).EndInit();
            this.gbPuerto.ResumeLayout(false);
            this.gbReproduccion.ResumeLayout(false);
            this.gbReproduccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbOpciones;
        private System.Windows.Forms.CheckBox chkAnimChart;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.GroupBox gbPuerto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnConsola;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAbrirArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkTest;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox gbReproduccion;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAvanzar;
        private System.Windows.Forms.Label lblRend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudUpdateDelay;
        private System.Windows.Forms.CheckBox chkLowUse;
        private System.Windows.Forms.Button btnAvanzarFinal;
        private System.Windows.Forms.LinkLabel llblVersion;
        private System.Windows.Forms.Button btnActSerie;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

