using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Windows.Forms;
using NLog;
using VMUtils;
using VMUtils.Interfaces;
using VM_FormUtils;
using VM_Main.Properties;
using VM_Model;

namespace VM_Main
{

    public partial class FrmVoiceRecognition : Form
    {
        private readonly IContentPathUtils _contentPathUtils;
        List<string> _correctAnswers;
        string _playsound;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly Dictionary<int, VoiceRecognitionScenario> _voiceRecognitions = new Dictionary<int, VoiceRecognitionScenario>();
        readonly VoiceRecognitionLoader _vrc = new VoiceRecognitionLoader(Logger);

        public FrmVoiceRecognition(List<VoiceRecognitionScenario> recognition, IContentPathUtils contentPathUtils)
        {
            _contentPathUtils = contentPathUtils;
            InitializeComponent();
            _voiceRecognitions = _vrc.PopulateVoiceRecognitionScenarios(recognition);
            LoadScenario(Randomiser.NextRange(1, _voiceRecognitions.Count));
        }

        private void LoadScenario(int index)
        {
            VoiceRecognitionScenario voiceResult;
            if (_voiceRecognitions.TryGetValue(index, out voiceResult))
            {
                _playsound = _contentPathUtils.GetFullSoundPath(voiceResult.AudioPath);
                _correctAnswers = voiceResult.Answers;
            }
            else
            {
                MessageBox.Show(Resources.Facerecognition_LoadScenario_Scenario_Load_Failed);
                Logger.Debug(string.Format("Scenario Loader Faulted on {0}", index));
            }
        }

        private void Talk()
        {
            var recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            btntalk.Text = Resources.Facerecognition_Talk_Speak_Now;
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                recognizer.SetInputToDefaultAudioDevice();
                //Loop through until we have a sucessful response
                for (var i = 0; i < 1; )
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
            btntalk.Text = Resources.Facerecognition_SucessfulRecognition_Answer;
            txtsaid.Text = speechResult;
            if (_correctAnswers.Contains(speechResult))
            {
                MessageBox.Show(Resources.WellDone);
                LoadScenario(Randomiser.NextRange(1, _voiceRecognitions.Count));
                txtsaid.Text = "";
            }
            else
            {
                MessageBox.Show(Resources.Wrong);
            }
        }

        private void btntalk_Click(object sender, EventArgs e)
        {
            Talk();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = _playsound;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

    }
}
