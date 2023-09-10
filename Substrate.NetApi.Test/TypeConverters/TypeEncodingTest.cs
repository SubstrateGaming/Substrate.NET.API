using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;
using NUnit.Framework;

namespace Substrate.NetApi.Test
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
            var dispatchClass3 = new BaseEnum<DispatchClass>();

            dispatchClass1.Create("0x00");
            dispatchClass2.Create(DispatchClass.Normal);

            int p = 0;
            dispatchClass3.Decode(dispatchClass2.Encode(), ref p);

            Assert.AreEqual(DispatchClass.Normal, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass3.Value);
            Assert.AreEqual(dispatchClass2.Encode(), dispatchClass1.Encode());

            dispatchClass1.Create("0x01");
            dispatchClass2.Create(DispatchClass.Operational);

            Assert.AreEqual(DispatchClass.Operational, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Encode(), dispatchClass1.Encode());

            dispatchClass1.Create("0x02");
            dispatchClass2.Create(DispatchClass.Mandatory);

            Assert.AreEqual(DispatchClass.Mandatory, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Value, dispatchClass1.Value);
            Assert.AreEqual(dispatchClass2.Encode(), dispatchClass1.Encode());
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

        [Test]
        public void BaseOptClassTest()
        {
            var optClass = new BaseOpt<NotSoComplexClass>();
            optClass.Create("0x010A00000014000000");
            Assert.That(optClass.Bytes, Is.Not.Null);
            Assert.That(optClass.Value.Bytes, Is.Not.Null);
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

        [Test]
        public void ExtEnumCreateTest()
        {
            var u8 = new U8(1);

            var vecExtEnumTypeFromCreateValue = new BaseEnumExt<PhaseState, U8>();
            vecExtEnumTypeFromCreateValue.Create(PhaseState.None, u8);

            var vecExtEnumTypeFromCreateByteArray = new BaseEnumExt<PhaseState, U8>();
            vecExtEnumTypeFromCreateByteArray.Create(new byte[] { 0, 1 });

            var vecExtEnumTypeFromCreateHex = new BaseEnumExt<PhaseState, U8>();
            vecExtEnumTypeFromCreateHex.Create("0x0001");

            Assert.That(vecExtEnumTypeFromCreateValue.Bytes, Is.EqualTo(vecExtEnumTypeFromCreateByteArray.Bytes));
            Assert.That(vecExtEnumTypeFromCreateValue.Value, Is.EqualTo(vecExtEnumTypeFromCreateByteArray.Value));

            Assert.That(vecExtEnumTypeFromCreateValue.Bytes, Is.EqualTo(vecExtEnumTypeFromCreateHex.Bytes));
            Assert.That(vecExtEnumTypeFromCreateValue.Value, Is.EqualTo(vecExtEnumTypeFromCreateHex.Value));

            var eventEnum = vecExtEnumTypeFromCreateValue.GetEnum();
            Assert.That(eventEnum, Is.EqualTo(PhaseState.None));
            Assert.That(eventEnum, Is.Not.EqualTo(Substrate.NetApi.Test.BaseTypesTest.PartialBalanceEvents.Endowed));

            var eventData = vecExtEnumTypeFromCreateValue.GetValues();
            Assert.IsInstanceOf<U8>(eventData);
            Assert.That(((U8)eventData).Value, Is.EqualTo(1));
        }

        [Test]
        public void ExtEnumXXX()
        {
            var vecExtEnumType = new BaseVec<BaseEnumExt<PhaseState, BaseTuple<Arr4U8, BaseVec<U8>>, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>>();

            var u8 = new U8();
            u8.Create(byte.MaxValue);

            var vec8 = new Arr4U8();
            vec8.Create(new U8[] { u8, u8, u8, u8 });

            var vec82 = new BaseVec<U8>();
            vec82.Create(new U8[] { u8 });

            var tu = new BaseTuple<Arr4U8, BaseVec<U8>>();
            tu.Create(vec8, vec82);

            var it = new BaseEnumExt<PhaseState, BaseTuple<Arr4U8, BaseVec<U8>>, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>();
            it.Create(PhaseState.None, tu);

            vecExtEnumType.Create(new[] { it });

            var encoded = vecExtEnumType.Encode();
            int p = 0;
            vecExtEnumType.Decode(encoded, ref p);

            Assert.Pass();
        }

        internal enum TestEnum26
        {
            T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26
        }

        [Test]
        public void ExtEnum26()
        {
            var ext1 = new BaseEnumExt<TestEnum26, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16>();

            var u8 = new U8();
            u8.Create(byte.MaxValue);

            var u16 = new U16();
            u16.Create(ushort.MaxValue);

            ext1.Create(TestEnum26.T2, u16);

            var encoded = ext1.Encode();

            var ext2 = new BaseEnumExt<TestEnum26, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16, U8, U16>();

            int p = 0;
            ext2.Decode(encoded, ref p);

            Assert.AreEqual(TestEnum26.T2, ext2.Value);
            Assert.AreEqual(ushort.MaxValue, ((U16)ext2.Value2).Value);
        }

        [Test]
        public void BalanceLockTest()
        {
            var u8 = new U8(byte.MaxValue);
            var vec8 = new Arr4U8();
            vec8.Create(new U8[] { u8, u8, u8, u8 });

            var b1 = new BalanceLock();
            b1.Create("0xFFFFFFFF0A000000000000000000000000000000");

            var b2 = new BalanceLock();
            b2.Create("0xFFFFFFFF0A000000000000000000000000000000");

            var balancesLock1 = new BaseVec<BalanceLock>(new BalanceLock[] { b1, b2 });
            
            var balancesLock2 = new BaseVec<BalanceLock>();
            balancesLock2.Create(
                "0x08FFFFFFFF0A000000000000000000000000000000FFFFFFFF0A000000000000000000000000000000");

            Assert.That(balancesLock1.Bytes, Is.EqualTo(balancesLock2.Bytes));
            Assert.That(balancesLock1.Value[0].Bytes, Is.EqualTo(balancesLock2.Value[0].Bytes));
            Assert.That(balancesLock1.Value[1].Bytes, Is.EqualTo(balancesLock2.Value[1].Bytes));
        }
    }

    #region Dynamic type encoding
    public sealed class Arr4U8 : BaseType
    {
        private Substrate.NetApi.Model.Types.Primitive.U8[] _value;

        public override int TypeSize
        {
            get
            {
                return 4;
            }
        }

        public Substrate.NetApi.Model.Types.Primitive.U8[] Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public override string TypeName()
        {
            return string.Format("[{0}; {1}]", new Substrate.NetApi.Model.Types.Primitive.U8().TypeName(), this.TypeSize);
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
            var array = new Substrate.NetApi.Model.Types.Primitive.U8[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new Substrate.NetApi.Model.Types.Primitive.U8(); t.Decode(byteArray, ref p); array[i] = t; };
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Create(Substrate.NetApi.Model.Types.Primitive.U8[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }

    public sealed class BalanceLock : BaseType
    {
        public Arr4U8 Id { get; set; }

        public U128 Amount { get; set; }

        public override string TypeName() => "BalanceLock";

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Arr4U8();
            Id.Decode(byteArray, ref p);
            Amount = new U128();
            Amount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }

    public sealed class NotSoComplexClass : BaseType
    {
        public U32 Id { get; set; }

        public U32 Id2 { get; set; }

        public override string TypeName() => "NotSoComplex";

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Id2.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new U32();
            Id.Decode(byteArray, ref p);
            Id2 = new U32();
            Id2.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
    #endregion
}