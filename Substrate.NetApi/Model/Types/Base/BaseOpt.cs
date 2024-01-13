using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Base Option Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseOpt<T> : IType where T : IType, new()
    {
        /// <summary>
        /// Explicit conversion from T to BaseOpt
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator BaseOpt<T>(T p) => new BaseOpt<T>(p);

        /// <summary>
        /// Explicit conversion from BaseOpt to T
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator T(BaseOpt<T> p) => p.OptionFlag ? p.Value : throw new InvalidOperationException("Option is None");

        /// <summary>
        /// Base Option Constructor
        /// </summary>
        public BaseOpt()
        { }

        /// <summary>
        /// Base Option Constructor
        /// </summary>
        /// <param name="value"></param>
        public BaseOpt(T value)
        {
            Create(value);
        }

        /// <summary>
        /// Type Name
        /// </summary>
        /// <returns></returns>
        public virtual string TypeName() => $"Option<{new T().TypeName()}>";

        /// <summary>
        /// Type Size
        /// </summary>
        public int TypeSize { get; set; }

        /// <summary>
        /// Bytes
        /// </summary>
        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        /// <summary>
        /// Encode to Bytes
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Decode from a byte array at certain position
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
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

        /// <summary>
        /// Option Flag
        /// </summary>
        public bool OptionFlag { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public T Value { get; internal set; }

        /// <summary>
        /// Create from a string
        /// </summary>
        /// <param name="value"></param>
        public void Create(T value)
        {
            OptionFlag = value != null;
            Value = value;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }

        /// <summary>
        /// Create from a string
        /// </summary>
        /// <param name="str"></param>
        public void Create(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// Create from a json string
        /// </summary>
        /// <param name="str"></param>
        public void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// Create from a byte array
        /// </summary>
        /// <param name="byteArray"></param>
        public void Create(byte[] byteArray)
        {
            var p = 0;
            Decode(byteArray, ref p);
        }

        /// <summary>
        /// New
        /// </summary>
        /// <returns></returns>
        public IType New() => this;

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}