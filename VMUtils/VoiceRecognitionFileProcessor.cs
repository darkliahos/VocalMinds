using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class VoiceRecognitionFileProcessor : IFileProcessor<VoiceRecognitionScenario>
    {
        private readonly ImportedScenarios _importedScenarios;

        public VoiceRecognitionFileProcessor(IImporter<ImportedScenarios> importer, string path)
        {
            _importedScenarios = importer.LoadFile(path);
        }
        public List<VoiceRecognitionScenario> LoadScenarioFromFile()
        {
            return _importedScenarios.VoiceRecognitionScenarios;
        }
    }
}