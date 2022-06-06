using Ajuna.NetApi.Model.Types.Metadata.V14;
using System;

namespace Ajuna.NetApi.Attributes
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
