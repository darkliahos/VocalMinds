using System;
using System.Collections.Generic;
using NLog;
using VM_Main.Properties;
using VM_Model;

namespace VM_Main
{
    public class FaceRecognitionLoader
    {
        public bool LoadHardcodedScenarios { get; set; }

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
                int index = 0;
                if (LoadHardcodedScenarios)
                {
                    //TODO We want to remove the hardcoding of Scenarios see Github issue #17
                    throw new  NotImplementedException("Preloaded Scenarios Cannot be loaded");
                    //faceRecognitions.Add(1,
                    //    new FaceRecognitionScenario(Guid.Parse("53f0fad0-46ed-417d-b0ae-f45adf29fd15"), "Angry",
                    //        Resources.angryface));
                    //faceRecognitions.Add(2,
                    //    new FaceRecognitionScenario(Guid.Parse("05c9d8df-6e1b-4db0-998e-b4122566eda5"), "Angry",
                    //        Resources.angryface2));
                    //faceRecognitions.Add(3,
                    //    new FaceRecognitionScenario(Guid.Parse("0e148757-d925-4235-9047-46dd6f1b0e65"), "Confused",
                    //        Resources.confusedlook));
                    //faceRecognitions.Add(4,
                    //    new FaceRecognitionScenario(Guid.Parse("f061eede-b1d2-46ff-b42a-210c393cfa4f"), "Sad",
                    //        Resources.sadface));
                    //faceRecognitions.Add(5,
                    //    new FaceRecognitionScenario(Guid.Parse("65abb15c-9c45-40bd-9183-4aafbaf55463"), "Scared",
                    //        Resources.scaredface));
                    //faceRecognitions.Add(6,
                    //    new FaceRecognitionScenario(Guid.Parse("dba59b88-c6b4-4a74-b81d-e2812c81200f"), "Happy",
                    //        Resources.happyface));
                    //faceRecognitions.Add(7,
                    //    new FaceRecognitionScenario(Guid.Parse("b7825e94-7149-42fb-870e-4e26292756fa"), "Happy",
                    //        Resources.happyface2));
                    index = 8;//Start the index at 8 to take into account of preloaded scenarios
                }
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
