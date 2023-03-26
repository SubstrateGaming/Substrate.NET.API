using System;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Substrate.NetApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SubstrateNodeTypeAttribute : Attribute
    {
        public TypeDefEnum NodeType { get; set; }

        public SubstrateNodeTypeAttribute(TypeDefEnum nodeType)
        {
            NodeType = nodeType;
        }
    }
}