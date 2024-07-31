using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Extrinsic Metadata Struct
    /// </summary>
    public class ExtrinsicMetadataV14 : BaseType
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

            ExtrinsicType = new TType();
            ExtrinsicType.Decode(byteArray, ref p);

            Version = new U8();
            Version.Decode(byteArray, ref p);

            SignedExtensions = new BaseVec<SignedExtensionMetadataStruct>();
            SignedExtensions.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Extrinsic Type
        /// </summary>
        public TType ExtrinsicType { get; private set; }

        /// <summary>
        /// Version
        /// </summary>
        public U8 Version { get; private set; }

        /// <summary>
        /// Signed Extensions
        /// </summary>
        public BaseVec<SignedExtensionMetadataStruct> SignedExtensions { get; private set; }
    }
}