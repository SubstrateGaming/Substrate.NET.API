using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U16 : BasePrim<ushort>
    {
        public U16()
        { }

        public U16(ushort value)
        {
            Create(value);
        }

        public override string TypeName() => "u16";

        public override int TypeSize => 2;

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
            Value = BitConverter.ToUInt16(byteArray, 0);
        }

        public override void Create(ushort value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        #region Compare
        public int CompareTo(U16 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(U16 self, U16 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(U16 self, U16 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(U16 self, U16 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(U16 self, U16 value)
        {
            return self.Value > value.Value;
        }

        public static U16 operator *(U16 self, U16 value)
        {
            return new U16((ushort)(self.Value * value.Value));
        }

        public static U16 operator +(U16 self, U16 value)
        {
            return new U16((ushort)(self.Value + value.Value));
        }

        public static U16 operator -(U16 self, U16 value)
        {
            if (self < value) throw new InvalidOperationException($"Error while performing {nameof(self)} - {nameof(value)} will result in negative number while should be positive");

            return new U16((ushort)(self.Value - value.Value));
        }

        public static U16 operator /(U16 self, U16 value)
        {
            return new U16((ushort)(self.Value / value.Value));
        }

        public static bool operator ==(U16 self, U16 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(U16 self, U16 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}