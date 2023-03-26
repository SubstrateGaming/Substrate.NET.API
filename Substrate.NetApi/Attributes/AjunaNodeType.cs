using System;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Substrate.NetApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AjunaNodeTypeAttribute : Attribute
    {
        public TypeDefEnum NodeType { get; set; }

        public AjunaNodeTypeAttribute(TypeDefEnum nodeType)
        {
            NodeType = nodeType;
        }
    }
}