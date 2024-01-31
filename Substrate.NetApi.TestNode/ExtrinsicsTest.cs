using NUnit.Framework;
using NUnit.Framework.Internal;
using Schnorrkel.Keys;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Threading;
using Substrate.NET.System.Threading.Tasks;

namespace Substrate.NetApi.TestNode
{
    public class ExtrinsicsTest
    {
        public MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToEd25519Bytes(), MiniSecretAlice.GetPair().Public.Key);
        public MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToEd25519Bytes(), MiniSecretBob.GetPair().Public.Key);

        protected const string WebSocketUrl = "ws://127.0.0.1:9944";

        protected SubstrateClient _substrateClient;

        protected ChargeType _chargeType;

        [SetUp]
        public async Task ConnectAsync()
        {
            await _substrateClient.ConnectAsync();
        }

        [TearDown]
        public async Task CloseAsync()
        {
            await _substrateClient.CloseAsync();
        }

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            _chargeType = ChargeAssetTxPayment.Default();
            _substrateClient = new SubstrateClient(new Uri(WebSocketUrl), _chargeType);

            try
            {
                await _substrateClient.ConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to Substrate node: {ex.Message}");
                Assert.Ignore("Skipped test because no active Substrate node was found on 127.0.0.1:9944");
            }
        }

        [OneTimeTearDown]
        public async Task TearDownAsync()
        {
            if (_substrateClient != null)
            {
                await _substrateClient.CloseAsync();
                _substrateClient.Dispose();
            }
        }

        /// <summary>
        /// Extrinsic Submit And Watch
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Extrinsic_SubmitAndWatchExtrinsicAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });

            var taskCompletionSource = new TaskCompletionSource<(bool, Hash)>();
            await _substrateClient.Author.SubmitAndWatchExtrinsicAsync((string subscriptionId, ExtrinsicStatus extrinsicUpdate) =>
            {
                if (extrinsicUpdate.ExtrinsicState == ExtrinsicState.Finalized ||
                    extrinsicUpdate.ExtrinsicState == ExtrinsicState.Dropped ||
                    extrinsicUpdate.ExtrinsicState == ExtrinsicState.Invalid)
                {
                    taskCompletionSource.SetResult((true, extrinsicUpdate.Hash));
                }
            }, method, Alice, _chargeType, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1)));
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");
        }

        /// <summary>
        /// Transaction Unstable Submit And Watch
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Extrinsic_TransactionUnstableSubmitAndWatchAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });

            var taskCompletionSource = new TaskCompletionSource<(bool, Hash)>();
            _ = await _substrateClient.Unstable.TransactionUnstableSubmitAndWatchAsync((string subscriptionId, TransactionEventInfo extrinsicUpdate) =>
            {
                if (extrinsicUpdate.TransactionEvent == TransactionEvent.Finalized ||
                    extrinsicUpdate.TransactionEvent == TransactionEvent.Dropped ||
                    extrinsicUpdate.TransactionEvent == TransactionEvent.Invalid ||
                    extrinsicUpdate.TransactionEvent == TransactionEvent.Error)
                {
                    taskCompletionSource.SetResult((true, extrinsicUpdate.Hash));
                }
            }, method, Alice, _chargeType, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1)));
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");
        }

        /// <summary>
        /// Transaction Unstable Unwatch
        /// </summary>
        /// <returns></returns>
        [Test, Timeout(10000)] // Timeout after 10 seconds
        public async Task Extrinsic_TransactionUnstableUnwatchAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });
            var cancellationTokenSource = new CancellationTokenSource();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            var subscriptionId = await _substrateClient.Unstable.TransactionUnstableSubmitAndWatchAsync(
                (subscriptionId, extrinsicUpdate) =>
                {
                    if (extrinsicUpdate.TransactionEvent != TransactionEvent.Validated)
                    {
                        taskCompletionSource.SetResult(true);
                    }
                },
                method, Alice, _chargeType, 64, cancellationTokenSource.Token);

            var unsubscribed = await _substrateClient.Unstable.TransactionUnstableUnwatchAsync(subscriptionId);
            Assert.IsTrue(unsubscribed, "Unsubscribing from transaction should be successful.");

            // Optionally: wait for the callback to be called, which should not happen
            var callbackCalled = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(500));
            if (callbackCalled == taskCompletionSource.Task)
            {
                Assert.Fail("Callback should not be called after unsubscribing.");
            }

            // Cleanup if needed
            cancellationTokenSource.Cancel();
        }
    }
}