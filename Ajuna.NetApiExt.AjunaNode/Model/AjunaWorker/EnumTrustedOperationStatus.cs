using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum TrustedOperationStatus
    {
        /// TrustedOperation is submitted to the top pool.
        Submitted,
        /// TrustedOperation is part of the future queue.
        Future,
        /// TrustedOperation is part of the ready queue.
        Ready,
        /// The operation has been broadcast to the given peers.
        Broadcast,
        /// TrustedOperation has been included in block with given hash.
        InSidechainBlock,
        /// The block this operation was included in has been retracted.
        Retracted,
        /// Maximum number of finality watchers has been reached,
        /// old watchers are being removed.
        FinalityTimeout,
        /// TrustedOperation has been finalized by a finality-gadget, e.g GRANDPA
        Finalized,
        /// TrustedOperation has been replaced in the pool, by another operation
        /// that provides the same tags. (e.g. same (sender, nonce)).
        Usurped,
        /// TrustedOperation has been dropped from the pool because of the limit.
        Dropped,
        /// TrustedOperation is no longer valid in the current state.
        Invalid,
    }

    public sealed class EnumTrustedOperationStatus : BaseEnumExt<TrustedOperationStatus, BaseVoid, BaseVoid, BaseVoid, BaseVoid, H256, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}
