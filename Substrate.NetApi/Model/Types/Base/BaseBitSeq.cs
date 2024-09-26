using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        private BitArray _bits { get; set; }

        /// <summary>
        /// Return if it is LSB (Least Significant Bit first) or MSB (Most Significant Bit first)
        /// </summary>
        public bool IsLsb {
            get
            {
                switch (typeof(T2).Name.ToLower())
                {
                    case "lsb0":
                        return true;
                    case "msb0":
                        return false;
                    default:
                        return true; // not sure if I should throw an exception here or just assume lsb0 (which is the default)
                }
            }
        }

        /// <summary>
        /// Encode to Bytes
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(new CompactInteger(Value.Length * 8).Encode());

            for (int i = 0; i < Value.Length; i++)
            {
                result.AddRange(IsLsb ? Reverse(Value[i].Encode()) : Value[i].Encode());
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
            int lengthInner = CompactInteger.Decode(byteArray, ref p);
            var length = (int)Math.Ceiling((decimal)lengthInner / (decimal)8);
            var tmpBytes = byteArray;
            if (IsLsb)
            {
                tmpBytes = Reverse(byteArray);
            }

            var array = new T1[length];
            for (var i = 0; i < length; i++)
            {
                var t = new T1();
                t.Decode(tmpBytes, ref p);
                array[i] = t;
            }

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
            Value = array;

            // By default, BitArray is using Lsb0. So we need to reverse the bits again
            _bits = new BitArray(array.SelectMany(x => Reverse(x.Encode())).ToArray());
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
        /// Create <see cref="BaseBitSeq{T1, T2}"/> from string bits
        /// Example : CreateFromBitString("0b11010000_00000001_10100000_00000000_00000000")
        /// </summary>
        /// <param name="bits"></param>
        public void CreateFromBitString(string bits)
        {
            var s = bits.Replace("0b", "").Split('_');

            var result = new List<byte>();

            for (int i = 0; i < s.Length; i++)
            {
                byte b = Convert.ToByte(s[i], 2);
                result.Add(IsLsb ? Reverse(b) : b);
            }

            result.InsertRange(0, new CompactInteger(result.Count * 8).Encode());
            Create(result.ToArray());
        }

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
        public override string ToString() => $"{{ bits = {_bits.Count}, capacity = {_bits.Count}}} => [{DisplayToBits()}]";

        /// <summary>
        /// Display this instance to bits
        /// </summary>
        /// <returns></returns>
        public string DisplayToBits()
        {
            var bitString = new System.Text.StringBuilder(_bits.Count);
            bitString.Append("0b");
            for(int i = 0; i < _bits.Length; i++)
            {
                bitString.Append(_bits[i] ? '1' : '0');
                
                if ((i + 1) % 8 == 0 && i != _bits.Count - 1)
                {
                    bitString.Append("_");
                }
            }

            return bitString.ToString();
        }

        public int InternalLength => _bits.Length;

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