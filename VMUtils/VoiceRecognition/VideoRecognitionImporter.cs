using System.IO;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.VoiceRecognition
{
    public class VideoRecognitionImporter : IImporter<ImportedVoiceRecognitionScenario>
    {
        private readonly ISerialiser<ImportedVoiceRecognitionScenario> _serialiser;

        public VideoRecognitionImporter(ISerialiser<ImportedVoiceRecognitionScenario> serialiser)
        {
            _serialiser = serialiser;
        }

        public ImportedVoiceRecognitionScenario LoadFile(string path)
        {
            string readOutput;
            using (var streamReader = new StreamReader(path))
            {
                readOutput = streamReader.ReadToEnd();
            }
            return StringToImportedScenarios(readOutput);
        }

        public ImportedVoiceRecognitionScenario StringToImportedScenarios(string jsonString)
        {
            return _serialiser.DeSerialise(jsonString);
        }

        public string WriteToString(ImportedVoiceRecognitionScenario importedScenarios)
        {
            return _serialiser.Serialise(importedScenarios);
        }
    }
}