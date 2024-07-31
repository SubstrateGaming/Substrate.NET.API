using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System;

namespace Substrate.NetApi.Model.Types.Metadata
{
    /// <summary>
    /// Runtime Metadata Type
    /// </summary>
    public class RuntimeMetadata<T> : BaseType where T : BaseType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => "RuntimeMetadata";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            MetaDataInfo = new MetaDataInfo();
            MetaDataInfo.Decode(byteArray, ref p);

            RuntimeMetadataData = new T();
            RuntimeMetadataData.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Meta Data Info
        /// </summary>
        public MetaDataInfo MetaDataInfo { get; private set; }

        /// <summary>
        /// Runtime Metadata Data
        /// </summary>
        public T RuntimeMetadataData { get; private set; }
    }
}