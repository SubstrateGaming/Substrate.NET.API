using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Type Portable Form
    /// </summary>
    public class TypePortableForm : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "Type<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Path = new Path();
            Path.Decode(byteArray, ref p);

            TypeParams = new BaseVec<TypeParameter>();
            TypeParams.Decode(byteArray, ref p);

            // Update to use BaseEnumRust
            var typeDecoderMap = new Dictionary<TypeDefEnum, Type>
            {
                { TypeDefEnum.Composite, typeof(TypeDefComposite) },
                { TypeDefEnum.Variant, typeof(TypeDefVariant) },
                { TypeDefEnum.Sequence, typeof(TypeDefSequence) },
                { TypeDefEnum.Array, typeof(TypeDefArray) },
                { TypeDefEnum.Tuple, typeof(TypeDefTuple) },
                { TypeDefEnum.Primitive, typeof(BaseEnum<TypeDefPrimitive>) },
                { TypeDefEnum.Compact, typeof(TypeDefCompact) },
                { TypeDefEnum.BitSequence, typeof(TypeDefBitSequence) },
            };

            TypeDef = new BaseEnumRust<TypeDefEnum>(typeDecoderMap);
            TypeDef.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Path
        /// </summary>
        public Path Path { get; private set; }

        /// <summary>
        /// Type Parameters
        /// </summary>
        public BaseVec<TypeParameter> TypeParams { get; private set; }

        /// <summary>
        /// Type Definition
        /// </summary>
        public BaseEnumRust<TypeDefEnum> TypeDef { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }

    /// <summary>
    /// Path
    /// </summary>
    public class Path : BaseVec<Str>
    {
        /// <inheritdoc/>
        public override string TypeName() => "Path<T: Form = MetaForm>";
    }

    /// <summary>
    /// Type Parameter
    /// </summary>
    public class TypeParameter : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeParameter<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParameterName = new Str();
            TypeParameterName.Decode(byteArray, ref p);

            TypeParameterType = new BaseOpt<TType>();
            TypeParameterType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Type Parameter Name
        /// </summary>
        public Str TypeParameterName { get; private set; }

        /// <summary>
        /// Type Parameter Type
        /// </summary>
        public BaseOpt<TType> TypeParameterType { get; private set; }
    }
}