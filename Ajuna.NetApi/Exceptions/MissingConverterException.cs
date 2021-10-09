using System;

namespace Ajuna.NetApi.Exceptions
{
    public class MissingConverterException : Exception
    {
        public MissingConverterException(string message) :
            base(message)
        { }
    }
}
