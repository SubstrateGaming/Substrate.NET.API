using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V15
{
    /// <summary>
    /// Palette Metadata
    /// </summary>
    public class PalletMetadataV15 : BaseType
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

            PalletName = new Str();
            PalletName.Decode(byteArray, ref p);

            PalletStorage = new BaseOpt<StorageMetadata>();
            PalletStorage.Decode(byteArray, ref p);

            PalletCalls = new BaseOpt<PalletCallMetadata>();
            PalletCalls.Decode(byteArray, ref p);

            PalletEvents = new BaseOpt<PalletEventMetadata>();
            PalletEvents.Decode(byteArray, ref p);

            PalletConstants = new BaseVec<PalletConstantMetadata>();
            PalletConstants.Decode(byteArray, ref p);

            PalletErrors = new BaseOpt<ErrorMetadata>();
            PalletErrors.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Palette Name
        /// </summary>
        public Str PalletName { get; private set; }

        /// <summary>
        /// Palette Storage
        /// </summary>
        public BaseOpt<StorageMetadata> PalletStorage { get; private set; }

        /// <summary>
        /// Palette Calls
        /// </summary>
        public BaseOpt<PalletCallMetadata> PalletCalls { get; private set; }

        /// <summary>
        /// Palette Events
        /// </summary>
        public BaseOpt<PalletEventMetadata> PalletEvents { get; private set; }

        /// <summary>
        /// Palette Constants
        /// </summary>
        public BaseVec<PalletConstantMetadata> PalletConstants { get; private set; }

        /// <summary>
        /// Palette Errors
        /// </summary>
        public BaseOpt<ErrorMetadata> PalletErrors { get; private set; }

        /// <summary>
        /// Index
        /// </summary>
        public U8 Index { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }
}