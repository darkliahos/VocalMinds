using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMUtils;
using VMUtils.Interfaces;
using VM_FormUtils;
using VM_Model;
using VM_ScenarioEditor.Validators;

namespace VM_ScenarioEditor
{
    public partial class SocialSimulatorEditor : Form
    {
        private readonly IImporter<ImportedSocialScenarios> _importer;
        private readonly IFileProcessor<SocialScenario, ImportedSocialScenarios> _processor;
        private readonly IExporter<ImportedSocialScenarios> _exporter;
        private readonly IMerge<ImportedSocialScenarios> _merge;
        private SocialSimulatorFileWriter writer;
        public SocialSimulatorEditor(IImporter<ImportedSocialScenarios> importer, IFileProcessor<SocialScenario, ImportedSocialScenarios> processor, IExporter<ImportedSocialScenarios> exporter, IMerge<ImportedSocialScenarios> merge, IContentPathUtils contentPathUtils)
        {
            _importer = importer;
            _processor = processor;
            _exporter = exporter;
            _merge = merge;
            InitializeComponent();
            string socialPath = contentPathUtils.GetRootContentFolder("Socialscenarios.js");
            writer = new SocialSimulatorFileWriter(_exporter, _processor, socialPath, _merge);

            if (SocialSimulatorFormState.EditingState)
            {
                txttitle.Text = SocialSimulatorFormState.SocialScenario.FriendlyName;
                txtAuthor.Text = SocialSimulatorFormState.SocialScenario.Author;
                LoadVideoSegments();
            }
        }

        private void LoadVideoSegments()
        {
            if (lstSegments.Items.Count > 0)
            {
                lstSegments.Items.Clear();
            }
            foreach (var segment in SocialSimulatorFormState.SocialScenario.VideoSegment)
            {
                lstSegments.Items.Add(segment.Description);
            }
        }

        public ImportedSocialScenarios State { get; set; }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SocialSimulatorFormState.SocialScenario.Author = txtAuthor.Text;
            SocialSimulatorFormState.SocialScenario.FriendlyName = txttitle.Text;

            var validationObject = SocialScenarioValidation.ValidateScenario();
            if (validationObject.HasErrors)
            {

                var sb = new StringBuilder();

                foreach (var em in validationObject.ErrorMessages)
                {
                    sb.Append(em);
                    sb.Append("\n");
                }

                MessageBox.Show(string.Format("There were Validation errors: \n {0}", sb), "Validation Errors");
            }
            else
            {
                if (SocialSimulatorFormState.SocialScenario.Id != Guid.Empty)
                {
                    var previousObject =
                        State.SocialScenario.First(x => x.Id == SocialSimulatorFormState.SocialScenario.Id);
                    State.SocialScenario.Remove(previousObject);
                }
                else
                {
                    SocialSimulatorFormState.SocialScenario.Id = Guid.NewGuid();
                }

                State.SocialScenario.Add(SocialSimulatorFormState.SocialScenario);

                writer.Save(State);
                MessageBox.Show("Saved Scenario");
                this.Close();
            }

        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var ssse = new SocialSimulatorSegmentEditor {Editing = false};
            var dr = ssse.ShowDialog();
            if (dr == DialogResult.OK)
                LoadVideoSegments();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (lstSegments.SelectedIndex != -1)
            {
                var segementName = lstSegments.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(segementName))
                {
                    var segement = SocialSimulatorFormState.SocialScenario.VideoSegment.FirstOrDefault(x => x.Description == segementName);
                    var ssse = new SocialSimulatorSegmentEditor(segement) { Editing = true };
                    var dr = ssse.ShowDialog();
                    if (dr == DialogResult.OK)
                        LoadVideoSegments();
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSegments.SelectedIndex != -1)
            {
                var segement = SocialSimulatorFormState.SocialScenario.VideoSegment.FirstOrDefault(x => x.Description == (string)lstSegments.SelectedItem);
                SocialSimulatorFormState.SocialScenario.VideoSegment.Remove(segement);
                lstSegments.Items.RemoveAt(lstSegments.SelectedIndex);
            }
        }
    }
}
