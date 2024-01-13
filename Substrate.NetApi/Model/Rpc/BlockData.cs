using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Block Data
    /// </summary>
    public class BlockData
    {
        /// <summary>
        /// Block Data Constructor
        /// </summary>
        /// <param name="block"></param>
        /// <param name="justification"></param>
        public BlockData(Block block, object justification)
        {
            Block = block;
            Justification = justification;
        }

        /// <summary>
        /// Block
        /// </summary>
        public Block Block { get; set; }
        
        /// <summary>
        /// Justification
        /// </summary>
        public object Justification { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}