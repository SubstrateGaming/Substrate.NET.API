using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Model.Types.Base.Abstraction
{
    public interface IBaseBitSeq : IType
    {
        IType[] GetValues();
        byte[] Reverse(byte[] b);
        byte Reverse(byte b);
    }
}
