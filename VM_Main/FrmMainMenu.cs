using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMUtils;
using VMUtils.Interfaces;
using VM_Model;

namespace VM_Main
{

    public partial class FrmMainMenu : Form
    {
        private readonly SocialSimulatorFileProcessor _socialSimulatorFileProcessor;
        private readonly VoiceRecognitionFileProcessor _voiceRecognitionFileProcessor;
        private readonly FaceRecognitionProcessor _faceRecognitionProcessor;
        
        private readonly IImporter<ImportedScenarios> _importer;
        private readonly IImporter<ImportedFaceRecognitionScenario> _faceimporter;
        private readonly IConfiguration _configuration;
        private List<FaceRecognitionScenario> _frs;
        private List<VoiceRecognitionScenario> _vrs;
        private List<VideoScenario> _vs; 

        public FrmMainMenu(IConfiguration configuration)
        {
            InitializeComponent();
            _importer = new Importer();
            _faceimporter = new FaceRecognitionImporter(new JsonSerialiser<ImportedFaceRecognitionScenario>());
            _configuration = configuration;
            if (_configuration.ReadBooleanSetting("LoadScenarios"))
            {
                string path = PathUtils.GetRootContentFolder("scenarios.js");
                string faceRecopath = PathUtils.GetRootContentFolder("facerecoscenarios.js");
                _voiceRecognitionFileProcessor = new VoiceRecognitionFileProcessor(_importer, path);
                _socialSimulatorFileProcessor = new SocialSimulatorFileProcessor(_importer, path);
                _faceRecognitionProcessor = new FaceRecognitionProcessor(_faceimporter, faceRecopath);
                Task<bool> sucessfulLoading = LoadTasks();

                if (!sucessfulLoading.Result)
                {
                    MessageBox.Show("File Load failed");
                }
            }
        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                _frs = await Task.FromResult<List<FaceRecognitionScenario>>(_faceRecognitionProcessor.LoadScenarioFromFile());
                _vrs = await Task.FromResult<List<VoiceRecognitionScenario>>(_voiceRecognitionFileProcessor.LoadScenarioFromFile());
                _vs = await Task.FromResult<List<VideoScenario>>(_socialSimulatorFileProcessor.LoadScenarioFromFile());
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
            if(_frs == null)
            {
                _frs = new List<FaceRecognitionScenario>();
            }

            FrmFaceRecognition faceReco = new FrmFaceRecognition(_frs);
            faceReco.Show();
        }

        private void btnvoicetones_Click(object sender, EventArgs e)
        {
            if (_vrs == null)
            {
                _vrs = new List<VoiceRecognitionScenario>();
            }
            FrmVoiceRecognition frmvce = new FrmVoiceRecognition(_vrs);
            frmvce.Show();
        }

        private void btnscrg_Click(object sender, EventArgs e)
        {
            FrmSocialSimulatorChooser scenarioChooser = new FrmSocialSimulatorChooser(_vs);
            scenarioChooser.Show();
        }

    }
}
