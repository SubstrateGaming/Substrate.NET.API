using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I8 : BasePrim<sbyte>
    {
        public I8()
        { }

        public I8(sbyte value)
        {
            Create(value);
        }

        public override string TypeName() => "i8";

        public override int TypeSize => 1;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = (sbyte)byteArray[0];
        }

        public override void Create(sbyte value)
        {
            Bytes = new byte[] { (byte)value };
            Value = value;
        }

        #region Compare
        public int CompareTo(I8 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(I8 self, I8 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(I8 self, I8 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(I8 self, I8 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(I8 self, I8 value)
        {
            return self.Value > value.Value;
        }

        public static I8 operator *(I8 self, I8 value)
        {
            return new I8((sbyte)(self.Value * value.Value));
        }

        public static I8 operator +(I8 self, I8 value)
        {
            return new I8((sbyte)(self.Value + value.Value));
        }

        public static I8 operator -(I8 self, I8 value)
        {
            return new I8((sbyte)(self.Value - value.Value));
        }

        public static I8 operator /(I8 self, I8 value)
        {
            return new I8((sbyte)(self.Value / value.Value));
        }

        public static bool operator ==(I8 self, I8 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(I8 self, I8 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}