using System;
using System.Windows.Forms;

namespace VM_Main
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
    public partial class Simulator : Form
    {
        //counter for the events
        string _placeHolder = "1";

        public Simulator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vidorder();
        }

        private void vidorder()
        {
            //string path = @"%PATH%\vidicontent\happy.avi";
            //string path = Environment.CurrentDirectory + "\\happy.avi";

            if(_placeHolder=="1")
            {
                //play good morning video
                //axWindowsMediaPlayer1.URL = @""+path+"";
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\hello.avi";
            }
            else if (_placeHolder == "2")
            {
                //play what is your name video
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\whatisyourname.avi";
            }
            else if (_placeHolder == "3")
            {
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\nicename.avi";
            }
            else if (_placeHolder == "4")
            {
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\howareyoufeeling.avi";
            }
            else if (_placeHolder == "happy")
            {
                //play happy reaction video
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\happyresponse.avi";
                

            }
            else if (_placeHolder == "sad")
            {
                axWindowsMediaPlayer1.URL = @"C:\projectvideos\sadresponse.avi";
            }

            //return edge
        }

        private string wasiright()
        {
            string correctword = wordbox.Text; 
            if (_placeHolder == "1")
            {
                if(correctword =="Hello")
                {
                    MessageBox.Show("Correct");
                    _placeHolder = "2";
                    wordbox.Text = "";
                }
                    else if(correctword=="Good morning")
                    {
                        MessageBox.Show("Correct");
                        _placeHolder = "2";
                        wordbox.Text = "";
                    }
                else if (correctword == "Good afternoon")
                {
                    MessageBox.Show("Correct");
                    _placeHolder = "2";
                    wordbox.Text = "";
                }
                else if (correctword == "Good evening")
                {
                    MessageBox.Show("Correct");
                    _placeHolder = "2";
                    wordbox.Text = "";
                }
                else if (correctword == "Hi")
                {
                    MessageBox.Show("Correct");
                    _placeHolder = "2";
                    wordbox.Text = "";
                }
                
                else
                {
                    MessageBox.Show("Try Again");
                    wordbox.Text = "";
                }
            }

            else if (_placeHolder == "2")
            {
                MessageBox.Show("That is a nice name");
                _placeHolder = "3";
                wordbox.Text = "";
            }
            else if (_placeHolder == "3")
            {
                MessageBox.Show("Thank you");
                _placeHolder = "4";
                wordbox.Text = "";
            }
            else if (_placeHolder == "4")
            {
                if (correctword == "I am happy")
                {
                    MessageBox.Show("Hooray!");
                    _placeHolder = "happy";
                    wordbox.Text = "";
                }
                else if (correctword == "I am sad")
                {
                    MessageBox.Show("Oh dear");
                    _placeHolder = "sad";
                    wordbox.Text = "";
                }
                else if (correctword == "I am grumpy")
                {
                    _placeHolder = "sad";
                    wordbox.Text = "";
                }
                else if (correctword == "I am angry")
                {
                    _placeHolder = "sad";
                    wordbox.Text = "";
                }
                else
                {
                    MessageBox.Show("Try Again");
                    wordbox.Text = "";
                }

            }
            else if (_placeHolder == "happy")
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
            else if (_placeHolder == "sad")
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
            return _placeHolder;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            wasiright();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
