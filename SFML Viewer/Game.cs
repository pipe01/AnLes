using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SFML_Viewer
{
    public class Game
    {
        #region Private variables
        private RenderWindow window;
        private IntPtr container;
        private View v;
        private Color windowColor = new Color(200, 200, 200);
        private List<RectangleShape> rects = new List<RectangleShape>();
        private Random rand = new Random();
        private Clock clock = new Clock();
        private Time oldTime, newTime;
        private float deltaTime;
        private Vector2u lastSize;
        private Vector2i mousePos, absMousePos, dragStart;
        private bool drag = false;
        private bool catchMouse = true;
        private Text textHoverTime = new Text();
        private Font arialFont;
        private RectangleShape startRect;
        private RectangleShape brect;
        private RectangleShape rect;
        private bool Exit = false;
        private float zoomScale = 1.0f;

        private int maxTiles { get { return (int)(window.GetView().Size.X / (IntTileWidth + 1)) + 2; } }

        private int visibleTileCount
        {
            get
            {
                v = window.GetView();
                int ret = Series.Count - firstVisibleIndex;
                ret = ret > maxTiles ? maxTiles : ret;
                return ret;
            }
        }

        private int firstVisibleIndex
        {
            get
            {
                return (int)((v.Center.X - v.Size.X / 2) / (IntTileWidth + 1f)); // + 1f);
            }
        }

        private float IntTileWidth { get { return TileWidth * ZoomScale; } }
        #endregion

        #region Public properties
        public float TileWidth { get; set; } = 15;
        public float TileHeight { get; set; } = 30;

        public Color EvenColor { get; set; } = new Color(160, 160, 160);
        public Color OddColor { get; set; } = new Color(180, 180, 180);
        public Color HighColor { get; set; } = new Color(210, 210, 210);

        public bool Running { get; set; } = false;

        public Series Series { get; private set; }

        public float ScrollStep { get; set; } = 2f;

        public float FPS { get { return 1000f / deltaTime; } }

        public float ZoomScale {
            get { return zoomScale; }
            set {
                zoomScale = value;
                brect = new RectangleShape(new Vector2f(IntTileWidth, v.Size.Y));
                rect = new RectangleShape(new Vector2f(IntTileWidth, TileHeight));
            }
        }

        public int UpdateInterval;
        #endregion

        public delegate void LoadDelegate();
        public event LoadDelegate Load;
        private void OnLoad()
        {
            if (Load != null)
                Load();
        }

        public void Start(IntPtr containerHandle)
        {
            //System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.SustainedLowLatency;
            container = containerHandle;

            Task.Run(() => 
            {
                Setup();
                while (window.IsOpen && !Exit)
                {
                    GameLoop();
                }
                Console.WriteLine("Exit game");
            });
        }

        private void Setup()
        {
            Series = new Series();

            ContextSettings contextSettings = new ContextSettings();
            contextSettings.AntialiasingLevel = 0;
            
            //window = new RenderWindow(new VideoMode(800, 600), "SFML Works!", Styles.Default, contextSettings);
            window = new RenderWindow(container, contextSettings);
            window.KeyPressed += Window_KeyPressed;
            window.MouseMoved += Window_MouseMoved;
            window.MouseButtonPressed += Window_MouseButtonPressed;
            window.MouseButtonReleased += Window_MouseButtonReleased;
            window.MouseWheelMoved += Window_MouseWheelMoved;
            window.SetActive(false);

            lastSize = window.Size;

            v = new View(GetWindowCenter(), window.Size.ToVector2f());
            window.SetView(v);

            for (int i = 0; i < 8; i++)
            {
                Series.Add(new Serie());

                byte[] c = new byte[3];
                rand.NextBytes(c);
                Series[i].TileColor = new Color(c[0], c[1], c[2]);
                Series[i].TileColorHL = AddColor(Series[i].TileColor, 30);
            }

            arialFont = new Font("./arial.ttf");

            textHoverTime.Font = arialFont;
            textHoverTime.CharacterSize = 13;
            textHoverTime.Color = Color.Black;
            textHoverTime.Style = Text.Styles.Regular;

            startRect = new RectangleShape(new Vector2f(TileWidth, window.Size.Y));
            startRect.FillColor = Color.White;
            startRect.Position = new Vector2f(-TileWidth - 1, 0);

            brect = new RectangleShape(new Vector2f(IntTileWidth, v.Size.Y));

            rect = new RectangleShape(new Vector2f(IntTileWidth, TileHeight));

            SetLowUsage(true);

            OnLoad();
        }

        private void Window_MouseWheelMoved(object sender, MouseWheelEventArgs e)
        {
            ZoomScale += e.Delta * 0.1f;
        }

        private void GameLoop()
        {
            oldTime = newTime;
            newTime = clock.ElapsedTime;
            deltaTime = (newTime.AsMicroseconds() - oldTime.AsMicroseconds()) / 1000f;

            if (!Exit && window.IsOpen)
                window.DispatchEvents();

            absMousePos = Mouse.GetPosition(window);
            mousePos = absMousePos;
            mousePos.X += (int)(window.GetView().Center.X - window.Size.X / 2);

            window.Clear(windowColor);

            int hoverIndex = (int)(mousePos.X / (IntTileWidth + 1));
            bool hover = mousePos.X >= 0 && mousePos.X <= window.Size.X && mousePos.Y >= 0 && mousePos.Y <= window.Size.Y;

            window.Draw(startRect);

            bool even = false;
            for (int i = Math.Max(ToEven(firstVisibleIndex - 1), 0); i < Math.Min(firstVisibleIndex + maxTiles, Series[0].Count); i++)
            {
                Color prev = even ? EvenColor : OddColor;
                brect.FillColor = i == hoverIndex && hover ? HighColor : prev;
                brect.Position = new Vector2f(i * (IntTileWidth + 1), 0);
                window.Draw(brect);
                even = !even;
            }

            for (int i = 0; i < 8; i++)
            {
                float y = i * (TileHeight + 1);

                Serie cur = Series[i];
                for (int d = firstVisibleIndex; d < firstVisibleIndex + maxTiles + 1; d++)
                {
                    if (d >= 0 && cur.Count > d)
                    {
                        rect.Position = new Vector2f(d * (IntTileWidth + 1), y);

                        if (d == hoverIndex && hover)
                            rect.FillColor = cur.TileColorHL;
                        else
                            rect.FillColor = cur.TileColor;

                        if (cur[d].Value)
                            window.Draw(rect);
                    }
                }
                cur = null;
            }

            textHoverTime.Position = new Vector2f(absMousePos.X + 3f + (v.Center.X - window.Size.X / 2), absMousePos.Y + 3);
            textHoverTime.DisplayedString = (Series.Count > hoverIndex && hoverIndex >= 0) ? Series.GetTime(hoverIndex).ToString(@"hh\:mm\:ss") : "";
            window.Draw(textHoverTime);
            
            if (Running && visibleTileCount >= maxTiles)
            {
                float step = (float)((IntTileWidth + 1) / ((double)UpdateInterval / deltaTime));
                MoveView(step);
            }

            if (firstVisibleIndex > Series.Count - 1)
            {
                CircleShape s = new CircleShape(10, 3);
                s.FillColor = Color.Black;
                s.Rotation = 270;
                for (int i = 0; i < 2; i++)
                {
                    s.Position = new Vector2f(v.Center.X - window.Size.X / 2 + 15, (window.Size.Y / 4) * (i == 0 ? 1 : 3));
                    window.Draw(s);
                }
                s.Dispose();
            }
            window.Display();
        }


        public void SetLowUsage(bool on)
        {
            if (on)
            {
                window.SetFramerateLimit(60);
            }
            else
            {
                window.SetFramerateLimit(uint.MaxValue);
            }
        }

        public void ScrollToEnd()
        {
            v = window.GetView();
            v.Center = GetWindowCenter() + new Vector2f((Series[0].Count - maxTiles / 2) * (IntTileWidth + 1), 0);
            window.SetView(v);
        }

        private Vector2f GetWindowCenter()
        {
            return new Vector2f(window.Size.X / 2, window.Size.Y / 2);
        }

        private int ToEven(int n)
        {
            return n % 2 == 0 ? n : n - 1;
        }

        private void MoveView(float x, float y = 0)
        {
            v = window.GetView();
            v.Center = new Vector2f(v.Center.X + x, v.Center.Y + y);
            window.SetView(v);
        }

        /*public void AddRandomTiles(int count = 1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Series[i].Add(rand.Next(0, 2) == 1);
                }
            }
        }*/


        private void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                drag = false;
                window.SetMouseCursorVisible(true);
            }
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                dragStart = Mouse.GetPosition(window);
                drag = true;
                //window.SetMouseCursorVisible(false);
            }
        }

        private void Window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            absMousePos = Mouse.GetPosition(window);
            mousePos = absMousePos;
            mousePos.X += (int)(window.GetView().Center.X - window.Size.X / 2);

            if (drag && catchMouse)
            {
                int dif = dragStart.X - absMousePos.X;
                MoveView(dif);
                dragStart = absMousePos;


                if (absMousePos.X >= window.Size.X)
                {
                    Mouse.SetPosition(new Vector2i(1, absMousePos.Y), window);
                    MoveView(-window.Size.X);
                }
                else if (absMousePos.X <= 0)
                {
                    Mouse.SetPosition(new Vector2i((int)window.Size.X - 1, absMousePos.Y), window);
                    MoveView(window.Size.X);
                }
            }
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Left:
                    break;
                default:
                    break;
            }
        }


        public void AddTiles(IEnumerable<SerieValue> values)
        {
            if (values.Count() == 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    Series[i].Add(values.ElementAt(i));
                }
            }
        }

        private Color AddColor(Color c, byte r, byte g, byte b)
        {
            return new Color((byte)(c.R < 255 - r ? c.R + r : 255), (byte)(c.G < 255 - g ? c.G + g : 255), (byte)(c.B < 255 - b ? c.B + b : 255));
        }
        private Color AddColor(Color c, byte all)
        {
            return AddColor(c, all, all, all);
        }

        public void Clear()
        {
            Series.ForEach((o) => { o.Clear(); });

            v = window.GetView();
            v.Center = GetWindowCenter();
            window.SetView(v);
        }

        public void Close()
        {
            Exit = true;
            window.Close();
        }

        public void Resize()
        {
            try
            {
                v = window.GetView();
                //v.Center = new Vector2f(v.Center.X - (window.Size.X - lastSize.X), v.Center.Y);
                v.Size = new Vector2f(window.Size.X, v.Size.Y);
                window.SetView(v);

                lastSize = window.Size;
            } catch (NullReferenceException) { }
        }

    }

    public class Series : List<Serie>
    {
        public Series() : base(8) { }

        public new int Count
        {
            get
            {
                int ret = 0;
                for (int i = 0; i < base.Count; i++)
                {
                    if (base[i].Count > ret)
                    {
                        ret = base[i].Count;
                    }
                }
                return ret;
            }
        }

        public TimeSpan GetTime(int index)
        {
            TimeSpan ret = TimeSpan.Zero;
            for (int i = 0; i < base.Count; i++)
            {
                if (base[i][index].Time > ret)
                    ret = base[i][index].Time;
            }
            return ret;
        }
    }

    public class Serie : List<SerieValue>
    {
        public Color TileColor, TileColorHL;
    }

    public struct SerieValue
    {
        public bool Value;
        public TimeSpan Time;

        public SerieValue(bool val, TimeSpan time)
        {
            this.Value = val;
            this.Time = time;
        }
    }

    public static class Extensions
    {
        public static Vector2f ToVector2f(this Vector2u v)
        {
            return new Vector2f(v.X, v.Y);
        }

        public static Vector2u ToVector2u(this Vector2f v)
        {
            return new Vector2u((uint)v.X, (uint)v.Y);
        }

        public static TimeSpan Multiply(this TimeSpan t, float factor)
        {
            return TimeSpan.FromTicks((long)(t.Ticks * factor));
        }
    }
}
