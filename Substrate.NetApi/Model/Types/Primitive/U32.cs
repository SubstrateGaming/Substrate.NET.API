using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U32 : BasePrim<uint>
    {
        public U32()
        { }

        public U32(uint value)
        {
            Create(value);
        }

        public override string TypeName() => "u32";

        public override int TypeSize => 4;

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
            Value = BitConverter.ToUInt32(byteArray, 0);
        }

        public override void Create(uint value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        #region Compare
        public int CompareTo(U32 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(U32 self, U32 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(U32 self, U32 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(U32 self, U32 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(U32 self, U32 value)
        {
            return self.Value > value.Value;
        }

        public static U32 operator *(U32 self, U32 value)
        {
            return new U32(self.Value * value.Value);
        }

        public static U32 operator +(U32 self, U32 value)
        {
            return new U32(self.Value + value.Value);
        }

        public static U32 operator -(U32 self, U32 value)
        {
            if (self < value) throw new InvalidOperationException($"Error while performing {nameof(self)} - {nameof(value)} will result in negative number while should be positive");

            return new U32(self.Value - value.Value);
        }

        public static U32 operator /(U32 self, U32 value)
        {
            return new U32(self.Value / value.Value);
        }

        public static bool operator ==(U32 self, U32 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(U32 self, U32 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}