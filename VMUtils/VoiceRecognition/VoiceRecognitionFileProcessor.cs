using System.Collections.Generic;
using VMUtils.Interfaces;
using VM.Model;

namespace VMUtils.VoiceRecognition
{
    public class VoiceRecognitionFileProcessor : IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario>
    {
        private ImportedVoiceRecognitionScenario _importedScenarios;
        private readonly IImporter<ImportedVoiceRecognitionScenario> _importer;
        private readonly string _path;

        public VoiceRecognitionFileProcessor(IImporter<ImportedVoiceRecognitionScenario> importer, string path)
        {
            _importer = importer;
            _path = path;
            _importedScenarios = importer.LoadFile(path);
        }
        public List<VoiceRecognitionScenario> LoadScenarioFromFile()
        {
            return _importedScenarios.VoiceRecognitionScenarios;
        }

        public ImportedVoiceRecognitionScenario LoadScenarioObject()
        {
            return _importedScenarios;
        }

        public ImportedVoiceRecognitionScenario RefreshScenarioObject()
        {
            _importedScenarios = _importer.LoadFile(_path);
            return _importedScenarios;
        }
    }
}