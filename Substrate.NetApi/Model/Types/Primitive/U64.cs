using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U64
    /// </summary>
    public class U64 : BasePrim<ulong>
    {
        /// <summary>
        /// Explicitly cast a ulong to a U64
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U64(ulong p) => new U64(p);

        /// <summary>
        /// Implicitly cast a U64 to a ulong
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator ulong(U64 p) => p.Value;

        /// <summary>
        /// U64 Constructor
        /// </summary>
        public U64()
        { }

        /// <summary>
        /// U64 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U64(ulong value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "u64";

        /// <inheritdoc/>
        public override int TypeSize => 8;

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
            Value = BitConverter.ToUInt64(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(ulong value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}