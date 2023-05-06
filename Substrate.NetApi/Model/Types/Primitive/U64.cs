using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U64 : BasePrim<ulong>
    {
        public U64()
        { }

        public U64(ulong value)
        {
            Create(value);
        }

        public override string TypeName() => "u64";

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
            Value = BitConverter.ToUInt64(byteArray, 0);
        }

        public override void Create(ulong value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        #region Compare
        public int CompareTo(U64 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(U64 self, U64 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(U64 self, U64 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(U64 self, U64 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(U64 self, U64 value)
        {
            return self.Value > value.Value;
        }

        public static U64 operator *(U64 self, U64 value)
        {
            return new U64(self.Value * value.Value);
        }

        public static U64 operator +(U64 self, U64 value)
        {
            return new U64(self.Value + value.Value);
        }

        public static U64 operator -(U64 self, U64 value)
        {
            if (self < value) throw new InvalidOperationException($"Error while performing {nameof(self)} - {nameof(value)} will result in negative number while should be positive");

            return new U64(self.Value - value.Value);
        }

        public static U64 operator /(U64 self, U64 value)
        {
            return new U64(self.Value / value.Value);
        }

        public static bool operator ==(U64 self, U64 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(U64 self, U64 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}