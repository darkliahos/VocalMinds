using System;

namespace VMUtils.Interfaces
{
    public interface ILogger
    {
        void LogError(Exception exception);

        void LogError(string message, Exception exception);

        void LogDebug(string message);

        void LogTrace(string message);
    }
}
