using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Model.Types.Base.Abstraction
{
    public interface IBaseEnumerable : IType
    {
        /// <summary>
        /// List of each item
        /// </summary>
        IType[] GetValues();
    }
}
