using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;
using VM_FormUtils;
using VM_Model;

namespace VM_Main
{
    /* TODO: Find a way of adding more stories */

    public partial class FrmStory : Form
    {
        private readonly Story _story;
        int openedPage = 0;
        private SpeechSynthesizer reader;
        private ContentPhysicalPathUtils contentUtils;

        public FrmStory(Story story)
        {
            _story = story;
            InitializeComponent();
            reader = new SpeechSynthesizer();
            contentUtils = new ContentPhysicalPathUtils();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            SetAndReturnPage();
            PageLoader();
        }

        private int SetAndReturnPage()
        {
            openedPage++;
            return openedPage;
        }

        private void PageLoader()
        {
            Page firstPage = _story.Pages[openedPage];
            Page secondPage = _story.Pages[openedPage +1];
            SetupPages(firstPage.Text, firstPage.Image, true);
            SetupPages(secondPage.Text, secondPage.Image, false);
        }

        private void SetupPages(string text, string imageToBeSet, bool firstPage)
        {
            if (firstPage)
            {
                pictureBox1.Image = Image.FromFile(contentUtils.GetFullStoryImagesPath(imageToBeSet));
                reader.SpeakAsync(text);
                lblone.Text = text;
            }
            else
            {
                pictureBox2.Image = Image.FromFile(contentUtils.GetFullStoryImagesPath(imageToBeSet));
                reader.SpeakAsync(text);
                lbltwo.Text = text;
            }
        }

        private void btnfinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
