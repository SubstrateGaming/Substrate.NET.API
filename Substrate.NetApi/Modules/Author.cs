using System;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Modules.Contracts;

namespace Substrate.NetApi.Modules
{
    /// <summary>
    /// Author Module
    /// </summary>
    public class Author : IAuthor
    {
        private readonly SubstrateClient _client;

        /// <summary>
        /// Author Module Constructor
        /// </summary>
        /// <param name="client"></param>
        internal Author(SubstrateClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<Extrinsic[]> PendingExtrinsicAsync()
        {
            return await PendingExtrinsicAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Extrinsic[]> PendingExtrinsicAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Extrinsic[]>("author_pendingExtrinsics", null, token);
        }

        /// <inheritdoc/>
        public async Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, CancellationToken.None);

            return await SubmitExtrinsicAsync(Utils.Bytes2HexString(extrinsic.Encode()));
        }

        /// <inheritdoc/>
        public async Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, token);

            return await SubmitExtrinsicAsync(Utils.Bytes2HexString(extrinsic.Encode()), token);
        }

        /// <inheritdoc/>
        public async Task<Hash> SubmitExtrinsicAsync(string parameters)
        {
            return await SubmitExtrinsicAsync(parameters, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Hash> SubmitExtrinsicAsync(string parameters, CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("author_submitExtrinsic", new object[] { parameters }, token);
        }

        /// <inheritdoc/>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            Method method, Account account, ChargeType charge, uint lifeTime)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, CancellationToken.None);

            return await SubmitAndWatchExtrinsicAsync(callback, Utils.Bytes2HexString(extrinsic.Encode()));
        }

        /// <inheritdoc/>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, token);
            var extrinsicHex = Utils.Bytes2HexString(extrinsic.Encode());
            return await SubmitAndWatchExtrinsicAsync(callback, extrinsicHex);
        }

        /// <inheritdoc/>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            string parameters)
        {
            return await SubmitAndWatchExtrinsicAsync(callback, parameters, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            string parameters, CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("author_submitAndWatchExtrinsic", new object[] { parameters }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnwatchExtrinsicAsync(string subscriptionId)
        {
            return await UnwatchExtrinsicAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnwatchExtrinsicAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("author_unwatchExtrinsic", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }
    }
}