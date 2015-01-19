using System.IO;
using VMUtils.Interfaces;

namespace VMUtils
{
    public class Exporter<TS> : IExporter<TS>
    {
        private readonly ISerialiser<TS> _serialiser;

        public Exporter(ISerialiser<TS> serialiser)
        {
            _serialiser = serialiser;
        }

        public void WriteToFile(TS importedScenarios, string outputPath)
        {
            File.WriteAllText(outputPath, WriteToString(importedScenarios));
        }

        public string WriteToString(TS importedScenarios)
        {
            return _serialiser.Serialise(importedScenarios);
        }
    }
}