using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Modules.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules
{
    /// <summary>
    /// New Api 2
    /// </summary>
    public class UnstableCalls : IUnstableCalls
    {
        /// <summary>The client</summary>
        private readonly SubstrateClient _client;

        /// <summary>
        /// New Api 2
        /// </summary>
        /// <param name="client"></param>
        internal UnstableCalls(SubstrateClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Transaction Unstable Submit And Watch Async
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <returns></returns>
        public async Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, Method method, Account account, ChargeType charge, uint lifeTime)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, CancellationToken.None);

            return await TransactionUnstableSubmitAndWatchAsync(callback, Utils.Bytes2HexString(extrinsic.Encode()));
        }

        /// <summary>
        /// Transaction Unstable Submit And Watch Async
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, token);
            var extrinsicHex = Utils.Bytes2HexString(extrinsic.Encode());
            return await TransactionUnstableSubmitAndWatchAsync(callback, extrinsicHex);
        }

        /// <summary>
        /// Transaction Unstable Submit And Watch Async
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, string parameters)
        {
            return await TransactionUnstableSubmitAndWatchAsync(callback, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Transaction Unstable Submit And Watch Async
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, string parameters, CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("transaction_unstable_submitAndWatch", new object[] { parameters }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <summary>
        /// Transaction Unstable Unwatch Async
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public async Task<bool> TransactionUnstableUnwatchAsync(string subscriptionId)
        {
            return await TransactionUnstableUnwatchAsync(subscriptionId, CancellationToken.None);
        }

        /// <summary>
        /// Transaction Unstable Unwatch Async
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> TransactionUnstableUnwatchAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("transaction_unstable_unwatch", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }
    }
}