using Substrate.NetApi.Model.Types.Base;
using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Rpc
{
    public enum ExtrinsicState
    {
        None, Future, Ready, Dropped, Invalid
    }

    public class ExtrinsicStatus
    {
        public ExtrinsicState ExtrinsicState { get; set; }
        public string[] Broadcast { get; set; }
        public Hash InBlock { get; set; }
        public Hash Retracted { get; set; }
        public Hash FinalityTimeout { get; set; }
        public Hash Finalized { get; set; }
        public Hash Usurped { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}