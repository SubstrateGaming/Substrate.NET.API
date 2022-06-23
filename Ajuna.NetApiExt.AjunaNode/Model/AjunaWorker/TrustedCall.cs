
using Ajuna.NetApi.Model.Base;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Base;

namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum TrustedCall
    {

        BalanceSetBalance,

        BalanceTransfer,

        BalanceUnshield,

        BalanceShield,

        BoardNewGame,

        BoardPlayTurn,

        BoardFinishGame
    }

    public sealed class EnumTrustedCall : BaseEnumExt<
        TrustedCall,
        BaseTuple<AccountId32, AccountId32, Balance, Balance>,
        BaseTuple<AccountId32, AccountId32, Balance>,
        BaseTuple<AccountId32, AccountId32, Balance, ShardIdentifier>,
        BaseTuple<AccountId32, AccountId32, Balance>,
        BaseTuple<AccountId32, SgxBoardId, BTreeSet>,
        BaseTuple<AccountId32, SgxGameTurn>,
        BaseTuple<AccountId32, SgxBoardId>
        >
    {
    }
}

