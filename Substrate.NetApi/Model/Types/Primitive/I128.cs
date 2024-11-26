using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// I128 Type
    /// </summary>
    public class I128 : BasePrim<i128>
    {
        /// <summary>
        /// Explicit conversion to I128
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I128(i128 p) => new I128(p);

        /// <summary>
        /// Explicitly cast a BigInteger to a I128
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I128(BigInteger p) => new I128(i128.FromBigInteger(p));

        /// <summary>
        /// Implicit conversion to i128
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator i128(I128 p) => p.Value;

        /// <summary>
        /// Implicit conversion to BigInteger
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BigInteger(I128 p) => p.Value.ToBigInteger();

        /// <summary>
        /// I128 Constructor
        /// </summary>
        public I128()
        { }

        /// <summary>
        /// I128 Constructor
        /// </summary>
        /// <param name="value"></param>
        public I128(i128 value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "i128";

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

            Bytes = byteArray;
            Value = new i128(byteArray);
        }

        /// <inheritdoc/>
        public void Create(BigInteger value)
        {
            Create(i128.FromBigInteger(value));
        }

        /// <inheritdoc/>
        public override void Create(i128 value)
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