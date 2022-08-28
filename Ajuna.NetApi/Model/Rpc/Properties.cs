using Newtonsoft.Json;

namespace Ajuna.NetApi.Model.Rpc
{
    public class Properties
    {
        public int Ss58Format { get; set; }
        public int TokenDecimals { get; set; }
        public string TokenSymbol { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
