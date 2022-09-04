using System;
using Newtonsoft.Json;
using Ajuna.NetApi.Model.Types.Base;
using Schnorrkel;
using System.Security.Principal;
using Chaos.NaCl;
using Org.BouncyCastle.Utilities;

namespace Ajuna.NetApi.Model.Types
{
    public enum KeyType
    {
        Ed25519,
        Sr25519
    }

    public class Account : AccountId
    {
        public KeyType KeyType;

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
                        throw new NotImplementedException($"Unknown key type found '{KeyType}'.");
                }
            }
        }

        [JsonIgnore] 
        public byte[] PrivateKey { get; private set; }

        public void Create(KeyType keyType, byte[] privateKey, byte[] publicKey)
        {
            KeyType = keyType;
            PrivateKey = privateKey;
            base.Create(publicKey);
        }

        public void Create(KeyType keyType, byte[] publicKey)
        {
            Create(keyType, null, publicKey);
        }

        /// <summary>
        /// Sign message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns signature of the signed message.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public byte[] Sign(byte[] message)
        {
            switch (KeyType)
            {
                case KeyType.Ed25519:
                    return Ed25519.Sign(message, PrivateKey);

                case KeyType.Sr25519:
                    return Sr25519v091.SignSimple(Bytes, PrivateKey, message);

                default:
                    throw new NotImplementedException($"Unknown key type found '{KeyType}'.");
            }
        }

        /// <summary>
        /// 
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

    }
}