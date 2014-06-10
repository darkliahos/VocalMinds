using System;
using System.Windows.Forms;

namespace VC_Main
{
    /* TODO
     * Complete Redo here, the main menu looks ugly
     */

    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnstartface_Click(object sender, EventArgs e)
        {
            Facerecognition frmone = new Facerecognition();
            frmone.Show();
        }

        private void btnvoicetones_Click(object sender, EventArgs e)
        {
            voicerecognition frmvce = new voicerecognition();
            frmvce.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnscrg_Click(object sender, EventArgs e)
        {
            //social simulator
            Simulator frmsos = new Simulator();
            frmsos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scribblepad scrb = new Scribblepad();
            scrb.Show();
        }
    }
}
