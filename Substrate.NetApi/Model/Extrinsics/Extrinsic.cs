using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Extrinsic
    /// </summary>
    public class Extrinsic
    {
        /// <summary>
        /// Signed
        /// </summary>
        public bool Signed { get; set; }

        /// <summary>
        /// Transaction Version
        /// </summary>
        public byte TransactionVersion { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Era
        /// </summary>
        public Era Era { get; set; }

        /// <summary>
        /// Nonce
        /// </summary>
        public CompactInteger Nonce { get; set; }

        /// <summary>
        /// Charge
        /// </summary>
        public ChargeType Charge { get; set; }

        /// <summary>
        /// Method
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// Signature
        /// </summary>
        public byte[] Signature { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Extrinsic"/> class.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="chargeType"></param>
        public Extrinsic(string str, ChargeType chargeType) : this(Utils.HexToByteArray(str).AsMemory(), chargeType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Extrinsic"/> class.
        /// </summary>
        /// <param name="memory"></param>
        /// <param name="chargeType"></param>
        internal Extrinsic(Memory<byte> memory, ChargeType chargeType)
        {
            int p = 0;
            int m;

            // length
            _ = CompactInteger.Decode(memory.ToArray(), ref p);

            // signature version
            m = 1;
            var _signatureVersion = memory.Slice(p, m).ToArray()[0];
            Signed = _signatureVersion >= 0x80;
            TransactionVersion = (byte)(_signatureVersion - (Signed ? 0x80 : 0x00));
            p += m;

            // this part is for signed extrinsics
            if (Signed)
            {
                // start bytes
                m = 1;
                var _startBytes = memory.Slice(p, m).ToArray()[0];
                p += m;

                // sender public key
                m = 32;
                var _senderPublicKey = memory.Slice(p, m).ToArray();
                p += m;

                // sender public key type
                m = 1;
                var _senderPublicKeyType = memory.Slice(p, m).ToArray()[0];
                p += m;

                var account = new Account();
                account.Create((KeyType)_senderPublicKeyType, _senderPublicKey);
                Account = account;

                // signature
                m = 64;
                Signature = memory.Slice(p, m).ToArray();
                p += m;

                // era
                m = 1;
                var era = memory.Slice(p, m).ToArray();
                if (era[0] != 0)
                {
                    m = 2;
                    era = memory.Slice(p, m).ToArray();
                }
                Era = Era.Decode(era);
                p += m;

                // nonce
                Nonce = CompactInteger.Decode(memory.ToArray(), ref p);

                // charge type
                Charge = chargeType;
                Charge.Decode(memory.ToArray(), ref p);
            }

            // method
            m = 2;
            var method = memory.Slice(p, m).ToArray();
            p += m;

            // parameters
            var parameter = memory.Slice(p).ToArray();

            Method = new Method(method[0], method[1], parameter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Extrinsic"/> class.
        /// </summary>
        /// <param name="signed">if set to <c>true</c> [signed].</param>
        /// <param name="account">The account.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="method">The method.</param>
        /// <param name="era">The era.</param>
        /// <param name="charge"></param>
        public Extrinsic(bool signed, Account account, CompactInteger nonce, Method method, Era era, ChargeType charge)
        {
            Signed = signed;
            TransactionVersion = Constants.ExtrinsicVersion;
            Account = account;
            Era = era;
            Nonce = nonce;
            Charge = charge;
            Method = method;
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            var result = new List<byte>();

            var signatureVersion = (byte)((Signed ? 0x80 : 0x00) + TransactionVersion);
            result.Add(signatureVersion);

            if (Signed)
            {
                result.AddRange(Account.Encode());
                result.Add(Account.KeyTypeByte);
                result.AddRange(Signature);
                result.AddRange(Era.Encode());
                result.AddRange(Nonce.Encode());
                result.AddRange(Charge.Encode());
            }

            result.AddRange(Method.Encode());

            var length = new CompactInteger(result.Count);
            result.InsertRange(0, length.Encode());

            return result.ToArray();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}