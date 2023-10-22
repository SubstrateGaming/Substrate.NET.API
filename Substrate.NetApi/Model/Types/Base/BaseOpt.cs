﻿using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    public class BaseOpt<T> : IType where T : IType, new()
    {
        public static implicit operator BaseOpt<T>(T p) => new BaseOpt<T>(p);

        public static explicit operator T(BaseOpt<T> p) => p.OptionFlag ? p.Value : throw new InvalidOperationException("Option is None");

        public BaseOpt()
        { }

        public BaseOpt(T value)
        {
            Create(value);
        }

        public virtual string TypeName() => $"Option<{new T().TypeName()}>";

        public int TypeSize { get; set; }

        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        public byte[] Encode()
        {
            var bytes = new List<byte>();
            if (OptionFlag)
            {
                bytes.Add(1);
                bytes.AddRange(Value.Encode());
            }
            else
            {
                bytes.Add(0);
            }

            return bytes.ToArray();
        }

        public void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            var optionByte = new U8();
            optionByte.Decode(byteArray, ref p);

            OptionFlag = optionByte.Value > 0;

            T t = default;
            if (optionByte.Value > 0)
            {
                t = new T();
                t.Decode(byteArray, ref p);
            }

            TypeSize = p - start;

            var bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, bytes, 0, TypeSize);

            Bytes = bytes;
            Value = t != null ? t : default;
        }

        public bool OptionFlag { get; set; }

        public T Value { get; internal set; }

        public void Create(T value)
        {
            OptionFlag = value != null;
            Value = value;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }

        public void Create(string str) => Create(Utils.HexToByteArray(str));

        public void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        public void Create(byte[] byteArray)
        {
            var p = 0;
            Decode(byteArray, ref p);
        }

        public IType New() => this;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}