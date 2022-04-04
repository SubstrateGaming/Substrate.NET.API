using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajuna.NetApi.Model.AjunaWorker
{
    public class RSAPubKey
    {
        public List<byte> N;
        public List<byte> E;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
