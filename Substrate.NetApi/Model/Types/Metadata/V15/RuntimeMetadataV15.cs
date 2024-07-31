using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Metadata.Base.Portable;
using Substrate.NetApi.Model.Types.Metadata.V15;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Runtime Metadata V14
    /// </summary>
    public class RuntimeMetadataV15 : BaseType
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

            Types = new PortableRegistry();
            Types.Decode(byteArray, ref p);

            Modules = new BaseVec<PalletMetadataV15>();
            Modules.Decode(byteArray, ref p);

            Extrinsic = new ExtrinsicMetadataV15();
            Extrinsic.Decode(byteArray, ref p);

            TypeId = new TType();
            TypeId.Decode(byteArray, ref p);

            Apis = new BaseVec<RuntimeApiMetadataV15>();
            Apis.Decode(byteArray, ref p);

            OuterEnums = new OuterEnumsV15();
            OuterEnums.Decode(byteArray, ref p);

            Custom = new CustomMetadataV15();
            Custom.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Types
        /// </summary>
        public PortableRegistry Types { get; private set; }

        /// <summary>
        /// Modules
        /// </summary>
        public BaseVec<PalletMetadataV15> Modules { get; private set; }

        /// <summary>
        /// Extrinsic
        /// </summary>
        public ExtrinsicMetadataV15 Extrinsic { get; private set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public TType TypeId { get; private set; }

        /// <summary>
        /// Apis
        /// </summary>
        public BaseVec<RuntimeApiMetadataV15> Apis { get; private set; }

        /// <summary>
        /// OuterEnums
        /// </summary>
        public OuterEnumsV15 OuterEnums { get; private set; }

        /// <summary>
        /// Custom
        /// </summary>
        public CustomMetadataV15 Custom { get; private set; }
    }
}