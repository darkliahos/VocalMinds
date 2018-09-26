using System.Collections.Generic;
using VMUtils.Interfaces;
using VM.Model;

namespace VMUtils
{
    public class SocialSimulatorFileProcessor : IFileProcessor<SocialScenario, ImportedSocialScenarios>
    {
        private readonly IImporter<ImportedSocialScenarios> _importer;
        private readonly string _path;
        private ImportedSocialScenarios _socialScenarios;

        public SocialSimulatorFileProcessor(IImporter<ImportedSocialScenarios> importer, string path)
        {
            _importer = importer;
            _path = path;
            _socialScenarios = importer.LoadFile(path);
        }

        public List<SocialScenario> LoadScenarioFromFile()
        {
            return _socialScenarios.SocialScenario;
        }

        public ImportedSocialScenarios LoadScenarioObject()
        {
            return _socialScenarios;
        }

        public ImportedSocialScenarios RefreshScenarioObject()
        {
            _socialScenarios = _importer.LoadFile(_path);
            return _socialScenarios;
        }
    }
}