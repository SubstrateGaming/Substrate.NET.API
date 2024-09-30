using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Bit Order
    /// </summary>
    public enum BitOrder
    {
        /// <summary>
        /// Least Significant Bit first
        /// </summary>
        Lsb0,

        /// <summary>
        /// Most Significant Bit first
        /// </summary>
        Msb0
    }

    /// <summary>
    /// This implemetation is just a fast hack, and misses to be complete.
    /// TODO: rework proper implementation https://docs.rs/bitvec/latest/bitvec/
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public class BaseBitSeq<T1> : IType
        where T1 : IType, new()
    {
        /// <summary>
        /// Bit Order (Msb0 or Lsb0).
        /// </summary>
        public BitOrder BitOrder { get; private set; }

        /// <summary>
        /// Type Name
        /// </summary>
        /// <returns></returns>
        public virtual string TypeName() => $"BitSequence<{new T1().TypeName()},{BitOrder}>";

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
               Utils.Reverse((byte)Value.Length)
            };
            for (int i = 0; i < Value.Length; i++)
            {
                result.AddRange(Utils.Reverse(Value[i].Encode()));
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

            var length = Utils.Reverse(byteArray[p]);

            p++;

            var array = new T1[length];
            for (var i = 0; i < length; i++)
            {
                var t = new T1();
                t.Decode(Utils.Reverse(byteArray), ref p);
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
        public void Create(T1[] list, BitOrder bitOrder)
        {
            Value = list;
            Bytes = Encode();
            TypeSize = Bytes.Length;
            BitOrder = bitOrder;
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