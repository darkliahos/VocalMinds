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

        public Task<VoiceRecognitionScenario> GetVRScenariosFromFile()
        {
            throw new NotImplementedException();
        }

        public Task<VideoScenario> GetVidWScenariosFromFile()
        {
            throw new NotImplementedException();
        }
    }
}