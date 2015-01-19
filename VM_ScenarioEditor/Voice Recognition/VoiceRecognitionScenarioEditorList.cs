﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM_Model;
using VM_ScenarioEditor.Properties;

namespace VM_ScenarioEditor
{
    public partial class VoiceRecognitionScenarioEditorList : Form
    {
        private readonly Logger _logger;
        private readonly IImporter<ImportedVoiceRecognitionScenario> _importer = new VoiceRecognitionImporter(serialiser);
        private readonly IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> _processor;
        private readonly IExporter<ImportedVoiceRecognitionScenario> _exporter;
        private readonly IMerge<ImportedVoiceRecognitionScenario> _merge;
        private Dictionary<string, VoiceRecognitionScenario> _vrsdict;
        private readonly IFileWriter<ImportedVoiceRecognitionScenario> writer;
        private ImportedVoiceRecognitionScenario _vrs;
        private static ISerialiser<ImportedVoiceRecognitionScenario> serialiser = new JsonSerialiser<ImportedVoiceRecognitionScenario>();

        public VoiceRecognitionScenarioEditorList(Logger logger, IImporter<ImportedVoiceRecognitionScenario> importer, IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> processor, IExporter<ImportedVoiceRecognitionScenario> exporter, IMerge<ImportedVoiceRecognitionScenario> merge)
        {
            _logger = logger;
            _importer = importer;
            _processor = processor;
            _exporter = exporter;
            _merge = merge;
            string voiceRecoPath = PathUtils.GetRootContentFolder("voicerecoscenarios.js");
            writer = new VoiceRecognitionFileWriter(_exporter, _processor, voiceRecoPath, _merge);
            _vrsdict = new Dictionary<string, VoiceRecognitionScenario>();
            Task<bool> sucessfulLoading = LoadTasks();
            InitializeComponent();
            LoadScenariosToForm();

        }

        private void LoadScenariosToForm()
        {
            lstScenarios.Items.Clear();
            _vrsdict.Clear();
            foreach (var voiceRecognitionScenario in _vrs.VoiceRecognitionScenarios)
            {
                lstScenarios.Items.Add(string.Format("{0} - {1}", voiceRecognitionScenario.Id, voiceRecognitionScenario.QuestionTitle));
                _vrsdict.Add(string.Format("{0} - {1}", voiceRecognitionScenario.Id, voiceRecognitionScenario.QuestionTitle), voiceRecognitionScenario);
            }
        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                _vrs = await Task.FromResult<ImportedVoiceRecognitionScenario>(_processor.LoadScenarioObject());
                Task.WaitAll();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            VoiceRecognitionScenario vs;
            if (_vrsdict.TryGetValue(lstScenarios.SelectedItem.ToString(), out vs))
            {
                var vre = new VoiceRecognitionEditor(vs);
                OpenForm(vre);
            }
            else
            {
                _logger.Error("Failed to get Dictionary Scenario");
                MessageBox.Show("Scenario may corrupted or malformed", Resources.ScenarioLoadHeader);
            }
        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            var vre = new VoiceRecognitionEditor();
            OpenForm(vre);
        }


        private void OpenForm(VoiceRecognitionEditor freInstance)
        {
            freInstance.VoiceRecognitionScenariosState = _vrs;
            freInstance.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            writer.LockFile();
            var inputObject = _processor.RefreshScenarioObject();
            inputObject.VoiceRecognitionScenarios.RemoveAll(x => x.Id == Guid.Parse(lstScenarios.SelectedItem.ToString().Remove(37)));
            writer.Save(inputObject);
            Task<bool> sucessfulLoading = LoadTasks();
            LoadScenariosToForm();
        }
    }


}
