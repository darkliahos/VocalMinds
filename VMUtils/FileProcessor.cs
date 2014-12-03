using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VM_Model;

namespace VMUtils
{
    public class FileProcessor:IFileProcessor
    {
        private readonly IImporter _importer;
        private readonly ImportedScenarios _importedScenarios;

        public FileProcessor(IImporter importer, string path)
        {
            _importer = importer;
            _importedScenarios = _importer.LoadFile(path);
        }

        public List<FaceRecognitionScenario> GetImportedFRScenariosFromFile()
        {
            return _importedScenarios.FaceRecognitionScenarios;
        }

        public List<VoiceRecognitionScenario> GetVRScenariosFromFile()
        {
            return _importedScenarios.VoiceRecognitionScenarios;
        }

        public Task<VideoScenario> GetVidWScenariosFromFile()
        {
            throw new NotImplementedException();
        }
    }
}