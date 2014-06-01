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
        private SpSharedRecoContext _objRecoContext;
        private ISpeechRecoGrammar _grammar;
        private ISpeechGrammarRule _command;
        string _userResponse;
        int _therandomvalue;
        string _correctAnswer;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly List<FaceRecognition> _faceRecognitions;
        

        public Facerecognition()
        {
            InitializeComponent();
            _faceRecognitions = new List<FaceRecognition>();
            PopulateFaceRecognition();
            FirstTimeInitialiser();
        }



        private void HypoEvent(int streamNumber, object streamPosition, ISpeechRecoResult result)
        {
            try
            {
                _userResponse = result.PhraseInfo.GetText();//gets what ever the user said and puts it in a variable
            }
            catch (Exception error)
            {
                Logger.ErrorException("HypoEvent Failure ",error);
                MessageBox.Show(Resources.NonComprehension);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                _objRecoContext = new SpSharedRecoContext();
                // Assign a eventhandler for the Hypothesis Event.
                _objRecoContext.Hypothesis += new _ISpeechRecoContextEvents_HypothesisEventHandler(HypoEvent);
                // Assign a eventhandler for the Recognition Event.
                //Creating an instance of the grammer object.
                _grammar = _objRecoContext.CreateGrammar(0);

                _command = _grammar.Rules.Add("MenuCommands", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);
                object PropValue = "";
                _command.InitialState.AddWordTransition(null, "happy", " ", SpeechGrammarWordType.SGLexical, "Happy", 1, ref PropValue, 1.0F);

                _command.InitialState.AddWordTransition(null, "grumpy", " ", SpeechGrammarWordType.SGLexical, "Grumpy", 2, ref PropValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "angry", " ", SpeechGrammarWordType.SGLexical, "angry", 3, ref PropValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "bossy", " ", SpeechGrammarWordType.SGLexical, "bossy", 4, ref PropValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "crazy", " ", SpeechGrammarWordType.SGLexical, "crazy", 5, ref PropValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "upset", " ", SpeechGrammarWordType.SGLexical, "upset", 6, ref PropValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "sad", " ", SpeechGrammarWordType.SGLexical, "sad", 7, ref PropValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "excitement", " ", SpeechGrammarWordType.SGLexical, "excitement", 8, ref PropValue, 1.0F);
                _grammar.Rules.Commit();
                _grammar.CmdSetRuleState("MenuCommandORHs", SpeechRuleState.SGDSActive);
            }
            catch (Exception error)
            {
                MessageBox.Show(Resources.speechreconotrunning);
                Logger.ErrorException("Answer Module", error);
            }
            textBox1.Focus();
        }

        private int RandomGenerator(int min, int max)
        {
            Random random = new Random();
            _therandomvalue = random.Next(min, max);
            return _therandomvalue;
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
