using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM_Model;

namespace VM_Main
{
    public partial class FrmSocialSimulatorChooser : Form
    {
        private readonly List<SocialScenario> _videoScenarios;

        public FrmSocialSimulatorChooser(List<SocialScenario> videoScenarios)
        {
            _videoScenarios = videoScenarios;
            InitializeComponent();
            GetListOfScenarios();
        }

        private void GetListOfScenarios()
        {
            foreach (var videoScenario in _videoScenarios)
            {
                lstScenarios.Items.Add(videoScenario.FriendlyName);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string selectedScenarios = lstScenarios.SelectedItem.ToString();
            var loadedScenario =_videoScenarios.FirstOrDefault(i => i.FriendlyName == selectedScenarios);
            if (loadedScenario == null)
            {
                throw new ArgumentNullException("Scenario does not exist");                
            }
            var socialSimulator = new FrmSocialSimulator(loadedScenario);
            socialSimulator.Show();
        }
    }
}
