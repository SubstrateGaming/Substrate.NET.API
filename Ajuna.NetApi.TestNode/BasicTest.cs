using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using NUnit.Framework;
using Schnorrkel.Keys;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ajuna.NetApi.TestNode
{
    public class BasicTest
    {
        private const string WebSocketUrl = "ws://rpc-parachain.bajun.network";

        private SubstrateClient _substrateClient;

        // Secret Key URI `//Alice` is account:
        // Secret seed:      0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
        // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Account ID:       0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // SS58 Address:     5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        public MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToBytes(), MiniSecretAlice.GetPair().Public.Key);

        // Secret Key URI `//Bob` is account:
        // Secret seed:      0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
        // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Account ID:       0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // SS58 Address:     5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        public MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);

        [SetUp]
        public void Setup()
        {
            _substrateClient = new SubstrateClient(new Uri(WebSocketUrl), ChargeTransactionPayment.Default());

        }

        [TearDown]
        public void TearDown()
        {
            _substrateClient.Dispose();
        }

        [Test]
        public async Task GetSystemChainTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.System.ChainAsync(CancellationToken.None);

            Assert.AreEqual("Bajun Kusama", result);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetSystemChainTypeTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.System.ChainTypeAsync(CancellationToken.None);

            Assert.AreEqual("Live", result);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetLocalListenAddressesTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.System.LocalListenAddressesAsync(CancellationToken.None);

            Assert.IsNotNull(result);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetLocalPeerIdTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.System.LocalPeerIdAsync(CancellationToken.None);

            Assert.IsNotNull(result);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetNodeRolesTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.System.NodeRolesAsync(CancellationToken.None);

            Assert.IsNotNull(result);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetSystemPropertiesTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.System.PropertiesAsync(CancellationToken.None);

            Assert.AreEqual(1337, result.Ss58Format);
            Assert.AreEqual(12, result.TokenDecimals);
            Assert.AreEqual("BAJU", result.TokenSymbol);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetBlockNumberTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var blockNumber = new BlockNumber();
            blockNumber.Create(0);

            var result = await _substrateClient.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None);

            Assert.AreEqual("0x35A06BFEC2EDF0FF4BE89A6428CCD9FF5BD0167D618C5A0D4341F9600A458D14", result.Value);

            await _substrateClient.CloseAsync();
        }

        /// <summary>
        /// Simple extrinsic tester
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        static void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
        {
            switch (extrinsicUpdate.ExtrinsicState)
            {
                case ExtrinsicState.None:
                    Assert.IsTrue(true);
                    Assert.IsTrue(extrinsicUpdate.InBlock.Value.Length > 0 || extrinsicUpdate.Finalized.Value.Length > 0);
                    break;
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
            }
        }

    }
}