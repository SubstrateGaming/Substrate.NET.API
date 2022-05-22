﻿using NUnit.Framework;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.TypeConverters;

namespace Ajuna.NetApi.Test
{
    public class TypeEncodingTest
    {
        [Test]
        public void VecU8EncodingTest()
        {
            var tc = new GenericTypeConverter<BaseVec<U8>>();
            var actual = (BaseVec<U8>)tc.Create("0x200101020304050607");

            Assert.AreEqual(actual.Bytes, actual.Encode());

            var t1 = new U8(); t1.Create(actual.Value[0].Value);
            var t2 = new U8(); t2.Create(actual.Value[1].Value);
            var t3 = new U8(); t3.Create(actual.Value[2].Value);
            var t4 = new U8(); t4.Create(actual.Value[3].Value);
            var t5 = new U8(); t5.Create(actual.Value[4].Value);
            var t6 = new U8(); t6.Create(actual.Value[5].Value);
            var t7 = new U8(); t7.Create(actual.Value[6].Value);
            var t8 = new U8(); t8.Create(actual.Value[7].Value);

            U8[] list = new U8[]
            {
                t1,t2,t3,t4,t5,t6,t7,t8
            };

            var vecU8 = new BaseVec<U8>();
            vecU8.Create(list);

            Assert.AreEqual("0x200101020304050607", Utils.Bytes2HexString(vecU8.Bytes));

        }

        public enum DispatchClass
        {
            Normal,
            Operational,
            Mandatory
        }

        [Test]
        public void EnumEncodingTest()
        {

            var dispatchClass1 = new BaseEnum<DispatchClass>();
            var dispatchClass2 = new BaseEnum<DispatchClass>();


            dispatchClass1.Create("0x00");
            dispatchClass2.Create(DispatchClass.Normal);

            Assert.AreEqual(DispatchClass.Normal, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass1.Value);

            dispatchClass1.Create("0x01");
            dispatchClass2.Create(DispatchClass.Operational);

            Assert.AreEqual(DispatchClass.Operational, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass1.Value);

            dispatchClass1.Create("0x02");
            dispatchClass2.Create(DispatchClass.Mandatory);

            Assert.AreEqual(DispatchClass.Mandatory, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass1.Value);

        }

        [Test]
        public void OptionEncodingTest()
        {
            var optionU8Null = new BaseOpt<U8>();
            var optionU8One = new BaseOpt<U8>();

            optionU8Null.Create("0x00");
            optionU8One.Create("0x0100");

            Assert.AreEqual(null, optionU8Null.Value);
            Assert.AreEqual(0, optionU8One.Value.Value);

            Assert.AreEqual("0x00", Utils.Bytes2HexString(optionU8Null.Bytes));
            Assert.AreEqual("0x0100", Utils.Bytes2HexString(optionU8One.Bytes));
        }

        public enum PhaseState
        {
            None,
            Finalization,
            Initialization
        }

        [Test]
        public void ExtEnumEncodingTest()
        {
            var extEnumType = new BaseEnumExt<PhaseState, U8, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>();

            int p = 0;
            extEnumType.Decode(new byte[] { 0x00, 0x01 }, ref p);

            Assert.AreEqual(PhaseState.None, extEnumType.Value);
            Assert.AreEqual("U8", extEnumType.Value2.GetType().Name);
            Assert.AreEqual(1, (extEnumType.Value2 as U8).Value);

        }

        [Test]
        public void ExtEnumDencodingTest()
        {
            var extEnumType = new BaseEnumExt<PhaseState, U8, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>();

            int p = 0;
            extEnumType.Decode(new byte[] { 0x00, 0x01 }, ref p);

            Assert.AreEqual(PhaseState.None, extEnumType.Value);
            Assert.AreEqual("U8", extEnumType.Value2.GetType().Name);
            Assert.AreEqual(1, (extEnumType.Value2 as U8).Value);

            Assert.AreEqual(new byte[] { 0x00, 0x01 }, extEnumType.Bytes);
        }
    }
}