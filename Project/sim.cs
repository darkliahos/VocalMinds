using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using SpeechLib;

namespace Project
{
/*
 Some quick notes:
 * Axwindowsmediaplayer is the name of the control
 * the first button submits what the user just said 
 (But hopefully I will be able to optomise it so the user just 
  speaks and the program automaitcally takes it on board, it will have 
  to be an on initinailise event)
 * the second button repeats what the simulation just said
 * the third button kicks off the simulator
 * Added voice recognition
 * Added an array that calls parts of the simulation
 */
    public partial class sim : Form
    {
        private SpeechLib.SpSharedRecoContext objRecoContext;
        private SpeechLib.ISpeechRecoGrammar grammar;
        string whatdidhesay = "Say Something";
        //counter for the events
        string count = "1";

        public sim()
        {
            InitializeComponent();
        }



        public void RecoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            whatdidhesay = Result.PhraseInfo.GetText(0, -1, true);
            Debug.WriteLine("Recognition: " + whatdidhesay + ", " + StreamNumber + ", " + StreamPosition);
            wordbox.Text = whatdidhesay; 

        }

        private void btnwhatdidyousay_Click(object sender, EventArgs e)//repeats the command
        {
            //plays video again
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vidorder();
        }

        private void vidorder()
        {
            //string path = @"%PATH%\vidicontent\happy.avi";
            //string path = Environment.CurrentDirectory + "\\happy.avi";

            if(count=="1")
            {
                //play good morning video
                //axWindowsMediaPlayer1.URL = @""+path+"";
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\hello.avi";
            }
            else if (count == "2")
            {
                //play what is your name video
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\whatisyourname.avi";
            }
            else if (count == "3")
            {
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\nicename.avi";
            }
            else if (count == "4")
            {
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\howareyoufeeling.avi";
            }
            else if (count == "happy")
            {
                //play happy reaction video
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\happyresponse.avi";
                

            }
            else if (count == "sad")
            {
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\sadresponse.avi";
            }

            //return edge
        }

        private string wasiright()
        {
            string correctword = wordbox.Text; 
            if (count == "1")
            {
                if(correctword =="Hello")
                {
                    MessageBox.Show("Correct");
                    count = "2";
                    wordbox.Text = "";
                }
                    else if(correctword=="Good morning")
                    {
                        MessageBox.Show("Correct");
                        count = "2";
                        wordbox.Text = "";
                    }
                else if (correctword == "Good afternoon")
                {
                    MessageBox.Show("Correct");
                    count = "2";
                    wordbox.Text = "";
                }
                else if (correctword == "Good evening")
                {
                    MessageBox.Show("Correct");
                    count = "2";
                    wordbox.Text = "";
                }
                else if (correctword == "Hi")
                {
                    MessageBox.Show("Correct");
                    count = "2";
                    wordbox.Text = "";
                }
                
                else
                {
                    MessageBox.Show("Try Again");
                    wordbox.Text = "";
                }
            }

            else if (count == "2")
            {
                MessageBox.Show("That is a nice name");
                count = "3";
                wordbox.Text = "";
            }
            else if (count == "3")
            {
                MessageBox.Show("Thank you");
                count = "4";
                wordbox.Text = "";
            }
            else if (count == "4")
            {
                if (correctword == "I am happy")
                {
                    MessageBox.Show("Hooray!");
                    count = "happy";
                    wordbox.Text = "";
                }
                else if (correctword == "I am sad")
                {
                    MessageBox.Show("Oh dear");
                    count = "sad";
                    wordbox.Text = "";
                }
                else if (correctword == "I am grumpy")
                {
                    count = "sad";
                    wordbox.Text = "";
                }
                else if (correctword == "I am angry")
                {
                    count = "sad";
                    wordbox.Text = "";
                }
                else
                {
                    MessageBox.Show("Try Again");
                    wordbox.Text = "";
                }

            }
            else if (count == "happy")
            {
                if (correctword == "Draw")
                {
                    //This opens up the scribblepad
                    Scribblepad scribley = new Scribblepad();
                    scribley.Show();
                }
                else if (correctword == "Story")
                {
                    //THis opens up the story 
                    StoryForm story = new StoryForm();
                    story.Show();
                }
            }
            else if (count == "sad")
            {
                if (correctword == "Draw")
                {
                    //This opens up the scribblepad
                    Scribblepad scribley = new Scribblepad();
                    scribley.Show();
                }
                else if (correctword == "Story")
                {
                    //THis opens up the story 
                    StoryForm story = new StoryForm();
                    story.Show();

                }
            }
            return count;
        }

        private void btnwasiright_Click(object sender, EventArgs e)
        {
            wasiright();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                grammar.DictationSetState(SpeechRuleState.SGDSInactive);
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            wasiright();
        }

        private void sim_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help hlpfrm = new Help();
            hlpfrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //NOTE: This code is only needed for Windows XP service pack 2 & 3 only, This code is irrelevent for
            //systems using Windows Vista and above

            //This will not work for Windows XP service pack 1 or below, please see final report for an explanation

            //code modified from an example showed by Suhel Survindas from C# Corner



            try
            {
                if (objRecoContext == null)
                {
                    objRecoContext = new SpeechLib.SpSharedRecoContext();
                    objRecoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(RecoContext_Recognition);
                    grammar = objRecoContext.CreateGrammar(1);
                    grammar.DictationLoad("", SpeechLoadOption.SLOStatic);
                }
                grammar.DictationSetState(SpeechRuleState.SGDSActive);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Problem initializing SAPI." + " This application may not run correctly.\r\n\r\n" + ex.ToString(), "Error");
            }

            wordbox.Focus();
        }
    }
}
