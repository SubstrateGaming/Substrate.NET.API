using System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Substrate.NetApi.Model.Types.Metadata
{
    /// <summary>
    /// Runtime Metadata Type
    /// </summary>
    public class RuntimeMetadata : BaseType
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

            RuntimeMetadataData = new RuntimeMetadataV14();
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
        public RuntimeMetadataV14 RuntimeMetadataData { get; private set; }
    }
}