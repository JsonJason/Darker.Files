using System;
using System.Windows.Forms;
using Darker.UI.Persistance.Overwatch;

namespace Darker.UI.Persistance
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            App app =  CreateAppFactory().Create();
            app.Start();
        }


        static AppFactory CreateAppFactory()
        {
            return new ComicsAppFactory();
            return new OwAppFactory();
          //  return new ShowAppFactory();
          //  return new PersistanceAppFactory();
        }

    }
}
