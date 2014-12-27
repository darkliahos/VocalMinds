using System;
using System.Windows.Forms;
using VM_Model;

namespace VM_ScenarioEditor
{
    public partial class FaceRecognitionEditor : Form
    {
        private Guid _freGuid;//TODO: This variable will be used when Editing a preexisting Scenario we need to ensure we delete the old version and use the new version
        public FaceRecognitionEditor()
        {
            InitializeComponent();
        }

        public FaceRecognitionEditor(FaceRecognitionScenario fs)
        {
            InitializeComponent();
            txttitle.Text = fs.QuestionTitle;
            txtImageName.Text = fs.ImageName;
            txtAuthor.Text = fs.Author;
            txtCopyrightNotice.Text = fs.CopyrightDisclaimer;
            lstAnswers.DataSource = fs.Answers;
            _freGuid = fs.Id;
        }
    }
}
