using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Modules.Contracts;

namespace Substrate.NetApi.Modules
{
    /// <summary> A system. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class Payment : IPayment
    {
        /// <summary> The client. </summary>
        private readonly SubstrateClient _client;

        /// <summary> Constructor. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="client"> The client. </param>
        internal Payment(SubstrateClient client)
        {
            _client = client;
        }

        public async Task<FeeDetails> QueryFeeDetailAsync(string extrinsic, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(extrinsic) ? null : extrinsic,
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };
            return await _client.InvokeAsync<FeeDetails>("payment_queryFeeDetails", fullParams, token);
        }

        public async Task<RuntimeDispatchInfoV1> QueryInfoAsync(string extrinsic, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(extrinsic) ? null : extrinsic,
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };
            return await _client.InvokeAsync<RuntimeDispatchInfoV1>("payment_queryInfo", fullParams, token);
        }
    }
}