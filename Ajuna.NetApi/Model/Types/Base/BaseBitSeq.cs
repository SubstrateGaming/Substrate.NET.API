using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Ajuna.NetApi.Model.Types.Base
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
        public virtual string TypeName() => $"BitSequence<{new T1().TypeName()},{new T2().TypeName()}>";

        public int TypeSize { get; set; }

        [JsonIgnore]
        public byte[] Bytes { get; internal set; }

        public byte[] Encode()
        {
            var result = new List<byte>();
            result.Add(Reverse((byte)Value.Length));
            for (int i = 0; i < Value.Length; i++)
            {
                result.AddRange(Reverse(Value[i].Encode()));
            }
            return result.ToArray();
        }

        public void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            var length = Reverse(byteArray[0]);

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

        public virtual T1[] Value { get; internal set; }

        public void Create(T1[] list)
        {
            Value = list;
            Bytes = Encode();
            TypeSize = CalcTypeSize();
        }
        protected int CalcTypeSize()
        {
            int p = 0;
            _ = CompactInteger.Decode(Bytes, ref p);
            return p + (Value != null ? Value.Sum(x => x.TypeSize) : 0);
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

        public byte[] Reverse(byte[] b)
        {
            byte[] p = new byte[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                p[i] = Reverse(b[i]);
            }
            return p;
        }

        public byte Reverse(byte b)
        {
            int a = 0;
            for (int i = 0; i < 8; i++)
                if ((b & (1 << i)) != 0)
                    a |= 1 << (7 - i);
            return (byte)a;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseBitSeq<T1, T2>) || !obj.GetType().Equals(this.GetType()))
                return false;

            var baseVec = (BaseBitSeq<T1, T2>)obj;
            return TypeSize == baseVec.TypeSize &&
                   (Bytes == null && baseVec.Bytes == null ||
                        Bytes.SequenceEqual(baseVec.Bytes) &&
                        (Value == null && baseVec.Value == null || Value.SequenceEqual(baseVec.Value)));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeSize, Bytes, Value);
        }
    }
}