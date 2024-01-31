namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// U8
    /// </summary>
    public class U8 : BasePrim<byte>
    {
        /// <summary>
        /// Explicitly cast a byte to a U8
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator U8(byte p) => new U8(p);

        /// <summary>
        /// Implicitly cast a U8 to a byte
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator byte(U8 p) => p.Value;

        /// <summary>
        /// U8 Constructor
        /// </summary>
        public U8()
        { }

        /// <summary>
        /// U8 Constructor
        /// </summary>
        /// <param name="value"></param>
        public U8(byte value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "u8";

        /// <inheritdoc/>
        public override int TypeSize => 1;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = byteArray[0];
        }

        /// <inheritdoc/>
        public override void Create(byte value)
        {
            Bytes = new byte[] { value };
            Value = value;
        }
    }
}