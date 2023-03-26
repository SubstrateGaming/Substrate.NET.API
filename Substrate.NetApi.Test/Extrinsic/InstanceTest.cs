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

        public static string[] Extrinsic = new string[]
        {
            // Timestamp set(now) with now = 1673908758014
            "0x280403000bfea5bcbc8501",
            // Staking bondExtra(maxAdditional) with maxAditional = 60000000000
            "0xbd01840021e64ca11afde772615b240dd09ada3fc96e46619b77f9c0ce3dcebc67878939006ac2017f7951358d09ca1c6da63501b8d00dd72703e593b4a0ca924d59360d4968abaf6361999a21943618ce0850f8b5f8dd51c54c772ffccb35ff63208a1d0025012000070107005847f80d",
            // Balances transferKeepAlive(dest, value)
            "0x45028400f371affe2fd3ebd6f0a607e983bc8f905cea0ca2668667a229e112b30c5f9bbd0096f3ac43319d2e980db0aaf2b7e5e985055ea87f7b2a91a2ee09a934aef55bad4ec0dfd93e7010bc5dbf290403051ec40d475534df90ce3e1dd8a5b1ab3f7a0e4502cd0e000503001c3ef60163945e2b4602f7c6b27fc1f8e79d7c3430e3518cf63dc8a6ee84e9740700325f9d08"
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
