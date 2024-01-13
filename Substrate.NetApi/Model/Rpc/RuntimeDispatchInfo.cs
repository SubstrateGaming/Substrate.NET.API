namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Runtime Dispatch Info
    /// </summary>
    public class RuntimeDispatchInfo
    {
        /// <summary>
        /// Weight
        /// </summary>
        public Weight Weight { get; set; }
        
        /// <summary>
        /// Class
        /// </summary>
        public string @Class { get; set; }
        
        /// <summary>
        /// Partial Fee
        /// </summary>
        public string PartialFee { get; set; }
    }

    /// <summary>
    /// Weight
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// Ref Time
        /// </summary>
        public int Ref_time { get; set; }
        
        /// <summary>
        /// Proof Size
        /// </summary>
        public int Proof_size { get; set; }
    }
}