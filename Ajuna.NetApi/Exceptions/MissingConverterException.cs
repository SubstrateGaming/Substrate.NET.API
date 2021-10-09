using System;

namespace AjunaNetApi.Exceptions
{
    public class MissingConverterException : Exception
    {
        public MissingConverterException(string message) :
            base(message)
        { }
    }
}
