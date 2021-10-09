using System;

namespace Ajuna.NetApi.Exceptions
{
    public class ClientNotConnectedException : Exception
    {
        public ClientNotConnectedException(string message)
            : base(message)
        { }
    }
}
