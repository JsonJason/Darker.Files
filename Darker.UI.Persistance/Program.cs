using System;
using System.Windows.Forms;

namespace Darker.UI.Persistance
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            App app = new PersistanceAppFactory().Create();
            app = new ShowAppFactory().Create();
            app.Start();
        }
    }
}
