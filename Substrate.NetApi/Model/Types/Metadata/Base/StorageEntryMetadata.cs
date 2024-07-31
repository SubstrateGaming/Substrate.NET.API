using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using static Substrate.NetApi.Model.Meta.Storage;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Storage Entry Metadata
    /// </summary>
    public class StorageEntryMetadata : BaseType
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

            StorageName = new Str();
            StorageName.Decode(byteArray, ref p);

            StorageModifier = new BaseEnum<Modifier>();
            StorageModifier.Decode(byteArray, ref p);

            StorageType = new BaseEnumExt<Storage.Type, TType, StorageEntryTypeMap>();
            StorageType.Decode(byteArray, ref p);

            StorageDefault = new ByteGetter();
            StorageDefault.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Storage Name
        /// </summary>
        public Str StorageName { get; private set; }

        /// <summary>
        /// Storage Modifier
        /// </summary>
        public BaseEnum<Modifier> StorageModifier { get; private set; }

        /// <summary>
        /// Storage Type
        /// </summary>
        public BaseEnumExt<Storage.Type, TType, StorageEntryTypeMap> StorageType { get; private set; }

        /// <summary>
        /// Storage Default
        /// </summary>
        public ByteGetter StorageDefault { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }
}