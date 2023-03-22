﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Types.Base
{
    public abstract class BaseType : IType
    {
        public virtual string TypeName() => GetType().Name;

        [JsonIgnore]
        public virtual int TypeSize { get; set; }

        [JsonIgnore]
        public byte[] Bytes { get; set; }

        public abstract byte[] Encode();

        public abstract void Decode(byte[] byteArray, ref int p);

        public virtual void Create(string str) => Create(Utils.HexToByteArray(str));

        public virtual void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        public virtual void Create(byte[] byteArray)
        {
            var p = 0;
            Bytes = byteArray;
            Decode(byteArray, ref p);
        }

        public IType New() => this;

        public override string ToString() => JsonConvert.SerializeObject(this);

        public override bool Equals(object obj)
        {
            if (!(obj is BaseType) || !obj.GetType().Equals(this.GetType()))
                return false;

            var baseType = (BaseType)obj;
            return TypeSize == baseType.TypeSize &&
                   TypeName() == baseType.TypeName() &&
                   (Bytes == null && baseType.Bytes == null || Bytes.SequenceEqual(baseType.Bytes));
        }
    }
}