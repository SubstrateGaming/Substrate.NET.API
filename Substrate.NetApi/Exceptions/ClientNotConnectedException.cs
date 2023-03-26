using System;

namespace Substrate.NetApi.Exceptions
{
    public class ClientNotConnectedException : Exception
    {
        public ClientNotConnectedException(string message)
            : base(message)
        { }
    }
}