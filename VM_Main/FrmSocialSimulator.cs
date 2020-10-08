using System;
using System.Windows.Forms;
using VMUtils.Interfaces;
using VM.Model;

namespace VM_Main
{
    public partial class FrmSocialSimulator : Form
    {
        private readonly SocialScenario _socialScenario;
        private readonly IContentPathUtils _contentWizardUtils;
        private readonly Story _selectedStory;
        private int _currentPlayOrder = 1;
        private VideoSegment _videoSegment;

        public FrmSocialSimulator(SocialScenario socialScenario, IContentPathUtils contentWizardUtils, Story selectedStory)
        {
            _socialScenario = socialScenario;
            _contentWizardUtils = contentWizardUtils;
            _selectedStory = selectedStory;
            InitializeComponent();
            SetUpVideoSegment();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void SetUpVideoSegment()
        {
            foreach (var videoSegment in _socialScenario.VideoSegment)
            {
                if (videoSegment.PlayOrder == ModelConstants.PlayOrderStory)
                {
                    var story = new FrmStory(_selectedStory);
                    story.Show();
                    break;
                }

                if (videoSegment.PlayOrder == ModelConstants.PlayOrderStory)
                {
                    var scribblePad = new FrmScribblePad();
                    scribblePad.Show();
                    break;
                }

                if (videoSegment.PlayOrder == _currentPlayOrder)
                {
                    _videoSegment = videoSegment;
                }

                if (videoSegment.PlayOrder == 0)
                {
                    // Stops endless scenarios
                    //TODO Really need a better way of finishing
                    MessageBox.Show("Well done on completing this scenario");
                    this.Close();
                }
            }
        }


        private void AnswerHandler(string response)
        {
            foreach (var res in _videoSegment.Responses)
            {
                if (response == res.Answer)
                {
                    _currentPlayOrder = res.SocialSimulatorAction;
                    MessageBox.Show("Well Done");//TODO: Better way of letting the user know if they did well?
                    SetUpVideoSegment();
                    break;
                }
            }
        }

    }
}
