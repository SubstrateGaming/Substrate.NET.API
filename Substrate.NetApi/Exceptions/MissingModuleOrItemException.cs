using System;

namespace Substrate.NetApi.Exceptions
{
    public class MissingModuleOrItemException : Exception
    {
        public MissingModuleOrItemException(string message)
            : base(message)
        {
        }
    }
}