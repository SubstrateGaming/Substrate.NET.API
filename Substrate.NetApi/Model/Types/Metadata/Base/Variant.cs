using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Variant Type
    /// </summary>
    public class Variant : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "Variant<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            VariantName = new Str();
            VariantName.Decode(byteArray, ref p);

            VariantFields = new BaseVec<Field>();
            VariantFields.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Variant Name
        /// </summary>
        public Str VariantName { get; private set; }

        /// <summary>
        /// Variant Fields
        /// </summary>
        public BaseVec<Field> VariantFields { get; private set; }

        /// <summary>
        /// Index
        /// </summary>
        public U8 Index { get; private set; }

        /// <summary>
        /// Docs
        /// </summary>
        public BaseVec<Str> Docs { get; private set; }
    }
}