using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I64 : BasePrim<long>, IComparable, IComparable<I64>, IEquatable<I64>
    {
        public I64()
        { }

        public I64(long value)
        {
            Create(value);
        }

        public override string TypeName() => "i64";

        public override int TypeSize => 8;

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
            Value = BitConverter.ToInt64(byteArray, 0);
        }

        public override void Create(long value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        #region Compare
        public int CompareTo(object obj)
        {
            if (obj is I64 validObj)
                return CompareTo(validObj);

            throw new InvalidOperationException($"{nameof(obj)} is not a valid {nameof(I64)} instance");
        }

        public int CompareTo(I64 other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(I64 other)
        {
            return Value.Equals(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(I64 self, I64 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(I64 self, I64 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(I64 self, I64 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(I64 self, I64 value)
        {
            return self.Value > value.Value;
        }

        public static I64 operator *(I64 self, I64 value)
        {
            return new I64(self.Value * value.Value);
        }

        public static I64 operator +(I64 self, I64 value)
        {
            return new I64(self.Value + value.Value);
        }

        public static I64 operator -(I64 self, I64 value)
        {
            return new I64(self.Value - value.Value);
        }

        public static I64 operator /(I64 self, I64 value)
        {
            return new I64(self.Value / value.Value);
        }

        public static bool operator ==(I64 self, I64 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(I64 self, I64 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}