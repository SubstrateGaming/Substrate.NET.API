using Ajuna.NetApi;
using Ajuna.NetApi.Model.AjunaWorker;
using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Org.BouncyCastle.Security;
using SimpleBase;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Ajuna.NetApiExt.Model.AjunaWorker.Helper
{
    public class Wrapper
    {
        public static EnumTrustedOperation GetEnumTrustedOperation(Account account, TrustedCallPayload trustedCallPayload)
        {
            var signature = new Signature64();
            var signatureArray = Schnorrkel.Sr25519v091.SignSimple(Utils.GetPublicKeyFrom(account.Value), account.PrivateKey, trustedCallPayload.Encode());
            signature.Create(signatureArray);

            var enumMultiSignature = new EnumMultiSignature();
            enumMultiSignature.Create(MultiSignature.Sr25519, signature);

            var trustedCallSigned = new TrustedCallSigned();
            trustedCallSigned.Call = trustedCallPayload.Call;
            trustedCallSigned.Nonce = trustedCallPayload.Nonce;
            trustedCallSigned.Signature = enumMultiSignature;

            var trustedOperation = new EnumTrustedOperation();
            trustedOperation.Create(TrustedOperation.DirectCall, trustedCallSigned);

            return trustedOperation;
        }

        public static EnumTrustedOperation GetEnumTrustedOperation(Account account, EnumTrustedGetter trustedGetter)
        {
            var signature = new Signature64();
            var signatureArray = Schnorrkel.Sr25519v091.SignSimple(Utils.GetPublicKeyFrom(account.Value), account.PrivateKey, trustedGetter.Encode());
            signature.Create(signatureArray);

            var enumMultiSignature = new EnumMultiSignature();
            enumMultiSignature.Create(MultiSignature.Sr25519, signature);

            var trustedGetterSigned = new TrustedGetterSigned();
            trustedGetterSigned.Getter = trustedGetter;
            trustedGetterSigned.Signature = enumMultiSignature;

            var getter = new EnumGetter();
            getter.Create(Getter.Trusted, trustedGetterSigned);

            var trustedOperation = new EnumTrustedOperation();
            trustedOperation.Create(TrustedOperation.Get, getter);

            return trustedOperation;
        }

        public static EnumTrustedOperation CreateGetter(Account accountName, TrustedGetter trustedGetter)
        {
            var account = new AccountId32();
            account.Create(accountName.Bytes);

            var enumTrustedGetter = new EnumTrustedGetter();
            enumTrustedGetter.Create(trustedGetter, account);

            return GetEnumTrustedOperation(accountName, enumTrustedGetter);
        }

        public static EnumTrustedOperation CreateCallPlayTurn(Account account, byte move, uint nonce, string mrenclaveHex, string shardHex)
        {
            var accountId32 = new AccountId32();
            accountId32.Create(account.Bytes);

            var column = new U8();
            column.Create(move);

            var playTurnTuple = new BaseTuple<AccountId32, U8>();
            playTurnTuple.Create(accountId32, column);

            var trustedCall = new EnumTrustedCall();
            trustedCall.Create(TrustedCall.ConnectfourPlayTurn, playTurnTuple);

            var index = new Ajuna.NetApi.Model.AjunaWorker.Index();
            index.Create(nonce);

            var mrenclave = new H256();
            mrenclave.Create(Base58.Bitcoin.Decode(mrenclaveHex).ToArray());

            var shard = new ShardIdentifier();
            shard.Create(Base58.Bitcoin.Decode(shardHex).ToArray());

            var trustedCallPayload = new TrustedCallPayload
            {
                Call = trustedCall,
                Nonce = index,
                Mrenclave = mrenclave,
                Shard = shard
            };

            return GetEnumTrustedOperation(account, trustedCallPayload);
        }

        public static EnumTrustedOperation CreateCallBalanceTransfer(Account fromAccount, Account toAccount, uint amount, uint nonce, string mrenclaveHex, string shardHex)
        {
            var aliceAccount = new AccountId32();
            aliceAccount.Create(fromAccount.Bytes);

            var bobAccount = new AccountId32();
            bobAccount.Create(toAccount.Bytes);

            var balance = new Balance();
            balance.Create(new BigInteger(amount));

            var balanceTransferTuple = new BaseTuple<AccountId32, AccountId32, Balance>();
            balanceTransferTuple.Create(aliceAccount, bobAccount, balance);

            var trustedCall = new EnumTrustedCall();
            trustedCall.Create(TrustedCall.BalanceTransfer, balanceTransferTuple);

            var index = new Ajuna.NetApi.Model.AjunaWorker.Index();
            index.Create(nonce);

            var mrenclave = new H256();
            mrenclave.Create(Base58.Bitcoin.Decode(mrenclaveHex).ToArray());

            var shard = new ShardIdentifier();
            shard.Create(Base58.Bitcoin.Decode(shardHex).ToArray());

            var trustedCallPayload = new TrustedCallPayload
            {
                Call = trustedCall,
                Nonce = index,
                Mrenclave = mrenclave,
                Shard = shard
            };

            return GetEnumTrustedOperation(fromAccount, trustedCallPayload);
        }

        public static byte[] SignTrustedOperation(RSAParameters shieldingKey, EnumTrustedOperation trustedOperation)
        {
            // - Encrypt Encoded TrustedOperation with RSAPubKey
            var keyPair = DotNetUtilities.GetRsaPublicKey(shieldingKey);
            return Utils.RSAEncryptBouncy(trustedOperation.Encode(), keyPair);
        }

        public static BaseVec<U8> VecU8FromBytes(byte[] vs)
        {
            var u8list = new List<U8>();
            for (int i = 0; i < vs.Length; i++)
            {
                var u8 = new U8();
                u8.Create(vs[i]);
                u8list.Add(u8);
            }
            var u8Array = u8list.ToArray();

            var result = new BaseVec<U8>();
            result.Create(u8Array);

            return result;
        }
    }
}
