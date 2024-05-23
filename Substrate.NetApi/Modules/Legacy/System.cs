using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Modules.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules
{
    /// <summary>
    /// System Module
    /// </summary>
    public class System : ISystem
    {
        private readonly SubstrateClient _client;

        /// <summary>
        /// System Module Constructor
        /// </summary>
        /// <param name="client"></param>
        internal System(SubstrateClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<uint> AccountNextIndexAsync(string address, CancellationToken token)
        {
            return await _client.InvokeAsync<uint>("system_accountNextIndex", new object[] { address }, token);
        }

        /// <inheritdoc/>
        public async Task<object> AddLogFilterAsync(string directives, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<uint>("system_addLogFilter", new object[] { directives }, token);
        }

        /// <inheritdoc/>
        public async Task<object> AddReservedPeerAsync(string peer, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<uint>("system_addReservedPeer", new object[] { peer }, token);
        }

        /// <inheritdoc/>
        public async Task<string> ChainAsync()
        {
            return await ChainAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> ChainAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_chain", null, token);
        }

        /// <inheritdoc/>
        public async Task<string> ChainTypeAsync()
        {
            return await ChainTypeAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> ChainTypeAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_chainType", null, token);
        }

        /// <inheritdoc/>
        public async Task<object> DryRunAsync(string extrinsicHex, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<string>("system_dryRun", new object[] { extrinsicHex }, token);
        }

        /// <inheritdoc/>
        public async Task<string> DryRunAtAsync(string extrinsicHex, string blockHashHex, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await _client.InvokeAsync<string>("system_dryRunAt", new object[] { extrinsicHex, blockHashHex }, token);
        }

        /// <inheritdoc/>
        public async Task<Health> HealthAsync()
        {
            return await HealthAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Health> HealthAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Health>("system_health", null, token);
        }

        /// <inheritdoc/>
        public async Task<string[]> LocalListenAddressesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string[]>("system_localListenAddresses", null, token);
        }

        /// <inheritdoc/>
        public async Task<string> LocalPeerIdAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_localPeerId", null, token);
        }

        /// <inheritdoc/>
        public async Task<string> NameAsync()
        {
            return await NameAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> NameAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_name", null, token);
        }

        /// <inheritdoc/>
        public async Task<string[]> NodeRolesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string[]>("system_nodeRoles", null, token);
        }

        /// <inheritdoc/>
        public async Task<object> PeersAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_peers", null, token);
        }

        /// <inheritdoc/>
        public async Task<Properties> PropertiesAsync()
        {
            return await PropertiesAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Properties> PropertiesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Properties>("system_properties", null, token);
        }

        /// <inheritdoc/>
        public async Task<object> RemoveReservedPeerAsync(string peerId, CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_removeReservedPeer", new object[] { peerId }, token);
        }

        /// <inheritdoc/>
        public async Task<object> ReservedPeersAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_reservedPeers", null, token);
        }

        /// <inheritdoc/>
        public async Task<object> ResetLogFilterAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<object>("system_resetLogFilter", null, token);
        }

        /// <inheritdoc/>
        public async Task<SyncState> SyncStateAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<SyncState>("system_syncState", null, token);
        }

        /// <inheritdoc/>
        public async Task<string> VersionAsync()
        {
            return await VersionAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> VersionAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<string>("system_version", null, token);
        }
    }
}