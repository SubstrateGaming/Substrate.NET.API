//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.FrameSystem
{
    
    
    /// <summary>
    /// >> 213 - Composite[frame_system.extensions.check_spec_version.CheckSpecVersion]
    /// </summary>
    public sealed class CheckSpecVersion : BaseType
    {
        
        public override string TypeName()
        {
            return "CheckSpecVersion";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TypeSize = p - start;
        }
    }
}
