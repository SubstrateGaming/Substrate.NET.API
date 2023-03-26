using System.Collections.Generic;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Rpc
{
    public class ReadProof
    {
        public Hash At { get; set; }

        public IEnumerable<Hash> Proof { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}