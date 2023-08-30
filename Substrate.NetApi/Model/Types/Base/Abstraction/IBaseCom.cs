using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Model.Types.Base.Abstraction
{
    public interface IBaseCom : IType
    {
        CompactInteger Value { get; }
    }
}
