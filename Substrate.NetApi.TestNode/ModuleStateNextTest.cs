using System;
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
    public class ModuleStateNextTest : NodeTest
    {
        public ModuleStateNextTest() 
            : base("wss://hydradx-rpc.dwellir.com") { }

        [Test]
        public async Task GetBlockAsyncTestAsync()
        {
            var result = await _substrateClient.Chain.GetBlockAsync(new Hash("0x467fb6268675b96e707df72d382c14da0045ebc553edd9850414560053870b09"), CancellationToken.None);

            Assert.IsNotNull(result);
        }

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
        [TestCase("0x467fb6268675b96e707df72d382c14da0045ebc553edd9850414560053870b09")]
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

    }
}