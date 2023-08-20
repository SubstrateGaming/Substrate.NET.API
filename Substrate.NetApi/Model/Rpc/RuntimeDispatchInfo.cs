namespace Substrate.NetApi.Model.Rpc
{
    public class RuntimeDispatchInfo
    {
        public Weight Weight { get; set; }
        public string @Class { get; set; }
        public string PartialFee { get; set; }
    }

    public class Weight
    {
        public int Ref_time { get; set; }
        public int Proof_size { get; set; }
    }
}