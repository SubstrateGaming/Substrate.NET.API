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
    /// UnstableCalls Module
    /// </summary>
    public class TransactionWatchCalls : ITransactionWatchCalls
    {
        /// <summary>The client</summary>
        private readonly SubstrateClient _client;

        /// <summary>
        /// UnstableCalls Module Constructor
        /// </summary>
        /// <param name="client"></param>
        internal TransactionWatchCalls(SubstrateClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<string> TransactionWatchV1SubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, Method method, Account account, ChargeType charge, uint lifeTime)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, CancellationToken.None);

            return await TransactionWatchV1SubmitAndWatchAsync(callback, Utils.Bytes2HexString(extrinsic.Encode()));
        }

        /// <inheritdoc/>
        public async Task<string> TransactionWatchV1SubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, token);
            var extrinsicHex = Utils.Bytes2HexString(extrinsic.Encode());
            return await TransactionWatchV1SubmitAndWatchAsync(callback, extrinsicHex);
        }

        /// <inheritdoc/>
        public async Task<string> TransactionWatchV1SubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, string parameters)
        {
            return await TransactionWatchV1SubmitAndWatchAsync(callback, parameters, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> TransactionWatchV1SubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, string parameters, CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("transactionWatch_v1_submitAndWatch", new object[] { parameters }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> TransactionWatchV1UnwatchAsync(string subscriptionId)
        {
            return await TransactionWatchV1UnwatchAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> TransactionWatchV1UnwatchAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("transactionWatch_v1_unwatch", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }
    }
}