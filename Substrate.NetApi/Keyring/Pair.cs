using Chaos.NaCl;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate.NetApi.Keyring
{
    public class DecodeResult : PairInfo
    {
        public DecodeResult(byte[] publicKey, byte[] privateKey, byte[] seed, byte[] secretKey) : base(publicKey, secretKey)
        {
            PrivateKey = privateKey;
            Seed = seed;
        }

        public byte[] PrivateKey { get; }
        public byte[] Seed { get; }
    }

    /// <summary>
    /// TODO : Use Schnorrkel.KeyPair ?
    /// </summary>
    public class PairInfo
    {
        public PairInfo(byte[] publicKey, byte[] secretKey)
        {
            PublicKey = publicKey;
            SecretKey = secretKey;
        }

        public byte[] PublicKey { get; set; }
        public byte[] SecretKey { get; set; }
    }

    public static class Pair
    {
        public const int PUB_LENGTH = 32;
        public const int SALT_LENGTH = 32;
        public const int SEC_LENGTH = 64;
        public const int SEED_LENGTH = 32;
        public static int SEED_OFFSET => PKCS8_HEADER.Length;

        public static readonly byte[] PKCS8_HEADER = new byte[] { 48, 83, 2, 1, 1, 48, 5, 6, 3, 43, 101, 112, 4, 34, 4, 32 };
        public static readonly byte[] PKCS8_DIVIDER = new byte[] { 161, 35, 3, 33, 0 };

        public const int ENCODING_VERSION = 3;
        public static readonly string[] ENCODING_NONE = { WalletJson.EncryptedToString(WalletJson.EncryptedJsonEncoding.None) };
        public static readonly string[] ENCODING = { 
            WalletJson.EncryptedToString(WalletJson.EncryptedJsonEncoding.Scrypt),
            WalletJson.EncryptedToString(WalletJson.EncryptedJsonEncoding.Xsalsa20Poly1305),
        };

        /// <summary>
        /// https://github.com/polkadot-js/common/blob/master/packages/keyring/src/pair/index.ts#L89
        /// </summary>
        /// <param name="setup"></param>
        /// <param name="publicKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="meta"></param>
        /// <param name="decoded"></param>
        /// <param name="encryptedEncoding"></param>
        /// <returns></returns>
        public static KeyringPair CreatePair(KeyringAddress setup, PairInfo pair, Meta meta, byte[] encoded, List<WalletJson.EncryptedJsonEncoding> encryptedEncoding, short ss58Format)
        {
            return new KeyringPair(
                setup.ToSS58(pair.PublicKey, ss58Format), 
                pair.PublicKey,
                encoded,
                meta, 
                pair,
                setup.KeyType,
                encryptedEncoding);
        }

        public static PairInfo DecodePair(string password, byte[] encrypted, List<WalletJson.EncryptedJsonEncoding> encryptionType)
        {
            var decrypted = Keyring.JsonDecryptData(password, encrypted, encryptionType);
            var header = decrypted.SubArray(0, PKCS8_HEADER.Length);

            if (!header.SequenceEqual(PKCS8_HEADER))
                throw new InvalidOperationException("Invalid PKCS8 header");

            var offset = SEED_OFFSET + SEC_LENGTH;
            var secretKey = decrypted.SubArray(SEED_OFFSET, offset);
            var divider = decrypted.SubArray(offset, offset + PKCS8_DIVIDER.Length);

            if (!divider.SequenceEqual(PKCS8_DIVIDER))
                throw new InvalidOperationException("Invalid PKCS8 divider");

            var publicOffset = offset + PKCS8_DIVIDER.Length;
            var publicKey = decrypted.SubArray(publicOffset, publicOffset + PUB_LENGTH);

            return new PairInfo(publicKey, secretKey);
        }

        public static byte[] EncodePair(string password, PairInfo pair)
        {
            if (IsLocked(pair.SecretKey))
                throw new InvalidOperationException("Secret key has to be set");

            var encoded = PKCS8_HEADER.Concat(pair.SecretKey).Concat(PKCS8_DIVIDER).Concat(pair.PublicKey).ToArray();

            if (string.IsNullOrEmpty(password))
                return encoded;

            var scryptResult = Scrypt.ScryptEncode(password, ScryptParam.Default);

            byte[] message = encoded;
            byte[] secret = scryptResult.Password.SubArray(0, 32);
            byte[] nonce = new byte[24].Populate();

            var naclResult = Chaos.NaCl.XSalsa20Poly1305.Encrypt(message, secret, nonce);

            return Scrypt.ToBytes(scryptResult.Salt, scryptResult.Param)
                .Concat(nonce)
                .Concat(naclResult)
                .ToArray();
        }

        public static WalletEncryption ToJsonPair(KeyType keyType, string address, Meta meta, byte[] encoded, bool isEncrypted)
        {
            return new WalletEncryption()
            {
                address = address,
                encoded = Convert.ToBase64String(encoded),
                encoding = new Encoding()
                {
                    content = new List<string>() { "pkcs8", keyType.ToString() },
                    type = isEncrypted ? ENCODING.ToList() : ENCODING_NONE.ToList(),
                    version = ENCODING_VERSION
                },
                meta = meta
            };
        }

        public static bool IsLocked(byte[] secretKey) => secretKey is null || !secretKey.Any();    
    }
}
