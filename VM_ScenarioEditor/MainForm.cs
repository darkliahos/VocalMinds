using System;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Extensions;
using VM_Model;

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
            var fr = new FaceRecongitionScenarioEditorList(Logger, new FaceRecognitionImporter(new JsonSerialiser<ImportedFaceRecognitionScenario>()));
            fr.OpenFormInMdi(this);
        }
    }
}
