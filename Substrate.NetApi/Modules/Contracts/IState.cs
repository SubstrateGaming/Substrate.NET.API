using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Modules.Contracts
{
    public interface IState
    {
        /// <summary>
        /// Asynchronously retrieves a paged list of keys from the state with a specified prefix.
        /// </summary>
        /// <param name="keyPrefix">The byte array representing the key prefix to query.</param>
        /// <param name="pageCount">The number of pages to retrieve.</param>
        /// <param name="startKey">The starting key for pagination, if any.</param>
        /// <returns>A task that represents the asynchronous operation and returns a JArray of keys.</returns>
        Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey);

        /// <summary>
        /// Asynchronously retrieves a paged list of keys from the state with a specified prefix, using a cancellation token.
        /// </summary>
        /// <param name="keyPrefix">The byte array representing the key prefix to query.</param>
        /// <param name="pageCount">The number of pages to retrieve.</param>
        /// <param name="startKey">The starting key for pagination, if any.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns a JArray of keys.</returns>
        Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves a paged list of keys from the state with a specified prefix at a specific block hash.
        /// </summary>
        /// <param name="keyPrefix">The byte array representing the key prefix to query.</param>
        /// <param name="pageCount">The number of pages to retrieve.</param>
        /// <param name="startKey">The starting key for pagination, if any.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns a JArray of keys at the specified block.</returns>
        Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, byte[] blockHash, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the metadata of the blockchain state.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and returns the metadata as a string.</returns>
        Task<string> GetMetaDataAsync();

        /// <summary>
        /// Asynchronously retrieves the metadata of the blockchain state with a cancellation token.
        /// </summary>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the metadata as a string.</returns>
        Task<string> GetMetaDataAsync(CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the metadata of the blockchain state at a specific block hash.
        /// </summary>
        /// <param name="blockHash">The block hash to query the metadata at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the metadata as a string at the specified block.</returns>
        Task<string> GetMetaDataAsync(byte[] blockHash, CancellationToken token);


        /// <summary>
        /// Asynchronously retrieves key-value pairs from the state with a specified prefix.
        /// </summary>
        /// <param name="keyPrefix">The byte array representing the key prefix.</param>
        /// <returns>A task that represents the asynchronous operation and returns a JArray of key-value pairs.</returns>
        Task<JArray> GetPairsAsync(byte[] keyPrefix);

        /// <summary>
        /// Asynchronously retrieves key-value pairs from the state with a specified prefix and a cancellation token.
        /// </summary>
        /// <param name="keyPrefix">The byte array representing the key prefix.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns a JArray of key-value pairs.</returns>
        Task<JArray> GetPairsAsync(byte[] keyPrefix, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves key-value pairs from the state with a specified prefix at a specific block hash.
        /// </summary>
        /// <param name="keyPrefix">The byte array representing the key prefix.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns a JArray of key-value pairs at the specified block.</returns>
        Task<JArray> GetPairsAsync(byte[] keyPrefix, byte[] blockHash, CancellationToken token);


        /// <summary>
        /// Asynchronously retrieves a read-proof for a set of keys in the state.
        /// </summary>
        /// <param name="keyPrefixes">A collection of byte arrays representing the keys for which the read-proof is requested.</param>
        /// <returns>A task that represents the asynchronous operation and returns the read-proof.</returns>
        Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes);

        /// <summary>
        /// Asynchronously retrieves a read-proof for a set of keys in the state with a cancellation token.
        /// </summary>
        /// <param name="keyPrefixes">A collection of byte arrays representing the keys for which the read-proof is requested.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the read-proof.</returns>
        Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves a read-proof for a set of keys in the state at a specific block hash.
        /// </summary>
        /// <param name="keyPrefixes">A collection of byte arrays representing the keys for which the read-proof is requested.</param>
        /// <param name="blockHash">The block hash to query the read-proof at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the read-proof at the specified block.</returns>
        Task<ReadProof> GetReadProofAsync(IEnumerable<byte[]> keyPrefixes, byte[] blockHash, CancellationToken token);


        /// <summary>
        /// Asynchronously retrieves the current runtime version of the blockchain.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and returns the current runtime version.</returns>
        Task<RuntimeVersion> GetRuntimeVersionAsync();

        /// <summary>
        /// Asynchronously retrieves the current runtime version of the blockchain with a cancellation token.
        /// </summary>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the current runtime version.</returns>
        Task<RuntimeVersion> GetRuntimeVersionAsync(CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the runtime version of the blockchain at a specific block hash.
        /// </summary>
        /// <param name="blockHash">The block hash to query the runtime version at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the runtime version at the specified block.</returns>
        Task<RuntimeVersion> GetRuntimeVersionAsync(byte[] blockHash, CancellationToken token);


        /// <summary>
        /// Asynchronously retrieves the storage data for given parameters.
        /// </summary>
        /// <param name="parameters">The parameters for which the storage data is requested.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage data.</returns>
        Task<object> GetStorageAsync(byte[] parameters);

        /// <summary>
        /// Asynchronously retrieves the storage data for given parameters with a cancellation token.
        /// </summary>
        /// <param name="parameters">The parameters for which the storage data is requested.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage data.</returns>
        Task<object> GetStorageAsync(byte[] parameters, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the storage data for given parameters at a specific block hash.
        /// </summary>
        /// <param name="parameters">The parameters for which the storage data is requested.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage data.</returns>
        Task<object> GetStorageAsync(byte[] parameters, byte[] blockHash, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the hash of the storage data for a given key.
        /// </summary>
        /// <param name="key">The key for which the storage hash is requested.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage hash.</returns>
        Task<Hash> GetStorageHashAsync(byte[] key);

        /// <summary>
        /// Asynchronously retrieves the hash of the storage data for a given key with a cancellation token.
        /// </summary>
        /// <param name="key">The key for which the storage hash is requested.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage hash.</returns>
        Task<Hash> GetStorageHashAsync(byte[] key, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the hash of the storage data for a given key at a specific block hash.
        /// </summary>
        /// <param name="key">The key for which the storage hash is requested.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage hash.</returns>
        Task<Hash> GetStorageHashAsync(byte[] key, byte[] blockHash, CancellationToken token);


        /// <summary>
        /// Asynchronously retrieves the storage size for given parameters.
        /// </summary>
        /// <param name="parameters">The parameters for which the storage size is requested.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage size.</returns>
        Task<U64> GetStorageSizeAsync(byte[] parameters);

        /// <summary>
        /// Asynchronously retrieves the storage size for given parameters with a cancellation token.
        /// </summary>
        /// <param name="parameters">The parameters for which the storage size is requested.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage size.</returns>
        Task<U64> GetStorageSizeAsync(byte[] parameters, CancellationToken token);

        /// <summary>
        /// Asynchronously retrieves the storage size for given parameters at a specific block hash.
        /// </summary>
        /// <param name="parameters">The parameters for which the storage size is requested.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the storage size.</returns>
        Task<U64> GetStorageSizeAsync(byte[] parameters, byte[] blockHash, CancellationToken token);

        /// <summary>
        /// Asynchronously queries storage changes for a given set of keys within a specified block range.
        /// </summary>
        /// <param name="keysList">List of keys to query for changes.</param>
        /// <param name="fromBlock">The starting block hash for the query range.</param>
        /// <param name="toBlock">The ending block hash for the query range.</param>
        /// <returns>A task that represents the asynchronous operation and returns a collection of storage change sets.</returns>
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock);

        /// <summary>
        /// Asynchronously queries storage changes for a given set of keys within a specified block range, with a cancellation token.
        /// </summary>
        /// <param name="keysList">List of keys to query for changes.</param>
        /// <param name="fromBlock">The starting block hash for the query range.</param>
        /// <param name="toBlock">The ending block hash for the query range.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns a collection of storage change sets.</returns>
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAsync(List<byte[]> keysList, string fromBlock, string toBlock, CancellationToken token);

        /// <summary>
        /// Asynchronously queries storage changes for a given set of keys at a specific block hash.
        /// </summary>
        /// <param name="keysList">List of keys to query for changes.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <returns>A task that represents the asynchronous operation and returns a collection of storage change sets at the specified block.</returns>
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, byte[] blockHash);

        /// <summary>
        /// Asynchronously queries storage changes for a given set of keys at a specific block hash, with a cancellation token.
        /// </summary>
        /// <param name="keysList">List of keys to query for changes.</param>
        /// <param name="blockHash">The block hash to query at.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation and returns a collection of storage change sets at the specified block.</returns>
        Task<IEnumerable<StorageChangeSet>> GetQueryStorageAtAsync(List<byte[]> keysList, string blockHash, CancellationToken token);

        /// <summary>
        /// Asynchronously subscribes to updates of the runtime version.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, returning a subscription ID as a string.</returns>
        Task<string> SubscribeRuntimeVersionAsync();

        /// <summary>
        /// Asynchronously subscribes to updates of the runtime version with a cancellation token.
        /// </summary>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning a subscription ID as a string.</returns>
        Task<string> SubscribeRuntimeVersionAsync(CancellationToken token);

        /// <summary>
        /// Asynchronously subscribes to updates of the runtime version at a specific block hash.
        /// </summary>
        /// <param name="blockHash">The block hash to subscribe to.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning a subscription ID as a string.</returns>
        Task<string> SubscribeRuntimeVersionAsync(byte[] blockHash, CancellationToken token);

        /// <summary>
        /// Asynchronously subscribes to changes in the storage for specified keys.
        /// </summary>
        /// <param name="keys">A collection of keys to subscribe to.</param>
        /// <param name="callback">The callback action to invoke on each storage change.</param>
        /// <returns>A task representing the asynchronous operation, returning a subscription ID as a string.</returns>
        Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback);

        /// <summary>
        /// Asynchronously subscribes to changes in the storage for specified keys, with a cancellation token.
        /// </summary>
        /// <param name="keys">A collection of keys to subscribe to.</param>
        /// <param name="callback">The callback action to invoke on each storage change.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning a subscription ID as a string.</returns>
        Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback, CancellationToken token);

        /// <summary>
        /// Asynchronously traces a block.
        /// </summary>
        /// <param name="parameters">The parameters specifying the block to trace.</param>
        /// <returns>A task representing the asynchronous operation, returning trace data.</returns>
        Task<object> GetTraceBlockAsync(byte[] parameters);

        /// <summary>
        /// Asynchronously traces a block with a cancellation token.
        /// </summary>
        /// <param name="parameters">The parameters specifying the block to trace.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning trace data.</returns>
        Task<object> GetTraceBlockAsync(byte[] parameters, CancellationToken token);

        /// <summary>
        /// Asynchronously traces a block at a specific block hash.
        /// </summary>
        /// <param name="parameters">The parameters specifying the block to trace.</param>
        /// <param name="blockHash">The block hash to trace.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning trace data at the specified block hash.</returns>
        Task<object> GetTraceBlockAsync(byte[] parameters, byte[] blockHash, CancellationToken token);

        /// <summary>
        /// Asynchronously unsubscribes from updates of the runtime version.
        /// </summary>
        /// <param name="subscriptionId">The subscription ID to cancel.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating success or failure.</returns>
        Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId);

        /// <summary>
        /// Asynchronously unsubscribes from updates of the runtime version with a cancellation token.
        /// </summary>
        /// <param name="subscriptionId">The subscription ID to cancel.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating success or failure.</returns>
        Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId, CancellationToken token);

        /// <summary>
        /// Asynchronously unsubscribes from changes in the storage.
        /// </summary>
        /// <param name="subscriptionId">The subscription ID to cancel.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating success or failure.</returns>
        Task<bool> UnsubscribeStorageAsync(string subscriptionId);

        /// <summary>
        /// Asynchronously unsubscribes from changes in the storage with a cancellation token.
        /// </summary>
        /// <param name="subscriptionId">The subscription ID to cancel.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating success or failure.</returns>
        Task<bool> UnsubscribeStorageAsync(string subscriptionId, CancellationToken token);
    }
}