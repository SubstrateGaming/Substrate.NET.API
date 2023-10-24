namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I8 : BasePrim<sbyte>
    {
        public static explicit operator I8(sbyte p) => new I8(p);

        public static implicit operator sbyte(I8 p) => p.Value;

        public I8()
        { }

        public I8(sbyte value)
        {
            Create(value);
        }

        public override string TypeName() => "i8";

        public override int TypeSize => 1;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = (sbyte)byteArray[0];
        }

        public override void Create(sbyte value)
        {
            Bytes = new byte[] { (byte)value };
            Value = value;
        }
    }
}