using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VMUtils;
using VMUtils.ContentWizard;
using VMUtils.Extensions;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.Validators;
using VMUtils.VoiceRecognition;
using VM_FormUtils;
using VM_FormUtils.Extensions;
using VM.Model;

namespace VM_ScenarioEditor
{
    public partial class ContentWizard : Form
    {
        private readonly ContentType _contentType;
        private readonly IContentPathUtils _contentPathUtils;
        public string RootFolder;
        private readonly ContentWizardValidator _validator;
        private readonly WizardContentFinder _wizardContentFinder;

        public string SelectedFile { get; set; }

        public ContentWizard(bool showSelectedButton, ContentType contentType)
        {
            _contentType = contentType;
            InitializeComponent();

            btnSelected.Visible = showSelectedButton;
            _contentPathUtils = new ContentPhysicalPathUtils();
            _validator = new ContentWizardValidator(new AppConfiguration());
            RootFolder = _contentPathUtils.GetRootContentFolder("");
            lstContentTypes.PopulateFromEnumerable(_contentPathUtils.GetSubDirectoryList(RootFolder).ReplaceStringInList(RootFolder, ""));

            string path = _contentPathUtils.GetRootContentFolder("Socialscenarios.js");
            string faceRecopath = _contentPathUtils.GetRootContentFolder("facerecoscenarios.js");
            string voiceRecopath = _contentPathUtils.GetRootContentFolder("voicerecoscenarios.js");
            var faceProcessor = new FaceRecognitionFileProcessor(new Importer<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>()), faceRecopath);
            var voiceProcessor = new VoiceRecognitionFileProcessor(new Importer<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>()), voiceRecopath);
            var videoProcessor = new SocialSimulatorFileProcessor(new Importer<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>()), path);
            _wizardContentFinder = new WizardContentFinder(_contentPathUtils, faceProcessor, voiceProcessor, videoProcessor);

        }

        private void lstContentTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            ReloadContentTypeList();
        }

        private void ReloadContentTypeList()
        {
            if (lstContent.Items.Count > 0)
            {
                lstContent.Items.Clear();
            }
            string replacementFolderName = RootFolder + lstContentTypes.Text + @"\";
            lstContent.PopulateFromEnumerable(
                _contentPathUtils.GetFilesInDirectory(string.Concat(RootFolder, lstContentTypes.Text))
                    .ReplaceStringInList(replacementFolderName, ""));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdImport.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string file = ofdImport.FileName;

                try
                {
                    File.Copy(file, GetContentFileName(ofdImport.SafeFileName), true);
                    ReloadContentTypeList();
                }
                catch (IOException)
                {
                    MessageBox.Show("Import Failed", string.Format("Import of File: {0} has failed", file), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            var validatorResult = _validator.ValidateSelection(lstContent.Text, _contentType);
            if (!validatorResult.HasErrors)
            {
                SelectedFile = lstContent.Text;
                if (SelectedFile != null)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(string.Format("Content Invalid: {0}", string.Join(", ", validatorResult.ErrorMessages.ToArray())));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Enabled = false;
            axWindowsMediaPlayer1.URL = null;
            pictureBox1.Image = null;

            var contentType = _contentPathUtils.GetContentType(lstContent.Text);
            if(contentType.HasValue)
            {
                if (_wizardContentFinder.ContentIsBeingUsedBy(lstContent.Text, contentType.Value).Count == 0)
                {
                    if (MessageBox.Show("Are you sure you want to Delete?", "Delete Content?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(GetContentFileName(lstContent.Text));
                            ReloadContentTypeList();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Delete Failed", "Failed to delete file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unable to delete file because it is being using somewhere else", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetContentFileName(string fileName)
        {
            return _contentPathUtils.GetTargetFolder(fileName) + @"\" + fileName;
        }

        private void lstContent_Click(object sender, EventArgs e)
        {
            string fileName = lstContent.Text;
            var contentType = _contentPathUtils.GetContentType(fileName);

            if(contentType.HasValue)
            {
                if (contentType == ContentType.Image)
                {
                    SetPreviewImage(fileName);
                }
                if (contentType == ContentType.Sound)
                {
                    SetPreviewMedia(fileName, false);
                }
                if (contentType == ContentType.Video)
                {
                    SetPreviewMedia(fileName, true);
                }

                var contentWizardList = _wizardContentFinder.ContentIsBeingUsedBy(lstContent.Text, contentType.Value);
                lstUsedBy.Items.Clear();
                if (contentWizardList.Count > 0)
                {
                    foreach (var content in contentWizardList)
                    {
                        lstUsedBy.Items.Add(content);
                    }
                }
            }

        }

        private void SetPreviewImage(string imagePath)
        {
            pictureBox1.Image = Image.FromFile(GetContentFileName(imagePath));
            axWindowsMediaPlayer1.URL = null;
            axWindowsMediaPlayer1.Enabled = false;
        }

        private void SetPreviewMedia(string imagePath, bool showWindow)
        {
            pictureBox1.Image = null;
            axWindowsMediaPlayer1.Enabled = true;
            int height = 45;
            int heightLoc = 194;
            if (showWindow)
            {
                height = 220;
                heightLoc = 0;
            }
            axWindowsMediaPlayer1.Size = new Size(220, height);
            axWindowsMediaPlayer1.Location = new Point(6, heightLoc);
            axWindowsMediaPlayer1.URL = GetContentFileName(imagePath);
        }

        private void ContentWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Kills Controls when the content Wizard is closing 
            //Fixes issue where the sound from a video or sound file can be heard when the form has since been closed*/
            axWindowsMediaPlayer1.Enabled = false;
            axWindowsMediaPlayer1.URL = null;
            pictureBox1.Image = null;
        }
    }
}
