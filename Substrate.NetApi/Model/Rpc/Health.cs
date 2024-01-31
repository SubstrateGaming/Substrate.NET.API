using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Health
    /// </summary>
    public class Health
    {
        /// <summary>
        /// Is Syncing
        /// </summary>
        public bool IsSyncing { get; set; }
        
        /// <summary>
        /// Peers
        /// </summary>
        public int Peers { get; set; }
        
        /// <summary>
        /// Should Have Peers
        /// </summary>
        public bool ShouldHavePeers { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}