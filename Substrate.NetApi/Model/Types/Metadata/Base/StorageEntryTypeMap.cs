using Substrate.NetApi.Model.Types.Base;
using System;
using static Substrate.NetApi.Model.Meta.Storage;

namespace Substrate.NetApi.Model.Types.Metadata.Base
{
    /// <summary>
    /// Storage Entry Type Map
    /// </summary>
    public class StorageEntryTypeMap : BaseType
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

            Hashers = new BaseVec<BaseEnum<Hasher>>();
            Hashers.Decode(byteArray, ref p);

            Key = new TType();
            Key.Decode(byteArray, ref p);

            Value = new TType();
            Value.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Hashers
        /// </summary>
        public BaseVec<BaseEnum<Hasher>> Hashers { get; private set; }

        /// <summary>
        /// Key
        /// </summary>
        public TType Key { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public TType Value { get; private set; }
    }
}