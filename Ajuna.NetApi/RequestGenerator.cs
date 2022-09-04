using System;
using System.Linq;
using System.Text;
using Chaos.NaCl;
using Schnorrkel;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;

namespace Ajuna.NetApi
{
    /// <summary>
    /// Request Generator creates a requests for storage queries or extrinsic calls.
    /// </summary>
    public class RequestGenerator
    {
        /// <summary>
        /// Create a request for a storage call, for generated code.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hashers"></param>
        /// <param name="module"></param>
        /// <param name="item"></param>
        /// <param name="key1Param"></param>
        /// <param name="key2Param"></param>
        /// <returns></returns>
        public static string GetStorage(string module, string item, Storage.Type type, Storage.Hasher[] hashers = null, IType[] keys = null)
        {
            var keybytes = GetStorageKeyBytesHash(module, item);

            switch (type)
            {
                case Storage.Type.Plain:
                    return Utils.Bytes2HexString(keybytes);

                case Storage.Type.Map:
                    for (int i = 0; i < hashers.Length; i++)
                    {
                        var key = keys[i].Encode();
                        var hasher = hashers[i];
                        keybytes = keybytes.Concat(HashExtension.Hash(hasher, key)).ToArray();
                    }
                    return Utils.Bytes2HexString(keybytes);

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets the storage key bytes hash.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static byte[] GetStorageKeyBytesHash(string module, string item)
        {
            var mBytes = Encoding.ASCII.GetBytes(module);
            var iBytes = Encoding.ASCII.GetBytes(item);
            return HashExtension.Twox128(mBytes).Concat(HashExtension.Twox128(iBytes)).ToArray();
        }

    }
}