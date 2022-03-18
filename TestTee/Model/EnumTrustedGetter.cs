using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Base;


namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum TrustedGetter
    {
        FreeBalance,
        ReservedBalance,
        Nonce,
        Board
    }

    /// <summary>
    /// >> 111 - Variant[pallet_balances.Releases]
    /// </summary>
    public sealed class EnumTrustedGetter : BaseEnumExt<TrustedGetter, AccountId32, AccountId32, AccountId32, AccountId32>
    {
    }

}
