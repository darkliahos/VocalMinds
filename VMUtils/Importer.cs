using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ImportedScenarios LoadFile(string path)
        {
            string readOutput = "";
            using (StreamReader streamReader = new StreamReader(path))
            {
                readOutput = streamReader.ReadToEnd();
            }
            return StringToImportedScenarios(readOutput);
        }

        public ImportedScenarios StringToImportedScenarios(string jsonString)
        {
            return _jsonSerialiser.DeSerialise(jsonString);
        }
    }
}
