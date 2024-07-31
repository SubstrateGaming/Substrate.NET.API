using Substrate.NetApi.Model.Types.Base;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Pallet Call Metadata
    /// </summary>
    public class PalletCallMetadata : BaseType
    {
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            CallType = new TType();
            CallType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Call Type
        /// </summary>
        public TType CallType { get; private set; }
    }
}