using NUnit.Framework;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Tests
{
    [TestFixture]
    public class BaseTupleTests
    {
        [Test]
        public void BaseTupleTest()
        {
            var u16Param = new U16(42);

            var t1 = new BaseTupleRust(typeof(U16));
            t1.Create("0x2a00");

            Assert.AreEqual(1, t1.Value.Length);
            Assert.AreEqual(t1.Bytes, new BaseTupleRust(new U16(42)).Bytes);
            Assert.AreEqual(((U16)t1.Value[0]).Value, ((U16)new BaseTupleRust(new U16(42)).Value[0]).Value);
            Assert.AreEqual(t1.TypeSize, new BaseTupleRust(new U16(42)).TypeSize);

            var t2 = new BaseTupleRust(typeof(U16), typeof(U16));
            t2.Create("0x2a002a00");
            Assert.AreEqual(2, t2.Value.Length);
            Assert.AreEqual(t2.Bytes, new BaseTupleRust(new U16(42), new U16(42)).Bytes);
            Assert.AreEqual(((U16)t2.Value[0]).Value, ((U16)new BaseTupleRust(new U16(42), new U16(42)).Value[0]).Value);
            Assert.AreEqual(((U16)t2.Value[1]).Value, ((U16)new BaseTupleRust(new U16(42), new U16(42)).Value[1]).Value);
            Assert.AreEqual(t2.TypeSize, new BaseTupleRust(new U16(42), new U16(42)).TypeSize);

            var t3 = new BaseTupleRust(typeof(U16), typeof(U16), typeof(U16));
            t3.Create("0x2a002a002a00");
            Assert.AreEqual(3, t3.Value.Length);
            Assert.AreEqual(t3.Bytes, new BaseTupleRust(new U16(42), new U16(42), new U16(42)).Bytes);
            Assert.AreEqual(((U16)t3.Value[0]).Value, ((U16)new BaseTupleRust(new U16(42), new U16(42), new U16(42)).Value[0]).Value);
            Assert.AreEqual(((U16)t3.Value[1]).Value, ((U16)new BaseTupleRust(new U16(42), new U16(42), new U16(42)).Value[1]).Value);
            Assert.AreEqual(((U16)t3.Value[2]).Value, ((U16)new BaseTupleRust(new U16(42), new U16(42), new U16(42)).Value[2]).Value);
            Assert.AreEqual(t3.TypeSize, new BaseTupleRust(new U16(42), new U16(42), new U16(42)).TypeSize);
        }

        [Test]
        public void BaseTupleCreateTest()
        {
            var u16 = new U16();
            u16.Create("0x2a00");

            var u32 = new U32();
            u32.Create("0xffffff00");

            var tupleOfTwo_1 = new BaseTupleRust(u16, u32);
            Assert.AreEqual("0x2A00FFFFFF00", Utils.Bytes2HexString(tupleOfTwo_1.Encode()));
            Assert.AreEqual(tupleOfTwo_1.Value.Length, new BaseTupleRust(u16, u32).Value.Length);
            Assert.AreEqual(tupleOfTwo_1.Bytes, new BaseTupleRust(u16, u32).Bytes);
            Assert.AreEqual(((U16)tupleOfTwo_1.Value[0]).Value, ((U16)new BaseTupleRust(u16, u32).Value[0]).Value);
            Assert.AreEqual(((U32)tupleOfTwo_1.Value[1]).Value, ((U32)new BaseTupleRust(u16, u32).Value[1]).Value);

            var tupleOfTwo_2 = new BaseTupleRust(typeof(U16), typeof(U32));
            tupleOfTwo_2.Create("0x2A00FFFFFF00");

            Assert.AreEqual(u16.Value, ((U16)tupleOfTwo_2.Value[0]).Value);
            Assert.AreEqual(u32.Value, ((U32)tupleOfTwo_2.Value[1]).Value);

            Assert.AreEqual(tupleOfTwo_1.Value.Length, tupleOfTwo_2.Value.Length);
            Assert.AreEqual(tupleOfTwo_1.Bytes, tupleOfTwo_2.Bytes);
            Assert.AreEqual(((U16)tupleOfTwo_1.Value[0]).Value, ((U16)tupleOfTwo_2.Value[0]).Value);
            Assert.AreEqual(((U32)tupleOfTwo_1.Value[1]).Value, ((U32)tupleOfTwo_2.Value[1]).Value);
        }

        [Test]
        public void BaseTypeEqualityWithNullBytes()
        {
            var baseTuple_1 = new BaseTupleRust(typeof(U32), typeof(U32));
            var baseTuple_2 = new BaseTupleRust(typeof(U32), typeof(U32));
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