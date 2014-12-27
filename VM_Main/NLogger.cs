using System;
using NLog;
using VMUtils.Interfaces;

namespace VM_Main
{
    public class NLogger:ILogger
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void LogError(Exception exception)
        {
            Logger.Error(exception);
        }

        public void LogError(string message, Exception exception)
        {
            Logger.Error(message, exception);
        }

        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        public void LogTrace(string message)
        {
            Logger.Trace(message);
        }
    }
}
