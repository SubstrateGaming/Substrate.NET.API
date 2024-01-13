using System;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// BlockNumber Type
    /// </summary>
    public class BlockNumber : BasePrim<uint>
    {
        /// <summary>
        /// Explicit conversion to BlockNumber
        /// </summary>
        /// <param name="p"></param>

        public static explicit operator BlockNumber(uint p) => new BlockNumber(p);

        /// <summary>
        /// Implicit conversion to uint
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator uint(BlockNumber p) => p.Value;

        /// <summary>
        /// BlockNumber Constructor
        /// </summary>
        public BlockNumber()
        { }

        /// <summary>
        /// BlockNumber Constructor
        /// </summary>
        /// <param name="value"></param>
        public BlockNumber(uint value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "T::BlockNumber";

        /// <inheritdoc/>
        public override int TypeSize => 4;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var reversed = Bytes;
            Array.Reverse(reversed);
            return reversed;
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = BitConverter.ToUInt32(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(uint value)
        {
            Bytes = BitConverter.GetBytes(value);
            Value = value;
        }
    }
}