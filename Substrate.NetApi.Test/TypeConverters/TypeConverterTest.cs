﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;
using NUnit.Framework;

namespace Substrate.NetApi.Test
{
    public class TypeConverterTest
    {
        [Test]
        public void BoolTypeConverterTest()
        {
            var tc = new GenericTypeConverter<Bool>();
            var actual = (Bool)tc.Create("0x00");
            Assert.AreEqual(false, actual.Value);
            actual = (Bool)tc.Create("0x01");
            Assert.AreEqual(true, actual.Value);
        }

        [Test]
        public void U16TypeConverterTest()
        {
            var tc = new GenericTypeConverter<U16>();
            var actual = (U16)tc.Create("0xf142");
            Assert.AreEqual((short)0x42f1, actual.Value);
        }

        [Test]
        public void U32TypeConverterTest()
        {
            var tc = new GenericTypeConverter<U32>();
            var actual = (U32)tc.Create("0xf142bca0");
            Assert.AreEqual(0xa0bc42f1, actual.Value);
        }

        [Test]
        public void U64TypeConverterTest()
        {
            var tc = new GenericTypeConverter<U64>();
            var actual = (U64)tc.Create("0x01de99faf142bca0");
            Assert.AreEqual(0xa0bc42f1fa99de01, actual.Value);
        }

        [Test]
        public void VecU8TypeConverterTest()
        {
            var tc = new GenericTypeConverter<BaseVec<U8>>();
            var actual = (BaseVec<U8>)tc.Create("0x200101020304050607");
            Assert.AreEqual(1, actual.Value[0].Value);
            Assert.AreEqual(1, actual.Value[1].Value);
            Assert.AreEqual(2, actual.Value[2].Value);
            Assert.AreEqual(3, actual.Value[3].Value);
            Assert.AreEqual(4, actual.Value[4].Value);
            Assert.AreEqual(5, actual.Value[5].Value);
            Assert.AreEqual(6, actual.Value[6].Value);
            Assert.AreEqual(7, actual.Value[7].Value);
        }
    }
}