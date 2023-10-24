using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Rpc
{
    public enum TransactionEvent
    {
        Validated,

        Broadcasted,

        BestChainBlockIncluded,

        Finalized,

        Error,

        Invalid,

        Dropped
    }

    public sealed class TransactionEventInfo
    {
        public TransactionEvent TransactionEvent { get; set; }

        public uint? NumPeers { get; set; }

        public Hash Hash { get; set; }

        public uint? Index { get; set; }

        public bool? Broadcasted { get; set; }

        public string Error { get; set; }
    }
}