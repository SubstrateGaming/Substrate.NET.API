using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U128 : BasePrim<BigInteger>, IComparable, IComparable<U128>, IEquatable<U128>
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

        public override void Create(BigInteger value)
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

        #region Compare
        public int CompareTo(object obj)
        {
            if (obj is U128 validObj)
                return CompareTo(validObj);

            throw new InvalidOperationException($"{nameof(obj)} is not a valid {nameof(U128)} instance");
        }

        public int CompareTo(U128 other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(U128 other)
        {
            return Value.Equals(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(U128 self, U128 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(U128 self, U128 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(U128 self, U128 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(U128 self, U128 value)
        {
            return self.Value > value.Value;
        }

        public static U128 operator *(U128 self, U128 value)
        {
            return new U128(self.Value * value.Value);
        }

        public static U128 operator +(U128 self, U128 value)
        {
            return new U128(self.Value + value.Value);
        }

        public static U128 operator -(U128 self, U128 value)
        {
            if (self < value) throw new InvalidOperationException($"Error while performing {nameof(self)} - {nameof(value)} will result in negative number while should be positive");

            return new U128(self.Value - value.Value);
        }

        public static U128 operator /(U128 self, U128 value)
        {
            return new U128(self.Value / value.Value);
        }

        public static bool operator ==(U128 self, U128 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(U128 self, U128 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}