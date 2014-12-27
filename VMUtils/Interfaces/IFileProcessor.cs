using System.Collections.Generic;

namespace VMUtils.Interfaces
{
    public interface IFileProcessor<T>
    {
        List<T> LoadScenarioFromFile();
    }
}