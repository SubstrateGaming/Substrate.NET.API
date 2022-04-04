
using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System.Collections.Generic;

namespace Ajuna.NetApi.Model.AjunaWorker
{
    public class TrustedCallPayload : BaseType
    {

        private EnumTrustedCall _call;

        public EnumTrustedCall Call
        {
            get
            {
                return this._call;
            }
            set
            {
                this._call = value;
            }
        }

        private Index _nonce;

        public Index Nonce
        {
            get
            {
                return this._nonce;
            }
            set
            {
                this._nonce = value;
            }
        }

        private H256 _mrenclave;

        public H256 Mrenclave
        {
            get
            {
                return this._mrenclave;
            }
            set
            {
                this._mrenclave = value;
            }
        }

        private ShardIdentifier _shard;

        public ShardIdentifier Shard
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

        public override string TypeName()
        {
            return "TrustedCallPayload";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Call.Encode());
            result.AddRange(Nonce.Encode());
            result.AddRange(Mrenclave.Encode());
            result.AddRange(Shard.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Call = new EnumTrustedCall();
            Call.Decode(byteArray, ref p);

            Nonce = new Index();
            Nonce.Decode(byteArray, ref p);

            Mrenclave = new H256();
            Mrenclave.Decode(byteArray, ref p);

            Shard = new ShardIdentifier();
            Shard.Decode(byteArray, ref p);

            TypeSize = p - start;
        }
    }
}