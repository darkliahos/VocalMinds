using System;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM_FormUtils;
using VM_FormUtils.Extensions;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class MainForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        readonly ContentPhysicalPathUtils _contentPathUtils = new ContentPhysicalPathUtils();
        private readonly string faceRecopath;
        private readonly string voiceRecopath;
        private readonly string socialSimualtorpath;


        public MainForm()
        {
            InitializeComponent();
            faceRecopath = _contentPathUtils.GetRootContentFolder("facerecoscenarios.js");
            voiceRecopath = _contentPathUtils.GetRootContentFolder("voicerecoscenarios.js");
            socialSimualtorpath = _contentPathUtils.GetRootContentFolder("Socialscenarios.js");
        }

        private void faceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _faceImporter = new Importer<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>());
            var fr = new FaceRecongitionScenarioEditorList(Logger, _faceImporter, new FaceRecognitionFileProcessor(_faceImporter, faceRecopath), new Exporter<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>()), new FaceRecognitionMerge(), _contentPathUtils);
            fr.OpenFormInMdi(this);
        }

        private void socialSimulatorScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _socialImporter = new Importer<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>());
            var fr = new SocialSimulatorScenarioEditorList(Logger, _socialImporter, new SocialSimulatorFileProcessor(_socialImporter, socialSimualtorpath), new Exporter<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>()), new SocialScenarioMerge(), _contentPathUtils);
            fr.OpenFormInMdi(this);
        }

        private void voiceRecognitionScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IImporter<ImportedVoiceRecognitionScenario> voiceImporter = new Importer<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>());
            var vr = new VoiceRecognitionScenarioEditorList(Logger, new VoiceRecognitionFileProcessor(voiceImporter, voiceRecopath), new Exporter<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>()), new VoiceRecognitionMerge(), _contentPathUtils);
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
