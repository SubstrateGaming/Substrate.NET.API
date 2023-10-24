using System;
using System.Text;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class PrimChar : BasePrim<char>
    {
        public static explicit operator PrimChar(char p) => new PrimChar(p);

        public static implicit operator char(PrimChar p) => p.Value;

        public PrimChar()
        { }

        public PrimChar(char value)
        {
            Create(value);
        }

        public override string TypeName() => "char";

        public override int TypeSize => 1;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = Encoding.UTF8.GetString(byteArray)[0];
        }

        public override void Create(char value)
        {
            Bytes = Encoding.UTF8.GetBytes(value.ToString());
            Value = value;
        }
    }
}