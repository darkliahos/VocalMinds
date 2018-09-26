using System;
using System.Collections.Generic;
using VM.Model;
using NLog;

namespace VMUtils.FaceRecognition
{
    public class FaceRecognitionLoader
    {
        private readonly Logger _logger;

        public FaceRecognitionLoader(Logger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Populates the Facerecognition Dictionary
        /// </summary>
        /// <param name="importedScenarios">A list of imported Scenarios</param>
        /// <returns></returns>
        public Dictionary<int, FaceRecognitionScenario> PopulateFaceRecognitionScenarios(List<FaceRecognitionScenario> importedScenarios)
        {
            var faceRecognitions = new Dictionary<int, FaceRecognitionScenario>();
            try
            {
                int index = 1;
                if (importedScenarios != null)
                {
                    foreach (var frs in importedScenarios)
                    {
                        faceRecognitions.Add(index, frs);
                        index++;
                    }
                }
            }
            catch (Exception error)
            {
                _logger.Error(error);
            }

            return faceRecognitions;
        }
    }
}
