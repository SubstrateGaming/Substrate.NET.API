using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


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

    public enum PublicGetter
    {
        SomeValue,
    }

    public sealed class EnumPublicGetter : BaseEnum<PublicGetter>
    {
    }
}
