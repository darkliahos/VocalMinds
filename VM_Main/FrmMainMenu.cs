using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMUtils;
using VM_Model;

namespace VM_Main
{

    public partial class FrmMainMenu : Form
    {
        private readonly FileProcessor _fileProcessor;
        private readonly IImporter _importer;
        private readonly IConfiguration _configuration;
        private List<FaceRecognitionScenario> _frs;
        private List<VoiceRecognitionScenario> _vrs;
        private List<VideoScenario> _vs; 
        private readonly bool _hardcodedScenarios;

        public FrmMainMenu(IImporter importer, IConfiguration configuration)
        {
            InitializeComponent();
            _importer = importer;
            _configuration = configuration;
            _hardcodedScenarios = _configuration.ReadBooleanSetting("UseHardcodedScenarios");
            if (_configuration.ReadBooleanSetting("LoadScenarios"))
            {
                string path = _configuration.ReadSetting("PathOutput");
                _fileProcessor = new FileProcessor(_importer, path);
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
                _frs = await Task.FromResult<List<FaceRecognitionScenario>>(_fileProcessor.GetFRScenariosFromFile());
                _vrs = await Task.FromResult<List<VoiceRecognitionScenario>>(_fileProcessor.GetVRScenariosFromFile());
                _vs = await Task.FromResult<List<VideoScenario>>(_fileProcessor.GetVidWScenariosFromFile());
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

            FrmFaceRecognition faceReco = new FrmFaceRecognition(_frs, _hardcodedScenarios);
            faceReco.Show();
        }

        private void btnvoicetones_Click(object sender, EventArgs e)
        {
            if (_vrs == null)
            {
                _vrs = new List<VoiceRecognitionScenario>();
            }
            FrmVoiceRecognition frmvce = new FrmVoiceRecognition(_vrs, _hardcodedScenarios);
            frmvce.Show();
        }

        private void btnscrg_Click(object sender, EventArgs e)
        {
            FrmSocialSimulatorChooser scenarioChooser = new FrmSocialSimulatorChooser(_vs, _hardcodedScenarios);
            scenarioChooser.Show();
        }

    }
}
