using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Runtime API Metadata
    /// </summary>
    public class RuntimeApiMetadataV15 : BaseType
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

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Methods = new BaseVec<RuntimeApiMethodMetadataV15>();
            Methods.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Name
        /// </summary>
        public Str Name { get; private set; }

        /// <summary>
        /// Methods
        /// </summary>
        public BaseVec<RuntimeApiMethodMetadataV15> Methods { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }

    /// <summary>
    /// Runtime API Method Metadata
    /// </summary>
    public class RuntimeApiMethodMetadataV15 : BaseType
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

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Inputs = new BaseVec<RuntimeApiMethodParamMetadataV15>();
            Inputs.Decode(byteArray, ref p);

            Output = new TType();
            Output.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Name
        /// </summary>
        public Str Name { get; private set; }

        /// <summary>
        /// Inputs
        /// </summary>
        public BaseVec<RuntimeApiMethodParamMetadataV15> Inputs { get; private set; }

        /// <summary>
        /// Output
        /// </summary>
        public TType Output { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }

    /// <summary>
    /// Runtime API Method Param Metadata
    /// </summary>
    public class RuntimeApiMethodParamMetadataV15 : BaseType
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

            Name = new Str();
            Name.Decode(byteArray, ref p);

            TypeId = new TType();
            TypeId.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Name
        /// </summary>
        public Str Name { get; private set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public TType TypeId { get; private set; }
    }
}