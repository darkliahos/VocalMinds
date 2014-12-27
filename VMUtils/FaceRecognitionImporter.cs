using System.IO;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class FaceRecognitionImporter : IImporter<ImportedFaceRecognitionScenario>
    {
        private readonly JsonSerialiser<ImportedFaceRecognitionScenario> _jsonSerialiser = new JsonSerialiser<ImportedFaceRecognitionScenario>();

        public void WriteToFile(ImportedFaceRecognitionScenario importedScenarios, string outputPath)
        {
            File.WriteAllText(outputPath, WriteToString(importedScenarios));
        }

        public string WriteToString(ImportedFaceRecognitionScenario importedScenarios)
        {
            return _jsonSerialiser.Serialise(importedScenarios);
        }

        public ImportedFaceRecognitionScenario LoadFile(string path)
        {
            string readOutput;
            using (var streamReader = new StreamReader(path))
            {
                readOutput = streamReader.ReadToEnd();
            }
            return StringToImportedScenarios(readOutput);
        }

        public ImportedFaceRecognitionScenario StringToImportedScenarios(string jsonString)
        {
            return _jsonSerialiser.DeSerialise(jsonString);
        }
    }
}