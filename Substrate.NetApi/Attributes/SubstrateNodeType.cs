using System;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Substrate.NetApi.Attributes
{
    /// <summary>
    /// Substrate Node Type Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SubstrateNodeTypeAttribute : Attribute
    {
        /// <summary>
        /// Node Type
        /// </summary>
        public TypeDefEnum NodeType { get; set; }

        /// <summary>
        /// Substrate Node Type Attribute
        /// </summary>
        /// <param name="nodeType"></param>
        public SubstrateNodeTypeAttribute(TypeDefEnum nodeType)
        {
            NodeType = nodeType;
        }
    }
}