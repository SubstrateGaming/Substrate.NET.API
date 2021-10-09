using System;

namespace AjunaNetApi.Exceptions
{
    public class MissingModuleOrItemException : Exception
    {
        public MissingModuleOrItemException(string message)
            : base(message)
        {

        }
    }
}
