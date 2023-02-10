using System;
using System.Linq;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Sign;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Schnorrkel.Keys;

namespace Ajuna.NetApi.Test.Keys
{
    public class Ed25519Tests
    {
        private Random _random;

        [OneTimeSetUp]
        public void Setup()
        {
            _random = new Random();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Ed25519KeyPairTest()
        {
            var priKey0x =
                "0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e";
            var pubKey0x = "0x278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e";

            var priKey = Utils.HexToByteArray(priKey0x);
            var pubKey = Utils.HexToByteArray(pubKey0x);
            var seed = priKey.Take(32).ToArray();

            Chaos.NaCl.Ed25519.KeyPairFromSeed(out pubKey, out priKey, seed);

            Assert.AreEqual("0xF5E5767CF153319517630F226876B86C8160CC583BC013744C6BF255F5CC0EE5",
                Utils.Bytes2HexString(seed));
            Assert.AreEqual(
                "0xF5E5767CF153319517630F226876B86C8160CC583BC013744C6BF255F5CC0EE5278117FC144C72340F67D0F2316E8386CEFFBF2B2428C9C51FEF7C597F1D426E",
                Utils.Bytes2HexString(priKey));
            Assert.AreEqual("0x278117FC144C72340F67D0F2316E8386CEFFBF2B2428C9C51FEF7C597F1D426E",
                Utils.Bytes2HexString(pubKey));

            var accountId = new AccountId();
            accountId.Create("0x278117FC144C72340F67D0F2316E8386CEFFBF2B2428C9C51FEF7C597F1D426E");
            Assert.AreEqual("5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM", accountId.Value);
        }

        [Test]
        public void Ed25519KeyPairTest2()
        {
            var seed = Utils.HexToByteArray("0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5");
            byte[] pubKey, priKey;
            Chaos.NaCl.Ed25519.KeyPairFromSeed(out pubKey, out priKey, seed);

            Assert.AreEqual(
                Utils.HexToByteArray(
                    "0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e"),
                Chaos.NaCl.Ed25519.ExpandedPrivateKeyFromSeed(seed));
        }

        [Test]
        public void Ed25519SignatureTest()
        {
            var priKey0x =
                "0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e";
            var pubKey0x = "0x278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e";

            var priKey = Utils.HexToByteArray(priKey0x);
            var pubKey = Utils.HexToByteArray(pubKey0x);

            var messageLength = _random.Next(10, 200);
            var message = new byte[messageLength];
            _random.NextBytes(message);

            //var message = signaturePayloadBytes.AsMemory().Slice(0, (int)payloadLength).ToArray();
            var simpleSign = Chaos.NaCl.Ed25519.Sign(message, priKey);

            Assert.True(Chaos.NaCl.Ed25519.Verify(simpleSign, message, pubKey));
        }

        [Test]
        public void SignatureVerifySignedOnNodeByAccount()
        {
            var priKey0x =
                "0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e";
            var privateKey = Utils.HexToByteArray(priKey0x);
            var publicKey = Utils.GetPublicKeyFrom("5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM");

            var messag1 = Utils.HexToByteArray("0xA81056D713AF1FF17B599E60D287952E89301B5208324A0529B62DC7369C745D");
            var signedByAcc1 =
                Utils.HexToByteArray(
                    "0x10b6aacb0beca6ca60b712fb5db54e957cec304489366544d96f3e59ac2d4328be7b6602ec98e622c0f16ab427eb497d6ef053e00ddfdb3d3f3b6496b0b17a0c");
            Assert.True(Chaos.NaCl.Ed25519.Verify(signedByAcc1, messag1, publicKey));

            var messag2 =
                Utils.HexToByteArray(
                    "0x0400FF8EAF04151687736326C9FEA17E25FC5287613693C912909CB226AA4794F26A484913DC4F62090B18B6893C1431369461069EE3E9C1DA7F9F9A8C097C0CEBBEAC2BB9");
            var signedByAcc2 =
                Utils.HexToByteArray(
                    "0x1c7921583e992bae122ba4a754eb84071ac8a627cc4d050047e3d0dbdaa64718a3728e8f87deb2cb9249527853f85833d1b1c2e3af1c60724c060c1b78670b02");
            Assert.True(Chaos.NaCl.Ed25519.Verify(signedByAcc2, messag2, publicKey));

            var simpleSign = Chaos.NaCl.Ed25519.Sign(messag2, privateKey);
            var simpleSignStr = Utils.Bytes2HexString(simpleSign);
            Assert.True(Chaos.NaCl.Ed25519.Verify(simpleSign, messag2, publicKey));
        }

        [Test]
        [TestCase("0xd2baabb61bcd0026e797136cb0938d55e3c3ea8825c163eb3d1738b3c79af8e8f4953ba4767dc5477202756d3fba97bc50fc3ac8355ff5acfba88a36311f2f0f")]
        public void SignatureVerifySignedOnNodeByAccountComparePolkadotJs(string polkadotJsSignature)
        {
            var rawSeed = "0x70f93a75dbc6ad5b0c051210704a00a9937732d0c360792b0fea24efb8ea8465";

            byte[] pubKey, priKey;
            Chaos.NaCl.Ed25519.KeyPairFromSeed(out pubKey, out priKey, Utils.HexToByteArray(rawSeed));


            var message = "I test this signature!";
            // According to https://github.com/polkadot-js/apps/blob/master/packages/page-signing/src/Sign.tsx#L93
            var messageBytes = WrapMessage.Wrap(message);

            var signature = Chaos.NaCl.Ed25519.Sign(messageBytes, priKey);
            var singatureHexString = Utils.Bytes2HexString(signature);

            // SIGn C#: 0x679FA7BC8B2A7C40B5ECD50CA041E961DB8971D2B454DB7DE64E543B3C1892A6D3F223DDA01C66B9878C149CFCC8B86ECF2B20F11F7610596F51479405776907

            // SIGn PolkaJS:0xd2baabb61bcd0026e797136cb0938d55e3c3ea8825c163eb3d1738b3c79af8e8f4953ba4767dc5477202756d3fba97bc50fc3ac8355ff5acfba88a36311f2f0f
            Assert.True(Chaos.NaCl.Ed25519.Verify(Utils.HexToByteArray(polkadotJsSignature), messageBytes, pubKey));
        }

        [Test]
        public void SignatureVerifyOnNodeSignedHereByAccount()
        {
            // https://polkadot.js.org/apps/#/signing/verify

            Assert.True(true);
        }
    }
}