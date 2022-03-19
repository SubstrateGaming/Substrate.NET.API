using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTee.Model
{
    class TestRSA
    {
        public List<byte> N;
        public List<byte> E;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
