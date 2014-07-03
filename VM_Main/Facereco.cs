using System;
using System.Collections.Generic;
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
        private readonly Dictionary<int, FaceRecognitionScenario>  _faceRecognitions = new Dictionary<int, FaceRecognitionScenario>();
        readonly FaceRecognitionLoader _frc = new FaceRecognitionLoader(Logger);

        public Facerecognition(List<FaceRecognitionScenario> recognition)
        {
            InitializeComponent();
            _faceRecognitions = _frc.PopulateFaceRecognition(recognition);
            LoadScenario(_frc.RandomGenerator(1, _faceRecognitions.Count));
        }

        private void Talk()
        {
            var recognizer = new SpeechRecognitionEngine();
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
                LoadScenario(_frc.RandomGenerator(1, _faceRecognitions.Count));
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
