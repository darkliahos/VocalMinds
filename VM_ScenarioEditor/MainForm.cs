using System;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Extensions;

namespace VM_ScenarioEditor
{
    public partial class MainForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public MainForm()
        {
            InitializeComponent();
        }

        private void faceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fr = new FaceRecongitionScenarioEditorList(Logger, new Importer());
            fr.OpenFormInMdi(this);
        }
    }
}
