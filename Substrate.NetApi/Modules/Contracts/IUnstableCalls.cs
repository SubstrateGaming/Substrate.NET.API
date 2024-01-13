using System;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Modules.Contracts
{
    /// <summary>
    /// UnstableCalls Module Interface
    /// </summary>
    public interface IUnstableCalls
    {
        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <returns></returns>
        Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, Method method, Account account, ChargeType charge, uint lifeTime);

        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token);

        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, string parameters);

        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> TransactionUnstableSubmitAndWatchAsync(Action<string, TransactionEventInfo> callback, string parameters, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> TransactionUnstableUnwatchAsync(string subscriptionId);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> TransactionUnstableUnwatchAsync(string subscriptionId, CancellationToken token);
    }
}