﻿using System;
using System.Linq;
using System.Text;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class Str : BasePrim<string>
    {
        public static explicit operator Str(string p) => new Str(p);

        public static implicit operator string(Str p) => p.Value;

        public Str()
        { }

        public Str(string value)
        {
            Create(value);
        }

        public override string TypeName() => "str";

        public override byte[] Encode()
        {
            return Utils.SizePrefixedByteArray(Encoding.UTF8.GetBytes(Value).ToList());
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            var value = String.Empty;

            var length = CompactInteger.Decode(byteArray, ref p);
            for (var i = 0; i < length; i++)
            {
                var t = new PrimChar();
                t.Decode(byteArray, ref p);
                value += t.Value;
            }

            TypeSize = p - start;

            var bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, bytes, 0, TypeSize);

            Bytes = bytes;
            Value = value;
        }

        public override void Create(string value)
        {
            Value = value;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }
    }
}