using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Rpc;

namespace Substrate.NetApi.Modules.Contracts
{
    public interface IPayment
    {
        /// <summary>
        /// Query the detailed fee of a given encoded extrinsic
        /// </summary>
        /// <param name="extrinsic"></param>
        /// <param name="blockHash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<FeeDetails> QueryFeeDetailAsync(string extrinsic, string blockHash, CancellationToken token);

        /// <summary>
        /// Retrieves the fee information for an encoded extrinsic
        /// </summary>
        /// <param name="extrinsic"></param>
        /// <param name="blockHash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<RuntimeDispatchInfoV1> QueryInfoAsync(string extrinsic, string blockHash, CancellationToken token);
    }
}