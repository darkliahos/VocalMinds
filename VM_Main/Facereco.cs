using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using NLog;
using System.Windows.Forms;
using VM_Main.Properties;
using VM_Model;

namespace VM_Main
{
    public partial class Facerecognition : Form
    {
        string _correctAnswer;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly Dictionary<int, FaceRecognitionScenario> _faceRecognitions = new Dictionary<int, FaceRecognitionScenario>(); 


        public Facerecognition(List<FaceRecognitionScenario> recognition)
        {
            InitializeComponent();
            PopulateFaceRecognition(recognition);
            LoadScenario(RandomGenerator(1, 7));
        }

        private int RandomGenerator(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        private void Talk()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            BtnConfirm.Text = "Speak Now";
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                recognizer.SetInputToDefaultAudioDevice();
                for(int i = 0; i <1;)
                {
                    RecognitionResult result = recognizer.Recognize();
                    if (result.Text != "")
                    {
                        SucessfulRecognition(result.Text);
                        break;
                    }
                }

            }
            catch (InvalidOperationException exception)
            {
               MessageBox.Show(String.Format("Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message));
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }  
        }

        private void SucessfulRecognition(string speechResult)
        {
            BtnConfirm.Text = "Answer";
            textBox1.Text = speechResult;
            if (speechResult == _correctAnswer)
            {

                MessageBox.Show(Resources.WellDone);
                LoadScenario(RandomGenerator(1, 7));
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show(Resources.Wrong);
            }
        }

        private void BtnConfirmClick(object sender, EventArgs e)
        {
            Talk();
        }

        /// <summary>
        /// Populate Face Recognition with scenarios
        /// </summary>
        private void PopulateFaceRecognition(List<FaceRecognitionScenario> importedScenarios)
        {
            _faceRecognitions.Add(1,new FaceRecognitionScenario(Guid.Parse("53f0fad0-46ed-417d-b0ae-f45adf29fd15"), "Angry", Resources.angryface));
            _faceRecognitions.Add(2,new FaceRecognitionScenario(Guid.Parse("05c9d8df-6e1b-4db0-998e-b4122566eda5"), "Angry", Resources.angryface2));
            _faceRecognitions.Add(3,new FaceRecognitionScenario(Guid.Parse("0e148757-d925-4235-9047-46dd6f1b0e65"), "Confused", Resources.confusedlook));
            _faceRecognitions.Add(4,new FaceRecognitionScenario(Guid.Parse("f061eede-b1d2-46ff-b42a-210c393cfa4f"), "Sad", Resources.sadface));
            _faceRecognitions.Add(5,new FaceRecognitionScenario(Guid.Parse("65abb15c-9c45-40bd-9183-4aafbaf55463"), "Scared", Resources.scaredface));
            _faceRecognitions.Add(6,new FaceRecognitionScenario(Guid.Parse("dba59b88-c6b4-4a74-b81d-e2812c81200f"), "Happy", Resources.happyface));
            _faceRecognitions.Add(7,new FaceRecognitionScenario(Guid.Parse("b7825e94-7149-42fb-870e-4e26292756fa"), "Happy", Resources.happyface2));

            if(importedScenarios != null)
            {
                int index = 8;
                foreach(FaceRecognitionScenario frs in importedScenarios)
                {
                    _faceRecognitions.Add(index, frs);
                    index++;
                }
            }
        }

        public void LoadScenario(int index)
        {
            FaceRecognitionScenario faceResult;
            if (_faceRecognitions.TryGetValue(index, out faceResult))
            {
                FaceBox.Image = faceResult.Image;
                _correctAnswer = faceResult.Answer;
            }
            else
            {
                MessageBox.Show(Resources.GeneratorFault);
                Logger.Debug(string.Format("Random Generator Faulted: {0}", index));
            }
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
