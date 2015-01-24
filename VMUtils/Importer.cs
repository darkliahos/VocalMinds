using System.IO;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class Importer<TScenario> : IImporter<TScenario>
    {
        private readonly ISerialiser<TScenario> _serialiser;

        public Importer(ISerialiser<TScenario> serialiser)
        {
            _serialiser = serialiser;
        }

        /// <summary>
        /// Load File Based On Path Given
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public TScenario LoadFile(string path)
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
        public TScenario StringToImportedScenarios(string jsonString)
        {
            return _serialiser.DeSerialise(jsonString);
        }

        public void WriteToFile(TScenario importedScenarios, string outputPath)
        {
            File.WriteAllText(outputPath, WriteToString(importedScenarios));
        }

        public string WriteToString(TScenario importedScenarios)
        {
            return _serialiser.Serialise(importedScenarios);
        }
    }
}
