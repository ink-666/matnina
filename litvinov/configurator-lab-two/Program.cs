using System;
using System.Windows.Forms;

namespace PcConfigurator
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
