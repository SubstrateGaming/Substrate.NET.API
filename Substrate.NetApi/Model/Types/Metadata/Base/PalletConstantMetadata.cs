using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Pallet Constant Metadata
    /// </summary>
    public class PalletConstantMetadata : BaseType
    {
        /// <summary>
        /// Encode to Bytes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode from a byte array at certain position
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ConstantName = new Str();
            ConstantName.Decode(byteArray, ref p);

            ConstantType = new TType();
            ConstantType.Decode(byteArray, ref p);

            ConstantValue = new ByteGetter();
            ConstantValue.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Constant Name
        /// </summary>
        public Str ConstantName { get; private set; }

        /// <summary>
        /// Constant Type
        /// </summary>
        public TType ConstantType { get; private set; }

        /// <summary>
        /// Constant Value
        /// </summary>
        public ByteGetter ConstantValue { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }
}