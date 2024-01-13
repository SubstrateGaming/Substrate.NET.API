using System;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Modules.Contracts
{
    /// <summary>
    /// Chain Module Interface
    /// </summary>
    public interface IChain
    {
        /// <summary>
        /// Get header and body of a relay chain block
        /// </summary>
        /// <returns></returns>
        Task<BlockData> GetBlockAsync();

        /// <summary>
        /// Get header and body of a relay chain block
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<BlockData> GetBlockAsync(CancellationToken token);

        /// <summary>
        /// Get header and body of a relay chain block
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        Task<BlockData> GetBlockAsync(Hash hash);

        /// <summary>
        /// Get header and body of a relay chain block
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<BlockData> GetBlockAsync(Hash hash, CancellationToken token);

        /// <summary>
        /// Get the block hash for a specific block
        /// </summary>
        /// <returns></returns>
        Task<Hash> GetBlockHashAsync();

        /// <summary>
        /// Get the block hash for a specific block
        /// </summary>
        /// <param name="blockNumber"></param>
        /// <returns></returns>
        Task<Hash> GetBlockHashAsync(BlockNumber blockNumber);

        /// <summary>
        /// Get the block hash for a specific block
        /// </summary>
        /// <param name="blockNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> GetBlockHashAsync(BlockNumber blockNumber, CancellationToken token);

        /// <summary>
        /// Get the block hash for a specific block
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> GetBlockHashAsync(CancellationToken token);

        /// <summary>
        /// Get hash of the last finalized block in the canon chain
        /// </summary>
        /// <returns></returns>
        Task<Hash> GetFinalizedHeadAsync();

        /// <summary>
        /// Get hash of the last finalized block in the canon chain
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> GetFinalizedHeadAsync(CancellationToken token);

        /// <summary>
        /// Retrieves the header for a specific block
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        Task<Header> GetHeaderAsync(Hash hash = null);

        /// <summary>
        /// Retrieves the header for a specific block
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Header> GetHeaderAsync(CancellationToken token);

        /// <summary>
        /// Retrieves the header for a specific block
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Header> GetHeaderAsync(Hash hash, CancellationToken token);

        /// <summary>
        /// Retrieves the newest header via subscription
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback);

        /// <summary>
        /// Retrieves the newest header via subscription
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback, CancellationToken token);

        /// <summary>
        /// Retrieves the best finalized header via subscription
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback);

        /// <summary>
        /// Retrieves the best finalized header via subscription
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback, CancellationToken token);

        /// <summary>
        /// Retrieves the best header via subscription
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback);

        /// <summary>
        /// Retrieves the best header via subscription
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeNewHeadsAsync(string subscriptionId, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> UnubscribeNewHeadsAsync(string subscriptionId);
    }
}