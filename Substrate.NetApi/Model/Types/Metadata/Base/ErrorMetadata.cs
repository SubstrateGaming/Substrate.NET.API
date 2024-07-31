using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Error Metadata
    /// </summary>
    public class ErrorMetadata : BaseType
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

            ErrorType = new TType();
            ErrorType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Error Type
        /// </summary>
        public TType ErrorType { get; private set; }
    }
}