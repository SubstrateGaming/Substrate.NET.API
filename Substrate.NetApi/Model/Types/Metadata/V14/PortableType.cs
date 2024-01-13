using System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Portable Type
    /// </summary>
    public class PortableType : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "PortableType";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            // #[codec(compact)]
            Id = new U32();
            Id.Create(CompactInteger.Decode(byteArray, ref p));

            Ty = new TypePortableForm();
            Ty.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Id
        /// </summary>
        public U32 Id { get; private set; }
        
        /// <summary>
        /// Ty
        /// </summary>
        public TypePortableForm Ty { get; private set; }
    }
}