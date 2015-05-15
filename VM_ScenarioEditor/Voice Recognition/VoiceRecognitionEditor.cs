using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMUtils;
using VMUtils.VoiceRecognition;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class VoiceRecognitionEditor : Form
    {
        private Guid _vreGuid;
        private static readonly JsonSerialiser<ImportedVoiceRecognitionScenario> Serialiser = new JsonSerialiser<ImportedVoiceRecognitionScenario>(); 
        private static readonly string VoiceRecoPath = ContentPhysicalPathUtils.GetRootContentFolder("voicerecoscenarios.js");
        public ImportedVoiceRecognitionScenario VoiceRecognitionScenariosState { get; set; }
        private readonly VoiceRecognitionFileWriter _vrfw = new VoiceRecognitionFileWriter(new Exporter<ImportedVoiceRecognitionScenario>(Serialiser), new VoiceRecognitionFileProcessor(new Importer<ImportedVoiceRecognitionScenario>(Serialiser), VoiceRecoPath), VoiceRecoPath, new VoiceRecognitionMerge());

        public VoiceRecognitionEditor(VoiceRecognitionScenario vs)
        {
            InitializeComponent();
            txttitle.Text = vs.QuestionTitle;
            txtAudioName.Text = vs.AudioPath;
            txtAuthor.Text = vs.Author;
            txtCopyrightNotice.Text = vs.CopyrightDisclaimer;
            
            foreach (var answer in vs.Answers)
            {
                lstAnswers.Items.Add(answer);
            }
            _vreGuid = vs.Id;
        }

        public VoiceRecognitionEditor()
        {
            _vreGuid = Guid.Empty;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var validationObject = CompileImportedVideoRecognitionScenario().Validation();
                if(validationObject.HasErrors)
                {

                    var sb = new StringBuilder();

                    foreach (var em in validationObject.ErrorMessages)
                    {
                        sb.Append(em);
                        sb.Append("\n");
                    }

                    MessageBox.Show(string.Format("There were Validation errors: \n {0}", sb), "Validation Errors");
                }
                else
                {
                    if (_vreGuid != Guid.Empty)
                    {
                        var previousObject =
                            VoiceRecognitionScenariosState.VoiceRecognitionScenarios.First(x => x.Id == _vreGuid);
                        VoiceRecognitionScenariosState.VoiceRecognitionScenarios.Remove(previousObject);
                    }

                    VoiceRecognitionScenariosState.VoiceRecognitionScenarios.Add(CompileImportedVideoRecognitionScenario());

                    _vrfw.Save(VoiceRecognitionScenariosState);
                    MessageBox.Show("Saved Scenario");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving Scenario");
            }

        }

        private VoiceRecognitionScenario CompileImportedVideoRecognitionScenario()
        {
            var voiceRecoScenario = new VoiceRecognitionScenario
            {
                Id = _vreGuid,
                Answers = AnswerCompilation(),
                Author = txtAuthor.Text,
                CopyrightDisclaimer = txtCopyrightNotice.Text,
                AudioPath = txtAudioName.Text,
                LastModified = DateTime.UtcNow,
                QuestionTitle = txttitle.Text,
            };

            if (voiceRecoScenario.Id == Guid.Empty)
            {
                voiceRecoScenario.Id = Guid.NewGuid();
            }

            return voiceRecoScenario;

        }

        private List<string> AnswerCompilation()
        {
            return lstAnswers.Items.Cast<string>().ToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstAnswers.SelectedIndex !=-1)
            {
                lstAnswers.Items.RemoveAt(lstAnswers.SelectedIndex);
            }
        }

        private void btnAddAnswers_Click(object sender, EventArgs e)
        {
            if (txtAnswerSingle.Text != "")
            {
                lstAnswers.Items.Add(txtAnswerSingle.Text);
                txtAnswerSingle.Text = "";
            }
        }

        private void btnSelectContentWizard_Click(object sender, EventArgs e)
        {
            var contentWizard = new ContentWizard(true, ContentType.Sound);
            var dr = contentWizard.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    txtAudioName.Text = contentWizard.SelectedFile;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("User Cancelled out of dialog");
                    break;
            }
        }

    }
}
