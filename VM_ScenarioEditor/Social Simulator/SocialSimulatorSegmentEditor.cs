using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VMUtils.Exceptions;
using VM.Model;
using VM_ScenarioEditor.Validators;

namespace VM_ScenarioEditor
{
    public partial class SocialSimulatorSegmentEditor : Form
    {
        public bool Editing { get; set; }

        public List<Response> SegmentResponseState { get; set; }

        public Guid SegmentId { get; set; }

        public SocialSimulatorSegmentEditor()
        {
            InitializeComponent();
            PopulateNextPlayOrder();
            cboResponseType.SelectedIndex = 0;
            SegmentResponseState = new List<Response>();
        }

        public SocialSimulatorSegmentEditor(VideoSegment scenario)
        {
            InitializeComponent();
            txtPlayOrder.Text = scenario.PlayOrder.ToString();
            txtDescription.Text = scenario.Description;
            SegmentResponseState = scenario.Responses;
            SegmentId = scenario.Id;
            foreach (var answer in scenario.Responses)
            {
                lstAnswers.Items.Add(answer.Answer);
            }

            PopulateNextPlayOrder();
            cboResponseType.SelectedIndex = 0;

        }

        private void btnSelectContentWizard_Click(object sender, EventArgs e)
        {
            var contentWizard = new ContentWizard(true, ContentType.Video);
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
                var scenarioValidationresponse = SocialScenarioValidation.ValidateSegmentResponse(segmentResponse);
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
                var digitPattern =  new Regex(@"^\d+");
                var mc = digitPattern.Matches(cboNextSegment.Text);
                // We only need to get the first match group from the Regex as we assume others are junk
                int.TryParse(mc[0].ToString(), out nextSegment);
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
            if (SegmentId == Guid.Empty)
            {
                SegmentId = Guid.NewGuid();
            }

            var segment = new VideoSegment
            {
                Id = SegmentId,
                Description = txtDescription.Text,
                PlayOrder = Convert.ToInt32(txtPlayOrder.Text),
                Responses = SegmentResponseState
            };

            var validate = SocialScenarioValidation.ValidateSegment(segment);
            if (!validate.HasErrors)
            {
                if (Editing)
                {
                    var oldSegment = SocialSimulatorFormState.SocialScenario.VideoSegment.FirstOrDefault(x => x.Id == SegmentId);
                    SocialSimulatorFormState.SocialScenario.VideoSegment.Remove(oldSegment);
                }

                SocialSimulatorFormState.SocialScenario.VideoSegment.Add(segment);
                MessageBox.Show("Segment Saved");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //this.DialogResult = DialogResult.Cancel;;
                MessageBox.Show(string.Format("Segment Invalid: {0}",
                    string.Join(", ", validate.ErrorMessages.ToArray())));
            }
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
