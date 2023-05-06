using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U8 : BasePrim<byte>
    {
        public U8()
        { }

        public U8(byte value)
        {
            Create(value);
        }

        public override string TypeName() => "u8";

        public override int TypeSize => 1;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = byteArray[0];
        }

        public override void Create(byte value)
        {
            Bytes = new byte[] { value };
            Value = value;
        }

        #region Compare
        public int CompareTo(U8 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(U8 self, U8 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(U8 self, U8 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(U8 self, U8 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(U8 self, U8 value)
        {
            return self.Value > value.Value;
        }

        public static U8 operator *(U8 self, U8 value)
        {
            return new U8((byte)(self.Value * value.Value));
        }

        public static U8 operator +(U8 self, U8 value)
        {
            return new U8((byte)(self.Value + value.Value));
        }

        public static U8 operator -(U8 self, U8 value)
        {
            if (self < value) throw new InvalidOperationException($"Error while performing {nameof(self)} - {nameof(value)} will result in negative number while should be positive");

            return new U8((byte)(self.Value - value.Value));
        }

        public static U8 operator /(U8 self, U8 value)
        {
            return new U8((byte)(self.Value / value.Value));
        }

        public static bool operator ==(U8 self, U8 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(U8 self, U8 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}