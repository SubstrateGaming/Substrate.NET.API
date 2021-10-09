using System;

namespace Ajuna.NetApi.Exceptions
{
    public class MissingParameterException : Exception
    {
        public MissingParameterException(string message)
            : base(message)
        { }
    }
}
