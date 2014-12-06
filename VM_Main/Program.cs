using System;
using System.Windows.Forms;
using VMUtils;

namespace VM_Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMainMenu(new Importer(), new Configuration()));
        }
    }
}
