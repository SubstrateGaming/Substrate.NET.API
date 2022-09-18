using System;
using NUnit.Framework;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Ajuna.NetApi.Model.Types.Primitive;

namespace Ajuna.NetApi.Test.Extrinsic
{
    public class SignedExtensionsTest
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

            var bytes = Utils.StringValueArrayBytesArray(
                "58, 6, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0");

            Assert.AreEqual(bytes.AsMemory().Slice(0, 5).ToArray(), signedExtensions.GetExtra());
            Assert.AreEqual(bytes.AsMemory().Slice(5, 72).ToArray(), signedExtensions.GetAdditionalSigned());
        }

        /// <summary>
        /// >> 677 - Composite[pallet_asset_tx_payment.ChargeAssetTxPayment]
        /// </summary>
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