using System;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Modules.Contracts;

namespace Substrate.NetApi.Modules
{
    /// <summary>
    /// Chain Module
    /// </summary>
    public class Chain : IChain
    {
        private readonly SubstrateClient _client;

        /// <summary>
        /// Chain Module Constructor
        /// </summary>
        /// <param name="client"></param>
        internal Chain(SubstrateClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<Header> GetHeaderAsync(CancellationToken token)
        {
            return await GetHeaderAsync(null, token);
        }

        /// <inheritdoc/>
        public async Task<Header> GetHeaderAsync(Hash hash = null)
        {
            return await GetHeaderAsync(hash, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Header> GetHeaderAsync(Hash hash, CancellationToken token)
        {
            var parameter = hash != null ? hash.Value : null;
            return await _client.InvokeAsync<Header>("chain_getHeader", new object[] { parameter }, token);
        }

        /// <inheritdoc/>
        public async Task<BlockData> GetBlockAsync()
        {
            return await GetBlockAsync(null, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<BlockData> GetBlockAsync(CancellationToken token)
        {
            return await GetBlockAsync(null, token);
        }

        /// <inheritdoc/>
        public async Task<BlockData> GetBlockAsync(Hash hash)
        {
            return await GetBlockAsync(hash, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<BlockData> GetBlockAsync(Hash hash, CancellationToken token)
        {
            var parameter = hash != null ? hash.Value : null;
            var result = await _client.InvokeAsync<BlockData>("chain_getBlock", new object[] { parameter }, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync()
        {
            return await GetBlockHashAsync(CancellationToken.None);
        }


        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync(BlockNumber blockNumber)
        {
            return await GetBlockHashAsync(blockNumber, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("chain_getBlockHash", new object[] { null }, token);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync(BlockNumber blockNumber, CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("chain_getBlockHash",
                new object[] { Utils.Bytes2HexString(blockNumber.Encode()) }, token);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetFinalizedHeadAsync()
        {
            return await GetFinalizedHeadAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetFinalizedHeadAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("chain_getFinalizedHead", null, token);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback)
        {
            return await SubscribeAllHeadsAsync(callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback, CancellationToken token)
        {
            var subscriptionId = await _client.InvokeAsync<string>("chain_subscribeAllHeads", null, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId)
        {
            return await UnsubscribeAllHeadsAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("chain_unsubscribeAllHeads", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback)
        {
            return await SubscribeNewHeadsAsync(callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback, CancellationToken token)
        {
            var subscriptionId = await _client.InvokeAsync<string>("chain_subscribeNewHeads", null, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnubscribeNewHeadsAsync(string subscriptionId)
        {
            return await UnsubscribeNewHeadsAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeNewHeadsAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("chain_unsubscribeNewHeads", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback)
        {
            return await SubscribeFinalizedHeadsAsync(callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback, CancellationToken token)
        {
            var subscriptionId = await _client.InvokeAsync<string>("chain_subscribeFinalizedHeads", null, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId)
        {
            return await UnsubscribeFinalizedHeadsAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId, CancellationToken token)
        {
            var result = await _client.InvokeAsync<bool>("chain_unsubscribeFinalizedHeads",
                new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }
    }
}