using Newtonsoft.Json;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;

namespace Substrate.NetApi.Model.Rpc
{
    public class FeeDetails
    {
        public InclusionFee InclusionFee { get; set; }
    }

    public class InclusionFee
    {
        [JsonConverter(typeof(GenericTypeConverter<U128>))]
        public U128 BaseFee { get; set; }
        [JsonConverter(typeof(GenericTypeConverter<U128>))]
        public U128 LenFee { get; set; }
        [JsonConverter(typeof(GenericTypeConverter<U128>))]
        public U128 AdjustedWeightFee { get; set; }
    }
}