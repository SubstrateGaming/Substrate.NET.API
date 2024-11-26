using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{

    /// <summary>
    /// U256
    /// </summary>
    public class U256 : BasePrim<u256>
    {
        /// <summary>
        /// Explicitly cast a u256 to a U256
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U256(u256 p) => new U256(p);

        /// <summary>
        /// Explicitly cast a BigInteger to a U256
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U256(BigInteger p) => new U256(u256.FromBigInteger(p));

        /// <summary>
        /// Implicitly cast a U256 to a u256
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator u256(U256 p) => p.Value;

        /// <summary>
        /// Implicit conversion to BigInteger
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BigInteger(U256 p) => p.Value.ToBigInteger();

        /// <summary>
        /// U256 Constructor
        /// </summary>
        public U256()
        { }

        /// <summary>
        /// U256 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U256(u256 value)
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
            if (byteArray.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                byteArray.CopyTo(newByteArray, 0);
                byteArray = newByteArray;
            }
            else if (byteArray.Length > TypeSize)
            {
                throw new NotSupportedException($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            Bytes = byteArray;
            Value = new u256(byteArray);
        }

        /// <inheritdoc/>
        public void Create(BigInteger value)
        {
            Create(u256.FromBigInteger(value));
        }

        /// <inheritdoc/>
        public override void Create(u256 value)
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