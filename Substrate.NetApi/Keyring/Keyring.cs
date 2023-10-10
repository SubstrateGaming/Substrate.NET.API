using Newtonsoft.Json;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Substrate.NetApi.Keyring
{
    public class KeyringAddress
    {
        public KeyType KeyType { get; set; }
        public Func<byte[], short, string> ToSS58 { get; set; }
    }

    public class Keyring
    {
        public const int NONCE_LENGTH = 24;
        public const int SCRYPT_LENGTH = 32 + (3 * 4);
        
        public IList<KeyringPair> Pairs { get; private set; } = new List<KeyringPair>();
        public short Ss58Format { get; set; } = 0;

        #region Add methods
        public void AddPair(KeyringPair keyringPair)
        {
            Pairs.Add(keyringPair);
        }

        public KeyringPair AddFromAddress(string address, Meta meta, byte[] encoded, KeyType keyType, bool ignoreChecksum, List<WalletJson.EncryptedJsonEncoding> encryptedEncoding)
        {
            var publicKey = Utils.GetPublicKeyFrom(address);

            var keyringPair = Pair.CreatePair(
                new KeyringAddress() { KeyType = keyType, ToSS58 = Utils.GetAddressFrom },
                new PairInfo(publicKey, new byte[32]),
                meta, encoded, encryptedEncoding, Ss58Format);

            AddPair(keyringPair);
            return keyringPair;
        }

        public KeyringPair AddFromJson(string jsonWallet)
        {
            return AddFromJson(JsonConvert.DeserializeObject<WalletEncryption>(jsonWallet));
        }

        public KeyringPair AddFromJson(WalletEncryption walletEncryption)
        {
            var keyringPair = CreateFromJson(walletEncryption);
            AddPair(keyringPair);
            return keyringPair;
        }

        public KeyringPair AddFromMnemonic(string mnemonic, Meta meta)
        {
            return AddFromUri(mnemonic, meta);
        }

        public KeyringPair AddFromUri(string uri, Meta meta)
        {
            var pair = CreateFromUri(uri, meta);
            AddPair(pair);

            return pair;
        }

        public KeyringPair AddFromSeed(byte[] seed, Meta meta)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Create method
        private KeyringPair CreateFromJson(WalletEncryption walletEncryption)
        {
            if(walletEncryption == null) throw new ArgumentNullException(nameof(walletEncryption));

            if (walletEncryption.encoding.version == 3 && walletEncryption.encoding.content[0] != "pkcs8")
                throw new InvalidOperationException($"Unable to decode non pkcs8 type, found {walletEncryption.encoding.content[0]} instead");

            KeyType keyType;
            switch(walletEncryption.encoding.content[1].ToLowerInvariant())
            {
                case "ed25519": 
                    keyType = KeyType.Ed25519;
                    break;
                case "sr25519": 
                    keyType = KeyType.Sr25519;
                    break;
                default: throw new InvalidOperationException($"{walletEncryption.encoding.content[1]} type is not supported");
            };

            List<WalletJson.EncryptedJsonEncoding> encryptedEncoding = walletEncryption.encoding.type.Select(encrypt => WalletJson.EncryptedFromString(encrypt)).ToList();

            var publicKey = Utils.GetPublicKeyFrom(walletEncryption.address);
            var encoded = Utils.IsHex(walletEncryption.encoded) ? 
                Utils.HexToByteArray(walletEncryption.encoded) :
                Convert.FromBase64String(walletEncryption.encoded);

            return Pair.CreatePair(
                new KeyringAddress() { KeyType = keyType, ToSS58 = Utils.GetAddressFrom },
                new PairInfo(publicKey, null), 
                walletEncryption.meta, encoded, encryptedEncoding, Ss58Format);
        }

        public KeyringPair CreateFromUri(string uri, Meta meta)
        {
            if(string.IsNullOrEmpty(uri)) throw new ArgumentNullException("uri");

            var resolvedUrl = uri.StartsWith("//") ? $"{Uri.DEV_PHRASE}{uri}" : uri;
            var extract = Uri.KeyExtractUri(resolvedUrl);

            throw new NotImplementedException();
        }
        #endregion

        #region Utility methods
        public static byte[] JsonDecryptData(string password, byte[] encrypted, List<WalletJson.EncryptedJsonEncoding> encryptedEncoding)
        {
            ensureDataIsSet(encrypted);

            if(encryptedEncoding.Any(x => x == WalletJson.EncryptedJsonEncoding.Xsalsa20Poly1305) && string.IsNullOrEmpty(password))
                throw new InvalidOperationException("Password require to encrypt data");

            var encoded = encrypted;
            if(!string.IsNullOrEmpty(password))
            {
                byte[] passwordBytes = password.ToBytes();
                if(encryptedEncoding.Any(x => x == WalletJson.EncryptedJsonEncoding.Scrypt))
                {
                    var scryptRes = Scrypt.FromBytes(encoded);
                    passwordBytes = Scrypt.ScryptEncode(password, scryptRes.Salt, scryptRes.Param).Password;
                    encrypted = encrypted.SubArray(SCRYPT_LENGTH);
                }

                encoded = Chaos.NaCl.XSalsa20Poly1305.TryDecrypt(
                    encrypted.Skip(NONCE_LENGTH).ToArray(),
                    Utils.BytesFixLength(passwordBytes, 256, true),
                    encrypted.Take(NONCE_LENGTH).ToArray());

            }

            if(encoded is null || !encoded.Any())
                throw new InvalidOperationException("Unable to decode using the supplied passphrase");

            return encoded;
        }

        private static void ensureDataIsSet(byte[] data, string message = "No data available")
        {
            if (data is null || !data.Any())
                throw new ArgumentException(string.IsNullOrEmpty(message) ? "No data available" : message);
        }
        #endregion
    }
}
