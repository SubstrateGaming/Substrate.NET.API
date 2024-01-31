using System;
using System.Text;
using Substrate.NetApi.Sign;
using NUnit.Framework;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi.Model.Types;
using System.Threading.Tasks;
using System.Linq;

namespace Substrate.NetApi.Test.Keys
{
    public class Sr25519Tests
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
        public void Sr25519KeyPairTest()
        {
            // Secret Key URI `//Alice` is account:
            // Secret seed:      0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
            // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
            // Account ID:       0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
            // SS58 Address:     5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY

            var miniSecretAlice = new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
            var keyPairAlice = miniSecretAlice.GetPair();

            Assert.AreEqual("0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d", Utils.Bytes2HexString(keyPairAlice.Public.Key).ToLower());
            Assert.AreEqual("0x925a225d97aa00682d6a59b95b18780c10d7032336e88f3442b42361f4a66011", Utils.Bytes2HexString(keyPairAlice.Secret.nonce).ToLower());
            Assert.AreEqual("5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY", Utils.GetAddressFrom(keyPairAlice.Public.Key));

            // Secret Key URI `//Bob` is account:
            // Secret seed:      0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
            // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
            // Account ID:       0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
            // SS58 Address:     5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty

            var miniSecretBob = new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
            var keyPairBob = miniSecretBob.GetPair();

            Assert.AreEqual("0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48", Utils.Bytes2HexString(keyPairBob.Public.Key).ToLower());
            Assert.AreEqual("0x41ae88f85d0c1bfc37be41c904e1dfc01de8c8067b0d6d5df25dd1ac0894a325", Utils.Bytes2HexString(keyPairBob.Secret.nonce).ToLower());
            Assert.AreEqual("5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty", Utils.GetAddressFrom(keyPairBob.Public.Key));
        }

        [Test]
        public void Sr25519SignatureTest()
        {
            var miniSecretAlice = new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
            var keyPairAlice = miniSecretAlice.GetPair();

            var messageLength = _random.Next(10, 200);
            var message = new byte[messageLength];
            _random.NextBytes(message);

            var simpleSign = Substrate.NET.Schnorrkel.Sr25519v091.SignSimple(keyPairAlice, message);

            Assert.True(Substrate.NET.Schnorrkel.Sr25519v091.Verify(simpleSign, keyPairAlice.Public.Key, message));
        }

        [Test]
        [TestCase("0x5c42ac4e2d55b8e59d9b255af370de03fe177f5545eecbbd784531cb2eb1f2553e0e2b91656f99fae930eb6ff8ac1a3eca4e19d307ecb39832a479a478a8608a")]
        public void Sr25519SignatureTestComparePolkadotJs(string polkadotJsSignature)
        {
            var miniSecretAlice = new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
            var keyPairAlice = miniSecretAlice.GetPair();

            var message = "I test this signature!";
            var messageBytes = WrapMessage.Wrap(message);

            var simpleSign = Substrate.NET.Schnorrkel.Sr25519v091.SignSimple(keyPairAlice, messageBytes);
            var singatureHexString = Utils.Bytes2HexString(simpleSign);
            // SIGn C#: 0x2A6346A8707A9929B65167C448F719FE977F2EE04D2CB250685C98C79CCBF2458901F9B386D08422D9102FBD8BF7CFECDF7605F4CDC5FA8D121E2E9730F9098C

            // SIGn PolkaJS:0x5c42ac4e2d55b8e59d9b255af370de03fe177f5545eecbbd784531cb2eb1f2553e0e2b91656f99fae930eb6ff8ac1a3eca4e19d307ecb39832a479a478a8608a
            var simpleSign2 = Utils.HexToByteArray(polkadotJsSignature);
            Assert.True(Substrate.NET.Schnorrkel.Sr25519v091.Verify(simpleSign2, keyPairAlice.Public.Key, messageBytes));
        }

        [Test]
        [TestCase("0x5c42ac4e2d55b8e59d9b255af370de03fe177f5545eecbbd784531cb2eb1f2553e0e2b91656f99fae930eb6ff8ac1a3eca4e19d307ecb39832a479a478a8608a")]
        public async Task AccountSr25519SignatureTestComparePolkadotJsAsync(string polkadotJsSignature)
        {
            var miniSecretAlice = new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);

        //    var account = Account.Build(KeyType.Sr25519, miniSecretAlice.ExpandToSecret().ToEd25519Bytes(), miniSecretAlice.GetPair().Public.Key);

        //    var message = "I test this signature!";
        //    var messageBytes = WrapMessage.Wrap(message);

            var signature1 = await Task.Run(() => account.Sign(messageBytes));
            var signature2 = await account.SignAsync(messageBytes);

            Assert.True(account.Verify(signature1, account.Bytes, messageBytes));
            Assert.True(account.Verify(signature2, account.Bytes, messageBytes));

            var signature3 = Utils.HexToByteArray(polkadotJsSignature);
            Assert.True(account.Verify(signature3, account.Bytes, messageBytes));
        }
    }
}