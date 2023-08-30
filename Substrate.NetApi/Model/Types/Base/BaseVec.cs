using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Substrate.NetApi.Model.Types.Base
{
    public class BaseVec<T> : IBaseEnumerable where T : IType, new()
    {
        public BaseVec()
        { }

        public BaseVec(T[] value)
        {
            Create(value);
        }

        public virtual string TypeName() => $"Vec<{new T().TypeName()}>";

        public int TypeSize { get; set; }

        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        public byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(new CompactInteger(Value.Length).Encode());
            for (int i = 0; i < Value.Length; i++)
            {
                result.AddRange(Value[i].Encode());
            }
            return result.ToArray();
        }

        public void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            var length = CompactInteger.Decode(byteArray, ref p);

            var array = new T[length];
            for (var i = 0; i < length; i++)
            {
                var t = new T();
                t.Decode(byteArray, ref p);
                array[i] = t;
            }

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
            Value = array;
        }

        public virtual T[] Value { get; internal set; }

        public IType[] GetValues() => Value.Select(x => (IType)x).ToArray();

        public void Create(T[] list)
        {
            Value = list;
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