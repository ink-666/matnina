using WinFormsApp2;

namespace WinFormsApp2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}