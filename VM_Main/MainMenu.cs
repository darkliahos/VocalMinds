using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMUtils;
using VM_Model;

namespace VM_Main
{
    /* TODO
     * Complete Redo here, the main menu looks ugly
     */

    public partial class MainMenu : Form
    {
        private readonly FileProcessor _fileProcessor;
        private readonly Importer _importer;

        public MainMenu()
        {
            InitializeComponent();
            _fileProcessor = new FileProcessor(_importer, "");
            Task<bool> sucessfulLoading = LoadTasks();



        }

        private async Task<bool> LoadTasks()
        {
            List<FaceRecognitionScenario> frs = await Task.FromResult<List<FaceRecognitionScenario>>(_fileProcessor.GetImportedFRScenariosFromFile());
            Task.WaitAll();
            return true;
        }

        private void btnstartface_Click(object sender, EventArgs e)
        {
            List<FaceRecognitionScenario> fce = new List<FaceRecognitionScenario>();
            Facerecognition faceReco = new Facerecognition(fce);
            faceReco.Show();
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
    }
}
