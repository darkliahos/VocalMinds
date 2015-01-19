using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class SocialSimulatorFileProcessor : IFileProcessor<VideoScenario, ImportedScenarios>
    {
        private readonly ImportedScenarios _importedScenarios;

        public SocialSimulatorFileProcessor(IImporter<ImportedScenarios> importer, string path)
        {
            _importedScenarios = importer.LoadFile(path);
        }

        public List<VideoScenario> LoadScenarioFromFile()
        {
            return _importedScenarios.VideoScenarios;
        }

        public ImportedScenarios LoadScenarioObject()
        {
            throw new System.NotImplementedException();
        }

        public ImportedScenarios RefreshScenarioObject()
        {
            throw new System.NotImplementedException();
        }
    }
}