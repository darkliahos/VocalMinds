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
        private readonly IFileWriter<ImportedSocialScenarios> writer;

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
            writer = new SocialSimulatorFileWriter(_exporter, _processor, socialPath, _merge);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SocialScenario ss;
            if (_sendict.TryGetValue(lstScenarios.SelectedItem.ToString(), out ss))
            {
                SocialScenarioFormLoad(ss, true);
            }
            else
            {
                _logger.Error("Failed to get Dictionary Scenario");
                MessageBox.Show("Scenario may corrupted or malformed", "Social Scenario Failed to load");
            }
        }

        private void OpenForm(SocialSimulatorEditor freInstance)
        {
            freInstance.State = _srs;
            freInstance.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            writer.LockFile();
            var inputObject = _processor.RefreshScenarioObject();
            inputObject.SocialScenario.RemoveAll(x => x.Id == Guid.Parse(lstScenarios.SelectedItem.ToString().Remove(37)));
            writer.Save(inputObject);
            Task<bool> sucessfulLoading = LoadTasks();
            LoadScenariosToForm();
        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            SocialScenarioFormLoad(new SocialScenario(), false);
        }

        private void SocialScenarioFormLoad(SocialScenario socialScenario, bool editingState)
        {
            SocialSimulatorFormState.SocialScenario = socialScenario;
            SocialSimulatorFormState.EditingState = editingState;
            var vre = new SocialSimulatorEditor(_importer, _processor, _exporter, _merge);
            OpenForm(vre);
        }

    }
}
