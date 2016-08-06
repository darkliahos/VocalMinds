using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Windows.Forms;
using VMUtils;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VM_Main.Properties;
using VM_Model;
using NLog;

namespace VM_Main
{
    public partial class FrmFaceRecognition : Form
    {
        private readonly IContentPathUtils _contentPathUtils;
        List<string> _correctAnswers;
        Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly Dictionary<int, FaceRecognitionScenario>  _faceRecognitions = new Dictionary<int, FaceRecognitionScenario>();

        public FrmFaceRecognition(List<FaceRecognitionScenario> recognition, IContentPathUtils contentPathUtils)
        {
            _contentPathUtils = contentPathUtils;
            InitializeComponent();
            var frc = new FaceRecognitionLoader(_logger);
            _faceRecognitions = frc.PopulateFaceRecognitionScenarios(recognition);
            LoadScenario(Randomiser.NextRange(1, _faceRecognitions.Count));
        }

        private void Talk()
        {
            var recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            BtnConfirm.Text = Resources.Facerecognition_Talk_Speak_Now;
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                recognizer.SetInputToDefaultAudioDevice();
                //Loop through until we have a sucessful response
                for(var i = 0; i <1;)
                {
                    var result = recognizer.Recognize();
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
            BtnConfirm.Text = Resources.Facerecognition_SucessfulRecognition_Answer;
            textBox1.Text = speechResult;
            if (_correctAnswers.Contains(speechResult))
            {
                MessageBox.Show(Resources.WellDone);
                LoadScenario(Randomiser.NextRange(1, _faceRecognitions.Count));
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
                FaceBox.ImageLocation = _contentPathUtils.GetFullImagePath(faceResult.ImageName);
                _correctAnswers = faceResult.Answers;
            }
            else
            {
                MessageBox.Show(Resources.Facerecognition_LoadScenario_Scenario_Load_Failed);
                _logger.Error(string.Format("Scenario Loader Faulted on {0}", index));
            }
        }
    }
}
