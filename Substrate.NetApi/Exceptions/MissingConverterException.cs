using System;

namespace Substrate.NetApi.Exceptions
{
    /// <summary>
    /// Missing Converter Exception
    /// </summary>
    public class MissingConverterException : Exception
    {
        /// <summary>
        /// Missing Converter Exception
        /// </summary>
        /// <param name="message"></param>
        public MissingConverterException(string message) :
            base(message)
        { }
    }
}