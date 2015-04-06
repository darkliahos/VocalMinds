using System.Linq;
using System.Windows.Forms;
using VM_Model;
using VM_ScenarioEditor.Social_Simulator;

namespace VM_ScenarioEditor
{
    public partial class SocialSimulatorEditor : Form
    {
        public SocialSimulatorEditor()
        {
            InitializeComponent();

            if (SocialSimulatorFormState.EditingState)
            {
                txttitle.Text = SocialSimulatorFormState.SocialScenario.FriendlyName;
                txtAuthor.Text = SocialSimulatorFormState.SocialScenario.Author;
                foreach (var segment in SocialSimulatorFormState.SocialScenario.VideoSegment)
                {
                    lstSegments.Items.Add(segment.Description);
                }
            }
        }

        public ImportedSocialScenarios State { get; set; }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //TODO: Final Save
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var ssse = new SocialSimulatorSegmentEditor();
            ssse.Show();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var segementName = lstSegments.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(segementName))
            {
                var segement = SocialSimulatorFormState.SocialScenario.VideoSegment.FirstOrDefault(x => x.Description == segementName);
                var ssse = new SocialSimulatorSegmentEditor(segement);
                ssse.Show();
            }
        }
    }
}
