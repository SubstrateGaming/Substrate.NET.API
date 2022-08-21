﻿using System.Threading;
using System.Threading.Tasks;
using Ajuna.NetApi.Model.Rpc;

namespace Ajuna.NetApi.Modules
{
    /// <summary> A system. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class System
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

        public async Task<uint> AccountNextIndexAsync(string address, CancellationToken token)
        {
            return await _client.InvokeAsync<uint>("system_accountNextIndex", new object[] {address}, token);
        }

        public async Task<Health> HealthAsync()
        {
            return await HealthAsync(CancellationToken.None);
        }

        public async Task<Health> HealthAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Health>("system_health", null, token);
        }

        public async Task<Properties> PropertiesAsync()
        {
            return await PropertiesAsync(CancellationToken.None);
        }

        public async Task<Properties> PropertiesAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Properties>("system_properties", null, token);
        }

    }
}