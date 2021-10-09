using System;

namespace AjunaNetApi.Exceptions
{
    public class ClientNotConnectedException : Exception
    {
        public ClientNotConnectedException(string message)
            : base(message)
        { }
    }
}
