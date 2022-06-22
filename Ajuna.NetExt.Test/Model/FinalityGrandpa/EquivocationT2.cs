//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.FinalityGrandpa;
using Ajuna.NetApi.Model.SpFinalityGrandpa;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.FinalityGrandpa
{
    
    
    /// <summary>
    /// >> 106 - Composite[finality_grandpa.EquivocationT2]
    /// </summary>
    public sealed class EquivocationT2 : BaseType
    {
        
        /// <summary>
        /// >> round_number
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U64 _roundNumber;
        
        /// <summary>
        /// >> identity
        /// </summary>
        private Ajuna.NetApi.Model.SpFinalityGrandpa.Public _identity;
        
        /// <summary>
        /// >> first
        /// </summary>
        private BaseTuple<Ajuna.NetApi.Model.FinalityGrandpa.Precommit,Ajuna.NetApi.Model.SpFinalityGrandpa.Signature> _first;
        
        /// <summary>
        /// >> second
        /// </summary>
        private BaseTuple<Ajuna.NetApi.Model.FinalityGrandpa.Precommit,Ajuna.NetApi.Model.SpFinalityGrandpa.Signature> _second;
        
        public Ajuna.NetApi.Model.Types.Primitive.U64 RoundNumber
        {
            get
            {
                return this._roundNumber;
            }
            set
            {
                this._roundNumber = value;
            }
        }
        
        public Ajuna.NetApi.Model.SpFinalityGrandpa.Public Identity
        {
            get
            {
                return this._identity;
            }
            set
            {
                this._identity = value;
            }
        }
        
        public BaseTuple<Ajuna.NetApi.Model.FinalityGrandpa.Precommit,Ajuna.NetApi.Model.SpFinalityGrandpa.Signature> First
        {
            get
            {
                return this._first;
            }
            set
            {
                this._first = value;
            }
        }
        
        public BaseTuple<Ajuna.NetApi.Model.FinalityGrandpa.Precommit,Ajuna.NetApi.Model.SpFinalityGrandpa.Signature> Second
        {
            get
            {
                return this._second;
            }
            set
            {
                this._second = value;
            }
        }
        
        public override string TypeName()
        {
            return "EquivocationT2";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RoundNumber.Encode());
            result.AddRange(Identity.Encode());
            result.AddRange(First.Encode());
            result.AddRange(Second.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RoundNumber = new Ajuna.NetApi.Model.Types.Primitive.U64();
            RoundNumber.Decode(byteArray, ref p);
            Identity = new Ajuna.NetApi.Model.SpFinalityGrandpa.Public();
            Identity.Decode(byteArray, ref p);
            First = new BaseTuple<Ajuna.NetApi.Model.FinalityGrandpa.Precommit,Ajuna.NetApi.Model.SpFinalityGrandpa.Signature>();
            First.Decode(byteArray, ref p);
            Second = new BaseTuple<Ajuna.NetApi.Model.FinalityGrandpa.Precommit,Ajuna.NetApi.Model.SpFinalityGrandpa.Signature>();
            Second.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
