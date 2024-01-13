using Substrate.NetApi.Model.Extrinsics;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Block
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Extrinsics
        /// </summary>
        public Extrinsic[] Extrinsics { get; set; }
        
        /// <summary>
        /// Header
        /// </summary>
        public Header Header { get; set; }
    }
}