using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Transaction Event
    /// </summary>
    public enum TransactionEvent
    {
        /// <summary>
        /// The validated event indicates that this transaction has been checked and is considered as valid by the runtime.
        /// </summary>
        Validated,

        /// <summary>
        /// The broadcasted event indicates the number of other peers this transaction has been broadcasted to.
        /// </summary>
        Broadcasted,

        /// <summary>
        /// The bestChainBlockIncluded event indicates which block of the best chain the transaction is included in.
        /// </summary>
        BestChainBlockIncluded,

        /// <summary>
        /// The finalized event indicates that this transaction is present in a block of the chain that is finalized.
        /// </summary>
        Finalized,

        /// <summary>
        /// The error event indicates that an internal error within the client has happened.
        /// </summary>
        Error,

        /// <summary>
        /// The invalid event indicates that the runtime has marked the transaction as invalid.
        /// </summary>
        Invalid,

        /// <summary>
        /// The dropped event indicates that the client wasn't capable of keeping track of this transaction.
        /// </summary>
        Dropped
    }

    /// <summary>
    /// Transaction Event Info
    /// </summary>
    public sealed class TransactionEventInfo
    {
        /// <summary>   
        /// Transaction Event
        /// </summary>
        public TransactionEvent TransactionEvent { get; set; }

        /// <summary>
        /// Is the total number of individual peers this transaction has been broadcasted to.
        /// </summary>
        public uint? NumPeers { get; set; }

        /// <summary>
        /// Is a string containing the hexadecimal-encoded hash of the header of the block. index is an integer indicating the
        /// 0-based index of this transaction within the body of this block.
        /// </summary>
        public Hash Hash { get; set; }

        /// <summary>
        /// Index is an integer indicating the 0-based index of this transaction within the body of this block.
        /// </summary>
        public uint? Index { get; set; }

        /// <summary>
        /// If the broadcasted field is true, then this transaction has been sent to other peers and might still be included in the
        /// chain in the future. No guarantee is offered that the transaction will be included in the chain even if broadcasted is
        /// true. However, if broadcasted is false, then it is guaranteed that this transaction will not be included, unless it has
        /// been submitted in parallel on a different node.
        /// </summary>
        public bool? Broadcasted { get; set; }

        /// <summary>
        /// Is a human-readable error message indicating what happened. This string isn't meant to be shown to end users, but is for
        /// developers to understand the problem.
        /// </summary>
        public string Error { get; set; }
    }
}