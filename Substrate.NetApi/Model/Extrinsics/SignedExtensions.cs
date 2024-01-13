using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Signed Extensions
    /// </summary>
    public class SignedExtensions
    {
        private readonly uint _specVersion;

        private readonly uint _txVersion;

        private readonly Hash _genesis;

        private readonly Hash _startEra;

        private readonly Era _mortality;

        private readonly CompactInteger _nonce;

        private readonly ChargeType _charge;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignedExtensions"/> class.
        /// </summary>
        /// <param name="specVersion">The spec version.</param>
        /// <param name="txVersion">The tx version.</param>
        /// <param name="genesis">The genesis.</param>
        /// <param name="startEra">The start era.</param>
        /// <param name="mortality">The mortality.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="chargeTransactionPayment">The charge transaction payment.</param>
        public SignedExtensions(uint specVersion, uint txVersion, Hash genesis, Hash startEra, Era mortality, CompactInteger nonce, ChargeType charge)
        {
            _specVersion = specVersion;
            _txVersion = txVersion;
            _genesis = genesis;
            _startEra = startEra;
            _mortality = mortality;
            _nonce = nonce;
            _charge = charge;
        }

        /// <summary>
        /// Gets the extra.
        /// </summary>
        /// <returns></returns>
        public byte[] GetExtra()
        {
            var bytes = new List<byte>();

            // CheckMortality
            bytes.AddRange(_mortality.Encode());

            // CheckNonce
            bytes.AddRange(_nonce.Encode());

            // ChargeType
            bytes.AddRange(_charge.Encode());

            return bytes.ToArray();
        }

        /// <summary>
        /// Gets the additional signed.
        /// </summary>
        /// <returns></returns>
        public byte[] GetAdditionalSigned()
        {
            var bytes = new List<byte>();

            // CheckSpecVersion
            bytes.AddRange(Utils.Value2Bytes(_specVersion));

            // CheckTxVersion
            bytes.AddRange(Utils.Value2Bytes(_txVersion));

            // CheckGenesis
            bytes.AddRange(_genesis.Bytes);

            // CheckMortality, Additional Blockhash check. Immortal = genesis_hash, Mortal = logic
            bytes.AddRange(_startEra.Bytes);

            return bytes.ToArray();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            var bytes = new List<byte>();

            // Extra: Era, Nonce & Tip
            bytes.AddRange(GetExtra());

            // Additional Signed: SpecVersion, TxVersion, Genesis, Blockhash
            bytes.AddRange(GetAdditionalSigned());

            return bytes.ToArray();
        }
    }
}