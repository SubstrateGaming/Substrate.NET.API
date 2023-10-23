using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Schnorrkel.Keys;

namespace Substrate.NetApi.TestNode
{
    public class ExtrinsicsTest
    {
        public MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToBytes(), MiniSecretAlice.GetPair().Public.Key);
        
        public MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);

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
        /// Extrinsic Remark test
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Extrinsic_RemarkTestAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });

            var taskCompletionSource = new TaskCompletionSource<(bool, Hash)>();
            await _substrateClient.Author.SubmitAndWatchExtrinsicAsync((string subscriptionId, ExtrinsicStatus extrinsicUpdate) => Callback(subscriptionId, extrinsicUpdate, taskCompletionSource), method, Alice, _chargeType, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1))); // 5 minutes or any appropriate timeout
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");
        }

        [Test]
        public async Task Extrinsic_FailTestAsync()
        {

            var method = new Method(0, "System", 1, "set_heap_pages", new U64(999).Encode());

            var taskCompletionSource = new TaskCompletionSource<(bool, Hash)>();

            var account = Bob;

            var subscriptionId = await _substrateClient.Author.SubmitAndWatchExtrinsicAsync((string subscriptionId, ExtrinsicStatus extrinsicUpdate) => Callback(subscriptionId, extrinsicUpdate, taskCompletionSource), method, account, _chargeType, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1))); // 5 minutes or any appropriate timeout
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");

            var block = await _substrateClient.Chain.GetBlockAsync((await taskCompletionSource.Task).Item2);

            var accountExtrinsics = block.Block.Extrinsics.Where(p => p.Signed && p.Account.Value == account.Value);
            Assert.AreEqual(1, accountExtrinsics.Count());

        }

        /// <summary>
        /// Extrinsic Transfer Callback test
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        /// <param name="taskCompletionSource"></param>
        private static void Callback(string subscriptionId, ExtrinsicStatus extrinsicUpdate, TaskCompletionSource<(bool, Hash)> taskCompletionSource)
        {
            ActionExtrinsicUpdate(subscriptionId, extrinsicUpdate);
            if (extrinsicUpdate.ExtrinsicState == ExtrinsicState.Finalized ||
                extrinsicUpdate.ExtrinsicState == ExtrinsicState.Dropped ||
                extrinsicUpdate.ExtrinsicState == ExtrinsicState.Invalid)
            {
                taskCompletionSource.SetResult((true, extrinsicUpdate.Hash));
            }
        }

        /// <summary>
        /// Simple extrinsic tester
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        private static void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
        {
            if (subscriptionId == null || subscriptionId.Length == 0)
            {
                Assert.IsTrue(false);
            }

            switch (extrinsicUpdate.ExtrinsicState)
            {
                case ExtrinsicState.Future:
                    Assert.IsTrue(false);
                    break;

                case ExtrinsicState.Ready:
                    Assert.IsTrue(true);
                    break;

                case ExtrinsicState.Dropped:
                    Assert.IsTrue(false);
                    break;

                case ExtrinsicState.Invalid:
                    Assert.IsTrue(false);
                    break;

                case ExtrinsicState.Broadcast:
                    Assert.IsTrue(extrinsicUpdate.Broadcast != null);
                    break;

                case ExtrinsicState.InBlock:
                    Assert.IsTrue(extrinsicUpdate.Hash.Value.Length > 0);
                    break;

                case ExtrinsicState.Retracted:
                    Assert.IsTrue(extrinsicUpdate.Hash.Value.Length > 0);
                    break;

                case ExtrinsicState.FinalityTimeout:
                    Assert.IsTrue(extrinsicUpdate.Hash.Value.Length > 0);
                    break;

                case ExtrinsicState.Finalized:
                    Assert.IsTrue(extrinsicUpdate.Hash.Value.Length > 0);
                    break;

                case ExtrinsicState.Usurped:
                    Assert.IsTrue(extrinsicUpdate.Hash.Value.Length > 0);
                    break;

                default:
                    Assert.IsTrue(false);
                    break;

            }
        }
    }
}