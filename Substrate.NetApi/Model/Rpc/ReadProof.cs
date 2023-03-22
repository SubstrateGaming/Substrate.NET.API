using Substrate.NetApi.Model.Types.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
