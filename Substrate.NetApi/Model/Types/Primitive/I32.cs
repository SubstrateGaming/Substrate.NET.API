using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// I32
    /// </summary>
    public class I32 : BasePrim<int>
    {
        /// <summary>
        /// Explicitly cast a int to a I32
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I32(int p) => new I32(p);

        /// <summary>
        /// Implicitly cast a I32 to a int
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator int(I32 p) => p.Value;

        /// <summary>
        /// I32 Constructor
        /// </summary>
        public I32()
        { }

        /// <summary>
        /// I32 Constructor
        /// </summary>
        /// <param name="value"></param>
        public I32(int value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "i32";

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
            Value = BitConverter.ToInt32(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(int value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}