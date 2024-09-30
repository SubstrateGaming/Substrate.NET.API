using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// This implemetation is just a fast hack, and misses to be complete.
    /// TODO: rework proper implementation https://docs.rs/bitvec/latest/bitvec/
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class BaseBitSeq<T1, T2> : IType
        where T1 : IType, new()
        where T2 : IType, new()
    {
        /// <summary>
        /// Type Name
        /// </summary>
        /// <returns></returns>
        public virtual string TypeName() => $"BitSequence<{new T1().TypeName()},{new T2().TypeName()}>";

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
            var result = new List<byte>
            {
                Reverse((byte)Value.Length)
            };
            for (int i = 0; i < Value.Length; i++)
            {
                result.AddRange(Reverse(Value[i].Encode()));
            }
            return result.ToArray();
        }

        /// <summary>
        /// Decode from a byte array at certain position
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            var length = Reverse(byteArray[p]);

            p++;

            var array = new T1[length];
            for (var i = 0; i < length; i++)
            {
                var t = new T1();
                t.Decode(Reverse(byteArray), ref p);
                array[i] = t;
            }

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
            Value = array;
        }

        /// <summary>
        /// Value
        /// </summary>
        public virtual T1[] Value { get; internal set; }

        /// <summary>
        /// Create from a string
        /// </summary>
        /// <param name="list"></param>
        public void Create(T1[] list)
        {
            Value = list;
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

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public byte[] Reverse(byte[] b)
        {
            byte[] p = new byte[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                p[i] = Reverse(b[i]);
            }
            return p;
        }

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public byte Reverse(byte b)
        {
            int a = 0;
            for (int i = 0; i < 8; i++)
                if ((b & (1 << i)) != 0)
                    a |= 1 << (7 - i);
            return (byte)a;
        }
    }
}