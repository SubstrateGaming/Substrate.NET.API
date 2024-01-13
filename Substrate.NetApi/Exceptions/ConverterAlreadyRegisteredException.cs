using System;

namespace Substrate.NetApi.Exceptions
{
    /// <summary>
    /// Converter Already Registered Exception
    /// </summary>
    public class ConverterAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Converter Already Registered Exception
        /// </summary>
        /// <param name="message"></param>
        public ConverterAlreadyRegisteredException(string message)
            : base(message)
        { }
    }
}