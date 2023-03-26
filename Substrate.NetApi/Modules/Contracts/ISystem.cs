using Substrate.NetApi.Model.Rpc;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules.Contracts
{
    public interface ISystem
    {
        /// <summary>
        /// Retrieves the next accountIndex as available on the node
        /// </summary>
        /// <param name="address"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<uint> AccountNextIndexAsync(string address, CancellationToken token);

        /// <summary>
        /// Adds the supplied directives to the current log filter
        /// </summary>
        /// <param name="directives"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> AddLogFilterAsync(string directives, CancellationToken token);

        /// <summary>
        /// Adds a reserved peer
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> AddReservedPeerAsync(string peer, CancellationToken token);

        /// <summary>
        /// Retrieves the chain
        /// </summary>
        /// <returns></returns>
        Task<string> ChainAsync();

        /// <summary>
        /// Retrieves the chain
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> ChainAsync(CancellationToken token);

        /// <summary>
        /// Retrieves the chain type
        /// </summary>
        /// <returns></returns>
        Task<string> ChainTypeAsync();

        /// <summary>
        /// Retrieves the chain type
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> ChainTypeAsync(CancellationToken token);

        /// <summary>
        /// Dry run an extrinsic at a given block
        /// </summary>
        /// <param name="extrinsicHex"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> DryRunAsync(string extrinsicHex, CancellationToken token);

        /// <summary>
        /// Dry run an extrinsic at a given block at specific block
        /// </summary>
        /// <param name="extrinsicHex"></param>
        /// <param name="blockHashHex"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> DryRunAtAsync(string extrinsicHex, string blockHashHex, CancellationToken token);

        /// <summary>
        /// Return health status of the node
        /// </summary>
        /// <returns></returns>
        Task<Health> HealthAsync();

        /// <summary>
        /// Return health status of the node
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Health> HealthAsync(CancellationToken token);

        /// <summary>
        /// The addresses include a trailing /p2p/ with the local PeerId, and are thus suitable to be passed to addReservedPeer or as a bootnode address for example
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string[]> LocalListenAddressesAsync(CancellationToken token);

        /// <summary>
        /// Returns the base58-encoded PeerId of the node
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> LocalPeerIdAsync(CancellationToken token);

        /// <summary>
        /// Retrieves the node name
        /// </summary>
        /// <returns></returns>
        Task<string> NameAsync();

        /// <summary>
        /// Retrieves the node name
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> NameAsync(CancellationToken token);

        /// <summary>
        /// Returns the roles the node is running as
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string[]> NodeRolesAsync(CancellationToken token);

        /// <summary>
        /// Returns the currently connected peers
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> PeersAsync(CancellationToken token);

        /// <summary>
        /// Get a custom set of properties as a JSON object, defined in the chain spec
        /// </summary>
        /// <returns></returns>
        Task<Properties> PropertiesAsync();

        /// <summary>
        /// Get a custom set of properties as a JSON object, defined in the chain spec
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Properties> PropertiesAsync(CancellationToken token);

        /// <summary>
        /// Remove a reserved peer
        /// </summary>
        /// <param name="peerId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> RemoveReservedPeerAsync(string peerId, CancellationToken token);

        /// <summary>
        /// Returns the list of reserved peers
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> ReservedPeersAsync(CancellationToken token);

        /// <summary>
        /// Resets the log filter to Substrate defaults
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<object> ResetLogFilterAsync(CancellationToken token);

        /// <summary>
        /// Returns the state of the syncing of the node
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<SyncState> SyncStateAsync(CancellationToken token);

        /// <summary>
        /// Retrieves the version of the node
        /// </summary>
        /// <returns></returns>
        Task<string> VersionAsync();

        /// <summary>
        /// Retrieves the version of the node
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> VersionAsync(CancellationToken token);
    }
}