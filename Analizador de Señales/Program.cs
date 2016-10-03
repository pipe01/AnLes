using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Analizador_de_Señales
{
    static class Program
    {
        public static SerialPort serialPort;
        public static Form1 form1;
        public static bool Debug = false;
        public static bool VS = false;
        public static Version CurrentVersion;
        private static bool console = true;
        private static IntPtr consoleHandle;
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
            VS = System.Diagnostics.Debugger.IsAttached;
            Debug = VS || args.Length > 0 && args.Contains("debug");
            CurrentVersion = Assembly.GetEntryAssembly().GetName().Version;
            consoleHandle = GetConsoleWindow();

            if (!Debug)
            {
                ToggleConsole();
            }
            Console.WriteLine("AnLes by pipe01");
            Console.WriteLine("Versión " + CurrentVersion);
            
            serialPort = new SerialPort();

            bool loop = true;

            /*Task.Run(() => 
            {
                while (loop)
                {
                    string input = Console.ReadLine();
                    Console.WriteLine(">" + input);
                }
            });*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);

            loop = false;
        }

        public static void ToggleConsole()
        {
            console = !console;
            if (console)
            {
                ShowWindow(consoleHandle, SW_SHOW);
            }
            else
            {
                ShowWindow(consoleHandle, SW_HIDE);
            }
        }
    }
}
