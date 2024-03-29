﻿using System;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using static Substrate.NetApi.Model.Meta.Storage;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Runtime Metadata V14
    /// </summary>
    public class RuntimeMetadataV14 : BaseType
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

            Types = new PortableRegistry();
            Types.Decode(byteArray, ref p);

            Modules = new BaseVec<PalletMetadata>();
            Modules.Decode(byteArray, ref p);

            Extrinsic = new ExtrinsicMetadataStruct();
            Extrinsic.Decode(byteArray, ref p);

            TypeId = new TType();
            TypeId.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Types
        /// </summary>
        public PortableRegistry Types { get; private set; }

        /// <summary>
        /// Modules
        /// </summary>
        public BaseVec<PalletMetadata> Modules { get; private set; }

        /// <summary>
        /// Extrinsic
        /// </summary>
        public ExtrinsicMetadataStruct Extrinsic { get; private set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public TType TypeId { get; private set; }
    }

    /// <summary>
    /// Meta Data Info Type
    /// </summary>
    public class MetaDataInfo : BaseType
    {
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode from byte array
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Magic = new U32();
            Magic.Decode(byteArray, ref p);

            Version = new U8();
            Version.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Magic
        /// </summary>
        public U32 Magic { get; private set; }

        /// <summary>
        /// Version
        /// </summary>
        public U8 Version { get; private set; }
    }

    /// <summary>
    /// Palette Metadata
    /// </summary>
    public class PalletMetadata : BaseType
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
    }

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

            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);

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
        /// Documentation
        /// </summary>
        public BaseVec<Str> Documentation { get; private set; }
    }

    /// <summary>
    /// Byte Getter
    /// </summary>
    public class ByteGetter : BaseVec<U8>
    {
    }

    /// <summary>
    /// Storage Entry Type Map
    /// </summary>
    public class StorageEntryTypeMap : BaseType
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

            Hashers = new BaseVec<BaseEnum<Hasher>>();
            Hashers.Decode(byteArray, ref p);

            Key = new TType();
            Key.Decode(byteArray, ref p);

            Value = new TType();
            Value.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Hashers
        /// </summary>
        public BaseVec<BaseEnum<Hasher>> Hashers { get; private set; }

        /// <summary>
        /// Key
        /// </summary>
        public TType Key { get; private set; }
        
        /// <summary>
        /// Value
        /// </summary>
        public TType Value { get; private set; }
    }

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

    /// <summary>
    /// Pallet Constant Metadata
    /// </summary>
    public class PalletConstantMetadata : BaseType
    {
        /// <summary>
        /// Encode to Bytes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode from a byte array at certain position
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ConstantName = new Str();
            ConstantName.Decode(byteArray, ref p);

            ConstantType = new TType();
            ConstantType.Decode(byteArray, ref p);

            ConstantValue = new ByteGetter();
            ConstantValue.Decode(byteArray, ref p);

            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Constant Name
        /// </summary>
        public Str ConstantName { get; private set; }

        /// <summary>
        /// Constant Type
        /// </summary>
        public TType ConstantType { get; private set; }

        /// <summary>
        /// Constant Value
        /// </summary>
        public ByteGetter ConstantValue { get; private set; }

        /// <summary>
        /// Documentation
        /// </summary>
        public BaseVec<Str> Documentation { get; private set; }
    }

    /// <summary>
    /// Error Metadata
    /// </summary>
    public class ErrorMetadata : BaseType
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

            ErrorType = new TType();
            ErrorType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Error Type
        /// </summary>
        public TType ErrorType { get; private set; }
    }

    /// <summary>
    /// Extrinsic Metadata Struct
    /// </summary>
    public class ExtrinsicMetadataStruct : BaseType
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
        /// </summary>
        public Str SignedIdentifier { get; private set; }
        
        /// <summary>
        /// Signed Extension Type
        /// </summary>
        public TType SignedExtType { get; private set; }
        
        /// <summary>
        /// Add Signed Extension Type
        /// </summary>
        public TType AddSignedExtType { get; private set; }
    }
}