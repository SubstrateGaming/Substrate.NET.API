using NUnit.Framework;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;

namespace Ajuna.NetApi.Test
{
    public class BaseTypesTest
    {
        [Test]
        public void BaseTupleTest()
        {
            var t1 = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U16>();
            t1.Create("0x2a00");
            Assert.AreEqual(1, t1.Value.Length);

            var t2 = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U16, Ajuna.NetApi.Model.Types.Primitive.U16>();
            t2.Create("0x2a002a00");
            Assert.AreEqual(2, t2.Value.Length);

            var t3 = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U16, Ajuna.NetApi.Model.Types.Primitive.U16, Ajuna.NetApi.Model.Types.Primitive.U16>();
            t3.Create("0x2a002a002a00");
            Assert.AreEqual(3, t3.Value.Length);
        }

        [Test]
        public void BaseTupleCreateTest()
        {
            var u16 = new Ajuna.NetApi.Model.Types.Primitive.U16();
            u16.Create("0x2a00");

            var u32 = new Ajuna.NetApi.Model.Types.Primitive.U32();
            u32.Create("0xffffff00");

            var tupleOfTwo_1 = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U16, Ajuna.NetApi.Model.Types.Primitive.U32>();
            tupleOfTwo_1.Create(u16, u32);

            Assert.AreEqual("0x2A00FFFFFF00", Utils.Bytes2HexString(tupleOfTwo_1.Encode()));

            var tupleOfTwo_2 = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U16, Ajuna.NetApi.Model.Types.Primitive.U32>();
            tupleOfTwo_2.Create("0x2A00FFFFFF00");

            Assert.AreEqual(u16.Value, ((Ajuna.NetApi.Model.Types.Primitive.U16)tupleOfTwo_2.Value[0]).Value);
            Assert.AreEqual(u32.Value, ((Ajuna.NetApi.Model.Types.Primitive.U32)tupleOfTwo_2.Value[1]).Value);
        }

        [Test]
        public void BaseVecTest()
        {
            // vec u16 test
            var vecUInt16 = new uint[] { 4, 8, 15, 16, 23, 42 };
            var baseVec = new BaseVec<Ajuna.NetApi.Model.Types.Primitive.U16>();
            baseVec.Create("0x18040008000f00100017002a00");
            for (int i = 0; i < vecUInt16.Length; i++)
            {
                Assert.AreEqual(vecUInt16[i], baseVec.Value[i].Value);
            }
        }

        [Test]
        public void BaseBitSeqTest()
        {
            var bitSeqTest1 = FromBitString("0b11010000_00000001_10100000_00000000_00000000");
            var baseBitSeq1 = new BaseBitSeq<U8, U8>();
            baseBitSeq1.Create("0xa00b80050000");
            for (int i = 0; i < bitSeqTest1.Length; i++)
            {
                Assert.AreEqual(bitSeqTest1[i], baseBitSeq1.Value[i].Value);
            }
            Assert.AreEqual("0xa00b80050000", Utils.Bytes2HexString(baseBitSeq1.Encode()).ToLower());

            var bitSeqTest2 = FromBitString("0b10000010_10000010_00101000_00000000_00000000");
            var baseBitSeq2 = new BaseBitSeq<U8, U8>();
            baseBitSeq2.Create("0xa04141140000");
            for (int i = 0; i < bitSeqTest1.Length; i++)
            {
                Assert.AreEqual(bitSeqTest2[i], baseBitSeq2.Value[i].Value);
            }
            Assert.AreEqual("0xa04141140000", Utils.Bytes2HexString(baseBitSeq2.Encode()).ToLower());
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

    }
}