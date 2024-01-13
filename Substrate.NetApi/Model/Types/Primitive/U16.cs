using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U16
    /// </summary>
    public class U16 : BasePrim<ushort>
    {
        /// <summary>
        /// Explicitly cast a ushort to a U16
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U16(ushort p) => new U16(p);

        /// <summary>
        /// Implicitly cast a U16 to a ushort
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator ushort(U16 p) => p.Value;

        /// <summary>
        /// U16 Constructor
        /// </summary>
        public U16()
        { }

        /// <summary>
        /// U16 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U16(ushort value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "u16";

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
            Value = BitConverter.ToUInt16(byteArray, 0);
        }

        /// <inheritdoc/>
        public override void Create(ushort value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }
    }
}