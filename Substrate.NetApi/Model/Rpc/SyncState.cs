using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Sync State
    /// </summary>
    public class SyncState
    {
        /// <summary>
        /// Starting Block
        /// </summary>
        public int StartingBlock { get; set; }
        
        /// <summary>
        /// Current Block
        /// </summary>
        public int CurrentBlock { get; set; }
        
        /// <summary>
        /// Highest Block
        /// </summary>
        public int HighestBlock { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}