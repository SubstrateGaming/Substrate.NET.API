﻿using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace Ajuna.NetApi.Model.Extrinsics
{
    public class UnCheckedExtrinsic : Extrinsic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnCheckedExtrinsic"/> class.
        /// </summary>
        /// <param name="signed">if set to <c>true</c> [signed].</param>
        /// <param name="account">The account.</param>
        /// <param name="method">The method.</param>
        /// <param name="era">The era.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="tip">The tip.</param>
        /// <param name="genesis">The genesis.</param>
        /// <param name="startEra">The start era.</param>
        public UnCheckedExtrinsic(bool signed, Account account, Method method, Era era, CompactInteger nonce, ChargePaymentShell chargePaymentShell)
             : base(signed, account, nonce, method, era, chargePaymentShell)
        {

        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Missing payload signature for signed transaction.</exception>
        public byte[] Encode()
        {
            if (Signed && Signature == null)
            {
                throw new Exception("Missing payload signature for signed transaction.");
            }

            var list = new List<byte>();

            // 4 is the TRANSACTION_VERSION constant and it is 7 bits long, the highest bit 1 for signed transaction, 0 for unsigned.
            list.Add((byte)(Constants.ExtrinsicVersion | (Signed ? 0x80 : 0)));

            // 32 bytes + prefix depending on address encoding in chain, see Constants.Address_version
            list.AddRange(Account.Encode());

            // key type ed = 00 and sr = FF
            list.Add(Account.KeyTypeByte);

            // add signature if exists
            if (Signature != null)
            {
                list.AddRange(Signature);
            }
            else
            {

            }

            list.AddRange(Era.Encode());

            list.AddRange(Nonce.Encode());

            list.AddRange(ChargePaymentShell.Encode());

            list.AddRange(Method.Encode());

            return Utils.SizePrefixedByteArray(list);
        }
    }
}
