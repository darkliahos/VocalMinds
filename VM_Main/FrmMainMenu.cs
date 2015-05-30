using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM_FormUtils;
using VM_Model;

namespace VM_Main
{

    public partial class FrmMainMenu : Form
    {
        private readonly SocialSimulatorFileProcessor _socialSimulatorFileProcessor;
        private readonly VoiceRecognitionFileProcessor _voiceRecognitionFileProcessor;
        private readonly FaceRecognitionFileProcessor _faceRecognitionFileProcessor;

        private readonly IImporter<ImportedSocialScenarios> _importer;
        private readonly IImporter<ImportedFaceRecognitionScenario> _faceimporter;
        private readonly IConfiguration _configuration;
        private List<FaceRecognitionScenario> _frs;
        private List<VoiceRecognitionScenario> _vrs;
        private List<SocialScenario> _vs;
        private IImporter<ImportedVoiceRecognitionScenario> _videoimporter;
        private IContentPathUtils _contentPathUtils;

        public FrmMainMenu(IConfiguration configuration)
        {
            InitializeComponent();
            _importer = new Importer<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>());
            _videoimporter = new Importer<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>());
            _faceimporter = new Importer<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>());
            _configuration = configuration;
            _contentPathUtils = new ContentPhysicalPathUtils();
            string path = _contentPathUtils.GetRootContentFolder("Socialscenarios.js");
            string faceRecopath = _contentPathUtils.GetRootContentFolder("facerecoscenarios.js");
            string voiceRecopath = _contentPathUtils.GetRootContentFolder("voicerecoscenarios.js");
            _voiceRecognitionFileProcessor = new VoiceRecognitionFileProcessor(_videoimporter, voiceRecopath);
            _socialSimulatorFileProcessor = new SocialSimulatorFileProcessor(_importer, path);
            _faceRecognitionFileProcessor = new FaceRecognitionFileProcessor(_faceimporter, faceRecopath);
            Task<bool> sucessfulLoading = LoadTasks();

            if (!sucessfulLoading.Result)
            {
                MessageBox.Show("File Load failed");
            }

        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                _frs = await Task.FromResult<List<FaceRecognitionScenario>>(_faceRecognitionFileProcessor.LoadScenarioFromFile());
                _vrs = await Task.FromResult<List<VoiceRecognitionScenario>>(_voiceRecognitionFileProcessor.LoadScenarioFromFile());
                _vs = await Task.FromResult<List<SocialScenario>>(_socialSimulatorFileProcessor.LoadScenarioFromFile());
                Task.WaitAll();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnstartface_Click(object sender, EventArgs e)
        {
            if (_frs == null)
            {
                _frs = new List<FaceRecognitionScenario>();
            }

            FrmFaceRecognition faceReco = new FrmFaceRecognition(_frs, _contentPathUtils);
            faceReco.Show();
        }

        private void btnvoicetones_Click(object sender, EventArgs e)
        {
            if (_vrs == null)
            {
                _vrs = new List<VoiceRecognitionScenario>();
            }
            FrmVoiceRecognition frmvce = new FrmVoiceRecognition(_vrs, _contentPathUtils);
            frmvce.Show();
        }

        private void btnscrg_Click(object sender, EventArgs e)
        {
            FrmSocialSimulatorChooser scenarioChooser = new FrmSocialSimulatorChooser(_vs, _contentPathUtils);
            scenarioChooser.Show();
        }

    }
}
