using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    /* TODO
     * Complete Redo here, the main menu looks ugly
     */

    public partial class Form1 : Form
    {
        public Form1()
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
            sim frmsos = new sim();
            frmsos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scribblepad scrb = new Scribblepad();
            scrb.Show();
        }
    }
}
