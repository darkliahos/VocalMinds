using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Interfaces;
using VM_Model;
using VM_ScenarioEditor.Properties;

namespace VM_ScenarioEditor
{
    public partial class FaceRecongitionScenarioEditorList : Form
    {
        private readonly Logger _logger;
        private List<FaceRecognitionScenario> _frs;
        private Dictionary<string, FaceRecognitionScenario> _frsdict; 
        private readonly FileProcessor _fileProcessor;
        private readonly IImporter _importer;

        public FaceRecongitionScenarioEditorList(Logger logger, IImporter importer)
        {
            InitializeComponent();
            _logger = logger;
            _importer = importer;
            _frsdict = new Dictionary<string, FaceRecognitionScenario>();
            string path = PathUtils.GetRootContentFolder("scenarios.js");
            _fileProcessor = new FileProcessor(_importer, path);
            Task<bool> sucessfulLoading = LoadTasks();
            LoadScenariosToForm();

        }

        private void LoadScenariosToForm()
        {
            foreach (var faceRecognitionScenario in _frs)
            {
                lstScenarios.Items.Add(string.Format("{0} - {1}", faceRecognitionScenario.Id, faceRecognitionScenario.QuestionTitle));
                _frsdict.Add(string.Format("{0} - {1}", faceRecognitionScenario.Id, faceRecognitionScenario.QuestionTitle), faceRecognitionScenario);
            }
            _frs.Clear();//Purge Original Loading List
        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                _frs = await Task.FromResult<List<FaceRecognitionScenario>>(_fileProcessor.GetFRScenariosFromFile());
                Task.WaitAll();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            var fre = new FaceRecognitionEditor();
            fre.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FaceRecognitionScenario fs;
            if (_frsdict.TryGetValue(lstScenarios.SelectedItem.ToString(), out fs))
            {
                var fre = new FaceRecognitionEditor(fs);
                fre.Show();
            }
            else
            {
                _logger.Error("Failed to get Dictionary Scenario");
                MessageBox.Show("Scenario may corrupted or malformed", Resources.ScenarioLoadHeader);
            }
               

        }
    }
}
