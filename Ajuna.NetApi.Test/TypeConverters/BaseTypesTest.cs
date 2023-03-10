using System;
using System.Linq;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NUnit.Framework;

namespace Ajuna.NetApi.Test
{
    public class BaseTypesTest
    {
        /*
         * Note : I use on purpose Assert.IsTrue(x.Equals(y)) instead of Assert.AreEqual(x, y)
         * because the green tick "n/n passing" on the Equals method and it's easier to navigate throw the code 
         */

        [Test]
        public void BaseTupleTest()
        {
            var u16Param = new U16(42);

            var t1 = new BaseTuple<U16>();
            t1.Create("0x2a00");
            Assert.AreEqual(1, t1.Value.Length);
            Assert.IsTrue(t1.Equals(new BaseTuple<U16>(u16Param)));

            var t2 = new BaseTuple<U16, U16>();
            t2.Create("0x2a002a00");
            Assert.AreEqual(2, t2.Value.Length);
            Assert.IsTrue(t2.Equals(new BaseTuple<U16, U16>(u16Param, u16Param)));

            var t3 = new BaseTuple<U16, U16, U16>();
            t3.Create("0x2a002a002a00");
            Assert.AreEqual(3, t3.Value.Length);
            Assert.IsTrue(t3.Equals(new BaseTuple<U16, U16, U16>(u16Param, u16Param, u16Param)));

            var t4 = new BaseTuple<U16, U16, U16>();
            t4.Create(u16Param, u16Param, u16Param);

            Assert.IsFalse(t2.Equals(t4));
            Assert.IsTrue(t3.Equals(t4));
        }

        [Test]
        public void BaseTupleCreateTest()
        {
            var u16 = new U16();
            u16.Create("0x2a00");

            var u32 = new U32();
            u32.Create("0xffffff00");

            var tupleOfTwo_1 = new BaseTuple<U16, U32>();
            tupleOfTwo_1.Create(u16, u32);

            Assert.AreEqual("0x2A00FFFFFF00", Utils.Bytes2HexString(tupleOfTwo_1.Encode()));
            Assert.IsTrue(tupleOfTwo_1.Equals(new BaseTuple<U16, U32>(u16, u32)));

            var tupleOfTwo_2 = new BaseTuple<U16, U32>();
            tupleOfTwo_2.Create("0x2A00FFFFFF00");

            Assert.AreEqual(u16.Value, ((U16)tupleOfTwo_2.Value[0]).Value);
            Assert.AreEqual(u32.Value, ((U32)tupleOfTwo_2.Value[1]).Value);

            Assert.IsTrue(tupleOfTwo_1.Equals(tupleOfTwo_2));
        }

        [Test]
        public void BaseVecTest()
        {
            // vec u16 test
            var vecUInt16 = new uint[] { 4, 8, 15, 16, 23, 42 };
            var baseVec = new BaseVec<U16>();
            baseVec.Create("0x18040008000f00100017002a00");
            for (int i = 0; i < vecUInt16.Length; i++)
            {
                Assert.AreEqual(vecUInt16[i], baseVec.Value[i].Value);
            }

            var baseVecCtor = new BaseVec<U16>(vecUInt16.Select(x => new U16((ushort)x)).ToArray());
            Assert.IsTrue(baseVec.Equals(baseVecCtor));

            // Just add an other value at the end and check equality fail
            var baseVecCtor_2 = new BaseVec<U16>(
                new uint[] { 4, 8, 15, 16, 23, 42, 100 }.Select(x => new U16((ushort)x)).ToArray());
            Assert.IsFalse(baseVecCtor.Equals(baseVecCtor_2));
        }

        [Test]
        public void BaseOptTest()
        {
            var baseOptEmpty = new BaseOpt<U32>();
            Assert.That(baseOptEmpty.OptionFlag, Is.EqualTo(false));
            Assert.That(baseOptEmpty.Value, Is.Null);

            var expectedOutput = new U64(100);
            var baseOptFilled = new BaseOpt<U64>();
            baseOptFilled.Create("0x016400000000000000");
            Assert.That(baseOptFilled.OptionFlag, Is.EqualTo(true));
            Assert.That(baseOptFilled.Value, Is.EqualTo(expectedOutput));

            var baseOptFilledWithValue = new BaseOpt<U64>();
            baseOptFilledWithValue.Create(expectedOutput);
            Assert.IsTrue(baseOptFilled.Equals(baseOptFilledWithValue));

            var baseOptFilledCtor = new BaseOpt<U64>(expectedOutput);
            Assert.That(baseOptFilledCtor.OptionFlag, Is.EqualTo(baseOptFilled.OptionFlag));
            Assert.IsTrue(baseOptFilledCtor.Equals(baseOptFilled));

            // Test case with Option flag = false while data are set
            var baseOptFilledError = new BaseOpt<U64>();
            baseOptFilledError.Create("0x006400000000000000");
            Assert.That(baseOptFilledError.OptionFlag, Is.EqualTo(false));
            Assert.That(baseOptFilledError.Bytes, Is.Not.Null);
            Assert.That(baseOptFilledError.Bytes.Length, Is.EqualTo(1));
        }

        [Test]
        public void BaseBitSeqTest()
        {
            var testCase1 = "0xa00b80050000";
            var bitSeqTest1 = FromBitString("0b11010000_00000001_10100000_00000000_00000000");
            var baseBitSeq1 = new BaseBitSeq<U8, U8>();
            baseBitSeq1.Create(testCase1);
            for (int i = 0; i < bitSeqTest1.Length; i++)
            {
                Assert.AreEqual(bitSeqTest1[i], baseBitSeq1.Value[i].Value);
            }
            Assert.AreEqual(testCase1, Utils.Bytes2HexString(baseBitSeq1.Encode()).ToLower());

            // Let's create the same object but with the other Create() method
            var baseBitSeq1_1 = new BaseBitSeq<U8, U8>();
            baseBitSeq1_1.Create(baseBitSeq1.Value);
            
            Assert.IsTrue(baseBitSeq1.Equals(baseBitSeq1_1));

            var bitSeqTest2 = FromBitString("0b10000010_10000010_00101000_00000000_00000000");
            var baseBitSeq2 = new BaseBitSeq<U8, U8>();
            baseBitSeq2.Create("0xa04141140000");
            for (int i = 0; i < bitSeqTest1.Length; i++)
            {
                Assert.AreEqual(bitSeqTest2[i], baseBitSeq2.Value[i].Value);
            }
            Assert.AreEqual("0xa04141140000", Utils.Bytes2HexString(baseBitSeq2.Encode()).ToLower());

            //
        }

        private byte[] FromBitString(string str)
        {
            var s = str.Replace("0b", "").Split('_');
            var result = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = Convert.ToByte(s[i], 2);
            }
            return result;
        }

        [Test]
        public void BaseComTest()
        {
            var baseComFromCtor = new BaseCom<U64>(new CompactInteger(new U64(10)));

            var baseComFromValue = new BaseCom<U64>();
            baseComFromValue.Create(new CompactInteger(new U64(10)));

            var baseComFromBytes = new BaseCom<U64>();
            baseComFromBytes.Create(new byte[] { 40 });

            var baseComFromHex = new BaseCom<U64>();
            baseComFromHex.Create("0x28");

            Assert.IsTrue(baseComFromValue.Equals(baseComFromCtor));
            Assert.IsTrue(baseComFromValue.Equals(baseComFromBytes));
            Assert.IsTrue(baseComFromValue.Equals(baseComFromHex));

            Assert.IsFalse(baseComFromValue.Equals(new BaseCom<U64>(new CompactInteger(new U64(20)))));
        }

        public enum PartialBalanceEvents
        {

            Endowed = 0,
            DustLost = 1,
            Transfer = 2,
            BalanceSet = 3,
        }

        [Test]
        public void BaseEnumTest()
        {
            var baseEnumFromValue = new BaseEnum<PartialBalanceEvents>();
            baseEnumFromValue.Create(PartialBalanceEvents.Transfer);

            var baseEnumFromBytes = new BaseEnum<PartialBalanceEvents>();
            baseEnumFromBytes.Create(new byte[] { 2 });

            var baseEnumFromHex = new BaseEnum<PartialBalanceEvents>();
            baseEnumFromHex.Create("0x02");

            Assert.IsTrue(baseEnumFromValue.Equals(baseEnumFromBytes));
            Assert.IsTrue(baseEnumFromValue.Equals(baseEnumFromHex));
            Assert.IsFalse(baseEnumFromValue.Equals(new BaseEnum<PartialBalanceEvents>(PartialBalanceEvents.BalanceSet)));
        }

        [Test]
        public void AccountIdTest()
        {
            var accountId = new AccountId();
            accountId.Create("0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d");

            var accountIdPrim = new AccountId("0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d");

            Assert.AreEqual(accountId.Bytes, accountIdPrim.Bytes);
        }

        [Test]
        public void HashTest()
        {
            var blockHash = new byte[]
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var hash = new Hash();
            hash.Create(blockHash);

            var hashPrim = new Hash(blockHash);

            Assert.AreEqual(hash.Bytes, hashPrim.Bytes);
        }

        [Test]
        public void BaseTypeEqualityTest()
        {
            var u32_1 = new U32(10);
            var u32_2 = new U32(10);
            var u32_3 = new U32(20);

            Assert.IsTrue(u32_1.Equals(u32_2));
            Assert.IsFalse(u32_1.Equals(u32_3));

            var u64_1 = new U64(10);
            var u64_2 = new U64(10);
            var u64_3 = new U64(20);

            Assert.IsTrue(u64_1.Equals(u64_2));
            Assert.IsTrue(u64_1.Equals(u64_2));
            Assert.IsFalse(u32_1.Equals(u64_1));
            Assert.IsFalse(u64_1.Equals(u64_3));

            Assert.IsTrue(new BaseOpt<U32>(new U32(1)).Equals(new BaseOpt<U32>(new U32(1))));
            Assert.IsTrue(new BaseVec<U32>(
                new U32[] { new U32(1)
                }).Equals(new BaseVec<U32>(
                    new U32[] { new U32(1)
                    })));
        }

        [Test]
        public void BaseTypeEqualityWithNullBytes()
        {
            var baseTuple_1 = new BaseTuple<U32, U32>();
            var baseTuple_2 = new BaseTuple<U32, U32>();

            // Bytes null, but should be equal
            Assert.That(baseTuple_1.Bytes, Is.Null);
            Assert.That(baseTuple_1, Is.EqualTo(baseTuple_2));

            var baseVec_1 = new BaseVec<U32>();
            Assert.That(baseTuple_1, Is.Not.EqualTo(baseVec_1));

            Assert.That(new BaseOpt<U32>(), Is.EqualTo(new BaseOpt<U32>()));
            Assert.That(new BaseVec<U32>(), Is.EqualTo(new BaseVec<U32>()));
        }
    }
}