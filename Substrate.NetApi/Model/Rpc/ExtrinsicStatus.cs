using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using System;

namespace Substrate.NetApi.Model.Rpc
{
    /// <summary>
    /// Extrinsic State
    /// </summary>
    public enum ExtrinsicState
    {
        /// <summary>
        /// Future
        /// </summary>
        Future, 
        
        /// <summary>
        /// Ready
        /// </summary>
        Ready, 
        
        /// <summary>
        /// Broadcast
        /// </summary>
        Broadcast, 
        
        /// <summary>
        /// InBlock
        /// </summary>
        InBlock, 
        
        /// <summary>
        /// Retracted
        /// </summary>
        Retracted, 
        
        /// <summary>
        /// FinalityTimeout
        /// </summary>
        FinalityTimeout, 
        
        /// <summary>
        /// Finalized
        /// </summary>
        Finalized, 
        
        /// <summary>
        /// Usurped
        /// </summary>
        Usurped, 
        
        /// <summary>
        /// Dropped
        /// </summary>
        Dropped, 
        
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid
    }

    /// <summary>
    /// Extrinsic Status
    /// </summary>
    public class ExtrinsicStatus
    {
        /// <summary>
        /// Extrinsic State
        /// </summary>
        public ExtrinsicState ExtrinsicState { get; set; }
        
        /// <summary>
        /// Broadcast
        /// </summary>
        public string[] Broadcast { get; set; }
        
        /// <summary>
        /// Hash
        /// </summary>
        public Hash Hash { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}