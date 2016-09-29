using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Analizador_de_Señales
{
    static class Program
    {
        public static SerialPort serialPort;
        public static Form1 form1;
        public static bool Debug = false;
        //public static Version CurrentVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Debug = args.Length > 0 && args.Contains("debug");

            if (!Debug)
                Debug = System.Diagnostics.Debugger.IsAttached;

            if (!Debug)
            {
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
            }
            Console.WriteLine("AnLes by pipe01");
            Console.WriteLine(new MStopwatch().Elapsed.ToString());

            serialPort = new SerialPort();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
