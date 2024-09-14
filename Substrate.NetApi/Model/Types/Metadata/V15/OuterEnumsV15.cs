using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V15
{
    /// <summary>
    /// Outer Enums
    /// </summary>
    public class OuterEnumsV15 : BaseType
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

            CallEnumTypeId = new TType();
            CallEnumTypeId.Decode(byteArray, ref p);

            EventEnumTypeId = new TType();
            EventEnumTypeId.Decode(byteArray, ref p);

            ErrorEnumTypeId = new TType();
            ErrorEnumTypeId.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Call Enum Type Id
        /// </summary>
        public TType CallEnumTypeId { get; private set; }

        /// <summary>
        /// Event Enum Type Id
        /// </summary>
        public TType EventEnumTypeId { get; private set; }

        /// <summary>
        /// Error Enum Type Id
        /// </summary>
        public TType ErrorEnumTypeId { get; private set; }
    }
}