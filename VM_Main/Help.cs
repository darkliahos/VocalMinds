using System;
using System.Windows.Forms;

namespace VM_Main
{
    /*TODO
     * Find out where the hell did the HTML Help go?
     */
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
