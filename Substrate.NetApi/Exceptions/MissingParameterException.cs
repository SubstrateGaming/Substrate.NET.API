using System;

namespace Substrate.NetApi.Exceptions
{
    public class MissingParameterException : Exception
    {
        public MissingParameterException(string message)
            : base(message)
        { }
    }
}