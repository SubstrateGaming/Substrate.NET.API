using System;

namespace Substrate.NetApi.Exceptions
{
    public class ConverterAlreadyRegisteredException : Exception
    {
        public ConverterAlreadyRegisteredException(string message)
            : base(message)
        { }
    }
}