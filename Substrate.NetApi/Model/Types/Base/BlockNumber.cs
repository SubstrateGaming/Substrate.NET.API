using System;

namespace Substrate.NetApi.Model.Types.Base
{
    public class BlockNumber : BasePrim<uint>
    {
        public static explicit operator BlockNumber(uint p) => new BlockNumber(p);

        public static implicit operator uint(BlockNumber p) => p.Value;

        public BlockNumber()
        { }

        public BlockNumber(uint value)
        {
            Create(value);
        }

        public override string TypeName() => "T::BlockNumber";

        public override int TypeSize => 4;

        public override byte[] Encode()
        {
            var reversed = Bytes;
            Array.Reverse(reversed);
            return reversed;
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = BitConverter.ToUInt32(byteArray, 0);
        }

        public override void Create(uint value)
        {
            Bytes = BitConverter.GetBytes(value);
            Value = value;
        }
    }
}