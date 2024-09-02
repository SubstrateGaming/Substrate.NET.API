using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Charge Type
    /// </summary>
    public abstract class ChargeType : BaseType
    {
    }

    /// <summary>
    /// Asset Identifier for AssetHubs and the Ajuna Chain.
    /// </summary>
    public enum NativeOrWithId
    {
        /// <summary>
        /// Native token. However, in the `ChargeAssetTxPayment` this is unused, as the none implies the Native asset.
        /// </summary>
        Native = 0,
        /// <summary>
        /// Some asset with a corresponding asset should be used for payment.
        /// </summary>
        WithId = 1,
    }

    /// <summary>
    /// Asset Identifier for AssetHubs and the Ajuna Chain.
    /// </summary>
    public sealed class EnumNativeOrWithId : BaseEnumExt<NativeOrWithId, BaseVoid, U32>
    {
    }


    /// <summary>
    /// Charge Asset Tx Payment
    /// </summary>
    public class ChargeAssetTxPayment : ChargeType
    {
        private CompactInteger _tip;
        private BaseOpt<EnumNativeOrWithId> _assetId;

        /// <summary>
        /// Charge Asset Tx Payment Constructor
        /// </summary>
        /// <param name="tip"></param>
        /// <param name="assetId"></param>
        public ChargeAssetTxPayment(CompactInteger tip, BaseOpt<EnumNativeOrWithId> assetId)
        {
            _tip = tip;
            _assetId = assetId;
        }

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var bytes = new List<byte>();

            // Tip
            bytes.AddRange(_tip.Encode());

            // AssetId
            bytes.AddRange(_assetId.Encode());

            return bytes.ToArray();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            _tip = CompactInteger.Decode(byteArray, ref p);
            _assetId = new BaseOpt<EnumNativeOrWithId>();
            _assetId.Decode(byteArray, ref p);
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <returns></returns>
        public static ChargeAssetTxPayment Default()
        {
            return new ChargeAssetTxPayment(0, new BaseOpt<EnumNativeOrWithId>());
        }

        /// <summary>
        /// Defines extrinsic payment with the asset id 
        /// </summary>
        /// <param name="tip"></param>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public static ChargeAssetTxPayment NewWithAsset(CompactInteger tip, U32 assetId)
        {
            var asset = new EnumNativeOrWithId();
            asset.Create(NativeOrWithId.WithId, assetId);

            return new ChargeAssetTxPayment(tip, new BaseOpt<EnumNativeOrWithId>(asset));
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