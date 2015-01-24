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

namespace VM_ScenarioEditor
{
    public partial class ContentWizard : Form
    {
        public ContentWizard()
        {
            InitializeComponent();
            LoadFolders(PhysicalPathUtils.GetSubDirectoryList(PhysicalPathUtils.GetRootContentFolder("")));
        }

        private void LoadFolders(IEnumerable<string> folderList)
        {
            lstContentTypes.BackColor = Color.LemonChiffon;
            foreach (var folder in folderList)
            {
                 lstContentTypes.Items.Add(folder.Replace(PhysicalPathUtils.GetRootContentFolder(""), ""));
            }
        }
    }
}
