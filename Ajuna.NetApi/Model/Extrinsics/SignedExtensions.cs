using System.Collections.Generic;
using System.Linq;
using Ajuna.NetApi.Model.Types.Base;

namespace Ajuna.NetApi.Model.Extrinsics
{
    public interface ISignedExtension
    {
        byte[] GetExtra();

        byte[] GetAdditionalSigned();
    }

    public class SignedExtensions : ISignedExtension
    {
        public uint SpecVersion { get; }

        public uint TxVersion { get; }

        public Hash Genesis { get; }

        public Hash StartEra { get; }

        public Era Mortality { get; }

        public CompactInteger Nonce { get; }

        public ChargePaymentShell ChargePaymentShell { get; }

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
        public SignedExtensions(uint specVersion, uint txVersion, Hash genesis, Hash startEra, Era mortality, CompactInteger nonce, ChargePaymentShell chargePaymentShell)
        {
            SpecVersion = specVersion;
            TxVersion = txVersion;
            Genesis = genesis;
            StartEra = startEra;
            Mortality = mortality;
            Nonce = nonce;
            ChargePaymentShell = chargePaymentShell;
        }

        /// <summary>
        /// Gets the extra.
        /// </summary>
        /// <returns></returns>
        public byte[] GetExtra()
        {
            return Mortality.Encode() // CheckMortality
                    .Concat(Nonce.Encode() // CheckNonce
                    .Concat(ChargePaymentShell.Encode())) // ChargePaymentShell
                    .ToArray();
        }

        /// <summary>
        /// Gets the additional signed.
        /// </summary>
        /// <returns></returns>
        public byte[] GetAdditionalSigned()
        {
            return Utils.Value2Bytes(SpecVersion) // CheckSpecVersion
                    .Concat(Utils.Value2Bytes(TxVersion) // CheckTxVersion
                    .Concat(Genesis.Bytes // CheckGenesis
                    .Concat(StartEra.Bytes))) // CheckMortality, Additional Blockhash check. Immortal = genesis_hash, Mortal = logic
                    .ToArray();
        }
    }
}
