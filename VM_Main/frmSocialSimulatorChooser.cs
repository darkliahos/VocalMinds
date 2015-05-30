using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VMUtils.Interfaces;
using VM_Model;

namespace VM_Main
{
    public partial class FrmSocialSimulatorChooser : Form
    {
        private readonly List<SocialScenario> _videoScenarios;
        private readonly IContentPathUtils _contentWizardUtils;

        public FrmSocialSimulatorChooser(List<SocialScenario> videoScenarios, IContentPathUtils contentWizardUtils)
        {
            _videoScenarios = videoScenarios;
            _contentWizardUtils = contentWizardUtils;
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
            this.Hide();
            string selectedScenarios = lstScenarios.SelectedItem.ToString();
            var loadedScenario =_videoScenarios.FirstOrDefault(i => i.FriendlyName == selectedScenarios);
            if (loadedScenario == null)
            {
                throw new ArgumentNullException("Scenario does not exist");                
            }
            var socialSimulator = new FrmSocialSimulator(loadedScenario, _contentWizardUtils);
            socialSimulator.Show();
            this.Close();
        }
    }
}
