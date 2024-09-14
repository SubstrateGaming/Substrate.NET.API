using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Palette Event Metadata
    /// </summary>
    public class PalletEventMetadata : BaseType
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

            EventType = new TType();
            EventType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Event Type
        /// </summary>
        public TType EventType { get; private set; }
    }
}