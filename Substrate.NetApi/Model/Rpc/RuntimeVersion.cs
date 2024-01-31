namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Runtime Version
    /// </summary>
    public class RuntimeVersion
    {
        /// <summary>
        /// Apis
        /// </summary>
        public object[][] Apis { get; set; }
        
        /// <summary>
        /// Authoring Version
        /// </summary>
        public int AuthoringVersion { get; set; }
        
        /// <summary>
        /// Impl Name
        /// </summary>
        public string ImplName { get; set; }
        
        /// <summary>
        /// Impl Version
        /// </summary>
        public uint ImplVersion { get; set; }
        
        /// <summary>
        /// Spec Name
        /// </summary>
        public string SpecName { get; set; }
        
        /// <summary>
        /// Spec Version
        /// </summary>
        public uint SpecVersion { get; set; }
        
        /// <summary>
        /// Transaction Version
        /// </summary>
        public uint TransactionVersion { get; set; }
    }
}