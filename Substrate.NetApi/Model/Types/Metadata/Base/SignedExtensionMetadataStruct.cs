using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Signed Extension Metadata Struct
    /// </summary>
    public class SignedExtensionMetadataStruct : BaseType
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

            SignedIdentifier = new Str();
            SignedIdentifier.Decode(byteArray, ref p);

            SignedExtType = new TType();
            SignedExtType.Decode(byteArray, ref p);

            AddSignedExtType = new TType();
            AddSignedExtType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Signed Identifier
        /// The unique signed extension identifier, which may be different from the type name.
        /// </summary>
        public Str SignedIdentifier { get; private set; }

        /// <summary>
        /// Signed Extension Type
        /// The type of the signed extension, with the data to be included in the extrinsic.
        /// </summary>
        public TType SignedExtType { get; private set; }

        /// <summary>
        /// Add Signed Extension Type
        /// The type of the additional signed data, with the data to be included in the signed payload
        /// </summary>
        public TType AddSignedExtType { get; private set; }
    }
}