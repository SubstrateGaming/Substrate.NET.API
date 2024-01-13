namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// I8
    /// </summary>
    public class I8 : BasePrim<sbyte>
    {
        /// <summary>
        /// Explicitly cast a sbyte to a I8
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator I8(sbyte p) => new I8(p);

        /// <summary>
        /// Implicitly cast a I8 to a sbyte
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator sbyte(I8 p) => p.Value;

        /// <summary>
        /// I8 Constructor
        /// </summary>
        public I8()
        { }

        /// <summary>
        /// I8 Constructor
        /// </summary>
        /// <param name="value"></param>
        public I8(sbyte value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "i8";

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
            Value = (sbyte)byteArray[0];
        }

        /// <inheritdoc/>
        public override void Create(sbyte value)
        {
            Bytes = new byte[] { (byte)value };
            Value = value;
        }
    }
}