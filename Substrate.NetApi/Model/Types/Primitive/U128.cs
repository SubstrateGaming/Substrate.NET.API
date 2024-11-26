using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U128
    /// </summary>
    public class U128 : BasePrim<BigInteger>
    {
        /// <summary>
        /// Explicitly cast a BigInteger to a U128
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U128(BigInteger p) => new U128(p);

        /// <summary>
        /// Implicitly cast a U128 to a BigInteger
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BigInteger(U128 p) => p.Value;

        /// <summary>
        /// U128 Constructor
        /// </summary>
        public U128()
        { }

        /// <summary>
        /// U128 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U128(BigInteger value)
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
                throw new InvalidOperationException($"Unable to create a {nameof(U128)} instance while value is negative");

            var byteArray = value.ToByteArray();

            if (byteArray.Length > TypeSize + 1)
            {
                throw new NotSupportedException($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            var bytes = new byte[TypeSize];
            Array.Copy(byteArray, 0, bytes, 0, TypeSize);
            Bytes = bytes;
            Value = value;
        }
    }
}