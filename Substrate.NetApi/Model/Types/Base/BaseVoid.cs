namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Base Void Type
    /// </summary>
    public class BaseVoid : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "Void";

        /// <inheritdoc/>
        public override int TypeSize => 0;

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            Bytes = new byte[] { };
        }

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return new byte[] { };
        }
    }
}