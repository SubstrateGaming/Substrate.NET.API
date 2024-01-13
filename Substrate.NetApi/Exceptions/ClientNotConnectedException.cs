using System;

namespace Substrate.NetApi.Exceptions
{

    /// <summary>
    /// Client Not Connected Exception
    /// </summary>
    public class ClientNotConnectedException : Exception
    {
        /// <summary>
        /// Client Not Connected Exception
        /// </summary>
        /// <param name="message"></param>
        public ClientNotConnectedException(string message)
            : base(message)
        { }
    }
}