using Substrate.NetApi.Model.Types.Base;
using System;

namespace Substrate.NetApi.Model.Types
{
    /// <summary>
    /// Abstract Base Primitive Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePrim<T> : BaseType
    {
        /// <summary>
        /// Base Primitive Constructor
        /// </summary>
        protected BasePrim()
        { }

        /// <summary>
        /// Base Primitive Constructor
        /// </summary>
        /// <param name="value"></param>
        protected BasePrim(T value)
        {
            Create(value);
        }

        /// <summary>
        /// Base Primitive Create
        /// </summary>
        /// <param name="value"></param>
        public abstract void Create(T value);

        /// <summary>
        /// Base Primitive Decode
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var memory = byteArray.AsMemory();
            var result = memory.Span.Slice(p, TypeSize).ToArray();
            p += TypeSize;
            Create(result);
        }

        /// <summary>
        /// Base Primitive to string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => this.Value.ToString();

        /// <summary>
        /// Base Primitive Value
        /// </summary>
        public T Value { get; set; }
    }
}