using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.FaceRecognition
{
    public class FaceRecognitionFileProcessor : IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>
    {
        private readonly IImporter<ImportedFaceRecognitionScenario> _importer;
        private readonly string _path;
        private ImportedFaceRecognitionScenario _importedScenarios;

        public FaceRecognitionFileProcessor(IImporter<ImportedFaceRecognitionScenario> importer, string path)
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
        public ImportedFaceRecognitionScenario LoadScenarioObject()
        {
            return _importedScenarios;
        }

        /// <summary>
        /// Refreshing the full scenario object from the file
        /// </summary>
        /// <returns></returns>
        public ImportedFaceRecognitionScenario RefreshScenarioObject()
        {
            _importedScenarios = _importer.LoadFile(_path);
            return _importedScenarios;
        }
    }
    }