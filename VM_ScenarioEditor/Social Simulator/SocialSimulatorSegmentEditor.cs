using System;
using System.Windows.Forms;
using VM_Model;

namespace VM_ScenarioEditor.Social_Simulator
{
    public partial class SocialSimulatorSegmentEditor : Form
    {
        public bool Editing { get; set; }

        public SocialSimulatorSegmentEditor()
        {
            InitializeComponent();
        }

        public SocialSimulatorSegmentEditor(VideoSegment scenario)
        {
            InitializeComponent();
            txtVideoName.Text = scenario.VideoPath;
            txtPlayOrder.Text = scenario.PlayOrder.ToString();
            txtDescription.Text = scenario.Description;
            foreach (var answer in scenario.Responses)
            {
                lstAnswers.Items.Add(answer);
            }
        }

        private void btnSelectContentWizard_Click(object sender, EventArgs e)
        {
            var contentWizard = new ContentWizard(true);
            var dr = contentWizard.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    txtVideoName.Text = contentWizard.SelectedFile;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("User Cancelled out of dialog");
                    break;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstAnswers.SelectedIndex != -1)
            {
                lstAnswers.Items.RemoveAt(lstAnswers.SelectedIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
