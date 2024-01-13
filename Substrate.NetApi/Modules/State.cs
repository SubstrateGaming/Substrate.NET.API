using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Modules.Contracts;

namespace Substrate.NetApi.Modules
{
    /// <summary> A state. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class State : IState
    {
        /// <summary>
        /// Substrate client.
        /// </summary>
        private readonly SubstrateClient _client;

        /// <summary>
        /// The state module allows you to interact with the storage of the runtime.
        /// </summary>
        /// <param name="client"></param>
        internal State(SubstrateClient client)
        {
            _client = client;
        }

        //state_call
        //state_callAt
        //state_getChildReadProof
        //state_getKeys

        /// <inheritdoc/>
        public Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey)
            => GetKeysPagedAsync(keyPrefix, pageCount, startKey, CancellationToken.None);

        /// <inheritdoc/>
        public Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey,
            CancellationToken token)
            => GetKeysPagedAsync(keyPrefix, pageCount, startKey, string.Empty, token);

        /// <inheritdoc/>
        public Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, byte[] blockHash, CancellationToken token)
            => GetKeysPagedAsync(keyPrefix, pageCount, startKey, Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(keyPrefix),
                pageCount,
                startKey != null ? Utils.Bytes2HexString(startKey) : null,
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };
            return await _client.InvokeAsync<JArray>("state_getKeysPaged", fullParams, token);
        }

        /// <inheritdoc/>
        public Task<string> GetMetaDataAsync()
            => GetMetaDataAsync(CancellationToken.None);

        /// <inheritdoc/>
        public Task<string> GetMetaDataAsync(CancellationToken token)
            => GetMetaDataAsync(string.Empty, token);

        /// <inheritdoc/>
        public Task<string> GetMetaDataAsync(byte[] blockHash, CancellationToken token)
            => GetMetaDataAsync(Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<string> GetMetaDataAsync(string blockHash, CancellationToken token)
        {
            var fullParams = new object[] { string.IsNullOrEmpty(blockHash) ? null : blockHash };
            return await _client.InvokeAsync<string>("state_getMetadata", fullParams, token);
        }

        /// <inheritdoc/>
        public Task<JArray> GetPairsAsync(byte[] keyPrefix)
            => GetPairsAsync(keyPrefix, CancellationToken.None);

        /// <inheritdoc/>
        public Task<JArray> GetPairsAsync(byte[] keyPrefix, CancellationToken token)
            => GetPairsAsync(keyPrefix, string.Empty, token);

        /// <inheritdoc/>
        public Task<JArray> GetPairsAsync(byte[] keyPrefix, byte[] blockHash, CancellationToken token)
            => GetPairsAsync(keyPrefix, Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<JArray> GetPairsAsync(byte[] keyPrefix, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(keyPrefix),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<JArray>("state_getPairs", fullParams, token);
        }


        /// <inheritdoc/>
        public Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes)
         => GetReadProofAsync(keyPrefixes, CancellationToken.None);


        /// <inheritdoc/>
        public Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, CancellationToken token)
            => GetReadProofAsync(keyPrefixes, string.Empty, token);


        /// <inheritdoc/>
        public Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, byte[] blockHash, CancellationToken token)
            => GetReadProofAsync(keyPrefixes, Utils.Bytes2HexString(blockHash), token);


        /// <inheritdoc/>
        public async Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                keyPrefixes?.Select(k => Utils.Bytes2HexString(k)).ToArray(),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<ReadProof>("state_getReadProof", fullParams, token);
        }

        /// <inheritdoc/>
        public Task<RuntimeVersion> GetRuntimeVersionAsync()
            => GetRuntimeVersionAsync(CancellationToken.None);

        /// <inheritdoc/>
        public Task<RuntimeVersion> GetRuntimeVersionAsync(CancellationToken token)
            => GetRuntimeVersionAsync(string.Empty, token);

        /// <inheritdoc/>
        public Task<RuntimeVersion> GetRuntimeVersionAsync(byte[] blockHash, CancellationToken token)
            => GetRuntimeVersionAsync(Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<RuntimeVersion> GetRuntimeVersionAsync(string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<RuntimeVersion>("state_getRuntimeVersion", fullParams, token);
        }

        /// <inheritdoc/>
        public Task<object> GetStorageAsync(byte[] parameters)
            => GetStorageAsync(parameters, CancellationToken.None);

        /// <inheritdoc/>
        public Task<object> GetStorageAsync(byte[] parameters, CancellationToken token)
            => GetStorageAsync(parameters, string.Empty, token);

        /// <inheritdoc/>
        public Task<object> GetStorageAsync(byte[] parameters, byte[] blockHash, CancellationToken token)
            => GetStorageAsync(parameters, Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<object> GetStorageAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<object>("state_getStorage", fullParams.ToArray(), token);
        }

        /// <inheritdoc/>
        public Task<Hash> GetStorageHashAsync(byte[] key)
            => GetStorageHashAsync(key, CancellationToken.None);

        /// <inheritdoc/>
        public Task<Hash> GetStorageHashAsync(byte[] key, CancellationToken token)
            => GetStorageHashAsync(key, string.Empty, token);

        /// <inheritdoc/>
        public Task<Hash> GetStorageHashAsync(byte[] key, byte[] blockHash, CancellationToken token)
            => GetStorageHashAsync(key, Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<Hash> GetStorageHashAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<Hash>("state_getStorageHash", fullParams, token);
        }

        /// <inheritdoc/>
        public Task<U64> GetStorageSizeAsync(byte[] parameters)
            => GetStorageSizeAsync(parameters, CancellationToken.None);

        /// <inheritdoc/>
        public Task<U64> GetStorageSizeAsync(byte[] parameters, CancellationToken token)
            => GetStorageSizeAsync(parameters, string.Empty, token);

        /// <inheritdoc/>
        public Task<U64> GetStorageSizeAsync(byte[] parameters, byte[] blockHash, CancellationToken token)
            => GetStorageSizeAsync(parameters, Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<U64> GetStorageSizeAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            var res = await _client.InvokeAsync<string>("state_getStorageSize", fullParams.ToArray(), token);

            /*
             * Cedric : Is it better to override GenericTypeConverter.cs in order to do :
             * _client.InvokeAsync<U64> ?
             * Because actually converter force string cast (GenericTypeConverter.cs line 36) and it fail
             */
            var resNumber = new U64(ulong.Parse(res));
            return resNumber;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock)
            => GetQueryStorageAsync(keysList, fromBlock, toBlock, CancellationToken.None);

        /// <inheritdoc/>
        public async Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock, CancellationToken token)
        {
            var fullParams = new object[]
            {
                keysList.Select(p => Utils.Bytes2HexString(p)),
                string.IsNullOrEmpty(fromBlock) ? null : fromBlock,
                string.IsNullOrEmpty(toBlock) ? null : toBlock
            };

            var jArray = await _client.InvokeAsync<JArray>("state_queryStorage", fullParams, token);

            if (jArray.Count != 1)
            {
                return Enumerable.Empty<StorageChangeSet>();
            }
            return JsonConvert.DeserializeObject<IEnumerable<StorageChangeSet>>(jArray.ToString());
        }

        /// <inheritdoc/>
        public Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, byte[] blockHash)
            => GetQueryStorageAtAsync(keysList, Utils.Bytes2HexString(blockHash));

        /// <inheritdoc/>
        public Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, string blockHash)
            => GetQueryStorageAtAsync(keysList, blockHash, CancellationToken.None);


        /// <inheritdoc/>
        public async Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                keysList.Select(p => Utils.Bytes2HexString(p)),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            var jArray = await _client.InvokeAsync<JArray>("state_queryStorageAt", fullParams, token);

            if (jArray.Count != 1)
            {
                return Enumerable.Empty<StorageChangeSet>();
            }
            return JsonConvert.DeserializeObject<IEnumerable<StorageChangeSet>>(jArray.ToString());
        }

        /// <inheritdoc/>
        public Task<string> SubscribeRuntimeVersionAsync()
            => SubscribeRuntimeVersionAsync(CancellationToken.None);

        /// <inheritdoc/>
        public Task<string> SubscribeRuntimeVersionAsync(CancellationToken token)
            => SubscribeRuntimeVersionAsync(string.Empty, token);

        /// <inheritdoc/>
        public Task<string> SubscribeRuntimeVersionAsync(byte[] blockHash, CancellationToken token)
            => SubscribeRuntimeVersionAsync(Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<string> SubscribeRuntimeVersionAsync(string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<string>("state_subscribeRuntimeVersion", fullParams, token);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback)
        {
            return await SubscribeStorageAsync(keys, callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback,
            CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("state_subscribeStorage", new object[] { keys }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public Task<object> GetTraceBlockAsync(byte[] parameters)
            => GetTraceBlockAsync(parameters, CancellationToken.None);

        /// <inheritdoc/>
        public Task<object> GetTraceBlockAsync(byte[] parameters, CancellationToken token)
            => GetTraceBlockAsync(parameters, string.Empty, token);

        /// <inheritdoc/>
        public Task<object> GetTraceBlockAsync(byte[] parameters, byte[] blockHash, CancellationToken token)
            => GetTraceBlockAsync(parameters, Utils.Bytes2HexString(blockHash), token);

        /// <inheritdoc/>
        public async Task<object> GetTraceBlockAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<object>("state_traceBlock", fullParams, token);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId)
        {
            return await UnsubscribeRuntimeVersionAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId, CancellationToken token)
        {
            return await _client.InvokeAsync<bool>("state_unsubscribeRuntimeVersion", new object[] { subscriptionId },
                token);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeStorageAsync(string subscriptionId)
        {
            return await UnsubscribeStorageAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeStorageAsync(string subscriptionId, CancellationToken token)
        {
            return await _client.InvokeAsync<bool>("state_unsubscribeStorage", new object[] { subscriptionId }, token);
        }
    }
}