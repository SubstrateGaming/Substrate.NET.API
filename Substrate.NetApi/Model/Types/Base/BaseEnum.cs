using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Base Enum Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEnum<T> : IType where T : System.Enum
    {
        /// <summary>
        /// Explicit conversion from T to BaseEnum
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator BaseEnum<T>(T p) => new BaseEnum<T>(p);

        /// <summary>
        /// Implicit conversion from BaseEnum to T
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator T(BaseEnum<T> p) => p.Value;

        /// <summary>
        /// BaseEnum Constructor
        /// </summary>
        public BaseEnum()
        { }

        /// <summary>
        /// BaseEnum Constructor
        /// </summary>
        /// <param name="t"></param>
        public BaseEnum(T t)
        {
            Create(t);
        }

        /// <summary>
        /// BaseEnum Type Name
        /// </summary>
        /// <returns></returns>
        public string TypeName() => typeof(T).Name;

        /// <summary>
        /// BaseEnum Type Size
        /// </summary>
        public int TypeSize { get; set; } = 1;

        /// <summary>
        /// Base Enum Bytes
        /// </summary>
        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        /// <summary>
        /// Base Enum Encode
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            return Bytes;
        }

        /// <summary>
        /// Base Enum Decode
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public void Decode(byte[] byteArray, ref int p)
        {
            var memory = byteArray.AsMemory();
            var result = memory.Span.Slice(p, TypeSize).ToArray();
            p += TypeSize;
            Create(result);
        }

        /// <summary>
        /// Virtual Create
        /// </summary>
        /// <param name="str"></param>
        public virtual void Create(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// Virtual Create From Json
        /// </summary>
        /// <param name="str"></param>
        public virtual void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="t"></param>
        public void Create(T t)
        {
            Bytes = new byte[1] { Convert.ToByte(t) };
            Value = t;
        }


        /// <summary>
        /// Create
        /// </summary>
        /// <param name="byteArray"></param>
        public void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = (T)Enum.Parse(typeof(T), byteArray[0].ToString(), true);
        }

        /// <summary>
        /// New
        /// </summary>
        /// <returns></returns>
        public IType New() => this;

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// Base Enum Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T Value { get; internal set; }
    }
}