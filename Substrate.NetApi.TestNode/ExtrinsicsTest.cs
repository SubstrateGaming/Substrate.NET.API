using NUnit.Framework;
using NUnit.Framework.Internal;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.TestNode
{
    public class ExtrinsicsTest
    {
        public MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToEd25519Bytes(), MiniSecretAlice.GetPair().Public.Key);
        public MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToEd25519Bytes(), MiniSecretBob.GetPair().Public.Key);

        protected const string WebSocketUrl = "ws://127.0.0.1:9999";

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
                Assert.Ignore("Skipped test because no active Substrate node was found on 127.0.0.1:9999");
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
            var iType = new BaseVec<U8>(new U8[] { (U8)0x04, (U8)0xFF });

            // Pay in with the asset with asset id one, e.g. DOT on Ajuna Polkadot or PAS on Ajuna Paseo.
            var assetCharge = ChargeAssetTxPayment.NewWithAsset(0, new I32(0));
            var method = new Method(0, "System", 0, "remark", new IType[] { iType });

            var taskCompletionSource = new TaskCompletionSource<(bool, Hash)>();
            await _substrateClient.Author.SubmitAndWatchExtrinsicAsync((string subscriptionId, ExtrinsicStatus extrinsicUpdate) =>
            {
                Debug.WriteLine($"ExtrinsicUpdate: {extrinsicUpdate.ExtrinsicState}");

                switch (extrinsicUpdate.ExtrinsicState)
                {
                    case ExtrinsicState.Finalized:
                        taskCompletionSource.SetResult((true, extrinsicUpdate.Hash));
                        break;

                    case ExtrinsicState.Dropped:
                        Assert.Fail("Extrinsic was dropped!");
                        break;

                    case ExtrinsicState.Invalid:
                        Assert.Fail("Extrinsic was invalid!");
                        break;
                }
            }, method, Alice, assetCharge, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1)));
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");
        }

        /// <summary>
        /// Transaction V1 Submit And Watch
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Extrinsic_TransactionV1SubmitAndWatchAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });

            var taskCompletionSource = new TaskCompletionSource<(bool, Hash)>();
            _ = await _substrateClient.TransactionWatchCalls.TransactionWatchV1SubmitAndWatchAsync(
               (subscriptionId, extrinsicUpdate) =>
               {
                   Debug.WriteLine($"ExtrinsicUpdate: {extrinsicUpdate.TransactionEvent.ToString()}");

                   switch (extrinsicUpdate.TransactionEvent)
                   {
                       case TransactionEvent.Finalized:
                           taskCompletionSource.SetResult((true, extrinsicUpdate.Hash));
                           break;

                       case TransactionEvent.Dropped:
                           Assert.Fail("Extrinsic was dropped!");
                           break;

                       case TransactionEvent.Invalid:
                           Assert.Fail("Extrinsic was invalid!");
                           break;

                       case TransactionEvent.Error:
                           Assert.Fail("Extrinsic was errored!");
                           break;
                   }
               }, method, Alice, _chargeType, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1)));
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");
        }

        /// <summary>
        /// Transaction V1 Unwatch
        /// </summary>
        /// <returns></returns>
        [Test, Timeout(10000)] // Timeout after 10 seconds
        public async Task Extrinsic_TransactionV1UnwatchAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });
            var cancellationTokenSource = new CancellationTokenSource();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            var subscriptionId = await _substrateClient.TransactionWatchCalls.TransactionWatchV1SubmitAndWatchAsync(
                (subscriptionId, extrinsicUpdate) =>
                {
                    if (extrinsicUpdate.TransactionEvent != TransactionEvent.Validated)
                    {
                        taskCompletionSource.SetResult(true);
                    }
                },
                method, Alice, _chargeType, 64, cancellationTokenSource.Token);

            var unsubscribed = await _substrateClient.TransactionWatchCalls.TransactionWatchV1UnwatchAsync(subscriptionId);
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