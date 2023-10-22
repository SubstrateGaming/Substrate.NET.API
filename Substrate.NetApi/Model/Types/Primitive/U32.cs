﻿using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class U32 : BasePrim<uint>
    {
        public static explicit operator U32(uint p) => new U32(p);

        public static implicit operator uint(U32 p) => p.Value;

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
    }
}