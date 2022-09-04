using System;
using System.Collections.Generic;
using NUnit.Framework;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using static Ajuna.NetApi.Test.Extrinsic.SignedExtensionsTest;
using Ajuna.NetApi.Model.Types.Primitive;

namespace Ajuna.NetApi.Test.Extrinsic
{
    public class PayloadTest
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
        public void EncodeExtraTest()
        {
            var genesisHash = new byte[]
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var blockHash = new byte[]
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            var era = new Era(2048, 99, false);

            var paramsList = new List<byte>();
            paramsList.Add(0xFF);
            paramsList.AddRange(
                Utils.HexToByteArray(
                    "d43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d")); // Utils.GetPublicKeyFrom("5FfBQ3kwXrbdyoqLPvcXRp7ikWydXawpNs2Ceu3WwFdhZ8W4");          
            CompactInteger amount = 100;
            paramsList.AddRange(amount.Encode());
            var parameters = paramsList.ToArray();

            var method = new Method(0x06, 0x00, parameters);
            var methodBytes = Utils.StringValueArrayBytesArray(
                "6, 0, 255, 212, 53, 147, 199, 21, 253, 211, 28, 97, 20, 26, 189, 4, 169, 159, 214, 130, 44, 133, 88, 133, 76, 205, 227, 154, 86, 132, 231, 165, 109, 162, 125, 145, 1");

            Assert.AreEqual(methodBytes, method.Encode());

            var genesis = new Hash();
            genesis.Create(genesisHash);

            var startEra = new Hash();
            startEra.Create(blockHash);

            var tip = new BaseCom<U128>();
            tip.Create(0);
            //var assetId = new U32();
            //assetId.Create(0);
            var assetIdOpt = new BaseOpt<U32>();
            //assetIdOpt.Create(assetId);
            var chargePayment = new ChargeAssetTxPayment();
            chargePayment.Tip = tip;
            chargePayment.AssetId = assetIdOpt;

            var signedExtensions = new SignedExtensions(259, 1, genesis, startEra, era, 0, chargePayment);

            var payload = new Payload(method.Encode(), signedExtensions.GetExtra(), signedExtensions.GetAdditionalSigned());

            var payloadBytes = Utils.StringValueArrayBytesArray(
                "6, 0, 255, 212, 53, 147, 199, 21, 253, 211, 28, 97, 20, 26, 189, 4, 169, 159, 214, 130, 44, 133, 88, 133, 76, 205, 227, 154, 86, 132, 231, 165, 109, 162, 125, 145, 1, 58, 6, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0");

            Assert.AreEqual(payloadBytes, payload.Encode());
        }
        public sealed class ChargeAssetTxPayment : ChargePaymentShell
        {

            /// <summary>
            /// >> tip
            /// </summary>
            private Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> _tip;

            /// <summary>
            /// >> asset_id
            /// </summary>
            private Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> _assetId;

            public Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> Tip
            {
                get
                {
                    return this._tip;
                }
                set
                {
                    this._tip = value;
                }
            }

            public Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> AssetId
            {
                get
                {
                    return this._assetId;
                }
                set
                {
                    this._assetId = value;
                }
            }

            public override string TypeName()
            {
                return "ChargeAssetTxPayment";
            }

            public override byte[] Encode()
            {
                var result = new List<byte>();
                result.AddRange(Tip.Encode());
                result.AddRange(AssetId.Encode());
                return result.ToArray();
            }

            public override void Decode(byte[] byteArray, ref int p)
            {
                var start = p;
                Tip = new Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128>();
                Tip.Decode(byteArray, ref p);
                AssetId = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32>();
                AssetId.Decode(byteArray, ref p);
                TypeSize = p - start;
            }
        }
    }
}