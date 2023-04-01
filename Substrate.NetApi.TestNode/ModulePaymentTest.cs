using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.TestNode
{
    public class ModulePaymentTest : NodeTest
    {
        [Test]
        public async Task QueryFeeDetailTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var extrinsic = "0x25028400278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e00e7a640a15397d759c9203201c32a78fcaa9b3b64ef96b3d4210c0ee547d0cd0b96034aa7438380da4b3269bd53d868f367199e4823b441ed69bb88b27eb185060501440033060000000000000000000000000000000000000000000000000000000000000000";
            var result = await _substrateClient.Payment.QueryFeeDetailAsync(extrinsic, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.FeeDetails", result.GetType().ToString());
        }

        [Test]
        public async Task QueryInfoTestAsync()
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var extrinsic = "0x25028400278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e00e7a640a15397d759c9203201c32a78fcaa9b3b64ef96b3d4210c0ee547d0cd0b96034aa7438380da4b3269bd53d868f367199e4823b441ed69bb88b27eb185060501440033060000000000000000000000000000000000000000000000000000000000000000";
            var result = await _substrateClient.Payment.QueryInfoAsync(extrinsic, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.RuntimeDispatchInfoV1", result.GetType().ToString());
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetQueryStorageAtAsyncTestAsync(string storageKeyHex)
        {
            var storageKeys = new List<byte[]>() { Utils.HexToByteArray(storageKeyHex) };

            var results = await _substrateClient.State.GetQueryStorageAtAsync(storageKeys, string.Empty, CancellationToken.None);

            Assert.IsNotNull(results);
            Assert.IsNotNull(results.First());

            var result = results.First();
            Assert.True(result.Block.Value.StartsWith("0x"));
            Assert.AreEqual(1, result.Changes.Length);
            Assert.AreEqual("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000", result.Changes[0][0]);
            Assert.AreEqual("0x35a06bfec2edf0ff4be89a6428ccd9ff5bd0167d618c5a0d4341f9600a458d14", result.Changes[0][1]);
        }

        [Test]
        public async Task GetMetaData_ShouldWorkAsync()
        {
            var metadata_1 = await _substrateClient.State.GetMetaDataAsync();
            var metadata_2 = await _substrateClient.State.GetMetaDataAsync(CancellationToken.None);

            // We keep it simple just by checking if we got some data (no need to instanciate real metadata class)
            Assert.That(metadata_1, Is.Not.Null);
            Assert.That(metadata_2, Is.Not.Null);
            Assert.That(metadata_1, Is.EqualTo(metadata_2));
        }

        [Test]
        public async Task GetMetaDataAt_ShouldWorkAsync()
        {
            var blockHash = await givenBlockAsync();

            var metadata_1 = await _substrateClient.State.GetMetaDataAtAsync(blockHash, CancellationToken.None);
            var metadata_2 = await _substrateClient.State.GetMetaDataAtAsync(Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(metadata_1, Is.Not.Null);
            Assert.That(metadata_2, Is.Not.Null);
            Assert.That(metadata_1, Is.EqualTo(metadata_2));
        }

        [Test]
        public async Task GetRuntimeVersion_ShouldWorkAsync()
        {
            var runtimeVersion_1 = await _substrateClient.State.GetRuntimeVersionAsync();
            var runtimeVersion_2 = await _substrateClient.State.GetRuntimeVersionAsync(CancellationToken.None);

            Assert.That(runtimeVersion_1, Is.Not.Null);
            Assert.That(runtimeVersion_2, Is.Not.Null);

            Assert.That(runtimeVersion_1.ImplName, Is.EqualTo(runtimeVersion_2.ImplName));
            Assert.That(runtimeVersion_1.ImplVersion, Is.EqualTo(runtimeVersion_2.ImplVersion));
            Assert.That(runtimeVersion_1.TransactionVersion, Is.EqualTo(runtimeVersion_2.TransactionVersion));
            Assert.That(runtimeVersion_1.AuthoringVersion, Is.EqualTo(runtimeVersion_2.AuthoringVersion));
            Assert.That(runtimeVersion_1.SpecName, Is.EqualTo(runtimeVersion_2.SpecName));
            Assert.That(runtimeVersion_1.SpecVersion, Is.EqualTo(runtimeVersion_2.SpecVersion));
            Assert.That(runtimeVersion_1.Apis, Is.EquivalentTo(runtimeVersion_2.Apis));
        }

        [Test]
        public async Task GetRuntimeVersionAt_ShouldWorkAsync()
        {
            var blockHash = await givenBlockAsync();

            var runtimeVersion_1 = await _substrateClient.State.GetRuntimeVersionAtAsync(blockHash, CancellationToken.None);
            var runtimeVersion_2 = await _substrateClient.State.GetRuntimeVersionAtAsync(Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(runtimeVersion_1, Is.Not.Null);
            Assert.That(runtimeVersion_2, Is.Not.Null);

            Assert.That(runtimeVersion_1.ImplName, Is.EqualTo(runtimeVersion_2.ImplName));
            Assert.That(runtimeVersion_1.ImplVersion, Is.EqualTo(runtimeVersion_2.ImplVersion));
            Assert.That(runtimeVersion_1.TransactionVersion, Is.EqualTo(runtimeVersion_2.TransactionVersion));
            Assert.That(runtimeVersion_1.AuthoringVersion, Is.EqualTo(runtimeVersion_2.AuthoringVersion));
            Assert.That(runtimeVersion_1.SpecName, Is.EqualTo(runtimeVersion_2.SpecName));
            Assert.That(runtimeVersion_1.SpecVersion, Is.EqualTo(runtimeVersion_2.SpecVersion));
            Assert.That(runtimeVersion_1.Apis, Is.EquivalentTo(runtimeVersion_2.Apis));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetReadProof_ShouldWorkAsync(string storageKeyHex)
        {
            var storageKeys = new List<byte[]>() { Utils.HexToByteArray(storageKeyHex) };

            var call_1 = await _substrateClient.State.GetReadProofAsync(storageKeys);
            var call_2 = await _substrateClient.State.GetReadProofAsync(storageKeys, CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.At.Bytes, Is.EquivalentTo(call_2.At.Bytes));
            Assert.That(call_1.Proof.Select(x => x.Bytes), Is.EquivalentTo(call_2.Proof.Select(x => x.Bytes)));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetReadProofAt_ShouldWorkAsync(string storageKeyHex)
        {
            var blockHash = await givenBlockAsync();
            var storageKeys = new List<byte[]>() { Utils.HexToByteArray(storageKeyHex) };

            var call_1 = await _substrateClient.State.GetReadProofAtAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetReadProofAtAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.At.Bytes, Is.EquivalentTo(call_2.At.Bytes));
            Assert.That(call_1.Proof.Select(x => x.Bytes), Is.EquivalentTo(call_2.Proof.Select(x => x.Bytes)));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetStorage_ShouldWorkAsync(string storageKeyHex)
        {
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageAsync(storageKeys);
            var call_2 = await _substrateClient.State.GetStorageAsync(storageKeys, CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1, Is.EqualTo(call_2));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetStorageAt_ShouldWorkAsync(string storageKeyHex)
        {
            var blockHash = await givenBlockAsync();
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageAtAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetStorageAtAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1, Is.EqualTo(call_2));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetStorageHash_ShouldWorkAsync(string storageKeyHex)
        {
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageHashAsync(storageKeys);
            var call_2 = await _substrateClient.State.GetStorageHashAsync(storageKeys, CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.Bytes, Is.EquivalentTo(call_2.Bytes));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetStorageHashAt_ShouldWorkAsync(string storageKeyHex)
        {
            var blockHash = await givenBlockAsync();
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageHashAtAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetStorageHashAtAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.Bytes, Is.EquivalentTo(call_2.Bytes));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetStorageSize_ShouldWorkAsync(string storageKeyHex)
        {
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageSizeAsync(storageKeys);
            var call_2 = await _substrateClient.State.GetStorageSizeAsync(storageKeys, CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.Value, Is.EqualTo(call_2.Value));
        }

        [Test]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7a44704b568d21667356a5a050c118746b4def25cfda6ef3a00000000")]
        public async Task GetStorageSizeAt_ShouldWorkAsync(string storageKeyHex)
        {
            var blockHash = await givenBlockAsync();
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageSizeAtAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetStorageSizeAtAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.Value, Is.EqualTo(call_2.Value));
            Assert.That(call_1.Value, Is.EqualTo((ulong)32));
        }
    }
}