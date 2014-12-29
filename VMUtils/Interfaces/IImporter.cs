namespace VMUtils.Interfaces
{
    public interface IImporter<T>
    {
        /// <summary>
        /// Load Files From specified Path
        /// </summary>
        /// <param name="path">where the file is located</param>
        /// <returns>a fully formed object read from the file</returns>
        T LoadFile(string path);

        /// <summary>
        /// Creates an object based on a text json
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        T StringToImportedScenarios(string jsonString);
    }
}