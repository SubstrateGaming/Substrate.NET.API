using System;

namespace AjunaNetApi.Exceptions
{
    public class MissingParameterException : Exception
    {
        public MissingParameterException(string message)
            : base(message)
        { }
    }
}
