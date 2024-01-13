using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Account Id
    /// </summary>
    public class AccountId : BasePrim<string>
    {
        /// <summary>
        /// Account Id Constructor
        /// </summary>
        public AccountId()
        { }

        /// <summary>
        /// Account Id Constructor
        /// </summary>
        /// <param name="value"></param>
        public AccountId(string value)
        {
            Create(value);
        }

        /// <summary>
        /// Account Id Constructor
        /// </summary>
        /// <param name="value"></param>
        public AccountId(byte[] value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "T::AccountId";

        /// <inheritdoc/>
        public override int TypeSize => 32;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            switch (Constants.AddressVersion)
            {
                case 0:
                    return Bytes;

                case 1:
                    bytes.Add(0xFF);
                    bytes.AddRange(Bytes);
                    return bytes.ToArray();

                case 2:
                    bytes.Add(0x00);
                    bytes.AddRange(Bytes);
                    return bytes.ToArray();

                default:
                    throw new NotImplementedException("Unknown address version please refer to Constants.cs");
            }
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = Utils.GetAddressFrom(byteArray);
        }

        /// <inheritdoc/>
        public override void Create(string value) => Create(Utils.HexToByteArray(value));
    }
}