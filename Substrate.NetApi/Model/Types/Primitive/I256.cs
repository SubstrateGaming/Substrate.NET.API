using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// I256 Type
    /// </summary>
    public class I256 : BasePrim<i256>
    {
        /// <summary>
        /// Explicit conversion to I256
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I256(i256 p) => new I256(p);

        /// <summary>
        /// Explicitly cast a BigInteger to a I256
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I256(BigInteger p) => new I256(i256.FromBigInteger(p));

        /// <summary>
        /// Implicit conversion to i256
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator i256(I256 p) => p.Value;

        /// <summary>
        /// Implicit conversion to BigInteger
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BigInteger(I256 p) => p.Value.ToBigInteger();

        /// <summary>
        /// I256 Constructor
        /// </summary>
        public I256()
        { }

        /// <summary>
        /// I256 Constructor
        /// </summary>
        /// <param name="value"></param>
        public I256(i256 value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "i256";

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
            Value = new i256(byteArray);
        }

        /// <inheritdoc/>
        public void Create(BigInteger value)
        {
            Create(i256.FromBigInteger(value));
        }

        /// <inheritdoc/>
        public override void Create(i256 value)
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