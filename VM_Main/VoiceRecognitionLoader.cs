﻿using System;
using System.Collections.Generic;
using NLog;
using VM.Model;

namespace VM_Main
{
    public class VoiceRecognitionLoader
    {
        private readonly Logger _logger;

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


    }
}