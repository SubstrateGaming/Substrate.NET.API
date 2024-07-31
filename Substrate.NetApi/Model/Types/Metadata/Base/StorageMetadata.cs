using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Storage Metadata
    /// </summary>
    public class StorageMetadata : BaseType
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

            Prefix = new Str();
            Prefix.Decode(byteArray, ref p);

            Entries = new BaseVec<StorageEntryMetadata>();
            Entries.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Prefix
        /// </summary>
        public Str Prefix { get; private set; }

        /// <summary>
        /// Entries
        /// </summary>
        public BaseVec<StorageEntryMetadata> Entries { get; private set; }
    }
}