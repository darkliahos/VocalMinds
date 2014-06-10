using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using System.Windows.Forms;
using VC_Main.Properties;
using VM_Model;

namespace VC_Main
{
    public partial class Facerecognition : Form
    {
        string _userResponse;
        int _therandomvalue;
        string _correctAnswer;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly List<FaceRecognitionScenario> _faceRecognitions;


        public Facerecognition(List<FaceRecognitionScenario> recognition)
        {
            _faceRecognitions = recognition;
            InitializeComponent();
            SharedSpeechDictionary.InitaliseSpeechObject();
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
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("53f0fad0-46ed-417d-b0ae-f45adf29fd15"), "Angry", Resources.angryface));
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("05c9d8df-6e1b-4db0-998e-b4122566eda5"), "Angry", Resources.angryface2));
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("0e148757-d925-4235-9047-46dd6f1b0e65"), "Confused", Resources.confusedlook));
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("f061eede-b1d2-46ff-b42a-210c393cfa4f"), "Sad", Resources.sadface));
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("65abb15c-9c45-40bd-9183-4aafbaf55463"), "Scared", Resources.scaredface));
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("dba59b88-c6b4-4a74-b81d-e2812c81200f"), "Happy", Resources.happyface));
            _faceRecognitions.Add(new FaceRecognitionScenario(Guid.Parse("b7825e94-7149-42fb-870e-4e26292756fa"), "Happy", Resources.happyface2));
        }


        //TODO Rewrite this logic to match new types
        public void Picturechecker()
        {
            FaceRecognitionScenario faceResult = _faceRecognitions.FirstOrDefault(item => item.Answer == "");
            if(faceResult != null)
            {
                FaceBox.Image = faceResult.Image;
                _correctAnswer = faceResult.Answer;
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
