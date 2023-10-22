using System.Collections.Generic;
using System.Linq;

namespace Substrate.NetApi.Model.Types.Base
{
    public class Hash : BasePrim<string>
    {
        public static explicit operator Hash(byte[] p) => new Hash(p);

        public static implicit operator byte[](Hash p) => p.Bytes;

        public Hash()
        { }

        public Hash(string value)
        {
            Create(value);
        }

        public Hash(byte[] value)
        {
            Create(value);
        }

        public override string TypeName() => "T::Hash";

        public override int TypeSize => 32;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = Utils.Bytes2HexString(Bytes);
        }

        public override void Create(string value) => Create(Utils.HexToByteArray(value));
    }
}