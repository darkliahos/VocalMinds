﻿using System;
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
        private readonly IImporter _importer;
        private List<FaceRecognitionScenario> frs;

        public MainMenu(IImporter importer)
        {
            InitializeComponent();
            _importer = importer;
            if (Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["LoadScenarios"]))
            {
                string path = System.Configuration.ConfigurationSettings.AppSettings["PathOutput"].ToString();
                _fileProcessor = new FileProcessor(_importer, path);
                Task<bool> sucessfulLoading = LoadTasks();

                if (!sucessfulLoading.Result)
                {
                    MessageBox.Show("File Load failed");
                }
            }
        }

        private async Task<bool> LoadTasks()
        {
            try
            {
                frs =
                    await
                    Task.FromResult<List<FaceRecognitionScenario>>(_fileProcessor.GetImportedFRScenariosFromFile());
                Task.WaitAll();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnstartface_Click(object sender, EventArgs e)
        {
            if(frs == null)
            {
                frs = new List<FaceRecognitionScenario>();
            }
            
            Facerecognition faceReco = new Facerecognition(frs);
            faceReco.Show();
        }

        private void btnvoicetones_Click(object sender, EventArgs e)
        {
            voicerecognition frmvce = new voicerecognition();
            frmvce.Show();
        }

        private void btnscrg_Click(object sender, EventArgs e)
        {
            //social simulator
            Simulator frmsos = new Simulator();
            frmsos.Show();
        }
    }
}
