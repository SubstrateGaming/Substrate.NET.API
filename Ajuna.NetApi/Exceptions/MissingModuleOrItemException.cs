using System;

namespace Ajuna.NetApi.Exceptions
{
    public class MissingModuleOrItemException : Exception
    {
        public MissingModuleOrItemException(string message)
            : base(message)
        {

        }
    }
}
