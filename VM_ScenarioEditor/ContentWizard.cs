using System;
using System.IO;
using System.Windows.Forms;
using VMUtils;
using VMUtils.Extensions;
using VM_FormUtils.Extensions;

namespace VM_ScenarioEditor
{
    public partial class ContentWizard : Form
    {
        public string RootFolder = PhysicalPathUtils.GetRootContentFolder("");

        public string SelectedFile { get; set; }

        public ContentWizard(bool showSelectedButton)
        {
            InitializeComponent();

            btnSelected.Visible = showSelectedButton;

            lstContentTypes.PopulateFromEnumerable(PhysicalPathUtils.GetSubDirectoryList(RootFolder).ReplaceStringInList(RootFolder, ""));
        }

        private void lstContentTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstContent.Items.Count > 0)
            {
                lstContent.Items.Clear();
            }
            string replacementFolderName = RootFolder + lstContentTypes.Text + @"\";
            lstContent.PopulateFromEnumerable(PhysicalPathUtils.GetFilesInDirectory(string.Concat(RootFolder, lstContentTypes.Text)).ReplaceStringInList(replacementFolderName, ""));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdImport.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = ofdImport.FileName;

                try
                {
                    File.Copy(file, PhysicalPathUtils.GetTargetFolder(file) + @"\" + ofdImport.SafeFileName, true);
                }
                catch (IOException)
                {
                    MessageBox.Show("Import Failed", string.Format("Import of File: {0} has failed", file), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            SelectedFile = lstContent.Text;
            if (SelectedFile != null)
            {
                this.Close();
            }

        }


    }
}
