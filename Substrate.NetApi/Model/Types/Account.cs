using Chaos.NaCl;
using Newtonsoft.Json;
using Schnorrkel;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Substrate.NetApi.Model.Types
{
    /// <summary>
    /// Represents a key type.
    /// </summary>
    public enum KeyType
    {
        Ed25519,
        Sr25519
    }

    /// <summary>
    /// Interface for an account.
    /// </summary>
    public interface IAccount
    {
        byte[] Sign(byte[] message);

        bool Verify(byte[] signature, byte[] publicKey, byte[] message);
    }

    /// <summary>
    /// Represents an account.
    /// </summary>
    public class Account : AccountId, IAccount
    {
        public KeyType KeyType { get; private set; }

        [JsonIgnore]
        public byte KeyTypeByte
        {
            get
            {
                switch (KeyType)
                {
                    case KeyType.Ed25519:
                        return 0;

                    case KeyType.Sr25519:
                        return 1;

                    default:
                        throw new NotSupportedException($"Unknown key type found '{KeyType}'.");
                }
            }
        }

        [JsonIgnore] public byte[] PrivateKey { get; private set; }

        /// <summary>
        /// Creates the specified key type with private key.
        /// </summary>
        /// <param name="keyType"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        public void Create(KeyType keyType, byte[] privateKey, byte[] publicKey)
        {
            KeyType = keyType;
            PrivateKey = privateKey;
            base.Create(publicKey);
        }

        /// <summary>
        /// Creates the specified key type, without private key.
        /// </summary>
        /// <param name="keyType"></param>
        /// <param name="publicKey"></param>
        public void Create(KeyType keyType, byte[] publicKey)
        {
            Create(keyType, null, publicKey);
        }

        /// <summary>
        /// Builds the specified key type.
        /// </summary>
        /// <param name="keyType"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static Account Build(KeyType keyType, byte[] privateKey, byte[] publicKey)
        {
            var account = new Account();
            account.Create(keyType, privateKey, publicKey);
            return account;
        }

        /// <summary>
        /// Signs the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public byte[] Sign(byte[] message)
        {
            switch (KeyType)
            {
                case KeyType.Ed25519:
                    return Ed25519.Sign(message, PrivateKey);

                case KeyType.Sr25519:
                    return Sr25519v091.SignSimple(Bytes, PrivateKey, message);

                default:
                    throw new NotSupportedException($"Unknown key type found '{KeyType}'.");
            }
        }

        /// <summary>
        /// Verifies a signature from this account.
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Verify(byte[] signature, byte[] message)
        {
            return Verify(signature, Bytes, message);
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="publicKey"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public bool Verify(byte[] signature, byte[] publicKey, byte[] message)
        {
            switch (KeyType)
            {
                case KeyType.Ed25519:
                    return Ed25519.Verify(signature, message, publicKey);

                case KeyType.Sr25519:
                    return Sr25519v091.Verify(signature, publicKey, message);

                default:
                    throw new NotSupportedException($"Unknown key type found '{KeyType}'.");
            }
        }
    }
}