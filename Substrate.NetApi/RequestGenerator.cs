using System;
using System.Linq;
using System.Text;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Chaos.NaCl;
using Schnorrkel;
using System.Threading.Tasks;

namespace Substrate.NetApi
{
    /// <summary>
    /// Request Generator creates a requests for storage queries or extrinsic calls.
    /// </summary>
    public class RequestGenerator
    {
        /// <summary>
        /// Get the storage key.
        /// </summary>
        /// <param name="module">The module name.</param>
        /// <param name="item">The item name.</param>
        /// <param name="type">The storage type.</param>
        /// <param name="hashers">The hashers.</param>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
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

        /// <summary>
        /// Submits the extrinsic.
        /// </summary>
        /// <param name="signed">if set to <c>true</c> [signed].</param>
        /// <param name="account">The account.</param>
        /// <param name="method">The method.</param>
        /// <param name="era">The era.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="charge">The charge.</param>
        /// <param name="genesis">The genesis.</param>
        /// <param name="startEra">The start era.</param>
        /// <param name="runtime">The runtime.</param>
        /// <returns></returns>
        /// <exception cref="UnCheckedExtrinsic">signed, account, method, era, nonce, tip, genesis, startEra</exception>
        public static async Task<UnCheckedExtrinsic> SubmitExtrinsicAsync(bool signed, Account account, Method method, Era era,
            uint nonce, ChargeType charge, Hash genesis, Hash startEra, RuntimeVersion runtime)
        {
            var uncheckedExtrinsic =
                new UnCheckedExtrinsic(signed, account, method, era, nonce, charge, genesis, startEra);

            if (!signed)
            {
                return uncheckedExtrinsic;
            }

            Payload payload = uncheckedExtrinsic.GetPayload(runtime);

            // sign payload with the, Payloads longer than 256 bytes are going to be `blake2_256`-hashed. 
            byte[] signature = await account.SignPayloadAsync(payload);

            uncheckedExtrinsic.AddPayloadSignature(signature);

            return uncheckedExtrinsic;
        }
    }
}