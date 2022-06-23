using System;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using SubstrateNetWallet;
using Ajuna.NetWallet;
using Ajuna.NetApi.Model.FrameSystem;
using Ajuna.NetApi.Model.Types.Primitive;
using Schnorrkel.Keys;
using Ajuna.NetApi.Model.Types;

namespace SubstrateNetWalletTest
{
    public class WalletTest
    {
        // Secret Key URI `//Alice` is account:
        // Secret seed:      0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
        // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Account ID:       0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // SS58 Address:     5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        public MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToBytes(), MiniSecretAlice.GetPair().Public.Key);

        // Secret Key URI `//Bob` is account:
        // Secret seed:      0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
        // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Account ID:       0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // SS58 Address:     5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        public MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);


        [SetUp]
        public void Setup()
        {
            SystemInteraction.ReadData = f => File.ReadAllText(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.DataExists = f => File.Exists(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.ReadPersistent = f => File.ReadAllText(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.PersistentExists = f => File.Exists(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.Persist = (f, c) => File.WriteAllText(Path.Combine(Environment.CurrentDirectory, f), c);
        }

        [Test]
        public void IsValidPasswordTest()
        {
            var wallet = new Wallet();

            Assert.False(wallet.IsValidPassword("12345678"));
            Assert.False(wallet.IsValidPassword("ABCDEFGH"));
            Assert.False(wallet.IsValidPassword("abcdefgh"));
            Assert.False(wallet.IsValidPassword("ABCDefgh"));
            Assert.False(wallet.IsValidPassword("1BCDefg"));

            Assert.True(wallet.IsValidPassword("ABCDefg1"));
        }

        [Test]
        public void IsValidWalletNameTest()
        {
            var wallet = new Wallet();

            Assert.False(wallet.IsValidWalletName("1234"));
            Assert.False(wallet.IsValidWalletName("ABC_/"));

            Assert.True(wallet.IsValidWalletName("wal_let"));
            Assert.True(wallet.IsValidWalletName("1111111"));
        }

        [Test]
        public async Task CreateWalletTestAsync()
        {
            // create new wallet with password and persist
            var wallet1 = new Wallet();

            await wallet1.CreateAsync("aA1234dd");

            Assert.True(wallet1.IsCreated);

            Assert.True(wallet1.IsUnlocked);

            // read wallet
            var wallet2 = new Wallet();

            wallet2.Load();

            Assert.True(wallet2.IsCreated);

            Assert.False(wallet2.IsUnlocked);

            // unlock wallet with password
            await wallet2.UnlockAsync("aA1234dd");

            Assert.True(wallet2.IsUnlocked);

            Assert.AreEqual(wallet1.Account.Value, wallet2.Account.Value);


            var wallet3 = new Wallet();

            Assert.False(wallet3.IsCreated);

            wallet3.Load();

            Assert.True(wallet3.IsCreated);

            Assert.False(wallet3.IsUnlocked);

            // unlock wallet with password
            await wallet3.UnlockAsync("aA4321dd");

            Assert.False(wallet3.IsUnlocked);

            var wallet4 = new Wallet();
            wallet4.Load("dev_wallet");

            Assert.True(wallet4.IsCreated);
        }

        [Test]
        public async Task CreateMnemonicWalletTestAsync()
        {
            var mnemonic = "donor rocket find fan language damp yellow crouch attend meat hybrid pulse";

            // create new wallet with password and persist
            var wallet1 = new Wallet();

            await wallet1.CreateAsync("aA1234dd", mnemonic, "mnemonic_wallet");

            Assert.True(wallet1.IsCreated);

            Assert.True(wallet1.IsUnlocked);

            // read wallet
            var wallet2 = new Wallet();

            wallet2.Load("mnemonic_wallet");

            Assert.True(wallet2.IsCreated);

            Assert.False(wallet2.IsUnlocked);

            // unlock wallet with password
            await wallet2.UnlockAsync("aA1234dd");

            Assert.True(wallet2.IsUnlocked);

            Assert.AreEqual(wallet1.Account.Value, wallet2.Account.Value);
        }

        [Test]
        public async Task ConnectionTestAsync()
        {
            // create new wallet with password and persist
            var wallet = new Wallet();
            await wallet.StartAsync();

            Assert.True(wallet.IsConnected);

            Assert.AreEqual("Ajuna Dev Testnet", wallet.ChainInfo.Chain);

            await wallet.StopAsync();

            Assert.False(wallet.IsConnected);
        }


        [Test]
        public async Task CheckAccountAsync()
        {
            var wallet = new Wallet();
            wallet.Load("dev_wallet");

            Assert.True(wallet.IsCreated);

            await wallet.UnlockAsync("aA1234dd");

            Assert.True(wallet.IsUnlocked);

            Assert.AreEqual("5FfzQe73TTQhmSQCgvYocrr6vh1jJXEKB8xUB6tExfpKVCEZ", wallet.Account.Value);
        }

        [Test]
        public async Task CheckStorageCallsAsync()
        {
            // create new wallet with password and persist
            var wallet = new Wallet();

            await wallet.StartAsync();

            Assert.True(wallet.IsConnected);

            wallet.Load("dev_wallet");

            await wallet.UnlockAsync("aA1234dd");
            Assert.True(wallet.IsUnlocked);

            Assert.AreEqual("5FfzQe73TTQhmSQCgvYocrr6vh1jJXEKB8xUB6tExfpKVCEZ", wallet.Account.Value);

            Thread.Sleep(1000);

            Assert.True(BigInteger.Parse("400000000000000") < wallet.AccountInfo.Data.Free.Value);
            Assert.True(BigInteger.Parse("600000000000000") > wallet.AccountInfo.Data.Free.Value);

            var blockNumber = new BlockNumber();
            blockNumber.Create(10);
            var blockHash = await wallet.Client.Chain.GetBlockHashAsync(blockNumber);

            var header = await wallet.Client.Chain.GetHeaderAsync(blockHash);
            Assert.AreEqual(10, header.Number.Value);

            await wallet.StopAsync();

            Assert.False(wallet.IsConnected);
        }

        [Test]
        public async Task CheckRaisedChainInfoUpdatedAsync()
        {
            var wallet = new Wallet();

            await wallet.StartAsync();

            Assert.True(wallet.IsConnected);

            Assert.IsTrue(wallet.Load("dev_wallet"));

            ChainInfo test = null;
            
            void OnChainInfoUpdated(object sender, ChainInfo chainInfo)
            {
                test = chainInfo;
            }

            wallet.ChainInfoUpdated += OnChainInfoUpdated;

            Thread.Sleep(5000);

            Assert.IsNotNull(test);

            Assert.AreEqual("Ajuna Node", test.Name);

            wallet.ChainInfoUpdated -= OnChainInfoUpdated;
        }

        [Test]
        public async Task CheckRaisedAccountInfoUpdatedAsync()
        {
            // create new wallet with password and persist
            var wallet = new Wallet();

            await wallet.StartAsync();

            Assert.True(wallet.IsConnected);

            wallet.Load("dev_wallet");

            Assert.True(wallet.IsCreated);

            await wallet.UnlockAsync("aA1234dd");

            Assert.True(wallet.IsUnlocked);

            Assert.AreEqual("5FfzQe73TTQhmSQCgvYocrr6vh1jJXEKB8xUB6tExfpKVCEZ", wallet.Account.Value);

            AccountInfo test = null;

            wallet.AccountInfoUpdated += delegate(object sender, AccountInfo accountInfo)
            {
                test = accountInfo;
            };

            Thread.Sleep(10000);

            Assert.IsNotNull(test);

            Assert.AreEqual(0, test.Nonce.Value);

            Assert.True(BigInteger.Parse("400000000000000") < test.Data.Free.Value);
            Assert.True(BigInteger.Parse("600000000000000") > test.Data.Free.Value);
        }

    }
}