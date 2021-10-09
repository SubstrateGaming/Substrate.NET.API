using System;

namespace AjunaNetApi.Exceptions
{
    public class ConverterAlreadyRegisteredException : Exception
    {
        public ConverterAlreadyRegisteredException(string message)
            : base(message)
        { }
    }
}
