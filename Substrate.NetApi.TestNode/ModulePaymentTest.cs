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
        [TestCase("0x5d02840094546ff56643b8c0fed386347d7a8cd0b995383125a0fc0f0e45f0e33a6c58270128da3e1cd19a10e3bbdd37ef0f24a0424a6febc1a6adeaa46ef0294a0f300e795dc4cfd380345b4fa53e28a8c258bd4ff4b0ed6554b78fc292d3aed0659ac48a45031989000f0700c87277c3912dfe4107ab28c32309c6b10ca6c0ad6ebc540fbfd26674db51b5291f0000005b2c765c5c43be65")]
        public async Task QueryFeeDetailTestAsync(string extrinsicHex)
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.Payment.QueryFeeDetailAsync(extrinsicHex, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.FeeDetails", result.GetType().ToString());
        }

        [Test]
        [TestCase("0x5d02840094546ff56643b8c0fed386347d7a8cd0b995383125a0fc0f0e45f0e33a6c58270128da3e1cd19a10e3bbdd37ef0f24a0424a6febc1a6adeaa46ef0294a0f300e795dc4cfd380345b4fa53e28a8c258bd4ff4b0ed6554b78fc292d3aed0659ac48a45031989000f0700c87277c3912dfe4107ab28c32309c6b10ca6c0ad6ebc540fbfd26674db51b5291f0000005b2c765c5c43be65")]

        public async Task QueryInfoTestAsync(string extrinsicHex)
        {
            await _substrateClient.ConnectAsync(false, CancellationToken.None);

            var result = await _substrateClient.Payment.QueryInfoAsync(extrinsicHex, null, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Substrate.NetApi.Model.Rpc.RuntimeDispatchInfo", result.GetType().ToString());
        }
    }
}