using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Project.Properties;
using SpeechLib;
using System.Windows.Forms;

namespace Project
{
    public partial class Facerecognition : Form
    {
        string _userResponse;
        int _therandomvalue;
        string _correctAnswer;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly List<FaceRecognition> _faceRecognitions;
        

        public Facerecognition()
        {
            InitializeComponent();
            SharedSpeechDictionary.InitaliseSpeechObject();
            _faceRecognitions = new List<FaceRecognition>();
            PopulateFaceRecognition();
            FirstTimeInitialiser();
        }

        private void RandomGenerator(int min, int max)
        {
            var random = new Random();
            _therandomvalue = random.Next(min, max);
        }

        /// <summary>
        /// Reads Value from textbox if speech recognition is not supported
        /// </summary>
        /// <returns></returns>
        public string ReadFromTextBox()
        {
            _userResponse = textBox1.Text;
            return _userResponse;
        }

        private void BtnConfirmClick(object sender, EventArgs e)
        {                
            ReadFromTextBox();
            if (_userResponse == _correctAnswer)
            {

                MessageBox.Show(Resources.WellDone);
                FirstTimeInitialiser();
            }
            else
            {
                MessageBox.Show(Resources.Wrong);
            }
        }

        private void PopulateFaceRecognition()
        {
            _faceRecognitions.Add(new FaceRecognition(1, "Angry", Resources.angryface));
            _faceRecognitions.Add(new FaceRecognition(2, "Angry", Resources.angryface2));
            _faceRecognitions.Add(new FaceRecognition(3, "Confused", Resources.confusedlook));
            _faceRecognitions.Add(new FaceRecognition(4, "Sad", Resources.sadface));
            _faceRecognitions.Add(new FaceRecognition(5, "Scared", Resources.scaredface));
            _faceRecognitions.Add(new FaceRecognition(6, "Happy", Resources.happyface));
            _faceRecognitions.Add(new FaceRecognition(7, "Happy", Resources.happyface2));
        }



        public void Picturechecker()
        {
            FaceRecognition faceResult = _faceRecognitions.FirstOrDefault(item => item.Id == _therandomvalue);
            if(faceResult != null)
            {
                FaceBox.Image = faceResult.ImageAssociated;
                _correctAnswer = faceResult.Emotion;
            }
            else
            {
                MessageBox.Show(Resources.GeneratorFault);
                Logger.Debug(string.Format("Random Generator Faulted: {0}", _therandomvalue));
            }
        }

        public void FirstTimeInitialiser()
        {
            RandomGenerator(1, 7);
            Picturechecker();
            
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnHelpClick(object sender, EventArgs e)
        {
            var hlpfrm = new Help();
            hlpfrm.Show();
        }



    }
}
