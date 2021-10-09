using System;

namespace Ajuna.NetApi.Exceptions
{
    public class ConverterAlreadyRegisteredException : Exception
    {
        public ConverterAlreadyRegisteredException(string message)
            : base(message)
        { }
    }
}
