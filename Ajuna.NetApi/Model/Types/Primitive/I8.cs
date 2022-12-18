﻿namespace Ajuna.NetApi.Model.Types.Primitive
{
    public class I8 : BasePrim<sbyte>
    {
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

        public void Create(sbyte value)
        {
            Bytes = new byte[] { (byte)value };
            Value = value;
        }
    }
}