using System;
using System.Linq;
using System.Windows.Forms;
using VMUtils;
using VM_ScenarioEditor;

namespace VM_Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!args.Any())
            {
                Application.Run(new FrmMainMenu(new AppConfiguration()));
            }
            else if (args[0] == "EDITOR")
            {
                Application.Run(new MainForm());
            }

        }
    }
}
