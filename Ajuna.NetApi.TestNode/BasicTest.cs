using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Schnorrkel.Keys;

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

        [Test]
        public async Task GetAccountInfoTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var blockNumber = new U32();
            blockNumber.Create(0);

            var parameters = RequestGenerator.GetStorage("System", "BlockHash", 
                Model.Meta.Storage.Type.Map,
                new Model.Meta.Storage.Hasher[] { Model.Meta.Storage.Hasher.Twox64Concat}, 
                new IType[] { blockNumber });

            var result = await _substrateClient.GetStorageAsync<Arr32U8>(parameters, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("0x35A06BFEC2EDF0FF4BE89A6428CCD9FF5BD0167D618C5A0D4341F9600A458D14", Utils.Bytes2HexString(result.Value.Select(p => p.Value).ToArray()));

            blockNumber.Create(999999999);

            parameters = RequestGenerator.GetStorage("System", "BlockHash",
                Model.Meta.Storage.Type.Map,
                new Model.Meta.Storage.Hasher[] { Model.Meta.Storage.Hasher.Twox64Concat },
                new IType[] { blockNumber });

            result = await _substrateClient.GetStorageAsync<Arr32U8>(parameters, CancellationToken.None);

            Assert.IsNull(result);

            await _substrateClient.CloseAsync();
        }

        [Test]
        public async Task GetQueryStorageAtAsyncTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var list = new List<byte[]>() {
                Utils.HexToByteArray("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")};

            var result = await _substrateClient.State.GetQueryStorageAtAsync(list, CancellationToken.None);

            Assert.True(result.Block.Value.StartsWith("0x"));
            Assert.AreEqual(1, result.Changes.Length);
            Assert.AreEqual("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000", result.Changes[0][0]);
            Assert.AreEqual("0x35a06bfec2edf0ff4be89a6428ccd9ff5bd0167d618c5a0d4341f9600a458d14", result.Changes[0][1]);
            await _substrateClient.CloseAsync();
        }

        /// <summary>
        /// Simple extrinsic tester
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        private static void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
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

        /// <summary>
        /// >> 1 - Array
        /// </summary>
        public sealed class Arr32U8 : BaseType
        {

            private U8[] _value;

            public override int TypeSize
            {
                get
                {
                    return 32;
                }
            }

            public U8[] Value
            {
                get
                {
                    return this._value;
                }
                set
                {
                    this._value = value;
                }
            }

            public override string TypeName()
            {
                return string.Format("[{0}; {1}]", new U8().TypeName(), this.TypeSize);
            }

            public override byte[] Encode()
            {
                var result = new List<byte>();
                foreach (var v in Value) { result.AddRange(v.Encode()); };
                return result.ToArray();
            }

            public override void Decode(byte[] byteArray, ref int p)
            {
                var start = p;
                var array = new U8[TypeSize];
                for (var i = 0; i < array.Length; i++) { var t = new U8(); t.Decode(byteArray, ref p); array[i] = t; };
                var bytesLength = p - start;
                Bytes = new byte[bytesLength];
                System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
                Value = array;
            }

            public void Create(U8[] array)
            {
                Value = array;
                Bytes = Encode();
            }
        }
    }
}