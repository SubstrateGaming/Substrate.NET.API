using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules.Contracts
{
    public interface IAuthor
    {
        /// <summary>
        /// Returns all pending extrinsics, potentially grouped by sender
        /// </summary>
        /// <returns></returns>
        Task<Extrinsic[]> PendingExtrinsicAsync();

        /// <summary>
        /// Returns all pending extrinsics, potentially grouped by sender
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Extrinsic[]> PendingExtrinsicAsync(CancellationToken token);

        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <returns></returns>
        Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback, Method method, Account account, ChargeType charge, uint lifeTime);

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
        Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback, Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token);

        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback, string parameters);

        /// <summary>
        /// Submit and subscribe to watch an extrinsic until unsubscribed
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback, string parameters, CancellationToken token);

        /// <summary>
        /// Submit a fully formatted extrinsic for block inclusion
        /// </summary>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <returns></returns>
        Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime);

        /// <summary>
        /// Submit a fully formatted extrinsic for block inclusion
        /// </summary>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token);

        /// <summary>
        /// Submit a fully formatted extrinsic for block inclusion
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<Hash> SubmitExtrinsicAsync(string parameters);

        /// <summary>
        /// Submit a fully formatted extrinsic for block inclusion
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> SubmitExtrinsicAsync(string parameters, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> UnwatchExtrinsicAsync(string subscriptionId);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UnwatchExtrinsicAsync(string subscriptionId, CancellationToken token);
    }
}