using System.IO;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class FaceRecognitionExporter : IExporter<ImportedFaceRecognitionScenario>
    {
        private readonly ISerialiser<ImportedFaceRecognitionScenario> _serialiser;

        public FaceRecognitionExporter(ISerialiser<ImportedFaceRecognitionScenario> serialiser)
        {
            _serialiser = serialiser;
        }

        public void WriteToFile(ImportedFaceRecognitionScenario importedScenarios, string outputPath)
        {
            File.WriteAllText(outputPath, WriteToString(importedScenarios));
        }

        public string WriteToString(ImportedFaceRecognitionScenario importedScenarios)
        {
            return _serialiser.Serialise(importedScenarios);
        }
    }
}