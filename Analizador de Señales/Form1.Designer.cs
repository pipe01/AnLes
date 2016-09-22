﻿namespace Analizador_de_Señales
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnConsola = new System.Windows.Forms.Button();
            this.chkAnimChart = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAbrirArchivo = new System.Windows.Forms.Button();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.gbPuerto = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gbReproduccion = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btnParar = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.liveChart1 = new Analizador_de_Señales.LiveChart();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRend = new System.Windows.Forms.Label();
            this.gbOpciones.SuspendLayout();
            this.gbPuerto.SuspendLayout();
            this.gbReproduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOpciones
            // 
            this.gbOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpciones.Controls.Add(this.lblRend);
            this.gbOpciones.Controls.Add(this.label2);
            this.gbOpciones.Controls.Add(this.btnLimpiar);
            this.gbOpciones.Controls.Add(this.btnConsola);
            this.gbOpciones.Controls.Add(this.chkAnimChart);
            this.gbOpciones.Location = new System.Drawing.Point(131, 268);
            this.gbOpciones.Name = "gbOpciones";
            this.gbOpciones.Size = new System.Drawing.Size(231, 116);
            this.gbOpciones.TabIndex = 1;
            this.gbOpciones.TabStop = false;
            this.gbOpciones.Text = "Opciones";
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
            this.btnConsola.Enabled = false;
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
            // checkBox9
            // 
            this.checkBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(-3, 379);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(47, 17);
            this.checkBox9.TabIndex = 10;
            this.checkBox9.Text = "Test";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
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
            this.cbPort.Size = new System.Drawing.Size(101, 21);
            this.cbPort.TabIndex = 2;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // gbPuerto
            // 
            this.gbPuerto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPuerto.Controls.Add(this.btnCerrar);
            this.gbPuerto.Controls.Add(this.btnAbrir);
            this.gbPuerto.Controls.Add(this.cbPort);
            this.gbPuerto.Location = new System.Drawing.Point(12, 268);
            this.gbPuerto.Name = "gbPuerto";
            this.gbPuerto.Size = new System.Drawing.Size(113, 116);
            this.gbPuerto.TabIndex = 3;
            this.gbPuerto.TabStop = false;
            this.gbPuerto.Text = "Puerto serie";
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(0, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(0, 15);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(0, 29);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(0, 43);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(0, 57);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(0, 71);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(0, 85);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 4;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Enabled = false;
            this.checkBox8.Location = new System.Drawing.Point(0, 99);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 4;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 379);
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
            this.gbReproduccion.Controls.Add(this.button1);
            this.gbReproduccion.Controls.Add(this.label4);
            this.gbReproduccion.Controls.Add(this.trackBar1);
            this.gbReproduccion.Controls.Add(this.label3);
            this.gbReproduccion.Controls.Add(this.lblTiempo);
            this.gbReproduccion.Controls.Add(this.btnParar);
            this.gbReproduccion.Controls.Add(this.btnPlayPause);
            this.gbReproduccion.Controls.Add(this.btnGuardar);
            this.gbReproduccion.Controls.Add(this.btnAbrirArchivo);
            this.gbReproduccion.Location = new System.Drawing.Point(368, 268);
            this.gbReproduccion.Name = "gbReproduccion";
            this.gbReproduccion.Size = new System.Drawing.Size(220, 116);
            this.gbReproduccion.TabIndex = 6;
            this.gbReproduccion.TabStop = false;
            this.gbReproduccion.Text = "Reproduccion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Avanzar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
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
            this.trackBar1.Location = new System.Drawing.Point(6, 86);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 23);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 10;
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
            this.lblTiempo.Location = new System.Drawing.Point(165, 95);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox7);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.checkBox8);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Location = new System.Drawing.Point(594, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 116);
            this.panel1.TabIndex = 11;
            // 
            // liveChart1
            // 
            this.liveChart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveChart1.Animate = true;
            this.liveChart1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.liveChart1.Location = new System.Drawing.Point(12, 12);
            this.liveChart1.MaximumSize = new System.Drawing.Size(1000, 250);
            this.liveChart1.MinimumSize = new System.Drawing.Size(0, 250);
            this.liveChart1.Name = "liveChart1";
            this.liveChart1.RealTime = true;
            this.liveChart1.Size = new System.Drawing.Size(648, 250);
            this.liveChart1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rendimiento:";
            // 
            // lblRend
            // 
            this.lblRend.AutoSize = true;
            this.lblRend.Location = new System.Drawing.Point(118, 38);
            this.lblRend.Name = "lblRend";
            this.lblRend.Size = new System.Drawing.Size(0, 13);
            this.lblRend.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.liveChart1);
            this.Controls.Add(this.gbReproduccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbPuerto);
            this.Controls.Add(this.gbOpciones);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Analizador de Señales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbOpciones.ResumeLayout(false);
            this.gbOpciones.PerformLayout();
            this.gbPuerto.ResumeLayout(false);
            this.gbReproduccion.ResumeLayout(false);
            this.gbReproduccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAbrirArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox gbReproduccion;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private LiveChart liveChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRend;
        private System.Windows.Forms.Label label2;
    }
}

