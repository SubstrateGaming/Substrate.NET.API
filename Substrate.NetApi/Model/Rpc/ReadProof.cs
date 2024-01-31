using System.Collections.Generic;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Read Proof
    /// </summary>
    public class ReadProof
    {
        /// <summary>
        /// At
        /// </summary>
        public Hash At { get; set; }

        /// <summary>
        /// Proof
        /// </summary>
        public IEnumerable<Hash> Proof { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}