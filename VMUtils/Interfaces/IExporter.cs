namespace VMUtils.Interfaces
{
    public interface IExporter<T>
    {
        void WriteToFile(T importedScenarios, string outputPath);

        string WriteToString(T importedScenarios);   
    }
}