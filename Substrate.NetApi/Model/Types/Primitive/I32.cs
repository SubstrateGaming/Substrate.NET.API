using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I32 : BasePrim<int>
    {
        public I32()
        { }

        public I32(int value)
        {
            Create(value);
        }

        public override string TypeName() => "i32";

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
            Value = BitConverter.ToInt32(byteArray, 0);
        }

        public override void Create(int value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        #region Compare
        public int CompareTo(I32 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(I32 self, I32 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(I32 self, I32 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(I32 self, I32 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(I32 self, I32 value)
        {
            return self.Value > value.Value;
        }

        public static I32 operator *(I32 self, I32 value)
        {
            return new I32(self.Value * value.Value);
        }

        public static I32 operator +(I32 self, I32 value)
        {
            return new I32(self.Value + value.Value);
        }

        public static I32 operator -(I32 self, I32 value)
        {
            return new I32(self.Value - value.Value);
        }

        public static I32 operator /(I32 self, I32 value)
        {
            return new I32(self.Value / value.Value);
        }

        public static bool operator ==(I32 self, I32 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(I32 self, I32 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}