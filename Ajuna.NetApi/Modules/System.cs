using System;
using System.Threading;
using System.Threading.Tasks;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Modules.Contracts;

namespace Ajuna.NetApi.Modules
{
    /// <summary> A system. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class System : ISystem
    {
        /// <summary> The client. </summary>
        private readonly SubstrateClient _client;

        /// <summary> Constructor. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="client"> The client. </param>
        internal System(SubstrateClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Account Next Index
        /// </summary>
        /// <param name="address"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<uint> AccountNextIndexAsync(string address, CancellationToken token)
        {
            return await _client.InvokeAsync<uint>("system_accountNextIndex", new object[] { address }, token);
        }

        /// <summary>
        /// Add log filter (-32601: RPC call is unsafe to be called externally)
        /// </summary>
        /// <param name="directives"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> AddLogFilterAsync(string directives, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<uint>("system_addLogFilter", new object[] { directives }, token);
        }

        /// <summary>
        /// Add reserved peer filter (-32601: RPC call is unsafe to be called externally)
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> AddReservedPeerAsync(string peer, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<uint>("system_addReservedPeer", new object[] { peer }, token);
        }

        /// <summary> Chain asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> The chain. </returns>
        public async Task<string> ChainAsync()
        {
            return await ChainAsync(CancellationToken.None);
        }

        /// <summary> Chain asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> The chain. </returns>
        public async Task<string> ChainAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_chain", null, token);
        }

        /// <summary> Chain type asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> The chain type. </returns>
        public async Task<string> ChainTypeAsync()
        {
            return await ChainTypeAsync(CancellationToken.None);
        }

        /// <summary> Chain Type asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> The chain type . </returns>
        public async Task<string> ChainTypeAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_chainType", null, token);
        }

        /// <summary>
        /// Dry run
        /// </summary>
        /// <param name="extrinsicHex"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> DryRunAsync(string extrinsicHex, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<string>("system_dryRun", new object[] { extrinsicHex }, token);
        }

        /// <summary>
        /// Dry run at
        /// </summary>
        /// <param name="extrinsicHex"></param>
        /// <param name="blockHashHex"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> DryRunAtAsync(string extrinsicHex, string blockHashHex, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<string>("system_dryRunAt", new object[] { extrinsicHex, blockHashHex }, token);
        }

        /// <summary>
        /// Health
        /// </summary>
        /// <returns></returns>
        public async Task<Health> HealthAsync()
        {
            return await HealthAsync(CancellationToken.None);
        }

        /// <summary>
        /// Health
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<Health> HealthAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Health>("system_health", null, token);
        }

        /// <summary>
        /// Local listen addresses
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string[]> LocalListenAddressesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string[]>("system_localListenAddresses", null, token);
        }

        /// <summary>
        /// Local peer id
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> LocalPeerIdAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_localPeerId", null, token);
        }

        /// <summary> Name asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> The name. </returns>
        public async Task<string> NameAsync()
        {
            return await NameAsync(CancellationToken.None);
        }

        /// <summary> Name asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> The name. </returns>
        public async Task<string> NameAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_name", null, token);
        }

        /// <summary>
        /// Node roles
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string[]> NodeRolesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string[]>("system_nodeRoles", null, token);
        }

        /// <summary>
        /// Peers
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<object> PeersAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_peers", null, token);
        }

        /// <summary>
        /// Properties
        /// </summary>
        /// <returns></returns>
        public async Task<Properties> PropertiesAsync()
        {
            return await PropertiesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Properties
        /// </summary>
        /// <returns></returns>
        public async Task<Properties> PropertiesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Properties>("system_properties", null, token);
        }

        /// <summary>
        /// Remove reserved peer
        /// </summary>
        /// <param name="peerId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> RemoveReservedPeerAsync(string peerId, CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_removeReservedPeer", new object[] { peerId }, token);
        }

        /// <summary>
        /// Reserved peers
        /// </summary>
        /// <param name="peerId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> ReservedPeersAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_reservedPeers", null, token);
        }

        /// <summary>
        /// Reset log filter
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> ResetLogFilterAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_resetLogFilter", null, token);
        }

        /// <summary>
        /// Sync state
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<SyncState> SyncStateAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<SyncState>("system_syncState", null, token);
        }

        /// <summary> Version asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> The version. </returns>
        public async Task<string> VersionAsync()
        {
            return await VersionAsync(CancellationToken.None);
        }

        /// <summary> Version asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> The version. </returns>
        public async Task<string> VersionAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_version", null, token);
        }
    }
}