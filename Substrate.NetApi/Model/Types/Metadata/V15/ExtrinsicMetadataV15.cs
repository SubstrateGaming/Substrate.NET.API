using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Extrinsic Metadata Struct
    /// </summary>
    public class ExtrinsicMetadataV15 : BaseType
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

            Version = new U8();
            Version.Decode(byteArray, ref p);

            AddressType = new TType();
            AddressType.Decode(byteArray, ref p);

            CallType = new TType();
            CallType.Decode(byteArray, ref p);

            SignatureType = new TType();
            SignatureType.Decode(byteArray, ref p);

            ExtraType = new TType();
            ExtraType.Decode(byteArray, ref p);

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
        /// Address Type
        /// </summary>
        public TType AddressType { get; private set; }

        /// <summary>
        /// Call Type
        /// </summary>
        public TType CallType { get; private set; }

        /// <summary>
        /// Signature Type
        /// </summary>
        public TType SignatureType { get; private set; }

        /// <summary>
        /// Extra Type
        /// </summary>
        public TType ExtraType { get; private set; }

        /// <summary>
        /// Signed Extensions
        /// </summary>
        public BaseVec<SignedExtensionMetadataStruct> SignedExtensions { get; private set; }
    }
}