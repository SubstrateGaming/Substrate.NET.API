using System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Field Type
    /// </summary>
    public class Field : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "Field<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            FieldName = new BaseOpt<Str>();
            FieldName.Decode(byteArray, ref p);

            FieldTy = new TType();
            FieldTy.Decode(byteArray, ref p);

            FieldTypeName = new BaseOpt<Str>();
            FieldTypeName.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Field Name
        /// </summary>
        public BaseOpt<Str> FieldName { get; private set; }

        /// <summary>
        /// Field Type
        /// </summary>
        public TType FieldTy { get; private set; }

        /// <summary>
        /// Field Type Name
        /// </summary>
        public BaseOpt<Str> FieldTypeName { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }
}