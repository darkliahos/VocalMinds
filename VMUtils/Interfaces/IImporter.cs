using VM_Model;

namespace VMUtils.Interfaces
{
    public interface IImporter
    {
        void WriteToFile(ImportedScenarios importedScenarios, string outputPath);

        string WriteToString(ImportedScenarios importedScenarios);

        ImportedScenarios LoadFile(string path);

        ImportedScenarios StringToImportedScenarios(string jsonString);
    }
}