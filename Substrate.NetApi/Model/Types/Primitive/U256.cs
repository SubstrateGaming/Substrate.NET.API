using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U256 : BasePrim<BigInteger>
    {
        public U256()
        { }

        public U256(BigInteger value)
        {
            Create(value);
        }

        public override string TypeName() => "u256";

        public override int TypeSize => 32;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void CreateFromJson(string str)
        {
            var bytes = Utils.HexToByteArray(str, true);
            Array.Reverse(bytes);
            Create(bytes);
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

        public override void Create(BigInteger value)
        {
            // Ensure we have a positive number
            if (value.Sign < 0)
                throw new InvalidOperationException($"Unable to create a {nameof(U256)} instance while value is negative");

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
        public int CompareTo(U256 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(U256 self, U256 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(U256 self, U256 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(U256 self, U256 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(U256 self, U256 value)
        {
            return self.Value > value.Value;
        }

        public static U256 operator *(U256 self, U256 value)
        {
            return new U256(self.Value * value.Value);
        }

        public static U256 operator +(U256 self, U256 value)
        {
            return new U256(self.Value + value.Value);
        }

        public static U256 operator -(U256 self, U256 value)
        {
            if (self < value) throw new InvalidOperationException($"Error while performing {nameof(self)} - {nameof(value)} will result in negative number while should be positive");

            return new U256(self.Value - value.Value);
        }

        public static U256 operator /(U256 self, U256 value)
        {
            return new U256(self.Value / value.Value);
        }

        public static bool operator ==(U256 self, U256 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(U256 self, U256 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}