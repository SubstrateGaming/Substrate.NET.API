using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Base;
using System;


namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum TrustedOperation
    {

        IndirectCall,

        DirectCall,

        Get
    }

    public sealed class EnumTrustedOperation : BaseEnumExt<TrustedOperation, TrustedCallSigned, TrustedCallSigned, EnumGetter>
    {
    }
}
