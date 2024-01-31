using System.Collections.Generic;
using System.Linq;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Hash Type
    /// </summary>
    public class Hash : BasePrim<string>
    {
        /// <summary>
        /// Explicit conversion from byte[] to Hash
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator Hash(byte[] p) => new Hash(p);

        /// <summary>
        /// Implicit conversion from Hash to byte[]
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator byte[](Hash p) => p.Bytes;

        /// <summary>
        /// Hash Constructor
        /// </summary>
        public Hash()
        { }

        /// <summary>
        /// Hash Constructor
        /// </summary>
        /// <param name="value"></param>
        public Hash(string value)
        {
            Create(value);
        }

        /// <summary>
        /// Hash Constructor
        /// </summary>
        /// <param name="value"></param>
        public Hash(byte[] value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "T::Hash";

        /// <inheritdoc/>
        public override int TypeSize => 32;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = Utils.Bytes2HexString(Bytes);
        }

        /// <inheritdoc/>
        public override void Create(string value) => Create(Utils.HexToByteArray(value));
    }
}