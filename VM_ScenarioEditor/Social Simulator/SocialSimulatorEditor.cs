using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Windows.Forms;
using VM_Model;
using VM_ScenarioEditor.Social_Simulator;

namespace VM_ScenarioEditor
{
    public partial class SocialSimulatorEditor : Form
    {
        private List<VideoSegment> segments;
        public SocialSimulatorEditor(SocialScenario socialScenario)
        {
            InitializeComponent();
            txttitle.Text = socialScenario.FriendlyName;
            txtAuthor.Text = socialScenario.Author;
            segments = socialScenario.VideoSegment;
            foreach (var segment in socialScenario.VideoSegment)
            {
                lstSegments.Items.Add(segment.Description);
            }
        }

        public SocialSimulatorEditor()
        {
            InitializeComponent();
        }

        public ImportedSocialScenarios State { get; set; }

        private void btnSave_Click(object sender, System.EventArgs e)
        {

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
                var segement = segments.FirstOrDefault(x => x.Description == segementName);
                var ssse = new SocialSimulatorSegmentEditor(segement);
                ssse.Show();
            }
        }
    }
}
