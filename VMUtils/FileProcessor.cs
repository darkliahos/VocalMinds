using System.Collections.Generic;
using VM_Model;

namespace VMUtils
{
    public class FileProcessor:IFileProcessor
    {
        private readonly ImportedScenarios _importedScenarios;

        public FileProcessor(IImporter importer, string path)
        {
            _importedScenarios = importer.LoadFile(path);
        }

        public List<FaceRecognitionScenario> GetFRScenariosFromFile()
        {
            return _importedScenarios.FaceRecognitionScenarios;
        }

        public List<VoiceRecognitionScenario> GetVRScenariosFromFile()
        {
            return _importedScenarios.VoiceRecognitionScenarios;
        }

        public List<VideoScenario> GetVidWScenariosFromFile()
        {
            return _importedScenarios.VideoScenarios;
        }
    }
}