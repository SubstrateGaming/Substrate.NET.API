using System;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Types
{
    public abstract class BasePrim<T> : BaseType
    {
        protected BasePrim()
        { }

        protected BasePrim(T value)
        {
            Create(value);
        }

        public abstract void Create(T value);

        public override void Decode(byte[] byteArray, ref int p)
        {
            var memory = byteArray.AsMemory();
            var result = memory.Span.Slice(p, TypeSize).ToArray();
            p += TypeSize;
            Create(result);
        }

        public override string ToString() => this.Value.ToString();

        public T Value { get; set; }
    }
}