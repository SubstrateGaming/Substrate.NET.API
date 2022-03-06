using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ajuna.NetApi.Model.Extrinsics
{
    public class ChargeAssetTxPayment : IEncodable
    {
        private CompactInteger _tip;
        private CompactInteger _assetId;

        public ChargeAssetTxPayment(CompactInteger tip, CompactInteger asset)
        {
            _tip = tip;
            _assetId = asset;
        }

        public byte[] Encode()
        {
            var bytes = new List<byte>();

            // Tip
            bytes.AddRange(_tip.Encode());

            // Asset Id
            bytes.AddRange(_assetId.Encode());

            return bytes.ToArray();
        }

        public static ChargeAssetTxPayment Decode(Memory<byte> m, ref int p)
        {
            var tip = CompactInteger.Decode(m.ToArray(), ref p);
            var assetId = CompactInteger.Decode(m.ToArray(), ref p);
            return new ChargeAssetTxPayment(tip, assetId);
        }
    }
}
