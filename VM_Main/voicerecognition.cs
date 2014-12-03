using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NLog;
using SpeechLib;
/*
 * THINGS TO DO Code needs to be optomised a tad, some entities are irrelevent 
 * Add more expressions
 * Add some voices
 * Add Array System
 */
using VM_Main.Properties;
using VM_Model;

namespace VM_Main
{

    public partial class Voicerecognition : Form
    {
        string _correctAnswer;
        string _playsound;

        private SpSharedRecoContext objRecoContext = null;
        private ISpeechRecoGrammar grammar = null;
        private ISpeechGrammarRule command = null;
        string _userAnswer;

        
        int therandomvalue = 4;
        int runcount = 1;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly Dictionary<int, VoiceRecognitionScenario> _voiceRecognitions = new Dictionary<int, VoiceRecognitionScenario>();
        readonly VoiceRecognitionLoader _vrc = new VoiceRecognitionLoader(Logger);

        public Voicerecognition(List<VoiceRecognitionScenario> recognition)
        {
            InitializeComponent();
            _voiceRecognitions = _vrc.PopulateVoiceRecognitionScenarios(recognition);
            LoadScenario(Randomiser.RandomGenerator(1, _voiceRecognitions.Count));
        }

        private void LoadScenario(int index)
        {
            VoiceRecognitionScenario voiceResult;
            if (_voiceRecognitions.TryGetValue(index, out voiceResult))
            {
                _playsound = voiceResult.AudioPath;
                _correctAnswer = voiceResult.Answer;
            }
            else
            {
                MessageBox.Show(Resources.Facerecognition_LoadScenario_Scenario_Load_Failed);
                Logger.Debug(string.Format("Scenario Loader Faulted on {0}", index));
            }
        }

        private void btntalk_Click(object sender, EventArgs e)
        {
            //code adapted from an example by Suhel Survindas
            //original from here:
            try
            {
               
                objRecoContext = new SpSharedRecoContext();
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
                _userAnswer = Result.PhraseInfo.GetText(0, -1, true);//gets what ever the user said and puts it in a variable
            txtsaid.Text = _userAnswer;//TESTING PURPOSES
            }
                catch(Exception eh)
            {
                MessageBox.Show("Program did understand what you just said!" +"\n"+ eh);
                }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = _playsound;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
