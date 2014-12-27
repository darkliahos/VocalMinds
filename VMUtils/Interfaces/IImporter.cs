namespace VMUtils.Interfaces
{
    public interface IImporter<T>
    {
        void WriteToFile(T importedScenarios, string outputPath);

        string WriteToString(T importedScenarios);

        T LoadFile(string path);

        T StringToImportedScenarios(string jsonString);
    }
}