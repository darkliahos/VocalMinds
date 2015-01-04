using System.IO;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.FaceRecognition
{
    public class FaceRecognitionImporter : IImporter<ImportedFaceRecognitionScenario>
    {
        private readonly ISerialiser<ImportedFaceRecognitionScenario> _serialiser;

        public FaceRecognitionImporter(ISerialiser<ImportedFaceRecognitionScenario> serialiser)
        {
            _serialiser = serialiser;
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
            return _serialiser.DeSerialise(jsonString);
        }
    }
}