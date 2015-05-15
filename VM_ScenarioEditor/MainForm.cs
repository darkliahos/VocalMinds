using System;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM_FormUtils.Extensions;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class MainForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        string faceRecopath = ContentPhysicalPathUtils.GetRootContentFolder("facerecoscenarios.js");
        string voiceRecopath = ContentPhysicalPathUtils.GetRootContentFolder("voicerecoscenarios.js");
        string socialSimualtorpath = ContentPhysicalPathUtils.GetRootContentFolder("Socialscenarios.js");

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
            var _socialImporter = new Importer<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>());
            var fr = new SocialSimulatorScenarioEditorList(Logger, _socialImporter, new SocialSimulatorFileProcessor(_socialImporter, socialSimualtorpath), new Exporter<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>()), new SocialScenarioMerge());
            fr.OpenFormInMdi(this);
        }

        private void voiceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IImporter<ImportedVoiceRecognitionScenario> voiceImporter = new Importer<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>());
            var vr = new VoiceRecognitionScenarioEditorList(Logger, new VoiceRecognitionFileProcessor(voiceImporter, voiceRecopath), new Exporter<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>()), new VoiceRecognitionMerge());
            vr.OpenFormInMdi(this);
        }

        private void contentImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new ContentWizard(false, ContentType.Other).OpenFormInMdi(this);
            }
            catch (Exception error)
            {
                MessageBox.Show("Content Wizard Load Failed", error.Message);
            }

        }
    }
}
