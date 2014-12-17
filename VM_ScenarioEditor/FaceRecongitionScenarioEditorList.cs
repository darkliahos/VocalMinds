using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_ScenarioEditor
{
    public partial class FaceRecongitionScenarioEditorList : Form
    {
        public FaceRecongitionScenarioEditorList()
        {
            InitializeComponent();
        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            var fre = new FaceRecognitionEditor();
            fre.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var fre = new FaceRecognitionEditor(Guid.Parse(lstScenarios.SelectedValue.ToString()));
            fre.Show();
        }
    }
}
