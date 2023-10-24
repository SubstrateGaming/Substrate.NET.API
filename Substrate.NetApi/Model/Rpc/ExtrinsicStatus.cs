using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using System;

namespace Substrate.NetApi.Model.Rpc
{
    public enum ExtrinsicState
    {
        Future, Ready, Broadcast, InBlock, Retracted, FinalityTimeout, Finalized, Usurped, Dropped, Invalid
    }

    public class ExtrinsicStatus
    {
        public ExtrinsicState ExtrinsicState { get; set; }
        
        public string[] Broadcast { get; set; }
        
        public Hash Hash { get; set; }

        //public ulong? TxIndex { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}