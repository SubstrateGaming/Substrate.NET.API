using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U128 : BasePrim<BigInteger>
    {
        public U128()
        {
        }

        public U128(BigInteger value)
        {
            Create(value);
        }

        public override string TypeName() => "u128";

        public override int TypeSize => 16;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void CreateFromJson(string str)
        {
            var bytes = Utils.HexToByteArray(str, true);
            Array.Reverse(bytes);
            var result = new byte[TypeSize];
            bytes.CopyTo(result, 0);
            Create(result);
        }

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
                throw new Exception($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            Bytes = byteArray;
            Value = new BigInteger(byteArray);
        }

        public void Create(BigInteger value)
        {
            // Ensure we have a positive number
            if (value.Sign < 0)
                throw new InvalidOperationException($"Unable to create a {nameof(U128)} instance while value is negative");

            var byteArray = value.ToByteArray();

            if (byteArray.Length > TypeSize)
            {
                throw new Exception($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            var bytes = new byte[TypeSize];
            byteArray.CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}