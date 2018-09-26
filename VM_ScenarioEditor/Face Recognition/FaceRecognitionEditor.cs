using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VM_FormUtils;
using VM.Model;

namespace VM_ScenarioEditor
{
    public partial class FaceRecognitionEditor : Form
    {
        private readonly IContentPathUtils _contentPathUtils;
        private readonly Guid _freGuid;

        private static readonly ISerialiser<ImportedFaceRecognitionScenario> Serialiser = new JsonSerialiser<ImportedFaceRecognitionScenario>();
        private static readonly IMerge<ImportedFaceRecognitionScenario> Merge = new FaceRecognitionMerge(); 
        private static readonly IImporter<ImportedFaceRecognitionScenario> Importer = new Importer<ImportedFaceRecognitionScenario>(Serialiser);
        private static string _faceRecopath;
        private readonly FaceRecognitionFileWriter _fre;
        public ImportedFaceRecognitionScenario FaceRecognitionScenariosState { get; set; }
        public FaceRecognitionEditor()
        {
            _contentPathUtils = new ContentPhysicalPathUtils();
            _faceRecopath = _contentPathUtils.GetRootContentFolder("facerecoscenarios.js");
            _fre = new FaceRecognitionFileWriter(new Exporter<ImportedFaceRecognitionScenario>(Serialiser), new FaceRecognitionFileProcessor(Importer, _faceRecopath), _contentPathUtils.GetRootContentFolder("facerecoscenarios.js"), Merge);

            InitializeComponent();
            _freGuid = Guid.Empty;
        }

        public FaceRecognitionEditor(FaceRecognitionScenario fs, IContentPathUtils contentPathUtils)
        {
            _contentPathUtils = contentPathUtils;
            _faceRecopath = _contentPathUtils.GetRootContentFolder("facerecoscenarios.js");
            _fre = new FaceRecognitionFileWriter(new Exporter<ImportedFaceRecognitionScenario>(Serialiser), new FaceRecognitionFileProcessor(Importer, _faceRecopath), _contentPathUtils.GetRootContentFolder("facerecoscenarios.js"), Merge);

            InitializeComponent();
            txttitle.Text = fs.QuestionTitle;
            txtImageName.Text = fs.ImageName;
            txtAuthor.Text = fs.Author;
            txtCopyrightNotice.Text = fs.CopyrightDisclaimer;

            foreach (var answer in fs.Answers)
            {
                lstAnswers.Items.Add(answer);
            }
            _freGuid = fs.Id;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            var validationObject = CompileImportedFaceRecognitionScenario().Validation();
            if (validationObject.HasErrors)
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
                if (_freGuid != Guid.Empty)
                {
                    var previousObject = FaceRecognitionScenariosState.FaceRecognitionScenarios.First(x => x.Id == _freGuid);
                    FaceRecognitionScenariosState.FaceRecognitionScenarios.Remove(previousObject);
                }

                FaceRecognitionScenariosState.FaceRecognitionScenarios.Add(CompileImportedFaceRecognitionScenario());

                _fre.Save(FaceRecognitionScenariosState);
                MessageBox.Show("Saved Scenario");
                this.Close();
            }

        }

        private FaceRecognitionScenario CompileImportedFaceRecognitionScenario()
        {

            var faceRecoScenario = new FaceRecognitionScenario
            {
                Id = _freGuid,
                Answers = AnswerCompilation(),
                Author = txtAuthor.Text,
                CopyrightDisclaimer = txtCopyrightNotice.Text,
                ImageName = txtImageName.Text,
                LastModified = DateTime.UtcNow,
                QuestionTitle = txttitle.Text,
            };

            if (faceRecoScenario.Id == Guid.Empty)
            {
                faceRecoScenario.Id = Guid.NewGuid();
            }

            return faceRecoScenario;

        }

        private List<string> AnswerCompilation()
        {
            return lstAnswers.Items.Cast<string>().ToList();
        }

        private void btnAddAnswers_Click(object sender, EventArgs e)
        {
            if (txtAnswerSingle.Text != "")
            {
                lstAnswers.Items.Add(txtAnswerSingle.Text);
                txtAnswerSingle.Text = "";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstAnswers.SelectedIndex != 0)
            {
                lstAnswers.Items.RemoveAt(lstAnswers.SelectedIndex);
            }
        }

        private void btnSelectContentWizard_Click(object sender, EventArgs e)
        {
            var contentWizard = new ContentWizard(true, ContentType.Image);
            var dr = contentWizard.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    txtImageName.Text = contentWizard.SelectedFile;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("User Cancelled out of dialog");
                    break;
            }

        }
    }
}
