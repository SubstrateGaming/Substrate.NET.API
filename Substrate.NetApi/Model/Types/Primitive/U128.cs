using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U128
    /// </summary>
    public class U128 : BasePrim<u128>
    {
        /// <summary>
        /// Explicitly cast a u128 to a U128
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U128(u128 p) => new U128(p);

        /// <summary>
        /// Explicitly cast a BigInteger to a U128
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U128(BigInteger p) => new U128(u128.FromBigInteger(p));

        /// <summary>
        /// Implicitly cast a U128 to a u128
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator u128(U128 p) => p.Value;

        /// <summary>
        /// Implicit conversion to BigInteger
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BigInteger(U128 p) => p.Value.ToBigInteger();

        /// <summary>
        /// U128 Constructor
        /// </summary>
        public U128()
        { }

        /// <summary>
        /// U128 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U128(u128 value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "u128";

        /// <inheritdoc/>
        public override int TypeSize => 16;

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
            var result = new byte[TypeSize];
            bytes.CopyTo(result, 0);
            Create(result);
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            if (byteArray.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                byteArray.CopyTo(newByteArray, 0);
                byteArray = newByteArray;
            }
            else if(byteArray.Length > TypeSize)
            {
                throw new NotSupportedException($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            Bytes = byteArray;
            Value = new u128(byteArray);
        }

        /// <inheritdoc/>
        public void Create(BigInteger value)
        {
            Create(u128.FromBigInteger(value));
        }

        /// <inheritdoc/>
        public override void Create(u128 value)
        {
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