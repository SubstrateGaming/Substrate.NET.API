using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Rpc
{
    public class SyncState
    {
        public int StartingBlock { get; set; }
        public int CurrentBlock { get; set; }
        public int HighestBlock { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}