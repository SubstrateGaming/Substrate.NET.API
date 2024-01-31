using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U32
    /// </summary>
    public class U32 : BasePrim<uint>
    {
        /// <summary>
        /// Explicitly cast a uint to a U32
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U32(uint p) => new U32(p);

        /// <summary>
        /// Implicitly cast a U32 to a uint
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator uint(U32 p) => p.Value;

        /// <summary>
        /// U32 Constructor
        /// </summary>
        public U32()
        { }

        /// <summary>
        /// U32 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U32(uint value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "u32";

        /// <inheritdoc/>
        public override int TypeSize => 4;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void CreateFromJson(string str)
        {
            var bytes = Utils.HexToByteArray(str, true);
            Array.Reverse(bytes);
            var result = new byte[TypeSize];
            bytes.CopyTo(result, 0);
            Create(result);
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            if (byteArray.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                byteArray.CopyTo(newByteArray, 0);
                byteArray = newByteArray;
            }

            Bytes = byteArray;
            Value = BitConverter.ToUInt32(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(uint value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}