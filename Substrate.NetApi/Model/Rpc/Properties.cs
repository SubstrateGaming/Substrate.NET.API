using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Properties
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// SS58 Format
        /// </summary>
        public int Ss58Format { get; set; }
        
        /// <summary>
        /// Token Decimals
        /// </summary>
        public int TokenDecimals { get; set; }
        
        /// <summary>
        /// Token Symbol
        /// </summary>
        public string TokenSymbol { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}