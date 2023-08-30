using System.Collections.Generic;
using System.Numerics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;

namespace Substrate.NetApi.Test
{
    public class Balance : BasePrim<BigInteger>
    {
        public override string TypeName() => "T::Balance";

        public override int TypeSize => 16;

        public override byte[] Encode()
        {
            return new CompactInteger(Value).Encode();
        }

        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = new BigInteger(byteArray);
        }

        public override void Create(BigInteger value)
        {
            Bytes = value.ToByteArray();
            Value = value;
        }
    }

    public class AccountData : BaseType
    {
        public override string TypeName() => "AccountData<T::Balance>";

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

            Free = new Balance();
            Free.Decode(byteArray, ref p);

            Reserved = new Balance();
            Reserved.Decode(byteArray, ref p);

            MiscFrozen = new Balance();
            MiscFrozen.Decode(byteArray, ref p);

            FeeFrozen = new Balance();
            FeeFrozen.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Balance Free { get; private set; }
        public Balance Reserved { get; private set; }
        public Balance MiscFrozen { get; private set; }
        public Balance FeeFrozen { get; private set; }
    }

    public class AccountDataWithCharity : AccountData
    {
        public override string TypeName() => "AccountDataNewVersion<T::Balance>";

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Free.Encode());
            result.AddRange(Reserved.Encode());
            result.AddRange(MiscFrozen.Encode());
            result.AddRange(FeeFrozen.Encode());
            result.AddRange(Charity.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Free = new Balance();
            Free.Decode(byteArray, ref p);

            Reserved = new Balance();
            Reserved.Decode(byteArray, ref p);

            MiscFrozen = new Balance();
            MiscFrozen.Decode(byteArray, ref p);

            FeeFrozen = new Balance();
            FeeFrozen.Decode(byteArray, ref p);

            Charity = new Balance();
            Charity.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Balance Free { get; private set; }
        public Balance Reserved { get; private set; }
        public Balance MiscFrozen { get; private set; }
        public Balance FeeFrozen { get; private set; }
        public Balance Charity { get; private set; }
    }

    public class AccountInfo : BaseType
    {
        public override string TypeName() => "AccountInfo<T::Index, T::AccountData>";

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Nonce.Encode());
            result.AddRange(Consumers.Encode());
            result.AddRange(Providers.Encode());
            result.AddRange(AccountData.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Nonce = new U32();
            Nonce.Decode(byteArray, ref p);

            Consumers = new RefCount();
            Consumers.Decode(byteArray, ref p);

            Providers = new RefCount();
            Providers.Decode(byteArray, ref p);

            AccountData = new AccountData();
            AccountData.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public U32 Nonce { get; private set; }
        public RefCount Consumers { get; private set; }
        public RefCount Providers { get; private set; }
        public AccountData AccountData { get; private set; }
    }

    public class RefCount : U32
    {
        public override string TypeName() => "RefCount";
    }

    public class ValueTests
    {
        [Test]
        public void EncodingTest()
        {
            var accountId = new AccountId();
            accountId.Create("0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d");

            var balance = new Balance();
            balance.Create(100);

            var byteList = new List<byte>();
            foreach (var callArgument in new IType[] { accountId, balance })
            {
                byteList.AddRange(callArgument.Encode());
            }
            var callArguments = byteList.ToArray();

            switch (Constants.AddressVersion)
            {
                case 0:
                    Assert.AreEqual("D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D9101",
                        Utils.Bytes2HexString(callArguments, Utils.HexStringFormat.Pure));
                    break;

                case 1:
                    Assert.AreEqual("FFD43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D9101",
                        Utils.Bytes2HexString(callArguments, Utils.HexStringFormat.Pure));
                    break;

                case 2:
                    Assert.AreEqual("00D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D9101",
                        Utils.Bytes2HexString(callArguments, Utils.HexStringFormat.Pure));
                    break;
            }
        }

        [Test]
        public void BalanceTest()
        {
            var balance1 = new Balance();
            balance1.Create("0x518fd3f9a8503a4f7e00000000000000");
            Assert.AreEqual("2329998717451725147985", balance1.Value.ToString());

            var balance2 = new Balance();
            balance2.Create(Utils.HexToByteArray("518fd3f9a8503a4f7e00000000000000"));
            Assert.AreEqual("2329998717451725147985", balance2.Value.ToString());
        }

        [Test]
        public void AccountDataTest()
        {
            var accountData = new AccountData();
            accountData.Create(Utils.HexToByteArray(
                "518fd3f9a8503a4f7e0000000000000000c040b571e8030000000000000000000000c16ff2862300000000000000000000000000000000000000000000000000"));
            Assert.AreEqual("2329998717451725147985", accountData.Free.Value.ToString());
            Assert.AreEqual("1100000000000000", accountData.Reserved.Value.ToString());
            Assert.AreEqual("0", accountData.FeeFrozen.Value.ToString());
            Assert.AreEqual("10000000000000000", accountData.MiscFrozen.Value.ToString());
        }

        [Test]
        public void AccountInfoTest()
        {
            var accountInfo = new AccountInfo();
            accountInfo.Create(Utils.HexToByteArray(
                "0500000000000000010000001d58857016a4755a6c00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            Assert.AreEqual(5, accountInfo.Nonce.Value);
            Assert.AreEqual(0, accountInfo.Consumers.Value);
            Assert.AreEqual(1, accountInfo.Providers.Value);
            Assert.AreEqual("1998766656412604258333", accountInfo.AccountData.Free.Value.ToString());
            Assert.AreEqual("0", accountInfo.AccountData.Reserved.Value.ToString());
            Assert.AreEqual("0", accountInfo.AccountData.FeeFrozen.Value.ToString());
            Assert.AreEqual("0", accountInfo.AccountData.MiscFrozen.Value.ToString());
        }
    }
}