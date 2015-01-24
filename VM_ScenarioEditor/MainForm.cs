using System;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Extensions;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class MainForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        string faceRecopath = PathUtils.GetRootContentFolder("facerecoscenarios.js");
        string voiceRecopath = PathUtils.GetRootContentFolder("voicerecoscenarios.js");

        public MainForm()
        {
            InitializeComponent();
        }

        private void faceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _faceImporter = new Importer<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>());
            var fr = new FaceRecongitionScenarioEditorList(Logger, _faceImporter, new FaceRecognitionFileProcessor(_faceImporter, faceRecopath), new Exporter<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>()), new FaceRecognitionMerge());
            fr.OpenFormInMdi(this);
        }

        private void socialSimulatorScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Functionality Not Yet Implemented");
        }

        private void voiceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IImporter<ImportedVoiceRecognitionScenario> voiceImporter = new Importer<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>());
            var vr = new VoiceRecognitionScenarioEditorList(Logger, new VoiceRecognitionFileProcessor(voiceImporter, voiceRecopath), new Exporter<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>()), new VoiceRecognitionMerge());
            vr.OpenFormInMdi(this);
        }
    }
}
