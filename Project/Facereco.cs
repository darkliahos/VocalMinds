using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SpeechLib;
using System.Windows.Forms;

namespace Project
{
    public partial class Facerecognition : Form
    {
        private SpeechLib.SpSharedRecoContext objRecoContext = null;
        private SpeechLib.ISpeechRecoGrammar grammar = null;
        private SpeechLib.ISpeechGrammarRule command = null;
        string whatdidhesay;
        int questiondone;
        int totattmpts;
        int correctans;
        int therandomvalue;
        string correctword;

        public Facerecognition()
        {
            InitializeComponent();
            displayfirsttime();
        }

        private void Hypo_Event(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
        {
            try
            {
                whatdidhesay = Result.PhraseInfo.GetText(0, -1, true);//gets what ever the user said and puts it in a variable
                //txtaids.Text = whatdidhesay;//TESTING PURPOSES
            }
            catch (Exception eh)
            {
                MessageBox.Show("Program did understand what you just said!" + "\n" + eh);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                objRecoContext = new SpeechLib.SpSharedRecoContext();
                // Assign a eventhandler for the Hypothesis Event.
                objRecoContext.Hypothesis += new _ISpeechRecoContextEvents_HypothesisEventHandler(Hypo_Event);
                // Assign a eventhandler for the Recognition Event.
                //Creating an instance of the grammer object.
                grammar = objRecoContext.CreateGrammar(0);

                command = grammar.Rules.Add("MenuCommands", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);
                object PropValue = "";
                command.InitialState.AddWordTransition(null, "happy", " ", SpeechGrammarWordType.SGLexical, "Happy", 1, ref PropValue, 1.0F);

                command.InitialState.AddWordTransition(null, "grumpy", " ", SpeechGrammarWordType.SGLexical, "Grumpy", 2, ref PropValue, 1.0F);
                command.InitialState.AddWordTransition(null, "angry", " ", SpeechGrammarWordType.SGLexical, "angry", 3, ref PropValue, 1.0F);
                command.InitialState.AddWordTransition(null, "bossy", " ", SpeechGrammarWordType.SGLexical, "bossy", 4, ref PropValue, 1.0F);
                command.InitialState.AddWordTransition(null, "crazy", " ", SpeechGrammarWordType.SGLexical, "crazy", 5, ref PropValue, 1.0F);
                command.InitialState.AddWordTransition(null, "upset", " ", SpeechGrammarWordType.SGLexical, "upset", 6, ref PropValue, 1.0F);
                command.InitialState.AddWordTransition(null, "sad", " ", SpeechGrammarWordType.SGLexical, "sad", 7, ref PropValue, 1.0F);
                command.InitialState.AddWordTransition(null, "excitement", " ", SpeechGrammarWordType.SGLexical, "excitement", 8, ref PropValue, 1.0F);
                grammar.Rules.Commit();
                grammar.CmdSetRuleState("MenuCommandORHs", SpeechRuleState.SGDSActive);
            }
            catch (Exception ok)
            {
                MessageBox.Show("You have not got Windows Speech Recogntion running! " + "\n" + "\n" + ok);
            }
            textBox1.Focus();
        }

        private int RandomGenerator(int min, int max)
        {
            Random random = new Random();
            therandomvalue = random.Next(min, max);
            return therandomvalue;
        }

        public string readtextfromtextboxvistaalternate()
        {
            whatdidhesay = textBox1.Text;
            return whatdidhesay;
        }

        private void button1_Click(object sender, EventArgs e)
        {                
            readtextfromtextboxvistaalternate();
            if (whatdidhesay == correctword)
            {

                MessageBox.Show(correctword);
                MessageBox.Show("Well done");
                displayfirsttime();
            }
            else
            {
                MessageBox.Show(correctword);
                MessageBox.Show("Wrong, try again");
            }
        }
        public string picturechecker()
    {
            if (therandomvalue == 1)
            {
                pictureBox1.Image = Project.Properties.Resources.angryface;
                correctword = "Angry";

            }

            else if (therandomvalue == 2)
            {
                 pictureBox1.Image = Project.Properties.Resources.angryface2;
                 correctword = "Angry";
            }

            else if (therandomvalue == 3)
            {
                pictureBox1.Image = Project.Properties.Resources.confusedlook;
                correctword = "Confused";
            }
            else if (therandomvalue == 4)
            {
                pictureBox1.Image = Project.Properties.Resources.sadface;
                correctword = "Sad";
            }

            else if (therandomvalue == 5)
            {
                pictureBox1.Image = Project.Properties.Resources.scaredface;
                correctword = "Scared";
            }
            else if (therandomvalue == 6)
            {
                pictureBox1.Image = Project.Properties.Resources.happyface;
                correctword = "Happy";
            }

            else if (therandomvalue == 7)
            {
                pictureBox1.Image = Project.Properties.Resources.happyface2;
                correctword = "Happy";
            }

                    return correctword;    
    }

        public void displayfirsttime()
        {
            RandomGenerator(1, 7);
            picturechecker();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help hlpfrm = new Help();
            hlpfrm.Show();
        }

    }
}
