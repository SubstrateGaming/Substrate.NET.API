using System;

namespace Substrate.NetApi.Exceptions
{
    /// <summary>
    /// Missing Parameter Exception
    /// </summary>
    public class MissingParameterException : Exception
    {
        /// <summary>
        /// Missing Parameter Exception
        /// </summary>
        /// <param name="message"></param>
        public MissingParameterException(string message)
            : base(message)
        { }
    }
}