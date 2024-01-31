using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// I16 Type
    /// </summary>
    public class I16 : BasePrim<short>
    {
        /// <summary>
        /// Explicit conversion to I16
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I16(short p) => new I16(p);

        /// <summary>
        /// Implicit conversion to short
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator short(I16 p) => p.Value;

        /// <summary>
        /// I16 Constructor
        /// </summary>
        public I16()
        { }

        /// <summary>
        /// I16 Constructor
        /// </summary>
        /// <param name="value"></param>
        public I16(short value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "i16";

        /// <inheritdoc/>
        public override int TypeSize => 2;

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
            Value = BitConverter.ToInt16(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(short value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}