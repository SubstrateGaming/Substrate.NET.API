using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I256 : BasePrim<BigInteger>
    {
        public I256()
        { }

        public I256(BigInteger value)
        {
            Create(value);
        }

        public override string TypeName() => "i128";

        public override int TypeSize => 32;

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
            if (byteArray.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                byteArray.CopyTo(newByteArray, 0);
                byteArray = newByteArray;
            }

            Bytes = byteArray;
            Value = new BigInteger(byteArray);
        }

        public void Create(long value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        public override void Create(BigInteger value)
        {
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

        #region Compare
        public int CompareTo(I256 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(I256 self, I256 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(I256 self, I256 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(I256 self, I256 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(I256 self, I256 value)
        {
            return self.Value > value.Value;
        }

        public static I256 operator *(I256 self, I256 value)
        {
            return new I256(self.Value * value.Value);
        }

        public static I256 operator +(I256 self, I256 value)
        {
            return new I256(self.Value + value.Value);
        }

        public static I256 operator -(I256 self, I256 value)
        {
            return new I256(self.Value - value.Value);
        }

        public static I256 operator /(I256 self, I256 value)
        {
            return new I256(self.Value / value.Value);
        }

        public static bool operator ==(I256 self, I256 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(I256 self, I256 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}