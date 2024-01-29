using Chaos.NaCl;
using Newtonsoft.Json;
using Schnorrkel;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Substrate.NetApi.Model.Types
{
    /// <summary>
    /// Enum KeyType represents the type of cryptographic keys used in digital signatures.
    /// </summary>
    public enum KeyType
    {
        /// <summary>
        /// Ed25519: Elliptic Curve Digital Signature Algorithm using SHA-512 and Curve25519.
        /// Preferred for its balance of security and performance, suitable for scenarios
        /// requiring fast signature verification. Commonly used in secure communication,
        /// authentication, and blockchain applications.
        /// </summary>
        Ed25519,

        /// <summary>
        /// Sr25519: Schnorr signature scheme using SHA-512 and Curve25519, implemented in Schnorrkel.
        /// Offers advantages in complex cryptographic constructions and potentially better performance.
        /// Frequently used in decentralized systems and advanced cryptographic protocols.
        /// </summary>
        Sr25519
    }

    /// <summary>
    /// Interface for an account.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Sign the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Obsolete("Sign is deprecated, please use SignAsync instead.")]
        byte[] Sign(byte[] message);

        /// <summary>
        /// Asynchronouslys sign the specified message.
        /// </summary>
        /// <param name="message">The message bytes.</param>
        /// <returns></returns>
        Task<byte[]> SignAsync(byte[] message);

        /// <summary>
        /// Asynchronouslys sign the specified payload.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        Task<byte[]> SignPayloadAsync(Payload payload);

        /// <summary>
        /// Verifies a signature from this account.
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="publicKey"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool Verify(byte[] signature, byte[] publicKey, byte[] message);
    }

    /// <summary>
    /// Represents an account.
    /// </summary>
    public class Account : AccountId, IAccount
    {
        /// <summary>
        /// Key Type
        /// </summary>
        public KeyType KeyType { get; private set; }

        /// <summary>
        /// Key Type Byte
        /// </summary>
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

        /// <summary>
        /// Private Key
        /// </summary>
        [JsonIgnore] 
        public byte[] PrivateKey { get; private set; }

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

        /// <inheritdoc/>
        public override void CreateFromJson(string str)
        {
            throw new NotSupportedException("CreateFromJson is not supported for Account.");
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
        /// Asynchronously signs the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public virtual async Task<byte[]> SignAsync(byte[] message)
        {
            return await Task.Run(() => Sign(message));
        }

        /// <summary>
        /// Signs the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>)
        [Obsolete("Sign is deprecated, please use SignAsync instead.")]
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
        /// Asynchronously signs the specified payload.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<byte[]> SignPayloadAsync(Payload payload)
        {
            return await SignAsync(payload.Encode());
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