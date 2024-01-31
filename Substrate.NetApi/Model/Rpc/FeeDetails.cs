using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Fee Details
    /// </summary>
    public class FeeDetails
    {
        /// <summary>
        /// Inclusion Fee
        /// </summary>
        public InclusionFee InclusionFee { get; set; }
    }

    /// <summary>
    /// Inclusion Fee
    /// </summary>
    public class InclusionFee
    {
        /// <summary>
        /// Base Fee
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<U128>))]
        public U128 BaseFee { get; set; }

        /// <summary>
        /// Len Fee
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<U128>))]
        public U128 LenFee { get; set; }

        /// <summary>
        /// Adjusted Weight Fee
        /// </summary>
        [JsonConverter(typeof(GenericTypeConverter<U128>))]
        public U128 AdjustedWeightFee { get; set; }
    }
}