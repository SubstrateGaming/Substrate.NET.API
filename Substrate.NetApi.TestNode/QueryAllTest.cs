using NUnit.Framework;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.TestNode
{
    public class QueryAllTest : NodeTest
    {
        [Test]
        public async Task GetAllStorageTestAsync()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            string blockHash = null;
            byte[] startKey = null;

            List<(byte[], AccountId32, AccountInfo)> allPages = new();

            while (true)
            {
                var page = await GetAllStoragePagedAsync<AccountId32, AccountInfo>("System", "Account", startKey, 1000, blockHash, CancellationToken.None);
                if (page == null || page.Count == 0)
                {
                    break;
                }

                allPages.AddRange(page);
                startKey = page.Last().Item1;
            }

            stopwatch.Stop();

            Assert.IsNotNull(allPages);
            Assert.AreNotEqual(0, allPages.Count);
            Assert.Greater(20000, stopwatch.ElapsedMilliseconds, "Get all storage did use more then 10 sec., verify!");
        }

        public async Task<List<(byte[], T1, T2)>> GetAllStoragePagedAsync<T1, T2>(string module, string item, byte[] startKey, uint page, string blockHash, CancellationToken token)
            where T1 : IType, new()
            where T2 : IType, new()
        {
            if (!_substrateClient.IsConnected)
            {
                return null;
            }

            if (page < 2 || page > 1000)
            {
                throw new NotSupportedException("Page size must be in the range of 2 - 1000");
            }

            var result = new List<(byte[], T1, T2)>();
            var keyBytes = RequestGenerator.GetStorageKeyBytesHash(module, item);

            var storageKeys = await _substrateClient.State.GetKeysPagedAsync(keyBytes, page, startKey, token);
            if (storageKeys == null || !storageKeys.Any())
            {
                return result;
            }

            var storageChangeSets = await _substrateClient.State.GetQueryStorageAtAsync(storageKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), blockHash, token);
            if (storageChangeSets != null)
            {
                foreach (var storageChangeSet in storageChangeSets.First().Changes)
                {
                    var storageKeyString = storageChangeSet[0];

                    var keyParam = new T1();
                    keyParam.Create(storageKeyString[^(keyBytes.Length * 2)..]);

                    var valueParam = new T2();
                    valueParam.Create(storageChangeSet[1]);

                    result.Add((Utils.HexToByteArray(storageKeyString), keyParam, valueParam));
                }
            }

            return result;
        }
    }

    public sealed class AccountInfo : BaseType
    {
        public U32 Nonce { get; set; }

        public U32 Consumers { get; set; }

        public U32 Providers { get; set; }

        public U32 Sufficients { get; set; }

        public AccountData Data { get; set; }

        public override string TypeName()
        {
            return "AccountInfo";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Nonce.Encode());
            result.AddRange(Consumers.Encode());
            result.AddRange(Providers.Encode());
            result.AddRange(Sufficients.Encode());
            result.AddRange(Data.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Nonce = new U32();
            Nonce.Decode(byteArray, ref p);
            Consumers = new U32();
            Consumers.Decode(byteArray, ref p);
            Providers = new U32();
            Providers.Decode(byteArray, ref p);
            Sufficients = new U32();
            Sufficients.Decode(byteArray, ref p);
            Data = new AccountData();
            Data.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }

    public sealed class AccountData : BaseType
    {
        public U128 Free { get; set; }

        public U128 Reserved { get; set; }

        public U128 MiscFrozen { get; set; }

        public U128 FeeFrozen { get; set; }

        public override string TypeName()
        {
            return "AccountData";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Free.Encode());
            result.AddRange(Reserved.Encode());
            result.AddRange(MiscFrozen.Encode());
            result.AddRange(FeeFrozen.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Free = new U128();
            Free.Decode(byteArray, ref p);
            Reserved = new U128();
            Reserved.Decode(byteArray, ref p);
            MiscFrozen = new U128();
            MiscFrozen.Decode(byteArray, ref p);
            FeeFrozen = new U128();
            FeeFrozen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }

    public sealed class AccountId32 : BaseType
    {
        public Arr32U8 Value { get; set; }

        public override string TypeName()
        {
            return "AccountId32";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Arr32U8();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }

    public sealed class Arr32U8 : BaseType
    {
        public override int TypeSize
        {
            get
            {
                return 32;
            }
        }

        public U8[] Value { get; set; }

        public override string TypeName()
        {
            return string.Format("[{0}; {1}]", new U8().TypeName(), this.TypeSize);
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new U8[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new U8(); t.Decode(byteArray, ref p); array[i] = t; };
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Create(U8[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}