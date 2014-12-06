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
        private readonly List<VideoScenario> _videoScenarios;
        private readonly bool _hardCodedScenarios;

        public FrmSocialSimulatorChooser(List<VideoScenario> videoScenarios, bool hardCodedScenarios)
        {
            _videoScenarios = videoScenarios;
            _hardCodedScenarios = hardCodedScenarios;
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
            throw new NotImplementedException();
        }
    }
}
