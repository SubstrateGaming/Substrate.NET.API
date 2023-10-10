using Newtonsoft.Json;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Keyring
{
    public class KeyringPair
    {
        public KeyringPair(string address, byte[] addressRaw, byte[] encoded, Meta meta, PairInfo pair, KeyType keyType, List<WalletJson.EncryptedJsonEncoding> encryptedEncoding)
        {
            PairInformation = pair;
            Address = address;
            Encoded = encoded;
            AddressRaw = addressRaw;
            Meta = meta;
            KeyType = keyType;
            EncryptedEncoding = encryptedEncoding;
        }

        public string Address { get; internal set; }
        public byte[] AddressRaw { get; internal set; }
        public byte[] Encoded { get; internal set; }
        public Meta Meta { get; internal set; }
        public PairInfo PairInformation { get; internal set; }
        public KeyType KeyType { get; internal set; }
        public List<WalletJson.EncryptedJsonEncoding> EncryptedEncoding { get; internal set; }

        public bool IsLocked => Pair.IsLocked(PairInformation.SecretKey);

        public void Lock()
        {
            PairInformation.SecretKey = null;
        }

        public void Unlock(string password, byte[] userEncoded = null)
        {
            PairInformation = Pkcs8.Decode(password, !Pair.IsLocked(userEncoded) ? userEncoded : Encoded, EncryptedEncoding);
        }

        public byte[] Recode(string password)
        {
            return Pkcs8.Encode(password, Encoded, EncryptedEncoding);
        }

        public WalletEncryption ToWalletEncryption(string password)
        {
            if(Meta.whenCreated == default)
                Meta.whenCreated = DateTime.Now.Ticks;

            return Pair.ToJsonPair(KeyType, Address, Meta, Recode(password), !string.IsNullOrEmpty(password));
        }

        public string ToJson(string password)
        {
            return JsonConvert.SerializeObject(ToWalletEncryption(password));
        }

        public KeyringPair Derive(string sUri, Meta meta)
        {
            if (IsLocked)
                throw new InvalidOperationException("Cannot derive on locked KeyPair");

            // TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Build an account instance from KeyPair
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IAccount GetAccount()
        {
            if (IsLocked)
                throw new InvalidOperationException("Cannot build account instance on locked KeyPair");

            return Account.Build(KeyType, PairInformation.SecretKey, PairInformation.PublicKey);
        }

        public byte[] Sign(string message)
        {
            return GetAccount().Sign(message.ToBytes());
        }

        public bool Verify(byte[] signature, byte[] publicKey, byte[] message)
        {
            return GetAccount().Verify(signature, publicKey, message);
        }
    }
}
