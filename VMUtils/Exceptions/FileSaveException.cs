using System;

namespace VMUtils.Exceptions
{
    public class FileSaveException : Exception
    {
        public FileSaveException(string message)
            : base(message)
        {
        }

        public FileSaveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}