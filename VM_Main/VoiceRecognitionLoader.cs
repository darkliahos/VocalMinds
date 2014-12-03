using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NLog;
using VM_Main.Properties;
using VM_Model;

namespace VM_Main
{
    public class VoiceRecognitionLoader
    {
        public bool LoadHardcodedScenarios { get; set; }

        private readonly Logger _logger;

        public List<string> HardcodedList { get; set; }

        public VoiceRecognitionLoader(Logger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Populates the Voice Recognition Dictionary
        /// </summary>
        /// <param name="importedScenarios">A list of imported Scenarios</param>
        /// <returns></returns>
        public Dictionary<int, VoiceRecognitionScenario> PopulateVoiceRecognitionScenarios(List<VoiceRecognitionScenario> importedScenarios)
        {
            var voiceRecognitions = new Dictionary<int, VoiceRecognitionScenario>();
            try
            {
                var index = 1;
                if (LoadHardcodedScenarios)
                {
                    voiceRecognitions.Add(1, new VoiceRecognitionScenario
                    {
                        Answer = "Tired",
                        AudioPath = PathCombiner(@"\Resources\yawning_1.mp3"),
                        Author = "https://www.voices.com/",
                        CopyrightDisclaimer = "Royalty free Credit goes to https://www.voices.com/",
                        Id = Guid.Parse("a987ec24-a966-45d2-b58d-db6a241c135d")
                    });

                    voiceRecognitions.Add(2, new VoiceRecognitionScenario
                    {
                        Answer = "Sad",
                        AudioPath = PathCombiner(@"\Resources\sobbing_male_1.mp3"),
                        Author = "https://www.voices.com/",
                        CopyrightDisclaimer = "Royalty free Credit goes to https://www.voices.com/",
                        Id = Guid.Parse("013282a0-a859-4126-ae6b-c8f61032a458")
                    });

                    HardcodedList.Add("sobbing_male_1");
                    HardcodedList.Add("yawning_1");
                    index = 3;
                }
                if (importedScenarios != null)
                {
                    
                    foreach (var vrs in importedScenarios)
                    {
                        voiceRecognitions.Add(index, vrs);
                        index++;
                    }
                }
            }
            catch (Exception error)
            {
                _logger.Error(error);
            }

            return voiceRecognitions;

        }

        private string PathCombiner(string resultingpath)
        {
            string assPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string combinePath = string.Concat(assPath, resultingpath);
            return combinePath;
        }
    }
}