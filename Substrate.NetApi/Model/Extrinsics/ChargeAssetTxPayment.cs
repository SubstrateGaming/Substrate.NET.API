using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Charge Type
    /// </summary>
    public abstract class ChargeType : BaseType
    { }

    /// <summary>
    /// Charge Asset Tx Payment
    /// </summary>
    public class ChargeAssetTxPayment : ChargeType
    {
        private CompactInteger _tip;
        private BaseOpt<I32> _assetId;

        /// <summary>
        /// Charge Asset Tx Payment Constructor
        /// </summary>
        /// <param name="tip"></param>
        /// <param name="asset"></param>
        public ChargeAssetTxPayment(CompactInteger tip, BaseOpt<I32> asset)
        {
            _tip = tip;
            _assetId = asset;
        }

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var bytes = new List<byte>();

            // Tip
            bytes.AddRange(_tip.Encode());

            // Asset Id
            bytes.AddRange(_assetId.Encode());

            return bytes.ToArray();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            _tip = CompactInteger.Decode(byteArray, ref p);
            _assetId = new BaseOpt<I32>();
            _assetId.Decode(byteArray, ref p);
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <returns></returns>
        public static ChargeAssetTxPayment Default()
        {
            return new ChargeAssetTxPayment(0, new BaseOpt<I32>());
        }
    }

    /// <summary>
    /// Charge Transaction Payment
    /// </summary>
    public class ChargeTransactionPayment : ChargeType
    {
        private CompactInteger _tip;

        /// <summary>
        /// Charge Transaction Payment Constructor
        /// </summary>
        /// <param name="tip"></param>
        public ChargeTransactionPayment(CompactInteger tip)
        {
            _tip = tip;
        }

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var bytes = new List<byte>();

            // Tip
            bytes.AddRange(_tip.Encode());

            return bytes.ToArray();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            _tip = CompactInteger.Decode(byteArray, ref p);
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <returns></returns>
        public static ChargeTransactionPayment Default()
        {
            return new ChargeTransactionPayment(0);
        }
    }
}