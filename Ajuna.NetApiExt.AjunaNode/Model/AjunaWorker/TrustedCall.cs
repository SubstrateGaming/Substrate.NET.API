
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;

namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum TrustedCall
    {

        BalanceSetBalance,

        BalanceTransfer,

        BalanceUnshield,

        BalanceShield,

        NewGame,

        ConnectfourPlayTurn
    }

    public sealed class EnumTrustedCall : BaseEnumExt<
        TrustedCall,
        BaseTuple<AccountId32, AccountId32, Balance, Balance>,
        BaseTuple<AccountId32, AccountId32, Balance>,
        BaseTuple<AccountId32, AccountId32, Balance, ShardIdentifier>,
        BaseTuple<AccountId32, AccountId32, Balance>,
        BaseTuple<AccountId32, AccountId32, AccountId32>,
        BaseTuple<AccountId32, U8>,
        EnumGetter
        >
    {
    }
}