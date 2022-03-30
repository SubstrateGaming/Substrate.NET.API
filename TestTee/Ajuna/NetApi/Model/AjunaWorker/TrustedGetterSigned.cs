using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.AjunaWorker
{

    public sealed class TrustedGetterSigned : BaseType
    {

        /// <summary>
        /// >> value
        /// </summary>
        private EnumTrustedGetter _getter;

        public EnumTrustedGetter Getter
        {
            get
            {
                return this._getter;
            }
            set
            {
                this._getter = value;
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
            return "TrustedGetterSigned";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Getter.Encode());
            result.AddRange(Signature.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Getter = new EnumTrustedGetter();
            Getter.Decode(byteArray, ref p);

            Signature = new EnumMultiSignature();
            Signature.Decode(byteArray, ref p);

            TypeSize = p - start;
        }
    }

}
