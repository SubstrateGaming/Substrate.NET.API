using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Header
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Digest
        /// </summary>
        public Digest Digest { get; set; }

        /// <summary>
        /// Extrinsics Root
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash ExtrinsicsRoot { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<U64>))]
        public U64 Number { get; set; }

        /// <summary>
        /// Parent Hash
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash ParentHash { get; set; }

        /// <summary>
        /// State Root
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash StateRoot { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}