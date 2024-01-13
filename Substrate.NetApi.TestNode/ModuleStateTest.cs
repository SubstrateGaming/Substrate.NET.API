﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using StreamJsonRpc;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.TestNode
{
    public class ModuleStateTest : NodeTest
    {
        [Test]
        public async Task GetKeysPagedAtTestAsync()
        {
            var parameters = RequestGenerator.GetStorage("System", "Number",
                Model.Meta.Storage.Type.Plain);

            var currentBlocknumber = await _substrateClient.GetStorageAsync<U32>(parameters, CancellationToken.None);

            var blockNumber = new BlockNumber();
            blockNumber.Create(currentBlocknumber.Value);

            var blockHash = await _substrateClient.Chain.GetBlockHashAsync(blockNumber);

            var result = await _substrateClient.State.GetKeysPagedAsync(RequestGenerator.GetStorageKeyBytesHash("System", "BlockHash"), 10, null, blockHash.Bytes, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count);
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
            var blockHash = await GivenBlockAsync();

            var metadata_1 = await _substrateClient.State.GetMetaDataAsync(blockHash, CancellationToken.None);
            var metadata_2 = await _substrateClient.State.GetMetaDataAsync(Utils.Bytes2HexString(blockHash), CancellationToken.None);

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
            var blockHash = await GivenBlockAsync();

            var runtimeVersion_1 = await _substrateClient.State.GetRuntimeVersionAsync(blockHash, CancellationToken.None);
            var runtimeVersion_2 = await _substrateClient.State.GetRuntimeVersionAsync(Utils.Bytes2HexString(blockHash), CancellationToken.None);

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
            var blockHash = await GivenBlockAsync();
            var storageKeys = new List<byte[]>() { Utils.HexToByteArray(storageKeyHex) };

            var call_1 = await _substrateClient.State.GetReadProofAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetReadProofAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

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
            var blockHash = await GivenBlockAsync();
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetStorageAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

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
            var blockHash = await GivenBlockAsync();
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageHashAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetStorageHashAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

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
            var blockHash = await GivenBlockAsync();
            var storageKeys = Utils.HexToByteArray(storageKeyHex);

            var call_1 = await _substrateClient.State.GetStorageSizeAsync(storageKeys, blockHash, CancellationToken.None);
            var call_2 = await _substrateClient.State.GetStorageSizeAsync(storageKeys, Utils.Bytes2HexString(blockHash), CancellationToken.None);

            Assert.That(call_1, Is.Not.Null);
            Assert.That(call_2, Is.Not.Null);
            Assert.That(call_1.Value, Is.EqualTo(call_2.Value));
            Assert.That(call_1.Value, Is.EqualTo((ulong)32));
        }

        [Test]
        [TestCase("0xf0c365c3cf59d671eb72da0e7a4113c49f1f0515f462cdcf84e0f1d6045dfcbb")]
        public async Task SubscribeStorage_ShouldWorkAsync(string storageKeyHex)
        {
            Action<string, StorageChangeSet> callBack = (key, storacheChangeSet) =>
            {
                Assert.AreEqual("String", key.GetType().Name);
                Assert.AreEqual(1, storacheChangeSet.Changes.Length);
                Assert.AreEqual(2, storacheChangeSet.Changes[0].Length);
                Assert.AreEqual(storageKeyHex, storacheChangeSet.Changes[0][0]);
            };

            var subscriptionId = await _substrateClient.State.SubscribeStorageAsync(new JArray() { storageKeyHex }, callBack, CancellationToken.None);

            Thread.Sleep(20 * 1000);

            await _substrateClient.State.UnsubscribeStorageAsync(subscriptionId, CancellationToken.None);
        }

        [Test]
        public void SubscribeStorageAll_Failure()
        {

            var ex = Assert.ThrowsAsync<RemoteMethodNotFoundException>(
                 async () => await _substrateClient.State.SubscribeStorageAsync(null, (key, storacheChangeSet) => { })
             );

            Assert.AreEqual("RPC call is unsafe to be called externally", ex.Message);
        }
    }
}