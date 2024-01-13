using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Substrate.NetApi.Model.Meta
{
    /// <summary>
    /// Node Type
    /// </summary>
    public class NodeType
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonIgnore]
        public uint Id { get; set; }

        /// <summary>
        /// Path
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Path { get; set; }

        /// <summary>
        /// Type Params
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public NodeTypeParam[] TypeParams { get; set; }

        /// <summary>
        /// Type Def Enum
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeDefEnum TypeDef { get; set; }

        /// <summary>
        /// Docs
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Docs { get; set; }
    }

    /// <summary>
    /// Node Type Param
    /// </summary>
    public class NodeTypeParam
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Type Id
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public uint? TypeId { get; set; }
    }

    /// <summary>
    /// Node Type Primitive
    /// </summary>
    public class NodeTypePrimitive : NodeType
    {
        /// <summary>
        /// Primitive
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeDefPrimitive Primitive { get; set; }
    }

    /// <summary>
    /// Node Type Composite
    /// </summary>
    public class NodeTypeComposite : NodeType
    {
        /// <summary>
        /// Type Fields
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public NodeTypeField[] TypeFields { get; set; }
    }

    /// <summary>
    /// Node Type Field
    /// </summary>
    public class NodeTypeField
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Type Name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TypeName { get; set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }

        /// <summary>
        /// Docs
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Docs { get; set; }
    }

    /// <summary>
    /// Node Type Array
    /// </summary>
    public class NodeTypeArray : NodeType
    {
        /// <summary>
        /// Length
        /// </summary>
        public uint Length { get; set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }

    /// <summary>
    /// Node Type Sequence
    /// </summary>
    public class NodeTypeSequence : NodeType
    {
        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }

    /// <summary>
    /// Node Type Compact
    /// </summary>
    public class NodeTypeCompact : NodeType
    {
        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }

    /// <summary>
    /// Node Type Tuple
    /// </summary>
    public class NodeTypeTuple : NodeType
    {
        /// <summary>
        /// Type Ids
        /// </summary>
        public uint[] TypeIds { get; set; }
    }

    /// <summary>
    /// Node Type Bit Sequence
    /// </summary>
    public class NodeTypeBitSequence : NodeType
    {
        /// <summary>
        /// Type Id Store
        /// </summary>
        public uint TypeIdStore { get; set; }

        /// <summary>
        /// Type Id Order
        /// </summary>
        public uint TypeIdOrder { get; set; }
    }

    /// <summary>
    /// Node Type Variant
    /// </summary>
    public class NodeTypeVariant : NodeType
    {
        /// <summary>
        /// Variants
        /// </summary>
        public TypeVariant[] Variants { get; set; }
    }

    /// <summary>
    /// Type Variant
    /// </summary>
    public class TypeVariant
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type Fields
        /// </summary>
        public NodeTypeField[] TypeFields { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Docs
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Docs { get; set; }
    }
    
    /// <summary>
    /// Node Metadata V14
    /// </summary>
    public class NodeMetadataV14
    {
        /// <summary>
        /// Types
        /// </summary>
        public Dictionary<uint, NodeType> Types { get; set; }

        /// <summary>
        /// Modules
        /// </summary>
        public Dictionary<uint, PalletModule> Modules { get; set; }

        /// <summary>
        /// Extrinsic
        /// </summary>
        public ExtrinsicMetadata Extrinsic { get; set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }

    /// <summary>
    /// Signed Extension Metadata
    /// </summary>
    public class SignedExtensionMetadata
    {
        /// <summary>
        /// Signed Identifier
        /// </summary>
        public string SignedIdentifier { get; set; }

        /// <summary>
        /// Signed Ext Type
        /// </summary>
        public uint SignedExtType { get; set; }

        /// <summary>
        /// Add Signed Ext Type
        /// </summary>
        public uint AddSignedExtType { get; set; }
    }

    /// <summary>
    /// Extrinsic Metadata
    /// </summary>
    public class ExtrinsicMetadata
    {
        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Signed Extensions
        /// </summary>
        public SignedExtensionMetadata[] SignedExtensions { get; set; }
    }

    /// <summary>
    /// Pallet Constant
    /// </summary>
    public class PalletConstant
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public byte[] Value { get; set; }

        /// <summary>
        /// Docs
        /// </summary>
        public string[] Docs { get; set; }
    }

    /// <summary>
    /// Pallet Storage
    /// </summary>
    public class PalletStorage
    {
        /// <summary>
        /// Prefix
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Entries
        /// </summary>
        public Entry[] Entries { get; set; }
    }

    /// <summary>
    /// Entry
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Modifier
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Storage.Modifier Modifier { get; set; }

        /// <summary>
        /// Storage Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Storage.Type StorageType { get; set; }

        /// <summary>
        /// Type Map
        /// </summary>
        public (uint, TypeMap) TypeMap { get; set; }
        
        /// <summary>
        /// Default
        /// </summary>
        public byte[] Default { get; set; }

        /// <summary>
        /// Docs
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Docs { get; set; }
    }

    /// <summary>
    /// Type Map
    /// </summary>
    public class TypeMap
    {
        /// <summary>
        /// Hashers
        /// </summary>
        [JsonProperty("Hashers", ItemConverterType = typeof(StringEnumConverter))]
        public Storage.Hasher[] Hashers { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public uint Key { get; set; }
        
        /// <summary>
        /// Value
        /// </summary>
        public uint Value { get; set; }
    }

    /// <summary>
    /// Pallet Module
    /// </summary>
    public class PalletModule
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Storage
        /// </summary>
        public PalletStorage Storage { get; set; }

        /// <summary>
        /// Calls
        /// </summary>
        public PalletCalls Calls { get; set; }

        /// <summary>
        /// Events
        /// </summary>
        public PalletEvents Events { get; set; }

        /// <summary>
        /// Constants
        /// </summary>
        public PalletConstant[] Constants { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public PalletErrors Errors { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public uint Index { get; set; }
    }

    /// <summary>
    /// Pallete Calls
    /// </summary>
    public class PalletCalls
    {
        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }

    /// <summary>
    /// Pallet Events
    /// </summary>
    public class PalletEvents
    {
        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }

    /// <summary>
    /// Pallet Errors
    /// </summary>
    public class PalletErrors
    {
        /// <summary>
        /// Type Id
        /// </summary>
        public uint TypeId { get; set; }
    }
}