using Substrate.NetApi.Model.Extrinsics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NetApi.Test.Extrinsic
{
    public class InstanceTest
    {

        // Extrinsics created and signed with polkadot-js/apps.
        public static string[] Extrinsic = new string[]
        {
            // Timestamp set(now) with now = 1673908758014
            "0xc50184001cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c0188f4859d09355d8f964b8cbb8b84c5e0e2f86a423d30027d15764996dc198532044424e6cc2e281f4d23174b6bfb3d2af64917b7356e570f41a1e44bcaa47385650300000001000bfea5bcbc8501",
            // Staking bondExtra(maxAdditional) with maxAditional = 60000000000
            "0x710284001cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c01d0e951a27297d1418d17fcbadfc19441d2d276f358965a94ff87f1b1db287c4cae203b65dab926627c80deae720bca1335d771389843b1bf69b9e85139922b819503000000070000001cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c0a000000000000000000000000000000",
            // Balances transferKeepAlive(dest, value)
            "0x4d0284001cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c01e6da8673127ec665dbfb76322ffe12721caa9b747abc5b6ec8ab73ff34f07831ed9edc49d185483a0c538a120149b7b6367bcde7088873408cc49ec280976c8ba5000000000403001cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c0f0080c6a47e8d03"
        };

        [Test]
        [TestCaseSource(nameof(Extrinsic))]
        public void EncodeAndDecodeExtrinsic_ShouldBeEqual(string hex)
        {
            var extrinsic = new Model.Extrinsics.Extrinsic(hex, ChargeTransactionPayment.Default());

            var encoded = extrinsic.Encode();
            var hexFromEncoded = Utils.Bytes2HexString(encoded);
            var extrinsicFromEncoded = new Model.Extrinsics.Extrinsic(hexFromEncoded, ChargeTransactionPayment.Default());

            Assert.That(encoded, Is.EqualTo(extrinsicFromEncoded.Encode()));
        }
    }
}
