using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
/*
 * THINGS TO DO Code needs to be optomised a tad, some entities are irrelevent 
 * Add more expressions
 * Add some voices
 * Add Array System
 */ 
namespace Project
{

    public partial class voicerecognition : Form
    {
        private SpeechLib.SpSharedRecoContext objRecoContext = null;
        private SpeechLib.ISpeechRecoGrammar grammar = null;
        private SpeechLib.ISpeechGrammarRule command = null;
        string whatdidhesay;
        string playsound;
        string thecorrectword = "three";
        int therandomvalue=4;
        int runcount = 1;

        public voicerecognition()
        {
            InitializeComponent();
        }

        private void btntalk_Click(object sender, EventArgs e)
        {
            //code adapted from an example by Suhel Survindas
            //original from here:
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
                grammar.Rules.Commit();
                grammar.CmdSetRuleState("MenuCommandORHs", SpeechRuleState.SGDSActive);
                
            }
            catch (Exception ok)
            {
                MessageBox.Show("You have not got Windows Speech Recogntion running! " + "\n" + "\n" + ok);
            }
            txtsaid.Focus();
        }

        private void Hypo_Event(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
        {
            try{
                whatdidhesay = Result.PhraseInfo.GetText(0, -1, true);//gets what ever the user said and puts it in a variable
            txtsaid.Text = whatdidhesay;//TESTING PURPOSES
            }
                catch(Exception eh)
            {
                MessageBox.Show("Program did understand what you just said!" +"\n"+ eh);
                }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            voicechecker();
            axWindowsMediaPlayer1.URL = playsound;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        public void isitright()
        {
            readtextfromtextboxvistaalternate();
            if (whatdidhesay == thecorrectword)
            {
                MessageBox.Show("Correct");
                RandomGenerator(1, 15);

            }
            else
            {
                MessageBox.Show("Wrong");
            }
        }


        private int RandomGenerator(int min, int max)
        {
            Random random = new Random();
            therandomvalue = random.Next(min, max);
            return therandomvalue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            answerchecker();
            isitright();
            txtsaid.Text = "";

        }
        private void runcountchecker()
        {
            if (runcount == 1)
            {
                RandomGenerator(1, 15);

            }
            else
            {
            }
        }

        public string readtextfromtextboxvistaalternate()
        {
            whatdidhesay = txtsaid.Text;
            return whatdidhesay;
        }

        public string voicechecker()
        {
            if (therandomvalue == 1)
            {
                playsound = @"C:\projectaudio\Voicegame\1.wma";
            }
            else if (therandomvalue == 2)
            {
                playsound = @"C:\projectaudio\Voicegame\2.wma";
            }
            else if (therandomvalue == 3)
            {
                playsound = @"C:\projectaudio\Voicegame\3.wma";
            }
            else if (therandomvalue == 4)
            {
                playsound = @"C:\projectaudio\Voicegame\4.wma";
            }
            else if (therandomvalue == 5)
            {
                playsound = @"C:\projectaudio\Voicegame\5.wma";
            }
            else if (therandomvalue == 6)
            {
                playsound = @"C:\projectaudio\Voicegame\6.wma";

            }
            else if (therandomvalue == 7)
            {
                playsound = @"C:\projectaudio\Voicegame\7.wma";
            }
            else if (therandomvalue == 8)
            {
                playsound = @"C:\projectaudio\Voicegame\8.wma";
            }
            else if (therandomvalue == 9)
            {
                playsound = @"C:\projectaudio\Voicegame\9.wma";
            }
            else if (therandomvalue == 10)
            {
                playsound = @"C:\projectaudio\Voicegame\10.wma";

            }
            else if (therandomvalue == 11)
            {
                playsound = @"C:\projectaudio\Voicegame\11.wma";
            }
            else if (therandomvalue == 12)
            {
                playsound = @"C:\projectaudio\Voicegame\12.wma";
            }
            else if (therandomvalue == 13)
            {
                playsound = @"C:\projectaudio\Voicegame\13.wma";
            }
            else if (therandomvalue == 14)
            {
                playsound = @"C:\projectaudio\Voicegame\14.wma";


            }
            else if (therandomvalue == 15)
            {
                playsound = @"C:\projectaudio\Voicegame\15.wma";

            }
            return playsound;
        }

        public string answerchecker()
        {
            if (therandomvalue == 1)
            {

                thecorrectword = "Cross";
            }
            else if (therandomvalue == 2)
            {

                thecorrectword = "Mean";
            }
            else if (therandomvalue == 3)
            {

                thecorrectword = "Shocked";
            }
            else if (therandomvalue == 4)
            {

                thecorrectword = "Happy";
            }
            else if (therandomvalue == 5)
            {

                thecorrectword = "Sad";
            }
            else if (therandomvalue == 6)
            {
                thecorrectword = "Worried";

            }
            else if (therandomvalue == 7)
            {

                thecorrectword = "Upset";
            }
            else if (therandomvalue == 8)
            {
                thecorrectword = "Happy";
            }
            else if (therandomvalue == 9)
            {
                thecorrectword = "Sad";
            }
            else if (therandomvalue == 10)
            {
                thecorrectword = "Angry";

            }
            else if (therandomvalue == 11)
            {
                thecorrectword = "Worried";
            }
            else if (therandomvalue == 12)
            {
                thecorrectword = "Embarrassed";
            }
            else if (therandomvalue == 13)
            {
                thecorrectword = "Laughing";
            }
            else if (therandomvalue == 14)
            {
                thecorrectword = "Annoyed";

            }
            else if (therandomvalue == 15)
            {
                thecorrectword = "Cross";
            }
            return thecorrectword;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help hlpfrm = new Help();
            hlpfrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
