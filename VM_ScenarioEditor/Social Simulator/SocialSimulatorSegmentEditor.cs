using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VMUtils.Exceptions;
using VM_Model;
using VM_ScenarioEditor.Validators;

namespace VM_ScenarioEditor.Social_Simulator
{
    public partial class SocialSimulatorSegmentEditor : Form
    {
        public bool Editing { get; set; }

        public List<Response> SegmentResponseState { get; set; }

        public Guid Id { get; set; }

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
            SegmentResponseState = scenario.Responses;
            Id = scenario.Id;
            foreach (var answer in scenario.Responses)
            {
                lstAnswers.Items.Add(answer.Answer);
            }

            PopulateNextPlayOrder();
            cboResponseType.SelectedIndex = 0;

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
            try
            {
                var segmentResponse = new Response
                {
                    Answer = txtAnswerSingle.Text,
                    ResponseType = (ResponseType)cboResponseType.SelectedIndex,
                    SocialSimulatorAction = GetNextSegment()
                };
                var scenarioValidation = new SocialScenarioValidation();
                var scenarioValidationresponse = scenarioValidation.ValidateSegmentResponse(segmentResponse);
                if (scenarioValidationresponse.HasErrors)
                {
                    throw new ValidationException(string.Format("Segment Invalid: {0}", string.Join(", ",scenarioValidationresponse.ErrorMessages.ToArray())));
                }
                lstAnswers.Items.Add(txtAnswerSingle.Text);
                SegmentResponseState.Add(segmentResponse);
                ClearSegementResponseForm();
                PopulateNextPlayOrder();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error!");
            }

        }

        private int GetNextSegment()
        {
            int nextSegment = 0;
            if (cboNextSegment.Text != "")
            {
                string comboText = cboNextSegment.Text.Substring(0, 5);
                int.TryParse(comboText, out nextSegment);
            }
            return nextSegment;
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
            var segment = new VideoSegment
            {
                Description = txtDescription.Text,
                PlayOrder = Convert.ToInt32(txtPlayOrder.Text),
                VideoPath = txtVideoName.Text,
                Responses = SegmentResponseState
            };

            if (Editing)
            {
                var oldSegment = SocialSimulatorFormState.SocialScenario.VideoSegment.FirstOrDefault(x => x.Id == Id);
                SocialSimulatorFormState.SocialScenario.VideoSegment.Remove(oldSegment);
            }

            SocialSimulatorFormState.SocialScenario.VideoSegment.Add(segment);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSegementResponseForm();
        }

        private void ClearSegementResponseForm()
        {
            txtAnswerSingle.Text = "";
            cboNextSegment.SelectedIndex = 0;
            cboResponseType.SelectedIndex = 0;
            lstAnswers.SelectedIndex = 0;
        }

        private void PopulateNextPlayOrder()
        {
            if (cboNextSegment.Items.Count > 0)
            {
                cboNextSegment.Items.Clear();
            }

            foreach (var segment in SocialSimulatorFormState.SocialScenario.VideoSegment)
            {
                cboNextSegment.Items.Add(segment.PlayOrder + " - " + segment.Description);
            }
        }
    }
}
