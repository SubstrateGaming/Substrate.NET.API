using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V15
{
    public class CustomMetadataV15 : BaseType
    {
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Map = new BaseVec<BaseTuple<Str, CustomValueMetadataV15>>();
            Map.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Map
        /// </summary>
        public BaseVec<BaseTuple<Str, CustomValueMetadataV15>> Map { get; private set; }
    }

    /// <summary>
    /// Custom Value Metadata
    /// </summary>
    public class CustomValueMetadataV15 : BaseType
    {
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            CustomType = new TType();
            CustomType.Decode(byteArray, ref p);

            Value = new BaseVec<U8>();
            Value.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Custom Type
        /// </summary>
        public TType CustomType { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public BaseVec<U8> Value { get; private set; }
    }
}