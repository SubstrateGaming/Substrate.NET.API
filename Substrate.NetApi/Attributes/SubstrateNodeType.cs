using System;
using Substrate.NetApi.Model.Types.Metadata.Base;

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