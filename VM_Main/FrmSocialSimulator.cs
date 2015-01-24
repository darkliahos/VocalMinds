using System;
using System.Windows.Forms;
using VM_Model;

namespace VM_Main
{
    public partial class FrmSocialSimulator : Form
    {
        private readonly SocialScenario _socialScenario;
        private int _currentPlayOrder = 1;
        private string _currentUri = "";
        private VideoSegment _videoSegment;

        public FrmSocialSimulator(SocialScenario socialScenario)
        {
            _socialScenario = socialScenario;
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
                    var story = new FrmStory();
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
                    _currentUri = videoSegment.VideoPath;
                    _videoSegment = videoSegment;
                }
            }
        }

        private void btnPlay_Click(object sender, System.EventArgs e)
        {
            visualSocialInterface.URL = _currentUri;
            visualSocialInterface.Ctlcontrols.play();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            AnswerHandler(txtWordbox.Text);
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
