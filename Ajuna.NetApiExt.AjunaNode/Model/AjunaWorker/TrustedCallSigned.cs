using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.AjunaWorker
{

    public sealed class TrustedCallSigned : BaseVoid
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

        private EnumMultiSignature _signature;

        public EnumMultiSignature Signature
        {
            get
            {
                return this._signature;
            }
            set
            {
                this._signature = value;
            }
        }

        public override string TypeName()
        {
            return "TrustedCallSigned";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Call.Encode());
            result.AddRange(Nonce.Encode());
            result.AddRange(Signature.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Call = new EnumTrustedCall();
            Call.Decode(byteArray, ref p);

            Nonce = new Index();
            Nonce.Decode(byteArray, ref p);

            Signature = new EnumMultiSignature();
            Signature.Decode(byteArray, ref p);

            TypeSize = p - start;
        }
    }
}