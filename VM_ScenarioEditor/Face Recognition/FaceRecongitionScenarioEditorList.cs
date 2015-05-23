using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VM_FormUtils;
using VM_Model;
using VM_ScenarioEditor.Properties;

namespace VM_ScenarioEditor
{
    public partial class FaceRecongitionScenarioEditorList : Form
    {
        private readonly Logger _logger;
        private ImportedFaceRecognitionScenario _frs;
        private Dictionary<string, FaceRecognitionScenario> _frsdict;
        private readonly IImporter<ImportedFaceRecognitionScenario> _importer;
        private readonly IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> _processor;
        private readonly IExporter<ImportedFaceRecognitionScenario> _exporter;
        private readonly IMerge<ImportedFaceRecognitionScenario> _merge;
        private readonly IContentPathUtils _contentPathUtils;
        private readonly IFileWriter<ImportedFaceRecognitionScenario> writer;

        public FaceRecongitionScenarioEditorList(Logger logger, IImporter<ImportedFaceRecognitionScenario> importer, IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> processor, IExporter<ImportedFaceRecognitionScenario> exporter, IMerge<ImportedFaceRecognitionScenario> merge, IContentPathUtils contentPathUtils)
        {
            InitializeComponent();
            _logger = logger;
            _importer = importer;
            _processor = processor;
            _exporter = exporter;
            _merge = merge;
            _contentPathUtils = contentPathUtils;

            string faceRecopath = _contentPathUtils.GetRootContentFolder("facerecoscenarios.js");
            _logger.Debug(string.Format("Face Recognition Scenarios will load from : {0}", faceRecopath));
            writer = new FaceRecognitionFileWriter(_exporter, _processor, faceRecopath, _merge);
            _frsdict = new Dictionary<string, FaceRecognitionScenario>();
            Task<bool> sucessfulLoading = LoadTasks();
            LoadScenariosToForm();

        }

        private void LoadScenariosToForm()
        {
            lstScenarios.Items.Clear();
            _frsdict.Clear();
            foreach (var faceRecognitionScenario in _frs.FaceRecognitionScenarios)
            {
                lstScenarios.Items.Add(string.Format("{0} - {1}", faceRecognitionScenario.Id, faceRecognitionScenario.QuestionTitle));
                _frsdict.Add(string.Format("{0} - {1}", faceRecognitionScenario.Id, faceRecognitionScenario.QuestionTitle), faceRecognitionScenario);
            }
        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                _frs = await Task.FromResult<ImportedFaceRecognitionScenario>(_processor.LoadScenarioObject());
                Task.WaitAll();
                return true;
            }
            catch (Exception error)
            {
                _logger.Error(error.Message);
                return false;
            }
        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            var fre = new FaceRecognitionEditor();
            OpenForm(fre);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FaceRecognitionScenario fs;
            if (_frsdict.TryGetValue(lstScenarios.SelectedItem.ToString(), out fs))
            {
                var fre = new FaceRecognitionEditor(fs, _contentPathUtils);
                OpenForm(fre);
            }
            else
            {
                _logger.Error("Failed to get Dictionary Scenario");
                MessageBox.Show("Scenario may corrupted or malformed", Resources.ScenarioLoadHeader);
            }

        }

        private void OpenForm(FaceRecognitionEditor freInstance)
        {
            freInstance.FaceRecognitionScenariosState = _frs;
            freInstance.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            writer.LockFile();
            var inputObject = _processor.RefreshScenarioObject();
            inputObject.FaceRecognitionScenarios.RemoveAll(x => x.Id == Guid.Parse(lstScenarios.SelectedItem.ToString().Remove(37)));
            writer.Save(inputObject);
            Task<bool> sucessfulLoading = LoadTasks();
            LoadScenariosToForm();

        }
    }
}
