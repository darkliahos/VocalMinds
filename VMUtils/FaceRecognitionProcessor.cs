using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class FaceRecognitionProcessor : IFileProcessor<FaceRecognitionScenario>
    {
        private readonly ImportedFaceRecognitionScenario _importedScenarios;

        public FaceRecognitionProcessor(IImporter<ImportedFaceRecognitionScenario> importer, string path)
        {
            _importedScenarios = importer.LoadFile(path);
        }

        public List<FaceRecognitionScenario> LoadScenarioFromFile()
        {
            return _importedScenarios.FaceRecognitionScenarios;
        }
    }
}