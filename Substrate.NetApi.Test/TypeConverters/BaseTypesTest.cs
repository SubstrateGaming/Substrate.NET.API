using System;
using System.Linq;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Substrate.NetApi.Test
{
    public class BaseTypesTest
    {
        [Test]
        public void BaseTupleTest()
        {
            var u16Param = new U16(42);

            var t1 = new BaseTuple<U16>();
            t1.Create("0x2a00");
            Assert.AreEqual(1, t1.Value.Length);
            Assert.AreEqual(t1.Bytes, new BaseTuple<U16>(u16Param).Bytes);
            Assert.AreEqual(((U16)t1.Value[0]).Value, ((U16)new BaseTuple<U16>(u16Param).Value[0]).Value);
            Assert.AreEqual(t1.TypeSize, new BaseTuple<U16>(u16Param).TypeSize);


            var t2 = new BaseTuple<U16, U16>();
            t2.Create("0x2a002a00");
            Assert.AreEqual(2, t2.Value.Length);
            Assert.AreEqual(t2.Bytes, new BaseTuple<U16, U16>(u16Param, u16Param).Bytes);
            Assert.AreEqual(((U16)t2.Value[0]).Value, ((U16)new BaseTuple<U16, U16>(u16Param, u16Param).Value[0]).Value);
            Assert.AreEqual(((U16)t2.Value[1]).Value, ((U16)new BaseTuple<U16, U16>(u16Param, u16Param).Value[1]).Value);
            Assert.AreEqual(t2.TypeSize, new BaseTuple<U16, U16>(u16Param, u16Param).TypeSize);

            var t3 = new BaseTuple<U16, U16, U16>();
            t3.Create("0x2a002a002a00");
            Assert.AreEqual(3, t3.Value.Length);
            Assert.AreEqual(t3.Bytes, new BaseTuple<U16, U16, U16>(u16Param, u16Param, u16Param).Bytes);
            Assert.AreEqual(((U16)t3.Value[0]).Value, ((U16)new BaseTuple<U16, U16, U16>(u16Param, u16Param, u16Param).Value[0]).Value);
            Assert.AreEqual(((U16)t3.Value[1]).Value, ((U16)new BaseTuple<U16, U16, U16>(u16Param, u16Param, u16Param).Value[1]).Value);
            Assert.AreEqual(((U16)t3.Value[2]).Value, ((U16)new BaseTuple<U16, U16, U16>(u16Param, u16Param, u16Param).Value[1]).Value);
            Assert.AreEqual(t3.TypeSize, new BaseTuple<U16, U16, U16>(u16Param, u16Param, u16Param).TypeSize);
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
            Assert.AreEqual(tupleOfTwo_1.Value.Length, new BaseTuple<U16, U32>(u16, u32).Value.Length);
            Assert.AreEqual(tupleOfTwo_1.Bytes, new BaseTuple<U16, U32>(u16, u32).Bytes);
            Assert.AreEqual(((U16)tupleOfTwo_1.Value[0]).Value, ((U16)new BaseTuple<U16, U32>(u16, u32).Value[0]).Value);
            Assert.AreEqual(((U32)tupleOfTwo_1.Value[1]).Value, ((U32)new BaseTuple<U16, U32>(u16, u32).Value[1]).Value);

            var tupleOfTwo_2 = new BaseTuple<U16, U32>();
            tupleOfTwo_2.Create("0x2A00FFFFFF00");

            Assert.AreEqual(u16.Value, ((U16)tupleOfTwo_2.Value[0]).Value);
            Assert.AreEqual(u32.Value, ((U32)tupleOfTwo_2.Value[1]).Value);

            Assert.AreEqual(tupleOfTwo_1.Value.Length, tupleOfTwo_2.Value.Length);
            Assert.AreEqual(tupleOfTwo_1.Bytes, tupleOfTwo_2.Bytes);
            Assert.AreEqual(((U16)tupleOfTwo_1.Value[0]).Value, ((U16)tupleOfTwo_2.Value[0]).Value);
            Assert.AreEqual(((U32)tupleOfTwo_1.Value[1]).Value, ((U32)tupleOfTwo_2.Value[1]).Value);
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
            Assert.AreEqual(baseVec.Bytes, baseVecCtor.Bytes);
            Assert.AreEqual(baseVec.Value[0].Value, baseVecCtor.Value[0].Value);
            Assert.AreEqual(baseVec.TypeSize, baseVecCtor.TypeSize);

            // Just add an other value at the end and check equality fail
            var baseVecCtor_2 = new BaseVec<U16>(
                new uint[] { 4, 8, 15, 16, 23, 42, 100 }.Select(x => new U16((ushort)x)).ToArray());
            Assert.IsFalse(baseVecCtor.Equals(baseVecCtor_2));

            U16[] arrayFromBaseVec = baseVec;
            for (int i = 0; i < vecUInt16.Length; i++)
            {
                Assert.AreEqual(vecUInt16[i], arrayFromBaseVec[i].Value);
            }

            BaseVec<U16> baseVecFromU16Array = (BaseVec<U16>) arrayFromBaseVec;
            for (int i = 0; i < vecUInt16.Length; i++)
            {
                Assert.AreEqual(vecUInt16[i], baseVecFromU16Array.Value[i].Value);
            }
            Assert.AreEqual(baseVec.Bytes, baseVecFromU16Array.Bytes);
            Assert.AreEqual(baseVec.TypeSize, baseVecFromU16Array.TypeSize);
        }

        [Test]
        public void BaseOptTest()
        {
            var baseOptEmpty = new BaseOpt<U32>(null);
            Assert.That(baseOptEmpty.OptionFlag, Is.EqualTo(false));
            Assert.That(baseOptEmpty.Value, Is.Null);
            Assert.That(baseOptEmpty.Encode(), Is.Not.Null);

            var newDecoded = new BaseOpt<U32>();
            int p = 0;
            newDecoded.Decode(baseOptEmpty.Encode(), ref p);
            Assert.AreEqual(newDecoded.TypeSize, baseOptEmpty.TypeSize);

            var expectedOutput = new U64(100);
            var baseOptFilled = new BaseOpt<U64>();
            baseOptFilled.Create("0x016400000000000000");
            Assert.That(baseOptFilled.OptionFlag, Is.EqualTo(true));
            Assert.That(baseOptFilled.Value.Value, Is.EqualTo(expectedOutput.Value));

            var baseOptFilledWithValue = new BaseOpt<U64>();
            baseOptFilledWithValue.Create(expectedOutput);
            Assert.AreEqual(baseOptFilled.Bytes, baseOptFilledWithValue.Bytes);
            Assert.AreEqual(baseOptFilled.Value.Value, baseOptFilledWithValue.Value.Value);
            Assert.AreEqual(baseOptFilled.TypeSize, baseOptFilledWithValue.TypeSize);


            var baseOptFilledCtor = new BaseOpt<U64>(expectedOutput);
            Assert.That(baseOptFilledCtor.OptionFlag, Is.EqualTo(baseOptFilled.OptionFlag));
            Assert.AreEqual(baseOptFilledCtor.Bytes, baseOptFilled.Bytes);
            Assert.AreEqual(baseOptFilledCtor.Value.Value, baseOptFilled.Value.Value);
            Assert.AreEqual(baseOptFilledCtor.TypeSize, baseOptFilled.TypeSize);

            // Test case with Option flag = false while data are set
            var baseOptFilledError = new BaseOpt<U64>();
            baseOptFilledError.Create("0x006400000000000000");
            Assert.That(baseOptFilledError.OptionFlag, Is.EqualTo(false));
            Assert.That(baseOptFilledError.Bytes, Is.Not.Null);
            Assert.That(baseOptFilledError.Bytes.Length, Is.EqualTo(1));

            ulong value = 100;

            // Testing implicit operator
            BaseOpt<U64> implicitOpt = (U64)value;
            Assert.AreEqual(value, implicitOpt.Value.Value);

            // Testing explicit operator with a filled BaseOpt
            BaseOpt<U64> explicitOptFilled = new BaseOpt<U64>((U64)value);
            ulong explicitValueFilled = (U64)explicitOptFilled;
            Assert.AreEqual(value, explicitValueFilled);

            // Testing explicit operator with an empty BaseOpt
            BaseOpt<U64> explicitOptEmpty = new BaseOpt<U64>(null);
            bool exceptionThrown = false;
            try
            {
                _ = (U64)explicitOptEmpty;
            }
            catch (InvalidOperationException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Option is None", ex.Message);
            }
            Assert.IsTrue(exceptionThrown, "Exception not thrown for explicit cast of empty BaseOpt");

            // Testing explicit operator with a filled BaseOpt but OptionFlag = false (this is an unusual case)
            explicitOptFilled.OptionFlag = false;
            exceptionThrown = false;
            try
            {
                _ = (U64)explicitOptFilled;
            }
            catch (InvalidOperationException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Option is None", ex.Message);
            }
            Assert.IsTrue(exceptionThrown, "Exception not thrown for explicit cast with OptionFlag = false");
        }

        [Test]
        public void BaseBitSeqTest()
        {
            var testCase1 = "0xa00b80050000";
            var bitSeqTest1 = Utils.FromBitString("0b11010000_00000001_10100000_00000000_00000000");
            var baseBitSeq1 = new BaseBitSeq<U8>();
            baseBitSeq1.Create(testCase1);
            for (int i = 0; i < bitSeqTest1.Length; i++)
            {
                Assert.AreEqual(bitSeqTest1[i], baseBitSeq1.Value[i].Value);
            }
            Assert.AreEqual(testCase1, Utils.Bytes2HexString(baseBitSeq1.Encode()).ToLower());

            // Let's create the same object but with the other Create() method
            var baseBitSeq1_1 = new BaseBitSeq<U8>();
            baseBitSeq1_1.Create(baseBitSeq1.Value, BitOrder.Lsb0);
            Assert.AreEqual(baseBitSeq1.Bytes, baseBitSeq1_1.Bytes);
            Assert.AreEqual(baseBitSeq1.Value, baseBitSeq1_1.Value);
            Assert.AreEqual(baseBitSeq1.TypeSize, baseBitSeq1_1.TypeSize);

            var bitSeqTest2 = Utils.FromBitString("0b10000010_10000010_00101000_00000000_00000000");
            var baseBitSeq2 = new BaseBitSeq<U8>();
            baseBitSeq2.Create("0xa04141140000");
            for (int i = 0; i < bitSeqTest1.Length; i++)
            {
                Assert.AreEqual(bitSeqTest2[i], baseBitSeq2.Value[i].Value);
            }
            Assert.AreEqual("0xa04141140000", Utils.Bytes2HexString(baseBitSeq2.Encode()).ToLower());
        }

        [Test]
        public void BaseComTest()
        {
            var baseComFromValue = new BaseCom<U64>();
            baseComFromValue.Create(new CompactInteger(new U64(10)));

            var baseComFromCtor = new BaseCom<U64>(new CompactInteger(new U64(10)));

            var baseComFromBytes = new BaseCom<U64>();
            baseComFromBytes.Create(new byte[] { 40 });

            var baseComFromHex = new BaseCom<U64>();
            baseComFromHex.Create("0x28");

            Assert.AreEqual(baseComFromValue.Bytes, baseComFromCtor.Bytes);
            Assert.AreEqual(baseComFromValue.Value, baseComFromCtor.Value);
            Assert.AreEqual(baseComFromValue.TypeSize, baseComFromCtor.TypeSize);

            Assert.AreEqual(baseComFromValue.Bytes, baseComFromBytes.Bytes);
            Assert.AreEqual(baseComFromValue.Value, baseComFromBytes.Value);
            Assert.AreEqual(baseComFromValue.TypeSize, baseComFromBytes.TypeSize);

            Assert.AreEqual(baseComFromValue.Bytes, baseComFromHex.Bytes);
            Assert.AreEqual(baseComFromValue.Value, baseComFromHex.Value);
            Assert.AreEqual(baseComFromValue.TypeSize, baseComFromHex.TypeSize);

            Assert.AreNotEqual(baseComFromValue.Bytes, new BaseCom<U64>(new CompactInteger(new U64(20))).Bytes);
            Assert.AreNotEqual(baseComFromValue.Value, new BaseCom<U64>(new CompactInteger(new U64(20))).Value);
            Assert.AreEqual(baseComFromValue.TypeSize, new BaseCom<U64>(new CompactInteger(new U64(20))).TypeSize);

            Assert.AreEqual(baseComFromValue.Bytes, new BaseCom<U128>(new CompactInteger(new U128(10))).Bytes);
            Assert.AreEqual(baseComFromValue.Value, new BaseCom<U128>(new CompactInteger(new U128(10))).Value);
            Assert.AreEqual(baseComFromValue.TypeSize, new BaseCom<U128>(new CompactInteger(new U128(10))).TypeSize);

            // Test explicit conversion from CompactInteger to BaseCom
            var compactInt = new CompactInteger(new U64(10));
            var baseComFromExplicitConversion = (BaseCom<U64>)compactInt;
            Assert.AreEqual(baseComFromValue.Bytes, baseComFromExplicitConversion.Bytes);
            Assert.AreEqual(baseComFromValue.Value, baseComFromExplicitConversion.Value);
            Assert.AreEqual(baseComFromValue.TypeSize, baseComFromExplicitConversion.TypeSize);

            // Test implicit conversion from BaseCom to CompactInteger
            CompactInteger compactIntFromImplicitConversion = baseComFromValue;
            Assert.AreEqual(compactInt.Value, compactIntFromImplicitConversion.Value);
            Assert.AreEqual(compactInt.Encode(), compactIntFromImplicitConversion.Encode());
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

            Assert.AreEqual(baseEnumFromValue.Bytes, baseEnumFromBytes.Bytes);
            Assert.AreEqual(baseEnumFromValue.Value, baseEnumFromBytes.Value);
            Assert.AreEqual(baseEnumFromValue.TypeSize, baseEnumFromBytes.TypeSize);

            Assert.AreEqual(baseEnumFromValue.Bytes, baseEnumFromHex.Bytes);
            Assert.AreEqual(baseEnumFromValue.Value, baseEnumFromHex.Value);
            Assert.AreEqual(baseEnumFromValue.TypeSize, baseEnumFromHex.TypeSize);

            Assert.AreNotEqual(baseEnumFromValue.Bytes, new BaseEnum<PartialBalanceEvents>(PartialBalanceEvents.BalanceSet).Bytes);
            Assert.AreNotEqual(baseEnumFromValue.Bytes, new BaseEnum<PartialBalanceEvents>(PartialBalanceEvents.BalanceSet).Value);

            // Test explicit conversion from Enum to BaseEnum
            BaseEnum<PartialBalanceEvents> baseEnumFromImplicitConversion = (BaseEnum<PartialBalanceEvents>)PartialBalanceEvents.Transfer;
            Assert.AreEqual(baseEnumFromValue.Bytes, baseEnumFromImplicitConversion.Bytes);
            Assert.AreEqual(baseEnumFromValue.Value, baseEnumFromImplicitConversion.Value);
            Assert.AreEqual(baseEnumFromValue.TypeSize, baseEnumFromImplicitConversion.TypeSize);

            // Test implicit conversion from BaseEnum to Enum
            PartialBalanceEvents enumValueFromImplicitConversion = baseEnumFromValue;
            Assert.AreEqual(PartialBalanceEvents.Transfer, enumValueFromImplicitConversion);
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
            // Use a more meaningful byte array as test data
            var value = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
            var hexValue = Utils.Bytes2HexString(value);

            // Create Hash object using Create method
            var hash = new Hash();
            hash.Create(value);
            Assert.AreEqual(value, hash.Bytes);
            Assert.AreEqual(hexValue, hash.Value);

            // Create Hash object using constructor
            var hashPrim = new Hash(value);
            Assert.AreEqual(value, hashPrim.Bytes);
            Assert.AreEqual(hexValue, hashPrim.Value);

            // Test explicit conversion from byte[] to Hash
            Hash hashExplicit = (Hash)value;
            Assert.AreEqual(value, hashExplicit.Bytes);
            Assert.AreEqual(hexValue, hashExplicit.Value);

            // Test implicit conversion from Hash to byte[]
            byte[] bytesImplicit = hash;
            Assert.AreEqual(value, bytesImplicit);
        }

        [Test]
        public void BaseTypeEqualityWithNullBytes()
        {
            var baseTuple_1 = new BaseTuple<U32, U32>();
            var baseTuple_2 = new BaseTuple<U32, U32>();
            Assert.That(baseTuple_1.Bytes, Is.Null);
            Assert.That(baseTuple_1.Value, Is.Null);
            Assert.AreEqual(baseTuple_1.Bytes, baseTuple_2.Bytes);
            Assert.AreEqual(baseTuple_1.Value, baseTuple_2.Value);

            var baseOpt_1 = new BaseOpt<U32>();
            var baseOpt_2 = new BaseOpt<U32>();
            Assert.That(baseOpt_1.Bytes, Is.Null);
            Assert.That(baseOpt_1.Value, Is.Null);
            Assert.AreEqual(baseOpt_1.Bytes, baseOpt_2.Bytes);
            Assert.AreEqual(baseOpt_1.Value, baseOpt_2.Value);
            var baseVec_1 = new BaseVec<U32>();
            var baseVec_2 = new BaseVec<U32>();
            Assert.That(baseVec_1.Bytes, Is.Null);
            Assert.That(baseVec_1.Value, Is.Null);
            Assert.AreEqual(baseVec_1.Bytes, baseVec_2.Bytes);
            Assert.AreEqual(baseVec_1.Value, baseVec_2.Value);
        }
    }
}