//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.FrameSystem
{
    
    
    /// <summary>
    /// >> 224 - Composite[frame_system.extensions.check_mortality.CheckMortality]
    /// </summary>
    public sealed class CheckMortality : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.SpRuntime.EnumEra _value;
        
        public Ajuna.NetApi.Model.SpRuntime.EnumEra Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        
        public override string TypeName()
        {
            return "CheckMortality";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Ajuna.NetApi.Model.SpRuntime.EnumEra();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}