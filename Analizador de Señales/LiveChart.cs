using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Analizador_de_Señales
{
    public partial class LiveChart : UserControl
    {
        public LiveChart()
        {
            InitializeComponent();
        }

        public int start, count, rendercount, offset;
        public List<float> timesBetweenFrames = new List<float>();
        public float perfomance = 0.0f;
        public double scale = 0.5f;
        public Series[] Series { get; private set; } = new Series[8];
        public bool RealTime { get; set; } = true;
        public bool Animate { get; set; } = true;
        

        private Color[] colors = new Color[8];
        private Random r = new Random();
        private bool watchcoll = true;
        private int hoverIndex;
        private Brush color1, color2, hcolor1, hcolor2;
        private Point mousePos = Point.Empty;

        private int tilewidth
        {
            get { return (int)(30 * scale); }
        }
        private const int tileheight = 30;

        private int maxtile
        {
            get { return this.Width / (tilewidth + 1); }
        }

        private void LiveChart_Load(object sender, EventArgs e)
        {
            Color c2 = addColor(Color.LightGray, 25);
             color1 = new SolidBrush(Color.LightGray);
             color2 = new SolidBrush(c2);
            hcolor1 = new SolidBrush(addColor(Color.LightGray, 15));
            hcolor2 = new SolidBrush(addColor(c2, 15));

            for (int i = 0; i < 8; i++)
            {
                Series[i] = new Series();
                Series[i].values.CollectionChanged += Lseries_CollectionChanged;

                /*for (int x = 0; x < 1000; x++)
                {
                    series[i].values.Add(r.NextDouble() > 0.5f);
                }*/

                colors[i] = RandomColor();
            }
            count = 0;
            rendercount = this.Width / tilewidth + 2;

            this.MouseWheel += LiveChart_MouseWheel;
        }

        private void LiveChart_MouseWheel(object sender, MouseEventArgs e)
        {
            int s = e.Delta > 0 ? 1 : -1;
            if (Control.ModifierKeys == Keys.Control && scale > 0)
            {
                scale += s * 0.05f;
                if (scale <= 0)
                    scale = 0.05f;

                ScrollToEnd();
                this.Refresh();
            }
            else if (Control.ModifierKeys == Keys.None)
            {
                ScrollOne(s);

                this.Refresh();
            }
        }

        private void ScrollOne(int step, bool addrender = true, bool force = false)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { ScrollOne(step, addrender); });
            }
            else
            {
                if (!(Series[0].values.Count > maxtile && !force))
                {
                    Console.WriteLine("scroll " + step);
                    start += step;
                    offset += step;
                    this.Refresh();
                }
            }
        }

        private void Lseries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int precount = count;
            count = Series[0].values.Count;
            
            start = count - maxtile;
            ScrollOne(-1);

            if (watchcoll)
            {
                this.Invoke((MethodInvoker)delegate { this.Refresh(); });
            }
        }

        private void LiveChart_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        Stopwatch sw = new Stopwatch();
        public void Draw(Graphics g)
        {
            sw.Restart();
            rendercount = this.Width / (tilewidth + 1) + 1;

            /*bool highlighted = false;
            if (Series.First().values.Any() && hoverIndex > -1)
            {
                int si = mousePos.Y / (tileheight + 1);
                if (si < 8)
                {
                    highlighted = true;
                }
            }*/

            int st = count - rendercount;
            st = st < 0 ? 0 : st; 

            bool a = false;
            for (int vi = (st % 2 == 0 ? st : st - 1); vi < count && vi < start + rendercount; vi++)
            {
                Brush b;
                if (hoverIndex == vi)
                {
                    b = a ? hcolor1 : hcolor2;
                }
                else
                {
                    b = a ? color1 : color2;
                }
                a = !a;
                g.FillRectangle(b, (vi + offset) * (tilewidth + 1), 0, tilewidth, this.Height);
            }

            for (int i = 0; i < 8; i++)
            {
                Series s = Series[i];
                List<RectangleF> rects = new List<RectangleF>();
                Color c = colors[i];
                Brush b = new SolidBrush(c);
                Brush bh = new SolidBrush(addColor(c, 25, 25, 25));

                //st = 0;
                for (int vi = st; vi < count && vi < start + rendercount - 1; vi++)
                {
                    if (vi > start && s.values.Count > 0) // && vi > s.values.Count
                    {
                        int relvi = vi - start;
                        if (s.values[vi])
                        {
                            //rects.Add(new Rectangle(relvi * (width + 1), i * (30 + 1), width, 30));
                            g.FillRectangle(vi == hoverIndex ? bh : b, new RectangleF(vi * (tilewidth + 1), i * (tileheight + 1), tilewidth, tileheight));
                        }
                    }
                }
                //if (rects.Any())
                    //g.FillRectangles(new SolidBrush(c), rects.ToArray());
            }

            if (Series.First().values.Any() && hoverIndex > -1)
            {
                int si = mousePos.Y / (tileheight + 1);
                if (si < 8 && Series[si].times.Any())
                {
                    g.DrawString(Series[si].times[hoverIndex > Series[si].times.Count ? 0 : hoverIndex].ToString(@"hh\:mm\:ss"),
                        this.Font, Brushes.Black, Point.Add(mousePos, new Size(3, 4)));
                }
            }
            timesBetweenFrames.Add((sw.ElapsedTicks * (1f / 10000000)) * 1000f);
            sw.Reset();
        }

        public void Clear()
        {
            count = 0;
            rendercount = 0;
            start = 0;

            //Clear series
            Task.Run(() =>
            {
                foreach (var item in Series)
                {
                    item.values.Clear();
                    item.times.Clear();
                }
            });
        }

        private Color addColor(Color c, int r, int g, int b)
        {
            int nr = c.R + r;
            nr = nr > 255 ? 255 : nr;
            int ng = c.G + g;
            ng = ng > 255 ? 255 : ng;
            int nb = c.B + b;
            nb = nb > 255 ? 255 : nb;

            return Color.FromArgb(c.A, nr, ng, nb);
        }
        private Color addColor(Color c, int all)
        {
            return addColor(c, all, all, all);
        }


        private Point startP;
        private bool drag;
        private int acum;
        private void LiveChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                startP = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (ModifierKeys == Keys.None)
                    ScrollToEnd();
                else if (ModifierKeys == Keys.Control)
                {
                    scale = 0.5f;
                    this.Refresh();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
            }
        }

        private void picSeries_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                int diff = e.Location.X - startP.X;
                int step = diff / (tilewidth + 1);
                start += step;
                acum += diff;

                if (!RealTime)
                {
                    int c = acum / tilewidth;
                    if (c != 0)
                    {
                        if (c < 0)
                            rendercount -= c * 2;
                        else
                            rendercount -= c;
                        acum = 0;
                        this.Refresh();
                    }
                }
            }
            //else if (e.Button == MouseButtons.None)
            //{
                hoverIndex = e.X / (tilewidth + 1);
                if (hoverIndex > Series.First().values.Count - 1)
                    hoverIndex = -1;

                mousePos = e.Location;

                this.Refresh();

            //}
        }

        private void picSeries_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;

            this.Cursor = Cursors.Cross;
        }

        private void LiveChart_Resize(object sender, EventArgs e)
        {
            
        }

        private void picSeries_Resize(object sender, EventArgs e)
        {
            
        }

        private void timerPerf_Tick(object sender, EventArgs e)
        {
            if (timesBetweenFrames.Count > 0)
            {
                perfomance = Average(timesBetweenFrames.ToArray());
                timesBetweenFrames.Clear();
            }
        }

        private float Average(params float[] values)
        {
            float total = 0.0f;
            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }
            return total / values.Length;
        }

        private Color RandomColor()
        {
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        public void ScrollToEnd()
        {
            start = count - maxtile + 1;
        }

        public void AddOneSeries(TimeSpan elapsed, bool scroll = true)
        {
            watchcoll = false;
            for (int i = 0; i < 8; i++)
            {
                if (Series[i].values.Any())
                {
                    Series[i].times.Add(elapsed);
                    Series[i].values.Add(Series[i].values[Series[i].values.Count - 1]);
                }
                else
                    Series[i].values.Add(false);
            }
            rendercount++;
            watchcoll = true;

            if (scroll && start + count > maxtile)
                ScrollOne(-1);
        }
        public void AddOneSeries(bool on, int snum, TimeSpan elapsed, bool scroll = true)
        {
            watchcoll = false;
            for (int i = 0; i < 8; i++)
            {
                Series[i].times.Add(elapsed);
                Series[i].values.Add(snum == i ? on :
                  (Series[i].values.Count == 0 ? false :
                     Series[i].values[Series[i].values.Count - 1]));
            }
            rendercount++;
            watchcoll = true;

            if (scroll && start + count > maxtile)
                ScrollOne(-1);
        }
        public void AddOneSeries(bool[] state, TimeSpan elapsed, bool scroll = true)
        {
            watchcoll = false;
            for (int i = 0; i < 8; i++)
            {
                Series[i].times.Add(elapsed);
                Series[i].values.Add(state[i]);
            }
            rendercount++;
            watchcoll = true;

            if (scroll && start + count > maxtile)
                ScrollOne(-1);
        }
    }

    public class Series
    {

        public struct Value
        {
            public bool v;
            public TimeSpan ts;
        }

        public List<TimeSpan> times = new List<TimeSpan>();
        public ObservableCollection<bool> values = new ObservableCollection<bool>();
    }
}
