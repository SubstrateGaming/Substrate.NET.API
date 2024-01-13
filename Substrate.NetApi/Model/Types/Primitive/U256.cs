using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U256
    /// </summary>
    public class U256 : BasePrim<BigInteger>
    {
        /// <summary>
        /// Explicitly cast a BigInteger to a U256
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U256(BigInteger p) => new U256(p);

        /// <summary>
        /// Implicitly cast a U256 to a BigInteger
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BigInteger(U256 p) => p.Value;

        /// <summary>
        /// U256 Constructor
        /// </summary>
        public U256()
        { }

        /// <summary>
        /// U256 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U256(BigInteger value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "u256";

        /// <inheritdoc/>
        public override int TypeSize => 32;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void CreateFromJson(string str)
        {
            var bytes = Utils.HexToByteArray(str, true);
            Array.Reverse(bytes);
            Create(bytes);
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            // make sure it is unsigned we add 00 at the end
            if (byteArray.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                byteArray.CopyTo(newByteArray, 0);
                byteArray = newByteArray;
            }
            else if (byteArray.Length == TypeSize)
            {
                byte[] newArray = new byte[byteArray.Length + 2];
                byteArray.CopyTo(newArray, 0);
                newArray[byteArray.Length - 1] = 0x00;
            }
            else
            {
                throw new NotSupportedException($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            Bytes = byteArray;
            Value = new BigInteger(byteArray);
        }

        /// <inheritdoc/>
        public override void Create(BigInteger value)
        {
            // Ensure we have a positive number
            if (value.Sign < 0)
                throw new InvalidOperationException($"Unable to create a {nameof(U256)} instance while value is negative");

            var byteArray = value.ToByteArray();

            if (byteArray.Length > TypeSize)
            {
                throw new NotSupportedException($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            var bytes = new byte[TypeSize];
            byteArray.CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}