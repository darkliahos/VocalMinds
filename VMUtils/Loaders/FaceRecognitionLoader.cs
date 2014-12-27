using System;
using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.Loaders
{
    public class FaceRecognitionLoader
    {
        private readonly ILogger _logger;

        public FaceRecognitionLoader(ILogger logger)
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
                _logger.LogError(error);
            }

            return faceRecognitions;
        }
    }
}
