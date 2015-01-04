using System;

namespace VMUtils.Exceptions
{
    public class FileLockedException : Exception
    {
        public FileLockedException()
        {
        }

        public FileLockedException(string message)
            : base(message)
        {
        }

        public FileLockedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
