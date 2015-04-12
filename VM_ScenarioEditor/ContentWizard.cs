using System;
using System.IO;
using System.Windows.Forms;
using VMUtils;
using VMUtils.Extensions;
using VMUtils.Validators;
using VM_FormUtils.Extensions;

namespace VM_ScenarioEditor
{
    public partial class ContentWizard : Form
    {
        private readonly ContentType _contentType;
        public string RootFolder = PhysicalPathUtils.GetRootContentFolder("");
        private ContentWizardValidator validator;

        public string SelectedFile { get; set; }

        public ContentWizard(bool showSelectedButton, ContentType contentType)
        {
            _contentType = contentType;
            InitializeComponent();

            btnSelected.Visible = showSelectedButton;
            validator = new ContentWizardValidator(new AppConfiguration());
            lstContentTypes.PopulateFromEnumerable(PhysicalPathUtils.GetSubDirectoryList(RootFolder).ReplaceStringInList(RootFolder, ""));
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
                PhysicalPathUtils.GetFilesInDirectory(string.Concat(RootFolder, lstContentTypes.Text))
                    .ReplaceStringInList(replacementFolderName, ""));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdImport.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
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
            var validatorResult = validator.ValidateSelection(lstContent.Text, _contentType);
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
            if (MessageBox.Show("Are you sure you want to Delete?", "Delete Content?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        private string GetContentFileName(string fileName)
        {
            return PhysicalPathUtils.GetTargetFolder(fileName) + @"\" + fileName;
        }


    }
}
