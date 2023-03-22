﻿using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;

namespace Substrate.NetApi.Model.Rpc
{
    public class StorageChangeSet
    {
        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash Block { get; set; }

        public string[][] Changes { get; set; }
        //[JsonConverter(typeof(GenericTypeConverter<Vec<RustTuple<StorageKey, StorageData>>>))]
        //public Vec<RustTuple<StorageKey, StorageData>> Changes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// TODO: This needs to be verified, if we can use it to convert straight
    ///
    /// pub struct StorageChangeSet<Hash> {
    ///     pub block: Hash,
    ///     pub changes: Vec<(StorageKey, Option<StorageData>)>,
    /// }
    /// </summary>
    public class NewStorageChangeSet
    {
        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash Block { get; set; }

        [JsonConverter(typeof(GenericTypeConverter<BaseVec<BaseTuple<StorageKey, StorageData>>>))]
        public BaseVec<BaseTuple<StorageKey, StorageData>> Changes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class StorageKey : BaseVec<U8>
    {
        public override string TypeName() => "StorageKey";
    }

    public class StorageData : BaseVec<U8>
    {
        public override string TypeName() => "StorageData";
    }
}