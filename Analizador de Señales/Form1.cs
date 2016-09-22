using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Analizador_de_Señales
{
    public struct Token
    {
        public TimeSpan time;
        public int num1, num2;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool[] series = new bool[8];
        private string serialRec = "";
        private DateTime startTime;
        private TimeSpan endTime;
        private Stopwatch elapsed = new Stopwatch();
        private StringBuilder log = new StringBuilder();
        private int reprIndex = 0;
        private bool reproducing = false;
        private string[] reprLines;
        private Token[] reprTokens;
        private TimeSpan elOffset = TimeSpan.Zero;
        private System.Timers.Timer timerMain;
        private int[] seriesChanges = new int[2];

        private float TimeScale
        {
            get
            {
                return trackBar1.Value / 10;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.CurrentCulture = System.Globalization.CultureInfo.CurrentCulture;
            AutoUpdater.Start("http://pipe01.square7.ch/adl.xml");

            cbPort.Items.AddRange(SerialPort.GetPortNames());
            Program.serialPort.DataReceived += SerialPort_DataReceived;
            
            timerMain = new System.Timers.Timer();
            timerMain.Interval = 500;
            timerMain.Elapsed += timerMain_Tick;
        }

        private void timerMain_Tick(object sender, ElapsedEventArgs e)
        {
            //Tick();
        }

        private TimeSpan GetElapsed()
        {
            return elapsed.Elapsed + elOffset;
        }

        private void ClearChart()
        {
            liveChart1.Clear();

            reprTokens = null;
            reprLines = null;
            reproducing = false;
            reprIndex = 0;
            log.Clear();
            elapsed.Reset();
            timer1.Stop();
            serialRec = "";
            series = new bool[8];
        }

        private int GetYAxis(int i, int on)
        {
            return i * 2 + on;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialRec += Program.serialPort.ReadExisting();

            if (ParseData(serialRec))
            {
                serialRec = "";
            }
        }

        public bool ParseData(string str, bool force = false, bool dolog = true)
        {
            if (force || (str.EndsWith("\n") && str.Length == 3))
            {
                log.AppendFormat("{0} {1}", (int)GetElapsed().TotalMilliseconds, str);
                

                Console.Write(str);
                int num1 = int.Parse(str[0].ToString());
                int num2 = int.Parse(str[1].ToString());
                if (num1 < 9)
                {
                    series[num1 - 1] = num2 == 1;
                    return true;
                }
            }
            return false;
        }

        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.serialPort.PortName = cbPort.Items[cbPort.SelectedIndex].ToString();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                Program.serialPort.Open();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Se ha denegado el acceso al puerto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (Program.serialPort.IsOpen)
            {
                startTime = DateTime.Now;
                elapsed.Restart();
                log = new StringBuilder();
                log.AppendLine(startTime.Ticks.ToString());

                btnAbrir.Enabled = false;
                btnCerrar.Enabled = true;
                btnConsola.Enabled = true;
                btnAbrir.Enabled = false;
                btnGuardar.Enabled = false;
                gbReproduccion.Enabled = false;
                cbPort.Enabled = false;
                timer1.Start();
                timerMain.Start();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            Program.serialPort.Close();
            btnAbrir.Enabled = true;
            btnCerrar.Enabled = false;
            btnConsola.Enabled = false;
            btnAbrir.Enabled = true;
            btnGuardar.Enabled = true;
            gbReproduccion.Enabled = true;
            cbPort.Enabled = true;
            timer1.Stop();
            log.AppendFormat("{0} end", (int)GetElapsed().TotalMilliseconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.serialPort.IsOpen)
            {
                new frmConsole().Show();
            }
        }

        private void AddPoint(int series, int on)
        {
            /*int y = GetYAxis(series, on);
            tbScale.Invoke((MethodInvoker)delegate 
            {
                tbScale.Series[series].Points.AddXY(startTime.Add(GetElapsed()), y);
            });*/
            liveChart1.Invoke((MethodInvoker)delegate
            {
                liveChart1.AddOneSeries(on == 1, series, elapsed.Elapsed);
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.serialPort.IsOpen)
                Program.serialPort.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Tick();
            lblRend.Text = liveChart1.perfomance.ToString("0.0000") + " ms por frame";
        }

        private void Tick()
        {
            //count++;
            var e = GetElapsed();
            //Console.WriteLine((int)e.TotalMilliseconds);
            if (reproducing)
            {
                if (GetElapsed() > endTime)
                {
                    timer1.Stop();
                    return;
                }
                else if (reprIndex < reprTokens.Length)
                {
                    Token t = reprTokens[reprIndex];
                    if (GetElapsed() >= t.time)
                    {
                        ParseData(t.num1 + "" + t.num2, true);
                        reprIndex++;
                    }
                }
                lblTiempo.Invoke((MethodInvoker)delegate 
                {
                    lblTiempo.Text = GetElapsed().ToString(@"hh\:mm\:ss") + "/" + endTime.ToString(@"hh\:mm\:ss");
                });
            }
            else
            {
                lblTiempo.Invoke((MethodInvoker)delegate
                {
                    lblTiempo.Text = GetElapsed().ToString(@"hh\:mm\:ss");
                });
            }

            UpdateCheckboxes();

            liveChart1.AddOneSeries(series, elapsed.Elapsed);
        }

        private void UpdateCheckboxes()
        {
            int i = 0;
            foreach (var item in series)
            {
                var cbox = (panel1.Controls.Find("checkbox" + (i + 1), false).First() as CheckBox);
                cbox.Invoke((MethodInvoker)delegate { cbox.Checked = item; });
                i++;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                try
                {
                    log = new StringBuilder(File.ReadAllText(openFileDialog1.FileName));
                    reprLines = log.ToString().Split(new[] { '\r', '\n' });
                    startTime = new DateTime(long.Parse(reprLines[0]));
                    endTime = TimeSpan.FromMilliseconds(long.Parse(reprLines[reprLines.Length - 1].Split(' ')[0]));

                    List<Token> l = new List<Token>();
                    foreach (var item in reprLines)
                    {
                        if (item.Contains(" ") && !item.Contains("end"))
                        {
                            string[] spl = item.Split(' ');
                            Token t = new Token();
                            //t.time = new TimeSpan(long.Parse(spl[0]));
                            t.time = TimeSpan.FromMilliseconds(long.Parse(spl[0]));
                            t.num1 = int.Parse(spl[1][0].ToString());
                            t.num2 = int.Parse(spl[1][1].ToString());
                            l.Add(t);
                        }
                    }
                    reprTokens = l.ToArray();
                }
                catch (Exception)
                {
                    MessageBox.Show("Archivo no válido");
                    log = null;
                    reprLines = null;
                    startTime = DateTime.MinValue;
                    endTime = TimeSpan.Zero;
                }

                gbPuerto.Enabled = false;
                btnAbrir.Enabled = false;
                btnPlayPause.Enabled = true;
                btnParar.Enabled = true;

                reproducing = true;
                elapsed.Restart();
                //timer1.Start();
                timerMain.Start();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, log.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearChart();
        }

        private int pro = 0;
        private int step = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int num1 = r.Next(1, 8);
            int num2 = r.NextDouble() > 0.5f ? 1 : 0;

            /*if (!series[num1 - 1] && num2 == 0) num2 = 1;
            else if (series[num1 - 1] && num2 == 1) num2 = 0;*/

            num1 = pro + 1;
            num2 = liveChart1.Series[num1 - 1].values.Any() ?
                (liveChart1.Series[num1 - 1].values.Last() ? 0 : 1) : 1;

            
            if (pro >= 7) step = -1;
            else if (pro <= 0) step = 1;

            pro += step;

            series[num1 - 1] = num2 == 1;

            //Console.WriteLine(num2);
            //liveChart1.AddOneSeries(num2 == 1, num1 - 1, elapsed.Elapsed);
            //liveChart1.series[num1 - 1].values.Add(num2 == 1);

            //ParseData(num1 + "" + num2 + "\n", true);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            timer2.Enabled = checkBox9.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearChart();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (reproducing)
            {
                timer1.Enabled = !timer1.Enabled;
                if (timer1.Enabled)
                {
                    elapsed.Start();
                }
                else
                {
                    elapsed.Stop();
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmChooseTime frm = new frmChooseTime();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                elOffset += frm.Result;
            }
        }

        private void chkAnimChart_CheckedChanged(object sender, EventArgs e)
        {
            liveChart1.Animate = chkAnimChart.Checked;
        }
    }
}
