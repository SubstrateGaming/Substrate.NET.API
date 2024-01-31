namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// A compact type is a variable-length integer type that is encoded in a variable number of bytes depending on its value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseCom<T> : BaseType where T : IType, new()
    {
        /// <summary>
        /// Explicitly convert a CompactInteger to a BaseCom.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator BaseCom<T>(CompactInteger p) => new BaseCom<T>(p);

        /// <summary>
        /// Implicitly convert a BaseCom to a CompactInteger.
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator CompactInteger(BaseCom<T> p) => p.Value;

        /// <summary>
        /// Construct a new BaseCom.
        /// </summary>
        public BaseCom()
        { }

        /// <summary>
        /// Construct a new BaseCom.
        /// </summary>
        /// <param name="compactInteger"></param>
        public BaseCom(CompactInteger compactInteger)
        {
            Create(compactInteger);
        }

        /// <inheritdoc/>
        public override string TypeName() => $"Compact<{new T().TypeName()}>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Value.Encode();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = CompactInteger.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Value
        /// </summary>
        public virtual CompactInteger Value { get; internal set; }

        /// <summary>
        /// Create a new BaseCom.
        /// </summary>
        /// <param name="compactInteger"></param>
        public void Create(CompactInteger compactInteger)
        {
            Value = compactInteger;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }
    }
}