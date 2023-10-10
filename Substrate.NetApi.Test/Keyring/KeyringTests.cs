using Newtonsoft.Json;
using NUnit.Framework;
using Substrate.NetApi.Keyring;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NetApi.Test.Keyring
{
    public class KeyringTests
    {
        protected string readJsonFromFile(string jsonFile)
        {
            return File.ReadAllText($"{AppContext.BaseDirectory}\\Keyring\\MockAccounts\\{jsonFile}");
        }

        [Test]
        [TestCase("Mock_1.json")]
        public void ValidJson_WithValidPassword_ShouldUnlock(string json)
        {
            var input = readJsonFromFile(json);

            var keyring = new NetApi.Keyring.Keyring();
            var kp = keyring.AddFromJson(input);

            Assert.That(kp, Is.Not.Null);

            // Ensure wallet is lock because we don't provide any password
            Assert.That(kp.IsLocked, Is.EqualTo(true));
            
            kp.Unlock("SUBSTRATE");
            Assert.That(kp.IsLocked, Is.EqualTo(false));

            // And now lock it again
            kp.Lock();
            Assert.That(kp.IsLocked, Is.EqualTo(true));
        }

        [Test]
        [TestCase("Mock_1.json")]
        public void ValidJson_WithInvalidPassword_ShouldThrowException(string json)
        {
            var input = readJsonFromFile(json);

            var keyring = new NetApi.Keyring.Keyring();
            var res = keyring.AddFromJson(input);

            Assert.Throws<InvalidOperationException>(() => res.Unlock("SS2"));
        }

        [Test]
        [TestCase("Mock_1.json")]
        public void ValidJson_WithNewPassword_ShouldRewriteJson(string json)
        {
            var input = readJsonFromFile(json);

            var keyring = new NetApi.Keyring.Keyring();
            var keyringPair1 = keyring.AddFromJson(input);

            var walletEncryptionSamePassword = keyringPair1.ToWalletEncryption("SUBSTRATE");
            var keyringPair2 = keyring.AddFromJson(walletEncryptionSamePassword);

            Assert.That(keyringPair1.PairInformation.PublicKey, Is.EqualTo(keyringPair2.PairInformation.PublicKey));

            // Both are lock
            Assert.That(keyringPair1.IsLocked, Is.True);
            Assert.That(keyringPair2.IsLocked, Is.True);

            keyringPair1.Unlock("SUBSTRATE");
            keyringPair2.Unlock("SUBSTRATE");
            Assert.That(keyringPair1.PairInformation.SecretKey, Is.EqualTo(keyringPair2.PairInformation.SecretKey));
        }

        [Test, Ignore("WIP")]
        [TestCase("13zUtDC1UdzLu3ac7buXexHS1S5wAp5z1YmgsdiLHJpU7LtM")]
        public void AddFromMnemonic_WithValidMnemonic_ShouldSuceed(string address)
        {
            var meta = new Meta()
            {
                genesisHash = "0x35a06bfec2edf0ff4be89a6428ccd9ff5bd0167d618c5a0d4341f9600a458d14",
                isHardware = false,
                name = "SUBSTRATE"
            };
            var keyring = new NetApi.Keyring.Keyring();
            keyring.Ss58Format = 2;

            var kp = keyring.AddFromMnemonic("moral movie very draw assault whisper awful rebuild speed purity repeat card", meta);

            Assert.That(kp.Address, Is.EqualTo("HSLu2eci2GCfWkRimjjdTXKoFSDL3rBv5Ey2JWCBj68cVZj"));
        }
    }
}
