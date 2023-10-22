namespace Substrate.NetApi.Model.Types.Primitive
{
    public class Bool : BasePrim<bool>
    {
        public static explicit operator Bool(bool p) => new Bool(p);

        public static implicit operator bool(Bool p) => p.Value;

        public Bool()
        { }

        public Bool(bool value)
        {
            Create(value);
        }

        public override string TypeName() => "bool";

        public override int TypeSize => 1;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = byteArray[0] > 0;
        }

        public override void Create(bool value)
        {
            Bytes = new byte[] { (byte)(value ? 0x01 : 0x00) };
            Value = value;
        }
    }
}