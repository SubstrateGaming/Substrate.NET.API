using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules.Contracts
{
    public interface IState
    {
        /// <summary>
        /// Returns the keys with prefix from a child storage with pagination support
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="pageCount"></param>
        /// <param name="startKey"></param>
        /// <returns></returns>
        Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey);

        /// <summary>
        /// Returns the keys with prefix from a child storage with pagination support
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="pageCount"></param>
        /// <param name="startKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, CancellationToken token);

        /// <summary>
        /// Returns the keys with prefix from a child storage with pagination support at specific block
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="blockHash"></param>
        /// <param name="pageCount"></param>
        /// <param name="startKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<JArray> GetKeysPagedAtAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, byte[] blockHash, CancellationToken token);
        Task<JArray> GetKeysPagedAtAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, string blockHash, CancellationToken token);

        /// <summary>
        /// Returns the runtime metadata
        /// </summary>
        /// <returns></returns>
        Task<string> GetMetaDataAsync();

        /// <summary>
        /// Returns the runtime metadata
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> GetMetaDataAsync(CancellationToken token);

        /// <summary>
        /// Returns the runtime metadata at specific block
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> GetMetaDataAtAsync(byte[] blockHash, CancellationToken token);
        Task<string> GetMetaDataAtAsync(string blockHash, CancellationToken token);

        /// <summary>
        /// Returns the keys with prefix, leave empty to get all the keys
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <returns></returns>
        Task<JArray> GetPairsAsync(byte[] keyPrefix);

        /// <summary>
        /// Returns the keys with prefix, leave empty to get all the keys
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<JArray> GetPairsAsync(byte[] keyPrefix, CancellationToken token);

        /// <summary>
        /// Returns the keys with prefix, leave empty to get all the keys at specific block
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<JArray> GetPairsAtAsync(byte[] keyPrefix, byte[] blockHash, CancellationToken token);
        Task<JArray> GetPairsAtAsync(byte[] keyPrefix, string blockHash, CancellationToken token);

        /// <summary>
        /// Get storage from given parameter
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock);
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock, CancellationToken token);

        /// <summary>
        /// Get storage from given parameter at specific block
        /// </summary>
        /// <param name="keysList"></param>
        /// <param name="blockHash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, byte[] blockHash, CancellationToken token);
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, string blockHash, CancellationToken token);

        /// <summary>
        /// Returns proof of storage entries
        /// </summary>
        /// <returns></returns>
        Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes);
        Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, CancellationToken token);

        /// <summary>
        /// Returns proof of storage entries at a specific block state
        /// </summary>
        /// <returns></returns>
        Task<ReadProof> GetReadProofAtAsync(IEnumerable<byte[]> keyPrefixes, byte[] blockHash, CancellationToken token);
        Task<ReadProof> GetReadProofAtAsync(IEnumerable<byte[]> keyPrefixes, string blockHash, CancellationToken token);

        /// <summary>
        /// Get the runtime version
        /// </summary>
        /// <returns></returns>
        Task<RuntimeVersion> GetRuntimeVersionAsync();

        /// <summary>
        /// Get the runtime version
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<RuntimeVersion> GetRuntimeVersionAsync(CancellationToken token);

        /// <summary>
        /// Get the runtime version at specific block
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<RuntimeVersion> GetRuntimeVersionAtAsync(byte[] blockHash, CancellationToken token);
        Task<RuntimeVersion> GetRuntimeVersionAtAsync(string blockHash, CancellationToken token);

        /// <summary>
        /// Retrieves the storage for a key
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<object> GetStorageAsync(byte[] parameters);

        /// <summary>
        /// Retrieves the storage for a key
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> GetStorageAsync(byte[] parameters, CancellationToken token);

        /// <summary>
        /// Retrieves the storage for a key at specific block
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="blockHash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> GetStorageAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token);
        Task<object> GetStorageAtAsync(byte[] parameters, string blockHash, CancellationToken token);

        /// <summary>
        /// Retrieves the storage hash
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> GetStorageHashAsync(byte[] key);
        Task<Hash> GetStorageHashAsync(byte[] key, CancellationToken token);

        /// <summary>
        /// Retrieves the storage hash at specific block
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="blockHash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Hash> GetStorageHashAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token);
        Task<Hash> GetStorageHashAtAsync(byte[] parameters, string blockHash, CancellationToken token);

        /// <summary>
        /// Retrieves the storage size
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<U64> GetStorageSizeAsync(byte[] parameters);
        Task<U64> GetStorageSizeAsync(byte[] parameters, CancellationToken token);

        /// <summary>
        /// Retrieves the storage size at specific block
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<U64> GetStorageSizeAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token);
        Task<U64> GetStorageSizeAtAsync(byte[] parameters, string blockHash, CancellationToken token);

        /// <summary>
        /// Provides a way to trace the re-execution of a single block
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> GetTraceBlockAsync(byte[] parameters, CancellationToken token);
        Task<object> GetTraceBlockAsync(byte[] parameters);

        /// <summary>
        /// Provides a way to trace the re-execution of a single block at specific block
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> GetTraceBlockAtAsync(byte[] parameters, byte[] blockHash, CancellationToken token);
        Task<object> GetTraceBlockAtAsync(byte[] parameters, string blockHash, CancellationToken token);

        /// <summary>
        /// Retrieves the runtime version via subscription
        /// </summary>
        /// <returns></returns>
        Task<string> SubscribeRuntimeVersionAsync();

        /// <summary>
        /// Retrieves the runtime version via subscription
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubscribeRuntimeVersionAsync(CancellationToken token);

        /// <summary>
        /// Retrieves the runtime version via subscription at specific block
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubscribeRuntimeVersionAtAsync(byte[] blockHash, CancellationToken token);
        Task<string> SubscribeRuntimeVersionAtAsync(string blockHash, CancellationToken token);

        /// <summary>
        /// Subscribes to storage changes for the provided keys
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback);

        /// <summary>
        /// Subscribes to storage changes for the provided keys
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId, CancellationToken token);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeStorageAsync(string subscriptionId);

        /// <summary>
        /// Unsuscribe to given subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UnsubscribeStorageAsync(string subscriptionId, CancellationToken token);
    }
}