﻿using System;
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
    ///   <br />
    /// </summary>
    public class Author : IAuthor
    {
        /// <summary>The client</summary>
        private readonly SubstrateClient _client;

        /// <summary>Initializes a new instance of the <see cref="Author" /> class.</summary>
        /// <param name="client">The client.</param>
        internal Author(SubstrateClient client)
        {
            _client = client;
        }

        /// <summary>Pendings the extrinsic asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Extrinsic[]> PendingExtrinsicAsync()
        {
            return await PendingExtrinsicAsync(CancellationToken.None);
        }

        /// <summary>Pendings the extrinsic asynchronous.</summary>
        /// <param name="token">The token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Extrinsic[]> PendingExtrinsicAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Extrinsic[]>("author_pendingExtrinsics", null, token);
        }

        /// <summary>Submits the extrinsic asynchronous.</summary>
        /// <param name="callArguments">The call arguments.</param>
        /// <param name="account">The account.</param>
        /// <param name="tip">The tip.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, CancellationToken.None);

            return await SubmitExtrinsicAsync(Utils.Bytes2HexString(extrinsic.Encode()));
        }

        public async Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, token);

            return await SubmitExtrinsicAsync(Utils.Bytes2HexString(extrinsic.Encode()), token);
        }

        /// <summary>Submits the extrinsic asynchronous.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Hash> SubmitExtrinsicAsync(string parameters)
        {
            return await SubmitExtrinsicAsync(parameters, CancellationToken.None);
        }

        /// <summary>Submits the extrinsic asynchronous.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Hash> SubmitExtrinsicAsync(string parameters, CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("author_submitExtrinsic", new object[] { parameters }, token);
        }

        /// <summary>Submits the and watch extrinsic asynchronous.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="callArguments">The call arguments.</param>
        /// <param name="account">The account.</param>
        /// <param name="tip">The tip.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            Method method, Account account, ChargeType charge, uint lifeTime)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, CancellationToken.None);

            return await SubmitAndWatchExtrinsicAsync(callback, Utils.Bytes2HexString(extrinsic.Encode()));
        }

        /// <summary>Submits the and watch extrinsic asynchronous.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="callArguments">The call arguments.</param>
        /// <param name="account">The account.</param>
        /// <param name="tip">The tip.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token)
        {
            var extrinsic = await _client.GetExtrinsicParametersAsync(method, account, charge, lifeTime, signed: true, token);
            var extrinsicHex = Utils.Bytes2HexString(extrinsic.Encode());
            return await SubmitAndWatchExtrinsicAsync(callback, extrinsicHex);
        }

        /// <summary>Submits the and watch extrinsic asynchronous.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            string parameters)
        {
            return await SubmitAndWatchExtrinsicAsync(callback, parameters, CancellationToken.None);
        }

        /// <summary>Submits the and watch extrinsic asynchronous.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback,
            string parameters, CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("author_submitAndWatchExtrinsic", new object[] { parameters }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <summary>Unwatches the extrinsic asynchronous.</summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<bool> UnwatchExtrinsicAsync(string subscriptionId)
        {
            return await UnwatchExtrinsicAsync(subscriptionId, CancellationToken.None);
        }

        /// <summary>Unwatches the extrinsic asynchronous.</summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<bool> UnwatchExtrinsicAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("author_unwatchExtrinsic", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }
    }
}