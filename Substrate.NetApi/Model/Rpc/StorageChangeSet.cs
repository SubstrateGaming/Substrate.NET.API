using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Storage Change Set
    /// </summary>
    public class StorageChangeSet
    {
        /// <summary>
        /// Block Hash
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash Block { get; set; }

        /// <summary>
        /// Changes
        /// </summary>
        public string[][] Changes { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// Storage Key
    /// </summary>
    public class StorageKey : BaseVec<U8>
    {
        /// <inheritdoc/>
        public override string TypeName() => "StorageKey";
    }

    /// <summary>
    /// Storage Data
    /// </summary>
    public class StorageData : BaseVec<U8>
    {
        /// <inheritdoc/>
        public override string TypeName() => "StorageData";
    }
}