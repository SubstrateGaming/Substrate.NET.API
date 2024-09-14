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
        [TestCase("0x4902840094546ff56643b8c0fed386347d7a8cd0b995383125a0fc0f0e45f0e33a6c582701b475d9d1d45cc3f372607f3542ba5671a9328303610e4b6274e7e574eeff3064a7d1a2bfb807d7a0577f9fc2b47925db22ffb9ec8c1bf04793c5a3a789edf28245020101000005030094546ff56643b8c0fed386347d7a8cd0b995383125a0fc0f0e45f0e33a6c58270700e40b5402")]
        public async Task QueryFeeDetailTestAsync(string extrinsicHex)
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.Payment.QueryFeeDetailAsync(extrinsicHex, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.FeeDetails", result.GetType().ToString());
        }

        [Test]
        [TestCase("0x4902840094546ff56643b8c0fed386347d7a8cd0b995383125a0fc0f0e45f0e33a6c582701b475d9d1d45cc3f372607f3542ba5671a9328303610e4b6274e7e574eeff3064a7d1a2bfb807d7a0577f9fc2b47925db22ffb9ec8c1bf04793c5a3a789edf28245020101000005030094546ff56643b8c0fed386347d7a8cd0b995383125a0fc0f0e45f0e33a6c58270700e40b5402")]

        public async Task QueryInfoTestAsync(string extrinsicHex)
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.Payment.QueryInfoAsync(extrinsicHex, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.RuntimeDispatchInfo", result.GetType().ToString());
        }
    }
}