using System;
using System.Windows.Forms;
using VM_Model;

namespace VM_Main
{
/*
 Some quick notes:
 * Axwindowsmediaplayer is the name of the control
 * the first button submits what the user just said 
 (But hopefully I will be able to optomise it so the user just 
  speaks and the program automaitcally takes it on board, it will have 
  to be an on initinailise event)
 * the second button repeats what the simulation just said
 * the third button kicks off the simulator
 * Added voice recognition
 * Added an array that calls parts of the simulation
 */
    public partial class FrmSocialSimulator : Form
    {
        private readonly VideoScenario _videoScenario;

        public FrmSocialSimulator(VideoScenario videoScenario)
        {
            _videoScenario = videoScenario;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
