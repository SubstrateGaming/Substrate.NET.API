using Ajuna.NetApi;
using Ajuna.NetApi.Model.AjunaWorker;
using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Chaos.NaCl;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using Schnorrkel.Keys;
using SimpleBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.WebSockets;
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
        private const string Websocketurl = "ws://127.0.0.1:2000";
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
            // - TrustedOperation

            var account = new AccountId32();
            account.Create("0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d");

            var trustedGetter = new EnumTrustedGetter();
            trustedGetter.Create(TrustedGetter.Nonce, account);

            EnumTrustedOperation trustedOperation = GetEnumTrustedOperation(account, trustedGetter);

            // - ShardIdentifier

            var shardId = new H256();
            shardId.Create(Base58.Bitcoin.Decode("CAG7CwtvDb5AvC3yoxXetYqY97tGSUdywP1U6pgYf1Kh").ToArray());


            // - Get ShieldingKey

            var shieldingKeyReturn = await ShieldingKeyAsync();

            // - Create RSAPubKey from ShieldingKey

            TestRSA rsaPubKey = GetTestRSA(shieldingKeyReturn.Value.Bytes);

            // - Encrypt Encoded TrustedOperation with RSAPubKey
            var cypherText = EncryptRSA3072(trustedOperation.Encode(), new RSAParameters
            {
                Modulus = rsaPubKey.N.ToArray(),
                Exponent = rsaPubKey.E.ToArray()
            });

            // - Create Request
            Request request = new Request
            {
                Shard = shardId,
                CypherText = VecU8FromBytes(cypherText)
            };

            var final = request;
            Console.WriteLine($"REQUEST = {Utils.Bytes2HexString(final.Encode())}");

            BaseVec<U8> finalVecU8 = VecU8FromBytes(final.Encode());

            // - Send Request
            using var client = new SubstrateClient(new Uri(Websocketurl));
            await client.ConnectAsync(false, false, false, cancellationToken);
            var result = await client.InvokeAsync<byte[]>("author_submitExtrinsic", new object[] { Utils.Bytes2HexString(finalVecU8.Encode()) }, CancellationToken.None);

            RpcReturnValue returnValue = new RpcReturnValue();
            returnValue.Create(result);

            if (returnValue.DirectRequestStatus.Value == DirectRequestStatus.Error)
            {
                PrintBytes(returnValue.Value.Bytes);
            } 
            else
            {
                Console.WriteLine($"RETURN = {returnValue}");
            }
            
            await client.CloseAsync();

            //try
            //{
            //    //Create a UnicodeEncoder to convert between byte array and string.
            //    UnicodeEncoding ByteConverter = new UnicodeEncoding();

            //    //Create byte arrays to hold original, encrypted, and decrypted data.
            //    byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
            //    byte[] encryptedData;
            //    byte[] decryptedData;

            //    //Create a new instance of RSACryptoServiceProvider to generate
            //    //public and private key data.
            //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //    {

            //        //Pass the data to ENCRYPT, the public key information 
            //        //(using RSACryptoServiceProvider.ExportParameters(false),
            //        //and a boolean flag specifying no OAEP padding.
            //        encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

            //        //Pass the data to DECRYPT, the private key information 
            //        //(using RSACryptoServiceProvider.ExportParameters(true),
            //        //and a boolean flag specifying no OAEP padding.
            //        decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

            //        //Display the decrypted plaintext to the console. 
            //        Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
            //    }
            //}
            //catch (ArgumentNullException)
            //{
            //    //Catch this exception in case the encryption did
            //    //not succeed.
            //    Console.WriteLine("Encryption failed.");
            //}

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

        private static TestRSA GetTestRSA(byte[] shieldingKeyReturn)
        {
            var baseVec1 = new BaseVec<U8>();
            baseVec1.Create(shieldingKeyReturn);

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
            bytes2.ToArray();

            var rsaPubKeyStr = new UTF8Encoding().GetString(bytes2.ToArray());
            return JsonConvert.DeserializeObject<TestRSA>(rsaPubKeyStr);
        }

        private static EnumTrustedOperation GetEnumTrustedOperation(AccountId32 account, EnumTrustedGetter trustedGetter)
        {
            var signature = new Signature();
            var signatureArray = Schnorrkel.Sr25519v091.SignSimple(MiniSecretAlice.GetPair(), trustedGetter.Encode());
            signature.Create(signatureArray);

            var enumMultiSignature = new EnumMultiSignature();
            enumMultiSignature.Create(MultiSignature.Sr25519, signature);

            var trustedGetterSigned = new TrustedGetterSigned();
            trustedGetterSigned.Getter = trustedGetter;
            trustedGetterSigned.Signature = enumMultiSignature;

            var getter = new EnumGetter();
            getter.Create(Getter.trusted, trustedGetterSigned);

            var trustedOperation = new EnumTrustedOperation();
            trustedOperation.Create(TrustedOperation.Get, getter);

            return trustedOperation;
        }

        private static byte[] EncryptRSA3072(byte[] encodedTrustedOperation, RSAParameters parameters)
        {
            using RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            //Pass the data to ENCRYPT, the public key information 
            //(using RSACryptoServiceProvider.ExportParameters(false),
            //and a boolean flag specifying no OAEP padding.
            return RSAEncrypt(encodedTrustedOperation, parameters, false);
        }

        private async static Task<RpcReturnValue> ShieldingKeyAsync()
        {
            using var client = new SubstrateClient(new Uri(Websocketurl));

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

        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }

}
