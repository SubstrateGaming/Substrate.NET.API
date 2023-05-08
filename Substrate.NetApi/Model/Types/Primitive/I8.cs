namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I8 : BasePrim<sbyte>
    {
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