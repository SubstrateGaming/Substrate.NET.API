namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// Bool Type
    /// </summary>
    public class Bool : BasePrim<bool>
    {
        /// <summary>
        /// Explicit conversion to Bool
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator Bool(bool p) => new Bool(p);

        /// <summary>
        /// Implicit conversion to bool
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator bool(Bool p) => p.Value;

        /// <summary>
        /// Bool Constructor
        /// </summary>
        public Bool()
        { }

        /// <summary>
        /// Bool Constructor
        /// </summary>
        /// <param name="value"></param>
        public Bool(bool value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "bool";

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
            Value = byteArray[0] > 0;
        }

        /// <inheritdoc/>
        public override void Create(bool value)
        {
            Bytes = new byte[] { (byte)(value ? 0x01 : 0x00) };
            Value = value;
        }
    }
}