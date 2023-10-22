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
        public void CreateClient()
        {
            _chargeType = ChargeAssetTxPayment.Default();
            _substrateClient = new SubstrateClient(new Uri(WebSocketUrl), _chargeType);
        }

        [OneTimeTearDown]
        public void DisposeClient()
        {
            _substrateClient.Dispose();
        }

        /// <summary>
        /// Extrinsic Remark test
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Extrinsic_RemarkAsync()
        {
            var method = new Method(0, "System", 0, "remark", new byte[] { 0x04, 0xFF });

            var taskCompletionSource = new TaskCompletionSource<bool>();
            await _substrateClient.Author.SubmitAndWatchExtrinsicAsync((string subscriptionId, ExtrinsicStatus extrinsicUpdate) => Callback(subscriptionId, extrinsicUpdate, taskCompletionSource), method, Alice, _chargeType, 64, CancellationToken.None);

            var finished = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(TimeSpan.FromMinutes(1))); // 5 minutes or any appropriate timeout
            Assert.AreEqual(taskCompletionSource.Task, finished, "Test timed out waiting for final callback");
        }

        /// <summary>
        /// Extrinsic Transfer Callback test
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        /// <param name="taskCompletionSource"></param>
        private static void Callback(string subscriptionId, ExtrinsicStatus extrinsicUpdate, TaskCompletionSource<bool> taskCompletionSource)
        {
            ActionExtrinsicUpdate(subscriptionId, extrinsicUpdate);
            if (extrinsicUpdate.ExtrinsicState == ExtrinsicState.Finalized ||
                extrinsicUpdate.ExtrinsicState == ExtrinsicState.Dropped ||
                extrinsicUpdate.ExtrinsicState == ExtrinsicState.Invalid)
            {
                taskCompletionSource.SetResult(true);
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