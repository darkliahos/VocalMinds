using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMUtils;
using VMUtils.Extensions;
using VM_FormUtils.Extensions;

namespace VM_ScenarioEditor
{
    public partial class ContentWizard : Form
    {
        public string RootFolder = PhysicalPathUtils.GetRootContentFolder("");
        public ContentWizard()
        {
            InitializeComponent();

            lstContentTypes.PopulateFromEnumerable(PhysicalPathUtils.GetSubDirectoryList(RootFolder).ReplaceStringInList(RootFolder, ""));
        }

        private void lstContentTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstContent.Items.Count > 0)
            {
                lstContent.Items.Clear();
            }
            lstContent.PopulateFromEnumerable(PhysicalPathUtils.GetFilesInDirectory(string.Concat(RootFolder, lstContentTypes.Text)).ReplaceStringInList(RootFolder, ""));
        }


    }
}
