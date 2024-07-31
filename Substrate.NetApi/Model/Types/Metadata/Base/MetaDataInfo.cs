using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Meta Data Info Type
    /// </summary>
    public class MetaDataInfo : BaseType
    {
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode from byte array
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Magic = new U32();
            Magic.Decode(byteArray, ref p);

            Version = new U8();
            Version.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Magic
        /// </summary>
        public U32 Magic { get; private set; }

        /// <summary>
        /// Version
        /// </summary>
        public U8 Version { get; private set; }
    }
}