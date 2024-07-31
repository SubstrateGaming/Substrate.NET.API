using Newtonsoft.Json.Linq;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Modules.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules
{
    /// <summary>
    /// RuntimeCall Module
    /// </summary>
    public class RuntimeCall : IRuntimeCall
    {
        private readonly SubstrateClient _client;

        /// <summary>
        /// RuntimeCall Module Constructor
        /// </summary>
        /// <param name="client"></param>
        internal RuntimeCall(SubstrateClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<BaseOpt<BaseVec<U8>>> MetadataAtVersionAsync(uint version, CancellationToken token)
        {
            var fullParams = new object[]
            {
                "Metadata_metadata_at_version",
                Utils.Bytes2HexString(new U32(version).Encode()),
                null
            };

            var str = await _client.InvokeAsync<string>("state_call", fullParams, token);

            if (str == null || str.Length == 0)
            {
                return default;
            }

            var t = new BaseOpt<BaseVec<U8>>();
            t.Create(str);

            return t;
        }

        /// <inheritdoc/>
        public async Task<BaseVec<U32>> MetadataVersionsAsync(CancellationToken token)
        {
            var fullParams = new object[]
            {
                "Metadata_metadata_versions",
                Array.Empty<byte>(),
                null
            };

            var str = await _client.InvokeAsync<string>("state_call", fullParams, token);

            if (str == null || str.Length == 0)
            {
                return default;
            }

            var t = new BaseVec<U32>();
            t.Create(str);

            return t;
        }
    }
}