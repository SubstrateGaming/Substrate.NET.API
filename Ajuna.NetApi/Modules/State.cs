using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Modules.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Schnorrkel.Ristretto;

namespace Ajuna.NetApi.Modules
{
    /// <summary> A state. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class State : IState
    {
        /// <summary> The client. </summary>
        private readonly SubstrateClient _client;

        /// <summary> Constructor. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="client"> The client. </param>
        internal State(SubstrateClient client)
        {
            _client = client;
        }

        //state_call
        //state_callAt
        //state_getChildReadProof
        //state_getKeys

        public Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey)
            => GetKeysPagedAsync(keyPrefix, pageCount, startKey, CancellationToken.None);

        public Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey,
            CancellationToken token)
            => GetKeysPagedAtAsync(keyPrefix, string.Empty, pageCount, startKey, token);

        public Task<JArray> GetKeysPagedAtAsync(byte[] keyPrefix, byte[] blockHash, uint pageCount, byte[] startKey, CancellationToken token)
            => GetKeysPagedAtAsync(keyPrefix, Utils.Bytes2HexString(blockHash), pageCount, startKey, token);

        public async Task<JArray> GetKeysPagedAtAsync(byte[] keyPrefix, string blockHash, uint pageCount, byte[] startKey, CancellationToken token)
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

        public Task<string> GetMetaDataAsync()
            => GetMetaDataAsync(CancellationToken.None);

        public Task<string> GetMetaDataAsync(CancellationToken token)
            => GetMetaDataAtAsync(string.Empty, token);

        public Task<string> GetMetaDataAtAsync(byte[] blockHash, CancellationToken token)
            => GetMetaDataAtAsync(Utils.Bytes2HexString(blockHash), token);

        public async Task<string> GetMetaDataAtAsync(string blockHash, CancellationToken token)
        {
            var fullParams = new object[] { string.IsNullOrEmpty(blockHash) ? null : blockHash };
            return await _client.InvokeAsync<string>("state_getMetadata", fullParams, token);
        }

        public Task<JArray> GetPairsAsync(byte[] keyPrefix)
            => GetPairsAsync(keyPrefix, CancellationToken.None);

        public Task<JArray> GetPairsAsync(byte[] keyPrefix, CancellationToken token)
            => GetPairsAtAsync(keyPrefix, string.Empty, token);

        public Task<JArray> GetPairsAtAsync(byte[] keyPrefix, byte[] blockHash, CancellationToken token)
            => GetPairsAtAsync(keyPrefix, Utils.Bytes2HexString(blockHash), token);

        public async Task<JArray> GetPairsAtAsync(byte[] keyPrefix, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(keyPrefix),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<JArray>("state_getPairs", fullParams, token);
        }

        public Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes)
         => GetReadProofAsync(keyPrefixes, CancellationToken.None);

        public Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, CancellationToken token)
            => GetReadProofAtAsync(keyPrefixes, string.Empty, token);

        public Task<ReadProof> GetReadProofAtAsync(IEnumerable<byte[]> keyPrefixes, byte[] blockHash, CancellationToken token)
            => GetReadProofAtAsync(keyPrefixes, Utils.Bytes2HexString(blockHash), token);

        public async Task<ReadProof> GetReadProofAtAsync(IEnumerable<byte[]> keyPrefixes, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                keyPrefixes?.Select(k => Utils.Bytes2HexString(k)).ToArray(),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<ReadProof>("state_getReadProof", fullParams, token);
        }

        public Task<RuntimeVersion> GetRuntimeVersionAsync()
            => GetRuntimeVersionAsync(CancellationToken.None);

        public Task<RuntimeVersion> GetRuntimeVersionAsync(CancellationToken token)
            => GetRuntimeVersionAtAsync(string.Empty, token);

        public Task<RuntimeVersion> GetRuntimeVersionAtAsync(byte[] blockHash, CancellationToken token)
            => GetRuntimeVersionAtAsync(Utils.Bytes2HexString(blockHash), token);

        public async Task<RuntimeVersion> GetRuntimeVersionAtAsync(string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<RuntimeVersion>("state_getRuntimeVersion", fullParams, token);
        }

        public Task<object> GetStorageAsync(byte[] parameters)
            => GetStorageAsync(parameters, CancellationToken.None);

        public Task<object> GetStorageAsync(byte[] parameters, CancellationToken token)
            => GetStorageAtAsync(parameters, string.Empty, token);

        public Task<object> GetStorageAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token)
            => GetStorageAtAsync(parameters, Utils.Bytes2HexString(blockHash), token);

        public async Task<object> GetStorageAtAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<object>("state_getStorage", fullParams.ToArray(), token);
        }

        public Task<Hash> GetStorageHashAsync(byte[] key)
            => GetStorageHashAsync(key, CancellationToken.None);

        public Task<Hash> GetStorageHashAsync(byte[] key, CancellationToken token)
            => GetStorageHashAtAsync(key, string.Empty, token);

        public Task<Hash> GetStorageHashAtAsync(byte[] key, byte[] blockHash, CancellationToken token)
            => GetStorageHashAtAsync(key, Utils.Bytes2HexString(blockHash), token);

        public async Task<Hash> GetStorageHashAtAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<Hash>("state_getStorageHash", fullParams, token);
        }

        public Task<U64> GetStorageSizeAsync(byte[] parameters)
            => GetStorageSizeAsync(parameters, CancellationToken.None);
        public Task<U64> GetStorageSizeAsync(byte[] parameters, CancellationToken token)
            => GetStorageSizeAtAsync(parameters, string.Empty, token);

        public Task<U64> GetStorageSizeAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token)
            => GetStorageSizeAtAsync(parameters, Utils.Bytes2HexString(blockHash), token);

        public async Task<U64> GetStorageSizeAtAsync(byte[] parameters, string blockHash, CancellationToken token)
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
            var resNumber = new U64();
            resNumber.Create(UInt32.Parse(res));
            return resNumber;
        }

        public Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock)
            => GetQueryStorageAsync(keysList, fromBlock, toBlock, CancellationToken.None);

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
        
        public Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, byte[] blockHash, CancellationToken token)
            => GetQueryStorageAtAsync(keysList, Utils.Bytes2HexString(blockHash), token);

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

        public Task<string> SubscribeRuntimeVersionAsync()
            => SubscribeRuntimeVersionAsync(CancellationToken.None);

        public Task<string> SubscribeRuntimeVersionAsync(CancellationToken token)
            => SubscribeRuntimeVersionAtAsync(string.Empty, token);

        public Task<string> SubscribeRuntimeVersionAtAsync(byte[] blockHash, CancellationToken token)
            => SubscribeRuntimeVersionAtAsync(Utils.Bytes2HexString(blockHash), token);

        public async Task<string> SubscribeRuntimeVersionAtAsync(string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<string>("state_subscribeRuntimeVersion", fullParams, token);
        }

        public async Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback)
        {
            return await SubscribeStorageAsync(keys, callback, CancellationToken.None);
        }

        public async Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback,
            CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("state_subscribeStorage", new object[] { keys }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        public Task<object> GetTraceBlockAsync(byte[] parameters)
            => GetTraceBlockAsync(parameters, CancellationToken.None);

        public Task<object> GetTraceBlockAsync(byte[] parameters, CancellationToken token)
            => GetTraceBlockAtAsync(parameters, string.Empty, token);

        public Task<object> GetTraceBlockAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token)
            => GetTraceBlockAtAsync(parameters, Utils.Bytes2HexString(blockHash), token);

        public async Task<object> GetTraceBlockAtAsync(byte[] parameters, string blockHash, CancellationToken token)
        {
            var fullParams = new object[]
            {
                Utils.Bytes2HexString(parameters),
                string.IsNullOrEmpty(blockHash) ? null : blockHash
            };

            return await _client.InvokeAsync<object>("state_traceBlock", fullParams, token);
        }

        public async Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId)
        {
            return await UnsubscribeRuntimeVersionAsync(subscriptionId, CancellationToken.None);
        }

        public async Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId, CancellationToken token)
        {
            return await _client.InvokeAsync<bool>("state_unsubscribeRuntimeVersion", new object[] { subscriptionId },
                token);
        }

        public async Task<bool> UnsubscribeStorageAsync(string subscriptionId)
        {
            return await UnsubscribeStorageAsync(subscriptionId, CancellationToken.None);
        }

        public async Task<bool> UnsubscribeStorageAsync(string subscriptionId, CancellationToken token)
        {
            return await _client.InvokeAsync<bool>("state_unsubscribeStorage", new object[] { subscriptionId }, token);
        }
    }
}