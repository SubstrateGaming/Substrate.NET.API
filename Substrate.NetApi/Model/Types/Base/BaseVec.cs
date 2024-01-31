using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Base Vec Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseVec<T> : IType where T : IType, new()
    {
        /// <summary>
        /// Explicit conversion from T[] to BaseVec
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator BaseVec<T>(T[] p) => new BaseVec<T>(p);

        /// <summary>
        /// Implicit conversion from BaseVec to T[]
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator T[](BaseVec<T> p) => p.Value;

        /// <summary>
        /// BaseVec Constructor
        /// </summary>
        public BaseVec()
        { }

        /// <summary>
        /// BaseVec Constructor
        /// </summary>
        /// <param name="value"></param>
        public BaseVec(T[] value)
        {
            Create(value);
        }

        /// <summary>
        /// BaseVec Type Name
        /// </summary>
        /// <returns></returns>
        public virtual string TypeName() => $"Vec<{new T().TypeName()}>";

        /// <summary>
        /// BaseVec Type Size
        /// </summary>
        public int TypeSize { get; set; }

        /// <summary>
        /// BaseVec Bytes
        /// </summary>
        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        /// <summary>
        /// BaseVec Encode
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// BaseVec Decode
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
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

        /// <summary>
        /// BaseVec Value
        /// </summary>
        public virtual T[] Value { get; internal set; }

        /// <summary>
        /// BaseVec Create
        /// </summary>
        /// <param name="list"></param>
        public void Create(T[] list)
        {
            Value = list;
            Bytes = Encode();

            TypeSize = Bytes.Length;
        }

        /// <summary>
        /// BaseVec Create
        /// </summary>
        /// <param name="str"></param>
        public void Create(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// BaseVec Create From Json
        /// </summary>
        /// <param name="str"></param>
        public void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// BaseVec Create
        /// </summary>
        /// <param name="byteArray"></param>
        public void Create(byte[] byteArray)
        {
            var p = 0;
            Decode(byteArray, ref p);
        }

        /// <summary>
        /// BaseVec New
        /// </summary>
        /// <returns></returns>
        public IType New() => this;

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}