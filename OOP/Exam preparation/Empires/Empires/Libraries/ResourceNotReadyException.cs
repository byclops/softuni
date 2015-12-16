using System;

namespace Empires.Libraries
{
    public class ResourceNotReadyException : Exception
    {
        public ResourceNotReadyException()
        {
        }

        public ResourceNotReadyException(string message)
            : base(message)
        {
        }

        public ResourceNotReadyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}