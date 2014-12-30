using System.Collections.Generic;

namespace VMUtils.Interfaces
{
    public interface IFileProcessor<T,S>
    {
        List<T> LoadScenarioFromFile();

        S LoadScenarioObject();

        S RefreshScenarioObject();
    }
}