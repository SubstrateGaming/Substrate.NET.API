using System;

namespace Substrate.NetApi.Exceptions
{
    public class MissingConverterException : Exception
    {
        public MissingConverterException(string message) :
            base(message)
        { }
    }
}