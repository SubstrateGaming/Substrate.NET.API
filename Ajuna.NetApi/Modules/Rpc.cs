using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Ajuna.NetApi.Model.Rpc;

namespace Ajuna.NetApi.Modules
{
    /// <summary> A rpc. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class Rpc
    {
        /// <summary> The client. </summary>
        private readonly SubstrateClient _client;

        /// <summary> Constructor. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="client"> The client. </param>
        internal Rpc(SubstrateClient client)
        {
            _client = client;
        }

        public async Task<RpcMethods> GetMethodsAsync()
        {
            return await GetMethodsAsync(CancellationToken.None);
        }

        public async Task<RpcMethods> GetMethodsAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<RpcMethods>("rpc_methods", null, token);
        }

    }
}