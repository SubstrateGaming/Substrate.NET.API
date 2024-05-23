using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Modules.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules
{
    /// <summary>
    /// Payment Module
    /// </summary>
    public class Payment : IPayment
    {
        private readonly SubstrateClient _client;

        /// <summary>
        /// Payment Module Constructor
        /// </summary>
        /// <param name="client"></param>
        internal Payment(SubstrateClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<FeeDetails> QueryFeeDetailAsync(string extrinsic, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(extrinsic) ? null : extrinsic,
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };
            return await _client.InvokeAsync<FeeDetails>("payment_queryFeeDetails", fullParams, token);
        }

        /// <inheritdoc/>
        public async Task<RuntimeDispatchInfo> QueryInfoAsync(string extrinsic, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(extrinsic) ? null : extrinsic,
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };
            return await _client.InvokeAsync<RuntimeDispatchInfo>("payment_queryInfo", fullParams, token);
        }
    }
}