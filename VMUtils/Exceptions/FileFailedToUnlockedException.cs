using System;

namespace VMUtils.Exceptions
{
    public class FileFailedToUnlockedException : Exception
    {
        public FileFailedToUnlockedException()
        {
        }

        public FileFailedToUnlockedException(string message)
            : base(message)
        {
        }

        public FileFailedToUnlockedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}