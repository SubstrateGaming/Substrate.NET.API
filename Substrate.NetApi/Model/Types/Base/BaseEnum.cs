using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Substrate.NetApi.Model.Types.Base
{
    public class BaseEnum<T> : IType where T : System.Enum
    {
        public static explicit operator BaseEnum<T>(T p) => new BaseEnum<T>(p);

        public static implicit operator T(BaseEnum<T> p) => p.Value;

        public BaseEnum()
        { }

        public BaseEnum(T t)
        {
            Create(t);
        }

        public string TypeName() => typeof(T).Name;

        public int TypeSize { get; set; } = 1;

        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        public byte[] Encode()
        {
            return Bytes;
        }

        public void Decode(byte[] byteArray, ref int p)
        {
            var memory = byteArray.AsMemory();
            var result = memory.Span.Slice(p, TypeSize).ToArray();
            p += TypeSize;
            Create(result);
        }

        public virtual void Create(string str) => Create(Utils.HexToByteArray(str));

        public virtual void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        public void Create(T t)
        {
            Bytes = new byte[1] { Convert.ToByte(t) };
            Value = t;
        }

        public void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = (T)Enum.Parse(typeof(T), byteArray[0].ToString(), true);
        }

        public IType New() => this;

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T Value { get; internal set; }
    }
}