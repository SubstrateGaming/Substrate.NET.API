namespace Substrate.NetApi.Model.Rpc
{
    public class RuntimeDispatchInfoV1
    {
        public int Weight { get; set; }
        public string @Class { get; set; }
        public string PartialFee { get; set; }
    }
}