using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Substrate.NetApi.BIP39;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi.Extensions;

namespace Substrate.NetApi
{
    public static class Mnemonic
    {
        public enum BIP39Wordlist
        {
            English,
            Japanese,
            Korean,
            Spanish,
            ChineseSimplified,
            ChineseTraditional,
            French,
            Italian,
            Czech,
            Portuguese
        }

        /// <summary>
        /// Rfc2898DeriveBytes, with HMACSHA512 usable for .NETStandard 2.0
        /// </summary>
        /// <param name="dklen"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="iterationCount"></param>
        /// <returns></returns>
        public static byte[] PBKDF2Sha512GetBytes(int dklen, byte[] password, byte[] salt, int iterationCount)
        {
            using (var hmac = new HMACSHA512(password))
            {
                int hashLength = hmac.HashSize / 8;
                if ((hmac.HashSize & 7) != 0)
                    hashLength++;
                int keyLength = dklen / hashLength;
                if (dklen > (0xFFFFFFFFL * hashLength) || dklen < 0)
                {
                    throw new ArgumentOutOfRangeException("dklen");
                }
                if (dklen % hashLength != 0)
                {
                    keyLength++;
                }
                byte[] extendedkey = new byte[salt.Length + 4];
                Buffer.BlockCopy(salt, 0, extendedkey, 0, salt.Length);
                using (var ms = new MemoryStream())
                {
                    for (int i = 0; i < keyLength; i++)
                    {
                        extendedkey[salt.Length] = (byte)(((i + 1) >> 24) & 0xFF);
                        extendedkey[salt.Length + 1] = (byte)(((i + 1) >> 16) & 0xFF);
                        extendedkey[salt.Length + 2] = (byte)(((i + 1) >> 8) & 0xFF);
                        extendedkey[salt.Length + 3] = (byte)(((i + 1)) & 0xFF);
                        byte[] u = hmac.ComputeHash(extendedkey);
                        Array.Clear(extendedkey, salt.Length, 4);
                        byte[] f = u;
                        for (int j = 1; j < iterationCount; j++)
                        {
                            u = hmac.ComputeHash(u);
                            for (int k = 0; k < f.Length; k++)
                            {
                                f[k] ^= u[k];
                            }
                        }
                        ms.Write(f, 0, f.Length);
                        Array.Clear(u, 0, u.Length);
                        Array.Clear(f, 0, f.Length);
                    }
                    byte[] dk = new byte[dklen];
                    ms.Position = 0;
                    ms.Read(dk, 0, dklen);
                    ms.Position = 0;
                    for (long i = 0; i < ms.Length; i++)
                    {
                        ms.WriteByte(0);
                    }
                    Array.Clear(extendedkey, 0, extendedkey.Length);
                    return dk;
                }
            }
        }

        /// <summary>
        /// Get seed from entropy bytes, make  sure entropy is a byte array from a correctly recovered and checksumed BIP39.
        /// Following slices are supported:
        /// + 16 bytes for 12 words.
        /// + 20 bytes for 15 words.
        /// + 24 bytes for 18 words.
        /// + 28 bytes for 21 words.
        /// + 32 bytes for 24 words.
        /// Other slices will lead to a InvalidEntropy error.
        /// https://github.com/paritytech/substrate-bip39/blob/eef2f86337d2dab075806c12948e8a098aa59d59/src/lib.rs#L45
        /// </summary>
        /// <param name="entropyBytes"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] SeedFromEntropy(byte[] entropyBytes, string password)
        {
            CheckValidEntropy(entropyBytes);

            var saltBytes = Encoding.UTF8.GetBytes("mnemonic" + password);
            return PBKDF2Sha512GetBytes(64, entropyBytes, saltBytes, 2048);
        }

        /// <summary>
        /// Generate a mnemonic seed phrase from a given entropy.
        /// 16, 20, 24, 28, 32 Bytes Entropy supported.
        /// </summary>
        /// <param name="entropyBytes"></param>
        /// <returns></returns>
        public static string[] MnemonicFromEntropy(byte[] entropyBytes, BIP39Wordlist wordlistType)
        {
            if (entropyBytes.Length != 16
             && entropyBytes.Length != 20
             && entropyBytes.Length != 24
             && entropyBytes.Length != 28
             && entropyBytes.Length != 32)
            {
                return null;
            }

            var bitString = string.Concat(entropyBytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')))
                + DeriveChecksumBits(entropyBytes);

            var wordlist = GetWordlist(wordlistType);

            // split in 11bit strings, convert to decimal, get word at index
            return Enumerable.Range(0, bitString.Length / 11)
                .Select(i => wordlist.GetWordAtIndex(Convert.ToInt32(bitString.Substring(i * 11, 11), 2))).ToArray();
        }

        /// <summary>
        /// Get secret key from mnemonic
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="password"></param>
        /// <param name="bIP39Wordlist"></param>
        /// <returns></returns>
        public static byte[] GetSecretKeyFromMnemonic(string mnemonic, string password, BIP39Wordlist bIP39Wordlist)
        {
            var entropyBytes = Utils.HexToByteArray(MnemonicToEntropy(mnemonic, bIP39Wordlist));
            var seedBytes = SeedFromEntropy(entropyBytes, password);
            return seedBytes.AsMemory().Slice(0, 32).ToArray();
        }

        /// <summary>
        /// Get a key pair from mnemonic
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="password"></param>
        /// <param name="bIP39Wordlist"></param>
        /// <param name="expandMode"></param>
        /// <returns></returns>
        public static KeyPair GetKeyPairFromMnemonic(string mnemonic, string password, BIP39Wordlist bIP39Wordlist, ExpandMode expandMode)
        {
            var secretBytes = GetSecretKeyFromMnemonic(mnemonic, password, bIP39Wordlist);
            var miniSecret = new MiniSecret(secretBytes, expandMode);
            return new KeyPair(miniSecret.ExpandToPublic(), miniSecret.ExpandToSecret());
        }

        /// <summary>
        /// Get account from mnemonic
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="password"></param>
        /// <param name="bIP39Wordlist"></param>
        /// <param name="expandMode"></param>
        /// <returns></returns>
        public static Account GetAccountFromMnemonic(string mnemonic, string password, KeyType keyType, BIP39Wordlist bIP39Wordlist = BIP39Wordlist.English, ExpandMode expandMode = ExpandMode.Ed25519)
        {
            var secretBytes = GetSecretKeyFromMnemonic(mnemonic, password, bIP39Wordlist);

            switch (keyType)
            {
                case KeyType.Ed25519:
                    Chaos.NaCl.Ed25519.KeyPairFromSeed(out byte[] pubKey, out byte[] priKey, secretBytes.Take(32).ToArray());
                    return Account.Build(KeyType.Ed25519, priKey, pubKey);

                case KeyType.Sr25519:
                    var miniSecret = new MiniSecret(secretBytes, expandMode);
                    return Account.Build(KeyType.Sr25519, miniSecret.ExpandToSecret().ToEd25519Bytes(), miniSecret.GetPair().Public.Key);

                default:
                    throw new NotImplementedException($"KeyType {keyType} isn't implemented!");
            }
        }

        public static string MnemonicToEntropy(string mnemonic, BIP39Wordlist wordlistType)
        {
            var wordlist = GetWordlist(wordlistType);
            var words = mnemonic.Normalize(NormalizationForm.FormKD).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length % 3 != 0)
            {
                throw new FormatException("InvalidMnemonic");
            }

            var bits = String.Empty;
            foreach (var word in words.ToList())
            {
                if (!wordlist.WordExists(word, out int index))
                {
                    throw new FormatException("InvalidMnemonic");
                }
                bits += Convert.ToString(index, 2).PadLeft(11, '0');
            }

            // split the binary string into ENT/CS
            var dividerIndex = (int)Math.Floor((double)bits.Length / 33) * 32;
            var entropyBits = bits.Substring(0, dividerIndex);
            var checksumBits = bits.Substring(dividerIndex);

            // calculate the checksum and compare
            var entropyBytesMatch = Regex.Matches(entropyBits, "(.{1,8})")
                .OfType<Match>()
                .Select(m => m.Groups[0].Value)
                .ToArray();

            var entropyBytes = entropyBytesMatch
                .Select(bytes => Convert.ToByte(bytes, 2)).ToArray();

            CheckValidEntropy(entropyBytes);

            var newChecksum = DeriveChecksumBits(entropyBytes);

            if (newChecksum != checksumBits)
                throw new InvalidOperationException("InvalidChecksum");

            var result = BitConverter
                .ToString(entropyBytes)
                .Replace("-", "")
                .ToLower();

            return result;
        }

        private static void CheckValidEntropy(byte[] entropyBytes)
        {
            if (entropyBytes.Length < 16)
                throw new FormatException("InvalidEntropy");

            if (entropyBytes.Length > 32)
                throw new FormatException("InvalidEntropy");

            if (entropyBytes.Length % 4 != 0)
                throw new FormatException("InvalidEntropy");
        }

        private static string DeriveChecksumBits(byte[] entropyBytes)
        {
            var ent = entropyBytes.Length * 8;
            var cs = ent / 32;

            var sha256Provider = SHA256.Create();
            var hash = sha256Provider.ComputeHash(entropyBytes);
            string result = string.Join(null, hash.Select(h => Convert.ToString(h, 2).PadLeft(8, '0')));
            return result.Substring(0, cs);
        }

        private static Wordlist GetWordlist(BIP39Wordlist language)
        {
            switch (language)
            {
                case BIP39Wordlist.ChineseSimplified:
                    return new ChineseSimplified();

                case BIP39Wordlist.ChineseTraditional:
                    return new ChineseTraditional();

                case BIP39Wordlist.English:
                    return new English();

                case BIP39Wordlist.French:
                    return new French();

                case BIP39Wordlist.Italian:
                    return new Italian();

                case BIP39Wordlist.Japanese:
                    return new Japanese();

                case BIP39Wordlist.Korean:
                    return new Korean();

                case BIP39Wordlist.Spanish:
                    return new Spanish();

                case BIP39Wordlist.Czech:
                    return new Czech();

                case BIP39Wordlist.Portuguese:
                    return new Portuguese();

                default:
                    throw new InvalidOperationException($"Unknown {language} in BIP39 implementation!");
            }
        }

        public enum MnemonicSize
        {
            Words12,
            Words15,
            Words18,
            Words21,
            Words24
        }

        /// <summary>
        /// Generate new mnemonic based on nb words
        /// </summary>
        /// <param name="mnemonicSize"></param>
        /// <param name="bIP39Wordlist"></param>
        /// <returns></returns>
        public static string[] GenerateMnemonic(MnemonicSize mnemonicSize, BIP39Wordlist bIP39Wordlist = BIP39Wordlist.English)
        {
            switch (mnemonicSize)
            {
                case MnemonicSize.Words12:
                    return MnemonicFromEntropy(new byte[16].Populate(), bIP39Wordlist);
                case MnemonicSize.Words15:
                    return MnemonicFromEntropy(new byte[20].Populate(), bIP39Wordlist);
                case MnemonicSize.Words18:
                    return MnemonicFromEntropy(new byte[24].Populate(), bIP39Wordlist);
                case MnemonicSize.Words21:
                    return MnemonicFromEntropy(new byte[28].Populate(), bIP39Wordlist);
                case MnemonicSize.Words24:
                    return MnemonicFromEntropy(new byte[32].Populate(), bIP39Wordlist);
            }

            throw new InvalidOperationException("Invalid mnemonic size");
        }

        //public static byte[] MnemonicToMiniSecret(string mnemonic, string password, BIP39Wordlist bIP39Wordlist = BIP39Wordlist.English)
        //{
        //    if (!ValidateMnemonic(mnemonic, bIP39Wordlist))
        //    {
        //        throw new InvalidOperationException("Invalid bip39 mnemonic specified");
        //    }

        //    return GetSecretKeyFromMnemonic(mnemonic, password, bIP39Wordlist);
        //}

        public static bool ValidateMnemonic(string mnemonic, BIP39Wordlist bIP39Wordlist = BIP39Wordlist.English)
        {
            try
            {
                _ = MnemonicToEntropy(mnemonic, bIP39Wordlist);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}