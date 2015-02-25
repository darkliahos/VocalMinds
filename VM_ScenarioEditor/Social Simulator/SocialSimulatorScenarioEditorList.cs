using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Interfaces;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class SocialSimulatorScenarioEditorList : Form
    {
        private readonly Logger _logger;
        private readonly IImporter<ImportedSocialScenarios> _importer;
        private readonly IFileProcessor<SocialScenario, ImportedSocialScenarios> _processor;
        private readonly IExporter<ImportedSocialScenarios> _exporter;
        private readonly IMerge<ImportedSocialScenarios> _merge;
        private Dictionary<string, SocialScenario> _sendict;
        private ImportedSocialScenarios _srs;

        public SocialSimulatorScenarioEditorList(Logger logger, IImporter<ImportedSocialScenarios> importer, IFileProcessor<SocialScenario, ImportedSocialScenarios> processor, IExporter<ImportedSocialScenarios> exporter, IMerge<ImportedSocialScenarios> merge)
        {
            InitializeComponent();
            _logger = logger;
            _importer = importer;
            _processor = processor;
            _exporter = exporter;
            _merge = merge;
            _sendict = new Dictionary<string, SocialScenario>();
            string socialPath = PhysicalPathUtils.GetRootContentFolder("Socialscenarios.js");
            //TODO #27 Social Simulator Writer
            //writer = new SocialSimulatorWriter(_exporter, _processor, faceRecopath, _merge);
            Task<bool> sucessfulLoading = LoadTasks();
            LoadScenariosToForm();
        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                _srs = await Task.FromResult<ImportedSocialScenarios>(_processor.LoadScenarioObject());
                Task.WaitAll();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void LoadScenariosToForm()
        {
            lstScenarios.Items.Clear();
            _sendict.Clear();
            foreach (var socialScenario in _srs.SocialScenario)
            {
                lstScenarios.Items.Add(string.Format("{0} - {1}", socialScenario.Id, socialScenario.FriendlyName));
                _sendict.Add(string.Format("{0} - {1}", socialScenario.Id, socialScenario.FriendlyName), socialScenario);
            }
        }

    }
}
