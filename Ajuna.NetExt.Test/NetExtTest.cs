using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;
using Schnorrkel.Keys;
using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Ajuna.NetExt.Test
{
    public class NetExtTest
    {
        private const string WebSocketUrl = "ws://127.0.0.1:9944";

        private SubstrateClientExt _client;

        // Secret Key URI `//Alice` is account:
        // Secret seed:      0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
        // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Account ID:       0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // SS58 Address:     5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        public static MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public static Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToBytes(), MiniSecretAlice.GetPair().Public.Key);

        // Secret Key URI `//Bob` is account:
        // Secret seed:      0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
        // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Account ID:       0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // SS58 Address:     5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        public static MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public static Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);

        [SetUp]
        public void Setup()
        {
            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var console = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, console);

            // Apply config           
            LogManager.Configuration = config;

            _client = new SubstrateClientExt(new Uri(WebSocketUrl));
        }

        /// <summary>
        /// Simple extrinsic tester
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        static void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
        {
            switch (extrinsicUpdate.ExtrinsicState)
            {
                case ExtrinsicState.None:
                    Assert.IsTrue(true);
                    Assert.IsTrue(extrinsicUpdate.InBlock.Value.Length > 0 || extrinsicUpdate.Finalized.Value.Length > 0);
                    break;
                case ExtrinsicState.Future:
                    Assert.IsTrue(false);
                    break;
                case ExtrinsicState.Ready:
                    Assert.IsTrue(true);
                    break;
                case ExtrinsicState.Dropped:
                    Assert.IsTrue(false);
                    break;
                case ExtrinsicState.Invalid:
                    Assert.IsTrue(false);
                    break;
            }
        }

        [Test]
        public async Task GetMethodChainNameTestAsync()
        {
            await _client.ConnectAsync(false, CancellationToken.None);

            var result = await _client.GetMethodAsync<string>("system_chain");
            Assert.AreEqual("Ajuna Dev Testnet", result);

            await _client.CloseAsync();
        }

        [Test]
        public async Task BalanceTransferTestAsync()
        {
            var extrinsicWait = 10000;

            var cts = new CancellationTokenSource();

            await _client.ConnectAsync(false, cts.Token);

            var accountAlice = new AccountId32();
            accountAlice.Create(Utils.GetPublicKeyFrom(Alice.Value));

            var accountBob = new AccountId32();
            accountBob.Create(Utils.GetPublicKeyFrom(Bob.Value));

            var accountInfoAlice = await _client.SystemStorage.Account(accountAlice, CancellationToken.None);
            Assert.IsNotNull(accountInfoAlice);
            Assert.AreEqual(1, accountInfoAlice.Consumers.Value);
            var aliceFree = accountInfoAlice.Data.Free.Value;
            Assert.IsTrue(new BigInteger(10000000) < aliceFree);

            //Console.WriteLine($"Alice Free Balance = {accountInfoAlice.Data.Free.Value.ToString()}");

            //var accountInfoBob = await _client.SystemStorage.Account(accountBob, CancellationToken.None);
            //Console.WriteLine($"Bob Free Balance = {accountInfoBob.Data.Free.Value.ToString()}");

            var multiAddressBob = new EnumMultiAddress();
            multiAddressBob.Create(MultiAddress.Id, accountBob);

            var tx = new ChargeAssetTxPayment(0, 0);

            var amount = new BaseCom<U128>();
            amount.Create(100000);

            var extrinsicMethod = Ajuna.NetApi.Model.PalletBalances.BalancesCalls.Transfer(multiAddressBob, amount);

            // transaction from alice to bob for a certain amount of tokens
            var subscription = await _client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Alice, tx, 64, cts.Token);
            Assert.IsNotNull(subscription);
            
            Thread.Sleep(extrinsicWait);

            //accountInfoAlice = await _client.SystemStorage.Account(accountAlice, CancellationToken.None);
            //Console.WriteLine($"Alice Free Balance = {accountInfoAlice.Data.Free.Value.ToString()}");

            //accountInfoBob = await _client.SystemStorage.Account(accountBob, CancellationToken.None);
            //Console.WriteLine($"Bob Free Balance = {accountInfoBob.Data.Free.Value.ToString()}");
        }
    }
}