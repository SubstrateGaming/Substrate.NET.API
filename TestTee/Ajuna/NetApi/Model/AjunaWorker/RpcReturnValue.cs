using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System.Collections.Generic;


namespace Ajuna.NetApi.Model.AjunaWorker
{
    public sealed class RpcReturnValue : BaseType
    {

        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<U8> _value;

        public Ajuna.NetApi.Model.Types.Base.BaseVec<U8> Value
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


        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.Bool _doWatch;

        public Ajuna.NetApi.Model.Types.Primitive.Bool DoWatch
        {
            get
            {
                return this._doWatch;
            }
            set
            {
                this._doWatch = value;
            }
        }

        /// <summary>
        /// >> value
        /// </summary>
        private EnumDirectRequestStatus _directRequestStatus;

        public EnumDirectRequestStatus DirectRequestStatus
        {
            get
            {
                return this._directRequestStatus;
            }
            set
            {
                this._directRequestStatus = value;
            }
        }

        public override string TypeName()
        {
            return "RpcReturnValue";
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
            Value = new Ajuna.NetApi.Model.Types.Base.BaseVec<U8>();
            Value.Decode(byteArray, ref p);

            DoWatch = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            DoWatch.Decode(byteArray, ref p);

            DirectRequestStatus = new EnumDirectRequestStatus();
            DirectRequestStatus.Decode(byteArray, ref p);

            TypeSize = p - start;
        }
    }
}
