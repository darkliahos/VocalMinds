using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class SocialSimulatorFileProcessor : IFileProcessor<SocialScenario, ImportedSocialScenarios>
    {
        private readonly ImportedSocialScenarios _importedSocialScenarios;

        public SocialSimulatorFileProcessor(IImporter<ImportedSocialScenarios> importer, string path)
        {
            _importedSocialScenarios = importer.LoadFile(path);
        }

        public List<SocialScenario> LoadScenarioFromFile()
        {
            return _importedSocialScenarios.VideoScenarios;
        }

        public ImportedSocialScenarios LoadScenarioObject()
        {
            throw new System.NotImplementedException();
        }

        public ImportedSocialScenarios RefreshScenarioObject()
        {
            throw new System.NotImplementedException();
        }
    }
}