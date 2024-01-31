using System;

namespace Substrate.NetApi.Exceptions
{
    /// <summary>
    /// Missing Module Or Item Exception
    /// </summary>
    public class MissingModuleOrItemException : Exception
    {
        /// <summary>
        /// Missing Module Or Item Exception
        /// </summary>
        /// <param name="message"></param>
        public MissingModuleOrItemException(string message)
            : base(message)
        {
        }
    }
}