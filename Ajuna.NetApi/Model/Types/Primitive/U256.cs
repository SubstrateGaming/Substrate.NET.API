﻿using System;
using System.Numerics;

namespace Ajuna.NetApi.Model.Types.Primitive
{
    public class U256 : BasePrim<BigInteger>
    {
        public override string TypeName() => "u256";

        public override int TypeSize => 32;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void CreateFromJson(string str)
        {
            var bytes = Utils.HexToByteArray(str, true);
            Array.Reverse(bytes);
            Create(bytes);
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

        public void Create(BigInteger value)
        {
            var byteArray = value.ToByteArray();

            if (byteArray.Length > 16)
            {
                throw new Exception($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            var bytes = new byte[TypeSize];
            byteArray.CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}