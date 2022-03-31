using Ajuna.NetApi;
using Ajuna.NetApi.Model.AjunaWorker;
using Ajuna.NetApi.Model.PalletConnectfour;
using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Chaos.NaCl;
using Nerdbank.Streams;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;
using Org.BouncyCastle.Security;
using Schnorrkel.Keys;
using SimpleBase;
using StreamJsonRpc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTee.Model;

namespace TestTee
{
    class Program
    {
        //private const string Websocketurl = "ws://127.0.0.1:9944";
        //private const string Websocketurl = "wss://127.0.0.1:2001";
        //private const string Websocketurl = "ws://127.0.0.1:2000";
        // private const string Websocketurl = "wss://demo.piesocket.com/v3/channel_1?api_key=oCdCMcMPQpbvNjUIzqtvF1d2X2okWpDQj4AwARJuAgtjhzKxVEjQU6IdCjwm&notify_self";

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

        private static async Task Main(string[] args)
        {
            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new FileTarget("logfile")
            {
                FileName = "log.txt",
                DeleteOldFileOnStartup = true
            };

            var logconsole = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

            // Add this to your C# console app's Main method to give yourself
            // a CancellationToken that is canceled when the user hits Ctrl+C.
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Canceling...");
                cts.Cancel();
                e.Cancel = true;
            };

            try
            {
                Console.WriteLine("Press Ctrl+C to end.");
                await MainAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                // This is the normal way we close.
            }
        }

        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return true;
        }

        private static async Task MainAsync(CancellationToken cancellationToken)
        {
            //await LaunchGameAsync("ws://127.0.0.1:9944");

            await RunGameAsync("ws://127.0.0.1:2000");


        }

        private static async Task RunGameAsync(string websocketurl)
        {
            /**
             * docker ps
             * docker exec -it 7aeac2a21f93 /bin/bash
             * ./integritee-cli trusted transfer //Alice //Bob 1000 --mrenclave 2CMLqGnL56xp4qkVDq4pmKKYJn4btSGF9brgGEsGW3qm --direct
             */


            var shardHex = "2CMLqGnL56xp4qkVDq4pmKKYJn4btSGF9brgGEsGW3qm";
            var mrenclaveHex = "2CMLqGnL56xp4qkVDq4pmKKYJn4btSGF9brgGEsGW3qm";

            var client = new SubstrateClient(new Uri(websocketurl));

            var shieldingKeyReturn = await ShieldingKeyAsync(client);

            // - TrustedOperation

            EnumTrustedOperation tOpBoard = CreateGetter(Alice, TrustedGetter.Board);
            var boardValue = await ExecuteTrustedOperationAsync(client, tOpBoard, shieldingKeyReturn, shardHex);
            if (Unwrap(Wrapped.Board, boardValue, out BaseOpt<BoardStruct> optBoard))
            {
                if (optBoard != null && optBoard.OptionFlag)
                {
                    Console.WriteLine($"Opt. Board is {optBoard?.OptionFlag}");
                }
                
            }

            /**
                EnumTrustedOperation tOpPreBalance = CreateGetter(Alice, TrustedGetter.FreeBalance);
                var balanceValuePre = await ExecuteTrustedOperationAsync(client, tOpPreBalance, shieldingKeyReturn, shardHex);
                if (Unwrap(Wrapped.Balance, balanceValuePre, out Balance preBalance))
                {
                    Console.WriteLine($"Pre-balance is {preBalance.Value}");
                }

                EnumTrustedOperation tOpNonce = CreateGetter(Alice, TrustedGetter.Nonce);
                var nonceValue = await ExecuteTrustedOperationAsync(client, tOpNonce, shieldingKeyReturn, shardHex);
                if (Unwrap(Wrapped.Nonce, nonceValue, out U32 nonce))
                {
                    uint amount = 3333;
                    Console.WriteLine($"Current nonce is {nonce.Value}");
                    Console.WriteLine($"Doing a balance transfer of {amount}");
                    EnumTrustedOperation tOpTransfer = CreateCallBalanceTransfer(Alice, Bob, amount, nonce.Value, mrenclaveHex, shardHex);
                    var returnValue = await ExecuteTrustedOperationAsync(client, tOpTransfer, shieldingKeyReturn, shardHex);
                    if (Unwrap(Wrapped.Hash, returnValue, out H256 value)) {
                        Console.WriteLine($"Hash is {Utils.Bytes2HexString(value.Value.Bytes)}");
                    }
                }
                Console.WriteLine($"Waiting ... 1 sec");
                Thread.Sleep(1000);
                EnumTrustedOperation tOpPostBalance = CreateGetter(Alice, TrustedGetter.FreeBalance);
                var balanceValuePost = await ExecuteTrustedOperationAsync(client, tOpPostBalance, shieldingKeyReturn, shardHex);
                if (Unwrap(Wrapped.Balance, balanceValuePost, out Balance postBalance))
                {
                    Console.WriteLine($"Post-balance is {postBalance.Value}");
                }
            */

            //Thread.Sleep(10000);

            await client.CloseAsync();
        }

        /// <summary>
        /// Simple extrinsic tester
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        private static void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
        {
            switch (extrinsicUpdate.ExtrinsicState)
            {
                case ExtrinsicState.None:
                   if (extrinsicUpdate.InBlock.Value?.Length > 0 || extrinsicUpdate.Finalized.Value?.Length > 0) {

                   };
                   break;
                case ExtrinsicState.Future:
                    break;
                case ExtrinsicState.Ready:
                    break;
                case ExtrinsicState.Dropped:
                    break;
                case ExtrinsicState.Invalid:
                    break;
                default:
                    break;
            }
        }

        private static async Task LaunchGameAsync(string websocketurl)
        {
            var extrinsicWait = 10000;

            var client = new SubstrateClientExt(new Uri(websocketurl));

            var cts = new CancellationTokenSource();
            await client.ConnectAsync(false, true, true, cts.Token);

            var gameEngine = new Ajuna.NetApi.Model.PalletGameregistry.GameEngine();
            var id = new U8();
            id.Create(1);
            gameEngine.Id = id;
            var version = new U8();
            version.Create(1);
            gameEngine.Version = version;

            var gameQueuePre = await client.GameRegistryStorage.GameQueues(gameEngine, CancellationToken.None);


            var extrinsicMethod = Ajuna.NetApi.Model.PalletGameRegistry.GameRegistryCalls.Queue();

            // Alice queues for a game ...
            var subscription1 = await client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Alice, 0, 64, cts.Token);

            Thread.Sleep(extrinsicWait);

            // Bob queues for a game ...
            var subscription2 = await client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Bob, 0, 64, cts.Token);

            Thread.Sleep(extrinsicWait);

            var gameQueuePos = await client.GameRegistryStorage.GameQueues(gameEngine, CancellationToken.None);

        }

        private static bool Unwrap<T>(Wrapped wrapped, RpcReturnValue returnValue, out T result) where T : IType, new()
        {
            result = new T();

            switch (returnValue.DirectRequestStatus.Value)
            {
                case DirectRequestStatus.Ok:
                    break;

                case DirectRequestStatus.TrustedOperationStatus:

                    var valueBytes = returnValue.Value.Value.Select(p => p.Value).ToArray();

                    switch (wrapped)
                    {
                        case Wrapped.Nonce:
                            var nonceWrapped = new BaseOpt<BaseVec<U8>>();
                            nonceWrapped.Create(valueBytes);
                            if (nonceWrapped.OptionFlag)
                            {
                                var u32Wrapped = new BaseOpt<BaseVec<U8>>();
                                var u32Bytes = nonceWrapped.Value.Value.Select(p => p.Value).ToArray();
                                result.Create(u32Bytes);
                                return true;
                            }
                            break;

                        case Wrapped.Balance:
                            var balanceWrapped = new BaseOpt<BaseVec<U8>>();
                            balanceWrapped.Create(valueBytes);
                            if (balanceWrapped.OptionFlag)
                            {
                                var u128Wrapped = new BaseOpt<BaseVec<U8>>();
                                var u128Bytes = balanceWrapped.Value.Value.Select(p => p.Value).ToArray();
                                result.Create(u128Bytes);
                                return true;
                            }
                            break;

                        case Wrapped.Hash:
                            result.Create(valueBytes);
                            return true;

                        case Wrapped.Board:
                            result.Create(valueBytes);
                            return true;
                    }


                    break;

                case DirectRequestStatus.Error:
                    var byteArray = returnValue.Value.Bytes;
                    PrintBytes(UnwrapBytes(byteArray));
                    break;
            }

            return false;
        }

        private static async Task<RpcReturnValue> ExecuteTrustedOperationAsync(SubstrateClient client, EnumTrustedOperation trustedOperation, RpcReturnValue shieldingKeyReturn, string shardHex)
        {
            var cypherText = SignTrustedOperation(shieldingKeyReturn, trustedOperation);

            // - ShardIdentifier
            var shardId = new H256();
            shardId.Create(Base58.Bitcoin.Decode(shardHex).ToArray());

            Request request = new Request
            {
                Shard = shardId,
                CypherText = VecU8FromBytes(cypherText)
            };

            // open connection
            await client.ConnectAsync(false, false, false, CancellationToken.None);

            var result = await client.InvokeAsync<byte[]>("author_submitAndWatchExtrinsic", request.Encode().Cast<object>().ToArray(), CancellationToken.None);

            var returnValue = new RpcReturnValue();
            returnValue.Create(result);

            return returnValue;

        }

        private static EnumTrustedOperation CreateGetter(Account name, TrustedGetter trustedGetter)
        {
            var account = new AccountId32();
            account.Create(name.Bytes);

            var enumTrustedGetter = new EnumTrustedGetter();
            enumTrustedGetter.Create(trustedGetter, account);

            return GetEnumTrustedOperation(account, enumTrustedGetter);
        }

        private static EnumTrustedOperation CreateCallBalanceTransfer(Account alice, Account bob, uint amount, uint nonce, string mrenclaveHex, string shardHex)
        {
            var aliceAccount = new AccountId32();
            aliceAccount.Create(alice.Bytes);
            
            var bobAccount = new AccountId32();
            bobAccount.Create(bob.Bytes);
            
            var balance = new Balance();
            balance.Create(new BigInteger(amount));
            
            var balanceTransferTuple = new BaseTuple<AccountId32, AccountId32, Balance>();
            balanceTransferTuple.Create(aliceAccount, bobAccount, balance);
            
            var trustedCall = new EnumTrustedCall();
            trustedCall.Create(TrustedCall.BalanceTransfer, balanceTransferTuple);

            var index = new Ajuna.NetApi.Model.AjunaWorker.Index();
            index.Create(nonce);

            var mrenclave = new H256();
            mrenclave.Create(Base58.Bitcoin.Decode(mrenclaveHex).ToArray());

            var shard = new ShardIdentifier();
            shard.Create(Base58.Bitcoin.Decode(shardHex).ToArray());

            var trustedCallPayload = new TrustedCallPayload
            {
                Call = trustedCall,
                Nonce = index,
                Mrenclave = mrenclave,
                Shard = shard
            };

            return GetEnumTrustedOperation(aliceAccount, trustedCallPayload);
        }

        private static byte[] SignTrustedOperation(RpcReturnValue shieldingKeyReturn, EnumTrustedOperation trustedOperation)
        {
            // - Create RSAPubKey from ShieldingKey

            var rsaPubKeyStr = new UTF8Encoding().GetString(UnwrapBytes(shieldingKeyReturn.Value.Bytes));
            RSAPubKey rsaPubKey = JsonConvert.DeserializeObject<RSAPubKey>(rsaPubKeyStr);

            // - Encrypt Encoded TrustedOperation with RSAPubKey

            var rsaParameters = new RSAParameters { Modulus = rsaPubKey.N.ToArray(), Exponent = rsaPubKey.E.ToArray() };
            Array.Reverse(rsaParameters.Modulus, 0, rsaParameters.Modulus.Length);
            Array.Reverse(rsaParameters.Exponent, 0, rsaParameters.Exponent.Length);

            var keyPair = DotNetUtilities.GetRsaPublicKey(rsaParameters);
            return Utils.RSAEncryptBouncy(trustedOperation.Encode(), keyPair);
        }

        private static byte[] UnwrapBytes(byte[] byteArray)
        {
            var baseVec1 = new BaseVec<U8>();
            baseVec1.Create(byteArray);

            var bytes1 = new List<byte>();
            foreach (var by in baseVec1.Value)
            {
                bytes1.Add(by.Value);
            }
            var baseVec2 = new BaseVec<U8>();
            baseVec2.Create(bytes1.ToArray());

            var bytes2 = new List<byte>();
            foreach (var by in baseVec2.Value)
            {
                bytes2.Add(by.Value);
            }
            return bytes2.ToArray();
        }

        private static void PrintBytes(byte[] bytes)
        {
            var converter = new UTF8Encoding();
            var str = converter.GetString(bytes);
            Console.WriteLine(str);
        }

        private static BaseVec<U8> VecU8FromBytes(byte[] vs)
        {
            var u8list = new List<U8>();
            for (int i = 0; i < vs.Length; i++)
            {
                var u8 = new U8();
                u8.Create(vs[i]);
                u8list.Add(u8);
            }
            var u8Array = u8list.ToArray();

            var result = new BaseVec<U8>();
            result.Create(u8Array);

            return result;
        }

        private static EnumTrustedOperation GetEnumTrustedOperation(AccountId32 account, EnumTrustedGetter trustedGetter)
        {
            var signature = new Signature64();
            var signatureArray = Schnorrkel.Sr25519v091.SignSimple(MiniSecretAlice.GetPair(), trustedGetter.Encode());
            signature.Create(signatureArray);

            var enumMultiSignature = new EnumMultiSignature();
            enumMultiSignature.Create(MultiSignature.Sr25519, signature);

            var trustedGetterSigned = new TrustedGetterSigned();
            trustedGetterSigned.Getter = trustedGetter;
            trustedGetterSigned.Signature = enumMultiSignature;

            var getter = new EnumGetter();
            getter.Create(Getter.Trusted, trustedGetterSigned);

            var trustedOperation = new EnumTrustedOperation();
            trustedOperation.Create(TrustedOperation.Get, getter);

            return trustedOperation;
        }

        private static EnumTrustedOperation GetEnumTrustedOperation(AccountId32 aliceAccount, TrustedCallPayload trustedCallPayload)
        {
            var signature = new Signature64();
            var signatureArray = Schnorrkel.Sr25519v091.SignSimple(MiniSecretAlice.GetPair(), trustedCallPayload.Encode());
            signature.Create(signatureArray);

            var enumMultiSignature = new EnumMultiSignature();
            enumMultiSignature.Create(MultiSignature.Sr25519, signature);

            var trustedCallSigned = new TrustedCallSigned();
            trustedCallSigned.Call = trustedCallPayload.Call;
            trustedCallSigned.Nonce = trustedCallPayload.Nonce;
            trustedCallSigned.Signature = enumMultiSignature;

            var trustedOperation = new EnumTrustedOperation();
            trustedOperation.Create(TrustedOperation.DirectCall, trustedCallSigned);

            return trustedOperation;
        }

        private async static Task<RpcReturnValue> ShieldingKeyAsync(SubstrateClient client)
        {
            //using var client = new SubstrateClient(new Uri(Websocketurl));

            //var rpcMethods = await client.InvokeAsync<string>("rpc_methods", null, CancellationToken.None);
            //Console.WriteLine($"-----------> {rpcMethods}");

            //rpc_methods
            //author_getMuRaUrl
            //author_getShieldingKey byte[]
            //author_getUntrustedUrl
            //author_pendingExtrinsics
            //author_submitAndWatchExtrinsic
            //author_submitExtrinsic
            //chain_subscribeAllHeads
            //state_get
            //state_getMetadata
            //state_getRuntimeVersion
            //system_health
            //system_name
            //system_version

            await client.ConnectAsync(false, false, false, CancellationToken.None);

            var method = "author_getShieldingKey";
            var result = await client.InvokeAsync<byte[]>(method, null, CancellationToken.None);

            var rpcReturnValue = new RpcReturnValue();
            rpcReturnValue.Create(result);

            await client.CloseAsync();

            return rpcReturnValue;
        }

    }

}
