using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;

namespace Ajuna.NetApi.Model.Extrinsics
{
    public abstract class ChargeType : BaseType {}

    public class ChargeAssetTxPayment : ChargeType
    {
        private CompactInteger _tip;
        private CompactInteger _assetId;

        public ChargeAssetTxPayment(CompactInteger tip, CompactInteger asset)
        {
            _tip = tip;
            _assetId = asset;
        }

        public override byte[] Encode()
        {
            var bytes = new List<byte>();

            // Tip
            bytes.AddRange(_tip.Encode());

            // Asset Id
            bytes.AddRange(_assetId.Encode());

            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            _tip = CompactInteger.Decode(byteArray, ref p);
            _assetId = CompactInteger.Decode(byteArray, ref p);
        }

        public static ChargeAssetTxPayment Default()
        {
            return new ChargeAssetTxPayment(0, 0);
        }
    }

    public class ChargeTransactionPayment : ChargeType
    {
        private CompactInteger _tip;

        public ChargeTransactionPayment(CompactInteger tip)
        {
            _tip = tip;
        }

        public override byte[] Encode()
        {
            var bytes = new List<byte>();

            // Tip
            bytes.AddRange(_tip.Encode());

            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            _tip = CompactInteger.Decode(byteArray, ref p);
        }

        public static ChargeTransactionPayment Default()
        {
            return new ChargeTransactionPayment(0);
        }
    }
}
