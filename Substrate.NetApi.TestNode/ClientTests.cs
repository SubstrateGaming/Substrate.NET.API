using NUnit.Framework;
using Substrate.NetApi.Model.Extrinsics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.TestNode
{
    public class ClientTests
    {
        private SubstrateClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new SubstrateClient(new Uri("ws://rpc-parachain.bajun.network"), ChargeTransactionPayment.Default());
        }

        [Test]
        public async Task Connect_ShouldConnectSuccessfullyAsync()
        {
            Assert.That(_client.IsConnected, Is.False);

            await _client.ConnectAsync();
            Assert.That(_client.IsConnected, Is.True);
        }

        [Test]
        public async Task Connect_ShouldDisconnectSuccessfullyAsync()
        {
            await _client.ConnectAsync();
            Assert.That(_client.IsConnected, Is.True);

            await _client.CloseAsync();
            Assert.That(_client.IsConnected, Is.False);
        }

        [Test]
        public async Task Connect_ShouldTriggerEventAsync()
        {
            var onConnectionSetTriggered = new TaskCompletionSource<bool>();
            _client.ConnectionSet += (sender, e) => onConnectionSetTriggered.SetResult(true);

            await _client.ConnectAsync();

            await Task.WhenAny(onConnectionSetTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1)));
            Assert.That(onConnectionSetTriggered.Task.IsCompleted, Is.True);
        }

        [Test]
        public async Task OnConnectionLost_ShouldThrowDisconnectedEventAsync()
        {
            var onConnectionLostTriggered = new TaskCompletionSource<bool>();
            _client.ConnectionLost += (sender, e) => onConnectionLostTriggered.SetResult(true);

            await _client.ConnectAsync();
            await _client.CloseAsync();

            await Task.WhenAny(onConnectionLostTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1)));
            Assert.That(onConnectionLostTriggered.Task.IsCompleted, Is.True);
        }
    }
}
