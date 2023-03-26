namespace Substrate.NetApi.Model.Types.Base
{
    public class BaseCom<T> : BaseType where T : IType, new()
    {
        public BaseCom()
        { }

        public BaseCom(CompactInteger compactInteger)
        {
            Create(compactInteger);
        }

        public override string TypeName() => $"Compact<{new T().TypeName()}>";

        public override byte[] Encode()
        {
            return Value.Encode();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = CompactInteger.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public virtual CompactInteger Value { get; internal set; }

        public void Create(CompactInteger compactInteger)
        {
            Value = compactInteger;
            Bytes = Encode();

            TypeSize = Bytes?.Length ?? 0;
        }
    }
}