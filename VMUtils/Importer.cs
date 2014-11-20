using System.IO;
using VM_Model;

namespace VMUtils
{
    public class Importer : IImporter
    {
        private readonly JsonSerialiser<ImportedScenarios> _jsonSerialiser = new JsonSerialiser<ImportedScenarios>();

        public void WriteToFile(ImportedScenarios importedScenarios, string outputPath)
        {
            File.WriteAllText(outputPath, WriteToString(importedScenarios));
        }

        public string WriteToString(ImportedScenarios importedScenarios)
        {
            return _jsonSerialiser.Serialise(importedScenarios);
        }

        /// <summary>
        /// Load File Based On Path Given
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ImportedScenarios LoadFile(string path)
        {
            string readOutput;
            using (var streamReader = new StreamReader(path))
            {
                readOutput = streamReader.ReadToEnd();
            }
            return StringToImportedScenarios(readOutput);
        }

        /// <summary>
        /// Designed to Load a JSON string into an imported Scenarios object
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public ImportedScenarios StringToImportedScenarios(string jsonString)
        {
            return _jsonSerialiser.DeSerialise(jsonString);
        }
    }
}
