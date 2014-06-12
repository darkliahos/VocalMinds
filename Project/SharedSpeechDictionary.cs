using System;
using System.Runtime.InteropServices;
using NLog;
using SpeechLib;

namespace VM_Main
{
    public static class SharedSpeechDictionary
    {
        private static SpSharedRecoContext _speechDictionary;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static ISpeechRecoGrammar _grammar;

        private static ISpeechGrammarRule _command;

        public static string Translated { get; set; }

        public static void InitaliseSpeechObject()
        {
            _speechDictionary = new SpSharedRecoContext();
            PopulateSpeechDictionary();
        }

        private static void PopulateSpeechDictionary()
        {
            var osInfo = Environment.OSVersion;

            if(osInfo.Platform == PlatformID.Win32NT)
            {
                switch (osInfo.Version.Major)
                {
                    case 5:
                        XPSpeechMode();
                        break;
                    case 6:
                        VistaSpeechMode();
                        break;
                    default:
                        throw new NotSupportedException("Currently Supported for Windows XP, Vista & 7 Only");
                }
            }
            else
            {
                throw new NotSupportedException("Speech is not supported on running OS");
            }
        }

        /// <summary>
        /// Currently Supported for Windows Vista & 7
        /// </summary>
        private static void VistaSpeechMode()
        {
            // Assign a eventhandler for the Hypothesis Event.
            try
            {
                _speechDictionary = new SpeechLib.SpSharedRecoContext();
                // Assign a eventhandler for the Hypothesis Event.
                _speechDictionary.Hypothesis += new _ISpeechRecoContextEvents_HypothesisEventHandler(HypoEvent);
                // Assign a eventhandler for the Recognition Event.
                //Creating an instance of the grammer object.
                _grammar = _speechDictionary.CreateGrammar(0);

                _command = _grammar.Rules.Add("MenuCommands", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);

                object propValue = "";
                _command.InitialState.AddWordTransition(null, "happy", " ", SpeechGrammarWordType.SGLexical, "Happy", 1, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "grumpy", " ", SpeechGrammarWordType.SGLexical, "Grumpy", 2, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "angry", " ", SpeechGrammarWordType.SGLexical, "angry", 3, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "bossy", " ", SpeechGrammarWordType.SGLexical, "bossy", 4, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "crazy", " ", SpeechGrammarWordType.SGLexical, "crazy", 5, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "upset", " ", SpeechGrammarWordType.SGLexical, "upset", 6, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "sad", " ", SpeechGrammarWordType.SGLexical, "sad", 7, ref propValue, 1.0F);
                _command.InitialState.AddWordTransition(null, "excitement", " ", SpeechGrammarWordType.SGLexical, "excitement", 8, ref propValue, 1.0F);
                _grammar.Rules.Commit();
                _grammar.CmdSetRuleState("MenuCommandORHs", SpeechRuleState.SGDSActive);
            }
            catch (COMException error)
            {
                Logger.Error("SpeechLoader Failed", error);
                //Link to Error Codes: http://msdn.microsoft.com/en-us/library/ms717306(v=vs.85).aspx
                if (error.ErrorCode == -2147200940)
                {
                    Logger.Error("The rule already exists, but is not a top-level rule.");
                    throw new COMException("The rule already exists, but is not a top-level rule");
                }
            }
        }

        /// <summary>
        /// NOTE: This code is only supported for Windows XP service pack 2 & 3 only
        /// </summary>
        private static void XPSpeechMode()
        {
            if (_speechDictionary != null)
            {
                _speechDictionary = null;
                _grammar = null;
            }

            _speechDictionary = new SpSharedRecoContext();
            _speechDictionary.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(RecoContext_Recognition);
            _grammar = _speechDictionary.CreateGrammar(1);
            _grammar.DictationLoad();
            _grammar.DictationSetState(SpeechRuleState.SGDSActive);
        }

        public static void RecoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            Translated= Result.PhraseInfo.GetText(0, -1, true);
            Logger.Debug("Recognition: " + Translated + ", " + StreamNumber + ", " + StreamPosition);
        }

        private static void HypoEvent(int streamNumber, object streamPosition, ISpeechRecoResult result)
        {
            try
            {
                Translated= result.PhraseInfo.GetText();//gets what ever the user said and puts it in a variable
            }
            catch (Exception error)
            {
                Logger.Error("HypoEvent Failure", error);
                Translated= "";
            }
        }
    }
}
