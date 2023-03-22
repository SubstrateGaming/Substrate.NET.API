using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;

namespace Substrate.NetApi.Model.Rpc
{
    public class Header
    {
        public Digest Digest { get; set; }

        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash ExtrinsicsRoot { get; set; }

        [JsonConverter(typeof(GenericTypeConverter<U64>))]
        public U64 Number { get; set; }

        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash ParentHash { get; set; }

        [JsonConverter(typeof(GenericTypeConverter<Hash>))]
        public Hash StateRoot { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}