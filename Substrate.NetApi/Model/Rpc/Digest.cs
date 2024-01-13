using System.Collections.Generic;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Digest
    /// </summary>
    public class Digest
    {
        /// <summary>
        /// Logs
        /// </summary>
        public IList<string> Logs { get; set; }
    }
}