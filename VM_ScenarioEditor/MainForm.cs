using System;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Extensions;
using VMUtils.FaceRecognition;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class MainForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        string path = PathUtils.GetRootContentFolder("facerecoscenarios.js");
        public MainForm()
        {
            InitializeComponent();
        }

        private void faceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _faceImporter = new FaceRecognitionImporter(new JsonSerialiser<ImportedFaceRecognitionScenario>());
            var fr = new FaceRecongitionScenarioEditorList(Logger, _faceImporter, new FaceRecognitionProcessor(_faceImporter, path));
            fr.OpenFormInMdi(this);
        }
    }
}
