using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.AjunaWorker
{

    public sealed class Request : BaseType
    {
        private H256 _shard;

        public H256 Shard
        {
            get
            {
                return this._shard;
            }
            set
            {
                this._shard = value;
            }
        }

        private BaseVec<U8> _cypherText;

        public BaseVec<U8> CypherText
        {
            get
            {
                return this._cypherText;
            }
            set
            {
                this._cypherText = value;
            }
        }

        public override string TypeName()
        {
            return "Request";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Shard.Encode());
            result.AddRange(CypherText.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Shard = new H256();
            Shard.Decode(byteArray, ref p);

            CypherText = new BaseVec<U8>();
            CypherText.Decode(byteArray, ref p);

            TypeSize = p - start;
        }
    }

}
