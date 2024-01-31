using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// I64
    /// </summary>
    public class I64 : BasePrim<long>
    {
        /// <summary>
        /// Explicitly cast a long to a I64
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I64(long p) => new I64(p);

        /// <summary>
        /// Implicitly cast a I64 to a long
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator long(I64 p) => p.Value;

        /// <summary>
        /// I64 Constructor
        /// </summary>
        public I64()
        { }

        /// <summary>
        /// I64 Constructor
        /// </summary>
        /// <param name="value"></param>
        public I64(long value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "i64";

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
            Value = BitConverter.ToInt64(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(long value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}