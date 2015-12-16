using System;

namespace Empires.Libraries
{
    public class UnitNotReadyException: Exception
    {
        public UnitNotReadyException()
        {
        }

        public UnitNotReadyException(string message)
            : base(message)
        {
        }

        public UnitNotReadyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
