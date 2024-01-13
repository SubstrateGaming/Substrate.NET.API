using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Substrate.NetApi.Model.Rpc;

namespace Substrate.NetApi.Modules.Contracts
{
    /// <summary>
    /// Payment Module Interface
    /// </summary>
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
        Task<RuntimeDispatchInfo> QueryInfoAsync(string extrinsic, string blockHash, CancellationToken token);
    }
}