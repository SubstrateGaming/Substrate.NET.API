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
        [TestCase("0x25028400278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e00e7a640a15397d759c9203201c32a78fcaa9b3b64ef96b3d4210c0ee547d0cd0b96034aa7438380da4b3269bd53d868f367199e4823b441ed69bb88b27eb185060501440033060000000000000000000000000000000000000000000000000000000000000000")]
        public async Task QueryFeeDetailTestAsync(string extrinsicHex)
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.Payment.QueryFeeDetailAsync(extrinsicHex, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.FeeDetails", result.GetType().ToString());
        }

        [Test]
        [TestCase("0x25028400278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e00e7a640a15397d759c9203201c32a78fcaa9b3b64ef96b3d4210c0ee547d0cd0b96034aa7438380da4b3269bd53d868f367199e4823b441ed69bb88b27eb185060501440033060000000000000000000000000000000000000000000000000000000000000000")]

        public async Task QueryInfoTestAsync(string extrinsicHex)
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.Payment.QueryInfoAsync(extrinsicHex, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.RuntimeDispatchInfoV1", result.GetType().ToString());
        }
    }
}