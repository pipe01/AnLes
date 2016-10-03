using AutoUpdaterDotNET;
using SFML_Viewer;
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

        private enum State
        {
            Default,
            RealInputRunning,
            ReproductionRunning,
            RealInputClosed
        }

        private bool[] series = new bool[8];
        private string serialRec = "";
        private DateTime startTime;
        private TimeSpan endTime;
        private MStopwatch elapsed = new MStopwatch();
        private StringBuilder log = new StringBuilder();
        private int reprIndex = 0;
        private bool reproducing = false;
        private string[] reprLines;
        private Token[] reprTokens;
        private TimeSpan elOffset = TimeSpan.Zero;
        private System.Timers.Timer timerMain;
        private int[] seriesChanges = new int[2];
        private Game game;


        private float TimeScale
        {
            get
            {
                float ret = 0;
                if (trackBar1.InvokeRequired)
                {
                    trackBar1.Invoke((MethodInvoker)delegate { ret = trackBar1.Value / 100; });
                }
                else
                {
                    ret = trackBar1.Value / 100;
                }
                return ret;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.CurrentCulture = System.Globalization.CultureInfo.CurrentCulture;
            llblVersion.Text = "Versión " + Program.CurrentVersion;
            CheckUpdates();

            cbPort.Items.AddRange(SerialPort.GetPortNames());
            Program.serialPort.DataReceived += SerialPort_DataReceived;
            
            timerMain = new System.Timers.Timer();
            timerMain.Interval = 500;
            timerMain.Elapsed += timerMain_Tick;

            game = new Game();
            game.UpdateInterval = (int)nudUpdateDelay.Value;

            chkTest.Visible = Program.Debug;
        }

        public void CheckUpdates()
        {
            AutoUpdater.Start("http://pipe01.square7.ch/adl.xml", Program.VS ? new Version(0, 0, 0, 0) : Program.CurrentVersion);
        }

        private void timerMain_Tick(object sender, ElapsedEventArgs e)
        {
            //Tick();
        }

        private TimeSpan GetElapsed(bool original = false)
        {
            return (elapsed.Elapsed + elOffset).Multiply(original ? 1 : TimeScale);
        }

        private void ClearChart()
        {
            game.Clear();

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
            serialRec += Program.serialPort.ReadExisting().Replace("\r", "");

            ParseData(serialRec);
            serialRec = "";
        }

        public bool ParseData(string str, bool force = false, bool dolog = true)
        {
            if (Program.Debug)
                Console.WriteLine("Input: {0}", str.Replace("\n", "\\n"));

            string[] split = str.Split('\n');
            if (split.Length > 2)
            {
                for (int i = 0; i < split.Length - 1; i++)
                {
                    ParseData(split[i] + "\n");
                }
                return true;
            }
            else if (split.Length == 2)
            {
                if (force || (str.EndsWith("\n") && str.Length == 3))
                {
                    log.AppendFormat("{0} {1}", (int)GetElapsed().TotalMilliseconds, str);
                    int num1 = int.Parse(str[0].ToString());
                    int num2 = int.Parse(str[1].ToString());
                    if (num1 < 9)
                    {
                        series[num1 - 1] = num2 == 1;
                        return true;
                    }
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

                ChangeState(State.RealInputRunning);

                timer1.Start();
                timerMain.Start();

                game.Running = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            game.Running = false;
            Program.serialPort.Close();

            ChangeState(State.RealInputClosed);

            timer1.Stop();
            log.AppendFormat("{0} end", (int)GetElapsed().TotalMilliseconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ToggleConsole();
        }

        private void ChangeState(State state)
        {
            if (state != State.Default)
                ChangeState(State.Default);
            switch (state)
            {
                case State.Default:
                    btnAbrir.Enabled = true;
                    btnCerrar.Enabled = false;
                    btnAbrirArchivo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnLimpiar.Enabled = true;
                    gbReproduccion.Enabled = true;
                    cbPort.Enabled = true;
                    chkTest.Enabled = true;
                    chkTest.Checked = false;
                    btnAvanzarFinal.Enabled = false;
                    break;
                case State.RealInputRunning:
                    btnAbrir.Enabled = false;
                    btnCerrar.Enabled = true;
                    btnAbrir.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnLimpiar.Enabled = false;
                    gbReproduccion.Enabled = false;
                    cbPort.Enabled = false;
                    btnAvanzarFinal.Enabled = true;
                    break;
                case State.ReproductionRunning:
                    gbPuerto.Enabled = false;
                    btnAbrir.Enabled = false;
                    btnPlayPause.Enabled = true;
                    btnParar.Enabled = true;
                    gbReproduccion.Enabled = true;
                    chkTest.Checked = false;
                    chkTest.Enabled = false;
                    btnAvanzarFinal.Enabled = true;
                    break;
                case State.RealInputClosed:
                    gbReproduccion.Enabled = true;
                    btnPlayPause.Enabled = false;
                    btnParar.Enabled = false;
                    btnAbrirArchivo.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnAvanzarFinal.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.serialPort.IsOpen)
                Program.serialPort.Close();
            game.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Tick();
            //lblRend.Text = liveChart1.perfomance.ToString("0.0000") + " ms por frame";
        }

        private void Tick()
        {
            lblRend.Text = game.FPS.ToString("0.00") + " fps";

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
                    if (GetElapsed().Multiply(TimeScale) >= t.time)
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
                    lblTiempo.Text = GetElapsed(true).ToString(@"hh\:mm\:ss");
                });
            }

            UpdateCheckboxes();

            SerieValue[] vs = new SerieValue[8];
            for (int i = 0; i < series.Length; i++)
            {
                vs[i] = new SerieValue(series[i], elapsed.Elapsed);
            }

            game.AddTiles(vs);
            //liveChart1.AddOneSeries(series, elapsed.Elapsed);
        }

        private void UpdateCheckboxes()
        {
            /*int i = 0;
            foreach (var item in series)
            {
                var cbox = (panel1.Controls.Find("checkbox" + (i + 1), false).First() as CheckBox);
                cbox.Invoke((MethodInvoker)delegate { cbox.Checked = item; });
                i++;
            }*/
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

                ChangeState(State.ReproductionRunning);

                reproducing = true;
                elapsed.Restart();
                timer1.Start();
                game.Running = true;
                //timerMain.Start();
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
            ChangeState(State.Default);
        }

        private int pro = 0;
        private int step = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            int num1 = pro + 1;
            int num2 = game.Series[num1 - 1].Any() ?
                (game.Series[num1 - 1].Last().Value ? 0 : 1) : 1;
            
            if (pro >= 7) step = -1;
            else if (pro <= 0) step = 1;

            pro += step;

            ParseData(num1 + "" + num2 + "\n", true);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            timer2.Enabled = chkTest.Checked;
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
                elapsed.Offset += frm.Result;
            }
        }

        private void chkAnimChart_CheckedChanged(object sender, EventArgs e)
        {
            //liveChart1.Animate = chkAnimChart.Checked;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            game.Start(pictureBox1.Handle);
            ChangeState(State.Default);
        }

        private void gbOpciones_Enter(object sender, EventArgs e)
        {

        }

        private void nudUpdateDelay_ValueChanged(object sender, EventArgs e)
        {
            int v = (int)nudUpdateDelay.Value;
            timer1.Interval = v;
            game.UpdateInterval = v;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            game.Resize();
        }

        private void chkLowUse_CheckedChanged(object sender, EventArgs e)
        {
            game.SetLowUsage(chkLowUse.Checked);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            nudUpdateDelay.Value = 500 * (decimal)TimeScale;
        }

        private void btnAvanzarFinal_Click(object sender, EventArgs e)
        {
            if (reproducing)
            {
                SerieValue[] small = new SerieValue[8];
                for (int i = 0; i < reprTokens.Length; i++)
                {
                    var item = reprTokens[i];
                    small[item.num1 - 1] = new SerieValue(item.num2 == 1, item.time);
                    game.AddTiles(small);
                }
                elapsed.Offset = endTime - TimeSpan.FromSeconds(1);
                game.Running = false;
                game.ScrollToEnd();
            }
            else if (game.Series.Count > 0)
            {
                game.ScrollToEnd();
            }
        }

        private void llblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckUpdates();
        }

        private void btnActSerie_Click(object sender, EventArgs e)
        {
            cbPort.Items.Clear();
            cbPort.Items.AddRange(SerialPort.GetPortNames());
        }
    }

    public class MStopwatch : Stopwatch
    {
        public TimeSpan Offset { get; set; }

        public new TimeSpan Elapsed
        {
            get
            {
                return base.Elapsed + Offset;
            }
        }
    }
}
