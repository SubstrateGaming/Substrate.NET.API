using Schnorrkel.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Keyring
{
    public static class Pkcs8
    {

        public static PairInfo Decode(string password, byte[] encoded, List<WalletJson.EncryptedJsonEncoding> encryptedEncoding)
        {
            var decoded = Pair.DecodePair(password, encoded, encryptedEncoding);
            
            PairInfo res = null;
            if (decoded.SecretKey.Length == 64 )
            {
                res = new PairInfo(decoded.PublicKey, decoded.SecretKey);
            } else
            {
                // TODO : check
                byte[] privateKey;
                byte[] publicKey;
                Chaos.NaCl.Ed25519.KeyPairFromSeed(out publicKey, out privateKey, encoded);

                //var miniSecret = new MiniSecret(encoded, ExpandMode.Ed25519);

                res = new PairInfo(publicKey, privateKey);
            }

            return res;
        }

        /// <summary>
        /// https://github.com/polkadot-js/common/blob/master/packages/keyring/src/pair/index.ts#L104
        /// </summary>
        /// <param name="password"></param>
        /// <param name="encoded"></param>
        /// <param name="pair"></param>
        /// <param name="encryptionType"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static byte[] Encode(string password, byte[] encoded, List<WalletJson.EncryptedJsonEncoding> encryptionType)
        {
            var pkcs8Pair = Pkcs8.Decode(password, encoded, encryptionType);
            return Pair.EncodePair(password, pkcs8Pair);
        }
    }
}
