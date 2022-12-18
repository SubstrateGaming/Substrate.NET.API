using System;
using NUnit.Framework;

namespace Ajuna.NetApi.Test.Extrinsic
{
    public class UnCheckedExtrinsicTest
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

        //[Test]
        //public void BalanceTransferMockedTest1()
        //{
        //    var _runtime = new RuntimeVersion
        //    {
        //        SpecVersion = 1,
        //        TransactionVersion = 1
        //    };
        //    Constants.AddressVersion = 0;

        //    // Utils.HexToByteArray("0x9EFFC1668CA381C242885516EC9FA2B19C67B6684C02A8A3237B6862E5C8CD7E");
        //    var publicKey = Utils.GetPublicKeyFrom("5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM");
        //    CompactInteger nonce = 1;
        //    byte moduleIndex = 0x04;
        //    byte callIndex = 0x00;
        //    // Utils.HexToByteArray("0x9EFFC1668CA381C242885516EC9FA2B19C67B6684C02A8A3237B6862E5C8CD7E");
        //    var destPublicKey = Utils.GetPublicKeyFrom("5FfBQ3kwXrbdyoqLPvcXRp7ikWydXawpNs2Ceu3WwFdhZ8W4");
        //    CompactInteger amount = 987456321;
        //    var parameters = destPublicKey.Concat(amount.Encode()).ToArray();
        //    byte[] genesisHash = {0x00};
        //    byte[] currentBlockHash = {0x00};
        //    ulong currentBlockNumber = 47;
        //    CompactInteger tip = 1234;

        //    // mocked signature
        //    var signature =
        //        Utils.HexToByteArray(
        //            "0x14AE74DD7964365038EBA44F51C347B9C7070231D56E38EF1024457EBDC6DC03D20226243B1B2731DF6FD80F7170643221BD8BF8D06215D4BFEAC68A2C9D2305");

        //    var method = new Method(moduleIndex, callIndex, parameters);

        //    var era = new Era(Constants.ExtrinsicEraPeriodDefault, currentBlockNumber,
        //        currentBlockNumber == 0 ? true : false);

        //    var genesis = new Hash();
        //    genesis.Create(genesisHash);

        //    var currentBlock = new Hash();
        //    currentBlock.Create(currentBlockHash);

        //    var assetTxPayment = new ChargeAssetTxPayment(tip, 0);

        //    var uncheckedExtrinsic = new UnCheckedExtrinsic(true,
        //        Account.Build(KeyType.Ed25519, new byte[0], publicKey), method, era, nonce, assetTxPayment, genesis, currentBlock);

        //    var balanceTransfer =
        //        "0x350284278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e0014ae74dd7964365038eba44f51c347b9c7070231d56e38ef1024457ebdc6dc03d20226243b1b2731df6fd80f7170643221bd8bf8d06215d4bfeac68a2c9d2305f50204491304009effc1668ca381c242885516ec9fa2b19c67b6684c02a8a3237b6862e5c8cd7e068d6deb";

        //    uncheckedExtrinsic.AddPayloadSignature(signature);

        //    Assert.AreEqual(Utils.HexToByteArray(balanceTransfer), uncheckedExtrinsic.Encode());

        //    var _ = uncheckedExtrinsic.GetPayload(_runtime).Encode();
        //}

        //[Test]
        //public void BalanceTransferAliceTest()
        //{
        //    var _runtime = new RuntimeVersion
        //    {
        //        SpecVersion = 1,
        //        TransactionVersion = 2
        //    };
        //    Constants.AddressVersion = 2;

        //    /*
        //      {
        //        isSigned: true
        //        method: {
        //          args: {
        //            dest: {
        //              Id: 5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        //            }
        //            value: 100,000,000,000
        //          }
        //          method: transfer
        //          section: balances
        //        }
        //        era: {
        //          MortalEra: {
        //            period: 64
        //            phase: 54
        //          }
        //        }
        //        nonce: 0
        //        signature: 0x42727d9c8cffd2f77567d325a9748ec56fddf40959763dc0760bfb69ab753a0c5b2d80c15ac73a6582731314ad67e57625f36e195aff6d1f59315fb21e24e58a
        //        signer: {
        //          Id: 5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        //        }
        //        tip: 0
        //      }
        //     */

        //    //[
        //    //  {
        //    //    isSigned: true,
        //    //    method: {
        //    //      args: [
        //    //        5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM,
        //    //        4.321n Unit
        //    //      ],
        //    //      method: transfer,
        //    //      section: balances
        //    //    },
        //    //    era: {
        //    //      MortalEra: {
        //    //        period: 64,
        //    //        phase: 10
        //    //      }
        //    //    },
        //    //    nonce: 4,
        //    //    signature: 0x726ba1fab06d3e1bf6abfa0d5af85e25f2a970e11384162b7caf83935c58f769b6fef3b83a29ffd8d813a037d01cd6bcb21beaa88e9a18b3abe366b0458a8a82,
        //    //    signer: 5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY,
        //    //    tip: 1.234n Unit
        //    //  }
        //    //]
        //    // [{ "signature":{ "signer":"5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY","signature":{ "Sr25519":"0x726ba1fab06d3e1bf6abfa0d5af85e25f2a970e11384162b7caf83935c58f769b6fef3b83a29ffd8d813a037d01cd6bcb21beaa88e9a18b3abe366b0458a8a82"},"era":{ "MortalEra":"0xa500"},"nonce":4,"tip":1234},"method":{ "callIndex":"0x0400","args":{ "dest":"5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM","value":4321} } }]

        //    var privatKey =
        //        Utils.HexToByteArray(
        //            "0x33A6F3093F158A7109F679410BEF1A0C54168145E0CECB4DF006C1C2FFFB1F09925A225D97AA00682D6A59B95B18780C10D7032336E88F3442B42361F4A66011");

        //    var publicKey = Utils.GetPublicKeyFrom("5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY"); // Alice
        //    CompactInteger nonce = 0;
        //    byte moduleIndex = 0x06;
        //    byte callIndex = 0x00;

        //    var bytes = new List<byte>();
        //    bytes.AddRange(Utils.GetPublicKeyFrom("5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM"));
        //    CompactInteger amount = 4321;
        //    bytes.AddRange(amount.Encode());
        //    var parameters = bytes.ToArray();

        //    var genesisHash =
        //        Utils.HexToByteArray("0x1e247f07a0f015a562133284df819d46f081371ff1d24b91c62bbad679dafd5e");
        //    var startEra =
        //        Utils.HexToByteArray(
        //            "0xcfa2f9c52f94bc50658735d0f18f72590c981fdc15657636a99c437553c53253"); // CurrentBlock 780, startErar 778
        //    ulong currentBlockNumber = 1785;
        //    CompactInteger tip = 0;

        //    // mocked signature
        //    var signature =
        //        Utils.HexToByteArray(
        //            "0x42727d9c8cffd2f77567d325a9748ec56fddf40959763dc0760bfb69ab753a0c5b2d80c15ac73a6582731314ad67e57625f36e195aff6d1f59315fb21e24e58a");

        //    var method = new Method(moduleIndex, callIndex, parameters);

        //    var era = new Era(Constants.ExtrinsicEraPeriodDefault, currentBlockNumber,
        //        currentBlockNumber == 0 ? true : false);

        //    var genesis = new Hash();
        //    genesis.Create(genesisHash);

        //    var startEraHash = new Hash();
        //    startEraHash.Create(startEra);

        //    var assetTxPayment = new ChargeAssetTxPayment(tip, 0);

        //    var uncheckedExtrinsic = new UnCheckedExtrinsic(true,
        //        Account.Build(KeyType.Sr25519, new byte[0], publicKey), method, era, nonce, assetTxPayment, genesis, startEraHash);

        //    var balanceTransfer =
        //        "0x2d0284d43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d01726ba1fab06d3e1bf6abfa0d5af85e25f2a970e11384162b7caf83935c58f769b6fef3b83a29ffd8d813a037d01cd6bcb21beaa88e9a18b3abe366b0458a8a82a5001049130400278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e8543";

        //    uncheckedExtrinsic.AddPayloadSignature(signature);

        //    Assert.AreEqual(Utils.HexToByteArray(balanceTransfer), uncheckedExtrinsic.Encode());

        //    var payload = uncheckedExtrinsic.GetPayload(_runtime).Encode();

        //    var simpleSign = Sr25519v091.SignSimple(publicKey, privatKey, payload);

        //    Assert.True(Sr25519v091.Verify(simpleSign, publicKey, payload));

        //    Assert.True(Sr25519v091.Verify(signature, publicKey, payload));
        //}

        //[Test]
        //public void BalanceTransferAccountTest()
        //{
        //    var _runtime = new RuntimeVersion
        //    {
        //        SpecVersion = 259,
        //        TransactionVersion = 1
        //    };
        //    Constants.AddressVersion = 1;

        //    // 797447 --> 0xe7b99ee484e6369dd3c2a66d6306bffde5048ddf2090e990faae83e66f5275f4

        //    //var accountZurich = Account.Build(
        //    //    KeyType.Ed25519,
        //    //    Utils.HexToByteArray(
        //    //        "0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e"),
        //    //    Utils.GetPublicKeyFrom("5CxW5DWQDpXi4cpACd62wzbPjbYrx4y67TZEmRXBcvmDTNaM"));

        //    var privatKey =
        //        Utils.HexToByteArray(
        //            "0xf5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e");
        //    var publicKey = Utils.HexToByteArray("0x278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e");

        //    //var receiverPublicKey =
        //    //    Utils.Bytes2HexString(Utils.GetPublicKeyFrom("5DotMog6fcsVhMPqniyopz5sEJ5SMhHpz7ymgubr56gDxXwH"));

        //    var referenceExtrinsic =
        //        "0x490284ff278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e00cd5042c607aeaa099cce1d7f35b06c5c9e9a7bf34143b1f1e9d7e27b7f746ca3c2477bc2cb6657b7838cb862ea26398ca547053b509ad7a19d71aefef746050e36000c00000600ff4d2b23d27e1f6e3733d7ebf3dc04f3d5d0010cd18038055f9bbbab48f460b61e0b00b04e2bde6f";
        //    //                          "0x450284FF278117FC144C72340F67D0F2316E8386CEFFBF2B2428C9C51FEF7C597F1D426E00D6A14AAC2C0DA8330F67A04F9FF4154B3C31D02529EAF112A23D59F5A5E1D1766EFBB7F4DD56E6ED84A543DE94342BDEC8C80BDAC62373D22387EA980A42270F35000C000600FF4D2B23D27E1F6E3733D7EBF3DC04F3D5D0010CD18038055F9BBBAB48F460B61E0B00B04E2BDE6F"
        //    //                          "0x450284FF278117FC144C72340F67D0F2316E8386CEFFBF2B2428C9C51FEF7C597F1D426E00D6A14AAC2C0DA8330F67A04F9FF4154B3C31D02529EAF112A23D59F5A5E1D1766EFBB7F4DD56E6ED84A543DE94342BDEC8C80BDAC62373D22387EA980A42270F36000C000600FF4D2B23D27E1F6E3733D7EBF3DC04F3D5D0010CD18038055F9BBBAB48F460B61E0B00B04E2BDE6F"

        //    //var bytes = new List<byte>();
        //    //bytes.Add(0xFF);
        //    //bytes.AddRange(Utils.GetPublicKeyFrom("5DotMog6fcsVhMPqniyopz5sEJ5SMhHpz7ymgubr56gDxXwH"));
        //    //CompactInteger amount = 123000000000000;
        //    //bytes.AddRange(amount.Encode());
        //    //byte[] parameters = bytes.ToArray();
        //    ////var method = new Method(0x06, 0x00, parameters);
        //    var accountId = new AccountId();
        //    accountId.Create(Utils.GetPublicKeyFrom("5DotMog6fcsVhMPqniyopz5sEJ5SMhHpz7ymgubr56gDxXwH"));

        //    var balance = new Balance();
        //    balance.Create(123000000000000);

        //    var byteList = new List<byte>();
        //    foreach (var callArgument in new IType[] { accountId, balance })
        //    {
        //        byteList.AddRange(callArgument.Encode());
        //    }
        //    var callArguments = byteList.ToArray();

        //    var method = new Method(0x06, 0x00, callArguments);

        //    //var era = Era.Create(64, 797443);

        //    var era = new Era(128, 3, false);

        //    CompactInteger nonce = 3;

        //    CompactInteger tip = 0;

        //    var genesis = new Hash();
        //    genesis.Create(Utils.HexToByteArray("0x778c4bb53621114939206c9c9874c5fa1da38d2e14293d053a0b8dd6125b4042"));

        //    var startEra = new Hash();
        //    startEra.Create(Utils.HexToByteArray("0xd5a0f4467c6c8885b531f12028789e83c2e473b8d2d44edbc09811fd2f903f1f"));

        //    var assetTxPayment = new ChargeAssetTxPayment(tip, 0);

        //    var uncheckedExtrinsic = new UnCheckedExtrinsic(true
        //        , Account.Build(KeyType.Ed25519, privatKey, publicKey)
        //        , method
        //        , era
        //        , nonce
        //        , assetTxPayment
        //        , genesis
        //        , startEra // currentblock
        //    );

        //    //uncheckedExtrinsic.AddPayloadSignature(Utils.HexToByteArray("0xd6a14aac2c0da8330f67a04f9ff4154b3c31d02529eaf112a23d59f5a5e1d1766efbb7f4dd56e6ed84a543de94342bdec8c80bdac62373d22387ea980a42270f"));

        //    var payload = uncheckedExtrinsic.GetPayload(_runtime).Encode();

        //    /// Payloads longer than 256 bytes are going to be `blake2_256`-hashed.
        //    if (payload.Length > 256) payload = HashExtension.Blake2(payload, 256);

        //    byte[] signature;
        //    signature = Chaos.NaCl.Ed25519.Sign(payload, privatKey);
        //    //var signatureStr = Utils.Bytes2HexString(signature);

        //    uncheckedExtrinsic.AddPayloadSignature(signature);

        //    var uncheckedExtrinsicStr = Utils.Bytes2HexString(uncheckedExtrinsic.Encode());

        //    Assert.AreEqual(referenceExtrinsic, uncheckedExtrinsicStr.ToLower());
        //}
    }
}