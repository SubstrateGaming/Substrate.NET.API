using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ajuna.NetApi.Model.Rpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ajuna.NetApi.Modules
{
    /// <summary> A state. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class State
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="pageCount"></param>
        /// <param name="startKey"></param>
        /// <returns></returns>
        public async Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey)
        {
            return await GetKeysPagedAsync(keyPrefix, pageCount, startKey, CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="pageCount"></param>
        /// <param name="startKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey,
            CancellationToken token)
        {
            return startKey.Length == 0
                ? await _client.InvokeAsync<JArray>("state_getKeysPaged",
                    new object[] { Utils.Bytes2HexString(keyPrefix), pageCount }, token)
                : await _client.InvokeAsync<JArray>("state_getKeysPaged",
                    new object[] { Utils.Bytes2HexString(keyPrefix), pageCount, Utils.Bytes2HexString(startKey) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="pageCount"></param>
        /// <param name="startKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<JArray> GetKeysPagedAtAsync(byte[] keyPrefix, byte[] blockHash, uint pageCount, byte[] startKey, CancellationToken token)
        {
            throw new NotImplementedException();
            //return startKey.Length == 0
            //    ? await _client.InvokeAsync<JArray>("state_getKeysPagedAt",
            //        new object[] { Utils.Bytes2HexString(keyPrefix), 0, pageCount }, token)
            //    : await _client.InvokeAsync<JArray>("state_getKeysPagedAt",
            //        new object[] { Utils.Bytes2HexString(keyPrefix), 0, pageCount, Utils.Bytes2HexString(startKey) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetMetaDataAsync()
        {
            return await GetMetaDataAsync(CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> GetMetaDataAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("state_getMetadata", null, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <returns></returns>
        public async Task<JArray> GetPairsAsync(byte[] keyPrefix)
        {
            return await GetPairsAsync(keyPrefix, CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<JArray> GetPairsAsync(byte[] keyPrefix, CancellationToken token)
        {
            return await _client.InvokeAsync<JArray>("state_getPairs", new object[] { Utils.Bytes2HexString(keyPrefix) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task GetReadProofAsync()
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<object>("state_getReadProof", new object[] { }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<RuntimeVersion> GetRuntimeVersionAsync()
        {
            return await GetRuntimeVersionAsync(CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<RuntimeVersion> GetRuntimeVersionAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<RuntimeVersion>("state_getRuntimeVersion", null, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<object> GetStorageAsync(byte[] parameters)
        {
            return await GetStorageAsync(parameters, CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<object> GetStorageAsync(byte[] parameters, CancellationToken token)
        {
            return await _client.InvokeAsync<object>("state_getStorage", new object[] { Utils.Bytes2HexString(parameters) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<object> GetStorageAtAsync(byte[] parameters, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<object>("state_getStorageAt", new object[] { Utils.Bytes2HexString(parameters) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<object> GetStorageHashAsync(byte[] key, CancellationToken token)
        {
            return await _client.InvokeAsync<JArray>("state_getStorageHash", new object[] { Utils.Bytes2HexString(key) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> GetStorageHashAtAsync(byte[] parameters, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<object>("state_getStorageHashAt", new object[] { Utils.Bytes2HexString(parameters) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> GetStorageSizeAsync(byte[] parameters, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<object>("state_getStorageSize", new object[] { Utils.Bytes2HexString(parameters) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> GetStorageSizeAtAsync(byte[] parameters, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<object>("state_getStorageSizeAt", new object[] { Utils.Bytes2HexString(parameters) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> GetQueryStorageAsync(byte[] parameters, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<JArray>("state_queryStorage", jsonObject, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<StorageChangeSet> GetQueryStorageAtAsync(List<byte[]> keysList, CancellationToken token)
        {
            var jArray = await _client.InvokeAsync<JArray>("state_queryStorageAt", new object[] { keysList.Select(p => Utils.Bytes2HexString(p)).ToArray() }, token);
            if (jArray.Count != 1)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<StorageChangeSet>(jArray.First.ToString());
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<string> SubscribeRuntimeVersionAsync()
        {
            return await SubscribeRuntimeVersionAsync(CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> SubscribeRuntimeVersionAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("state_subscribeRuntimeVersion", null, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback)
        {
            return await SubscribeStorageAsync(keys, callback, CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback,
            CancellationToken token)
        {
            var subscriptionId =
                await _client.InvokeAsync<string>("state_subscribeStorage", new object[] { keys }, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> GetTraceBlockAsync(byte[] parameters, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<object>("state_traceBlock", new object[] { Utils.Bytes2HexString(parameters) }, token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public async Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId)
        {
            return await UnsubscribeRuntimeVersionAsync(subscriptionId, CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId, CancellationToken token)
        {
            return await _client.InvokeAsync<bool>("state_unsubscribeRuntimeVersion", new object[] { subscriptionId },
                token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public async Task<bool> UnsubscribeStorageAsync(string subscriptionId)
        {
            return await UnsubscribeStorageAsync(subscriptionId, CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> UnsubscribeStorageAsync(string subscriptionId, CancellationToken token)
        {
            return await _client.InvokeAsync<bool>("state_unsubscribeStorage", new object[] { subscriptionId }, token);
        }
    }
}