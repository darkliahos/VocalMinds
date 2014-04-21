using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Project
{
    /*
     * TODO: Find a way of adding more stories
     * clean up the hideous case statements
     * make the interface more generic
     * Perhaps have a standard format for stories*/

    public partial class StoryForm : Form
    {
        int pageopen = 0;
        private SpeechSynthesizer reader;

        public StoryForm()
        {
            InitializeComponent();
            reader = new SpeechSynthesizer();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            SetAndReturnPage();
            PageLoader();
        }

        private int SetAndReturnPage()
        {
            pageopen++;
            return pageopen;
        }

        private void PageLoader()
        {
            if (pageopen == 1)
            {
                SetupPages("There were 3 aliens who lived in a house on the moon, " + "\n" + "it was very dark where they lived.", Project.Properties.Resources.p1, true);
                SetupPages("In this house, there lived Daddy Alien, Mummy Alien " + "\n" + "and a baby Alien", Project.Properties.Resources.p2,false);
            }
            if (pageopen == 2)
            {
                SetupPages("They one day decided to go out for a walk in the park.", Project.Properties.Resources.p3, true);
                SetupPages("They left their house unlocked by accident", Project.Properties.Resources.p4, false);
            }
            if (pageopen ==3)
            {
                SetupPages("There was a little girl called Goldie who came from the " + "\n" + "planet Earth.", Project.Properties.Resources.p5, true);
                SetupPages("She had just arrived to the moon and was" + "\n" + "really tired and hungry.", Project.Properties.Resources.p6, false);
            }
            if (pageopen == 4)
            {
                SetupPages("She saw the house and decided to go in to see if" +"\n"+"she could get something to eat and go sleep somewhere", Project.Properties.Resources.p4, true);
                SetupPages("She saw 3 chairs in the house and decided she needed" +"\n"+"to sit down for a while", Project.Properties.Resources.p7, false);
            }
            if (pageopen == 5)
            {
                SetupPages("She sat on papa alien's chair," + "\n" + "too big she said to her self", Project.Properties.Resources.goldiesitsfirstchair, true);
                SetupPages("She then sat on mummy alien's chair," + "\n" + "too soft she thought", Project.Properties.Resources.goldiesitssecondchair, false);
            }
            if (pageopen == 6)
            {
                SetupPages("Then she sat on baby Alien's chair", Project.Properties.Resources.goldiesitsonlastchar, true);
                SetupPages("Just Right' She thought " + "\n" + "Then the chair broke", Project.Properties.Resources.goldiefallsoff, false);
            }
            if (pageopen == 7)
            {
                SetupPages("She then went into the kitchen to look for something to eat" + "\n" + "3 bowls full of hot porridge", Project.Properties.Resources.p12, true);
                SetupPages("First she tried Daddy alien's porridge " + "\n" + "'Too hot' she said", Project.Properties.Resources.p13, false);
            }
            if (pageopen == 8)
            {
                SetupPages("She then tried Mummy alien's porrdge" + "\n" + "'Too Cold' she said", Project.Properties.Resources.p14, true);
                SetupPages("She then tried Baby alien's porrdge" + "\n" + "'Just right' she said", Project.Properties.Resources.p15, false);
            }
            if (pageopen == 9)
            {
                SetupPages("Before she could finish it" +"\n"+ "She tipped porridge bowl over by accident", Project.Properties.Resources.p16, true);
                SetupPages("Goldie was tired and decided she needed a nap"+"\n"+"She saw 3 beds in the next room", Project.Properties.Resources.p17, false);
            }
            if (pageopen == 10)
            {
                SetupPages("She first tried Daddy Alien's bed "+"\n"+"'Too hard' She thought", Project.Properties.Resources.p18, true);
                SetupPages("She then tried Mummy Alien's bed" +"\n"+"'Too soft' She thought", Project.Properties.Resources.p19, false);
            }
            if (pageopen == 11)
            {
                SetupPages("She then tried Baby Alien's bed" +"\n"+ "She then fell asleep", Project.Properties.Resources.p20, true);
                SetupPages("The three Aliens came home, after thier long walk", Project.Properties.Resources.thealienscamehome, false);
            }
            if (pageopen == 12)
            {
                SetupPages("They saw the chairs were in a mess" +"\n" +" However Baby Alien's chair had been broken", Project.Properties.Resources.chairs_found, true);
                SetupPages("They saw the porridges had been disturbed" +"\n" + "Unfortunatly Baby Alien's porridge had been tipped over", Project.Properties.Resources.aliensfindporidge, false);
            }
            if (pageopen == 13)
            {
                SetupPages("They saw the beds had been upset and " + "\n" + "and in Baby Alien's bed, they found Goldie" + "\n" + "fast asleep", Project.Properties.Resources.aliensfindbed, true);
                SetupPages("Goldie woke up and then ran away", Project.Properties.Resources.goldierunsaway, false);

            }
            if (pageopen == 14)
            {
                SetupPages("The End", Project.Properties.Resources.THEEND, true);
                SetupPages("The End", Project.Properties.Resources.THEEND, false);
                btnnext.Hide();
            }
        }

        private void SetupPages(string text, Image imageToBeSet, bool firstPage)
        {
            if (firstPage)
            {
                pictureBox1.Image = imageToBeSet;
                reader.SpeakAsync(text);
                lblone.Text = text;
            }
            else
            {
                pictureBox2.Image = imageToBeSet;
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
