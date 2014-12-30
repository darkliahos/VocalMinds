using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class FaceRecognitionProcessor : IFileProcessor<FaceRecognitionScenario>
    {
        private readonly IImporter<ImportedFaceRecognitionScenario> _importer;
        private readonly string _path;
        private ImportedFaceRecognitionScenario _importedScenarios;

        public FaceRecognitionProcessor(IImporter<ImportedFaceRecognitionScenario> importer, string path)
        {
            _importer = importer;
            _path = path;
            _importedScenarios = importer.LoadFile(path);
        }

        public List<FaceRecognitionScenario> LoadScenarioFromFile()
        {
            return _importedScenarios.FaceRecognitionScenarios;
        }

        /// <summary>
        /// Overload to return just the imported Face Reco scenarios object
        /// </summary>
        /// <returns>A fully populated ImportedFaceRecognitionScenario from the file</returns>
        public ImportedFaceRecognitionScenario LoadFrsObject()
        {
            return _importedScenarios;
        }

        public ImportedFaceRecognitionScenario RefreshFrsObject()
        {
            _importedScenarios = _importer.LoadFile(_path);
            return _importedScenarios;
        }
    }
}