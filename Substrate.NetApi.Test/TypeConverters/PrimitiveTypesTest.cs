using System;
using System.Numerics;
using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;

namespace Substrate.NetApi.Test
{
    public class PrimitiveTypesTest
    {
        [Test]
        public void PrimBoolTest()
        {
            var primFalse = new Bool();
            primFalse.Create("0x00");
            Assert.AreEqual(false, primFalse.Value);

            var primTrue = new Bool();
            primTrue.Create("0x01");
            Assert.AreEqual(true, primTrue.Value);

            var primFalseCtor = new Bool(false);
            Assert.AreEqual(false, primFalseCtor.Value);
            Assert.AreEqual(primFalseCtor.Bytes, primFalse.Bytes);

            var primTrueCtor = new Bool(true);
            Assert.AreEqual(true, primTrueCtor.Value);
            Assert.AreEqual(primTrueCtor.Bytes, primTrue.Bytes);

            Bool primExplicit = (Bool)false;
            Assert.AreEqual(false, primExplicit.Value);

            bool primImplicit = new Bool(true);
            Assert.AreEqual(true, primImplicit);
        }

        [Test]
        public void PrimCharTest()
        {
            var value = 'b';

            var primChar = new PrimChar();
            primChar.Create(value);
            Assert.AreEqual(value, primChar.Value);

            var primCharCtor = new PrimChar(value);
            Assert.AreEqual(value, primCharCtor.Value);
            Assert.AreEqual(primCharCtor.Bytes, primChar.Bytes);

            PrimChar primExplicit = (PrimChar)value;
            Assert.AreEqual(value, primExplicit.Value);

            char primImplicit = new PrimChar(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimU8Test()
        {
            byte value = 69;

            var prim = new U8();
            prim.Create("0x45");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new U8(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            U8 primExplicit = (U8)value;
            Assert.AreEqual(value, primExplicit.Value);

            byte primImplicit = new U8(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimU16Test()
        {
            ushort value = 42;

            var prim = new U16();
            prim.Create("0x2a00");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new U16(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            U16 primExplicit = (U16)value;
            Assert.AreEqual(value, primExplicit.Value);

            ushort primImplicit = new U16(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimU16CreateTest()
        {
            var prim = new U16();
            prim.Create(33333);
            Assert.AreEqual("0x3582", Utils.Bytes2HexString(prim.Bytes));

            var primCtor = new U16(33333);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimU32Test()
        {
            uint value = 16777215;

            var prim = new U32();
            prim.Create("0xffffff00");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new U32(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            U32 primExplicit = (U32)value;
            Assert.AreEqual(value, primExplicit.Value);

            uint primImplicit = new U32(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimU32CreateTest()
        {
            var prim = new U32();
            prim.Create(33333);
            Assert.AreEqual("0x35820000", Utils.Bytes2HexString(prim.Bytes));

            var primCtor = new U32(33333);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimU64Test()
        {
            ulong value = 72057589759737855;

            var prim = new U64();
            prim.Create("0xffffff00ffffff00");
            Assert.AreEqual(72057589759737855, prim.Value);

            var primCtor = new U64(72057589759737855);
            Assert.AreEqual(prim.Value, primCtor.Value);

            U64 primExplicit = (U64)value;
            Assert.AreEqual(value, primExplicit.Value);

            ulong primImplicit = new U64(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimU64CreateTest()
        {
            var prim = new U64();
            prim.Create(33333);
            Assert.AreEqual("0x3582000000000000", Utils.Bytes2HexString(prim.Bytes));
            
            var primCtor = new U64(33333);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimU128Test()
        {
            var value = BigInteger.Parse("1329227916866238350086128051511361535");

            var prim = new U128();
            prim.Create("0xffffff00ffffff00ffffff00ffffff00");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new U128(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            U128 primExplicit = (U128)value;
            Assert.AreEqual(value, primExplicit.Value);

            BigInteger primImplicit = new U128(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimU128CreateTest()
        {
            var number = new BigInteger(33333);
            var prim = new U128();
            prim.Create(new BigInteger(33333));
            Assert.AreEqual("0x35820000000000000000000000000000", Utils.Bytes2HexString(prim.Bytes));

            var prim2 = new U128();
            prim2.Create("0x35820000000000000000000000000000");
            Assert.AreEqual(number, prim2.Value);

            Assert.AreEqual(prim.Bytes, prim2.Bytes);

            var primCtor = new U128(number);
            Assert.AreEqual(prim.Value, primCtor.Value);

            // 0 is a valid input
            var primZero = new U128(0);
            Assert.That(primZero.Value, Is.EqualTo(BigInteger.Zero));
        }

        [Test]
        public void PrimU128_WithNegativeNumber_ShouldFail()
        {
            var number = new BigInteger(-1000);
            Assert.Throws<InvalidOperationException>(() => new U128(number));
        }

        [Test]
        public void PrimU256Test()
        {
            var value = BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495");

            var prim = new U256();
            prim.Create("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new U256(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            // 0 is a valid input
            var primZero = new U256(0);
            Assert.That(primZero.Value, Is.EqualTo(BigInteger.Zero));

            U256 primExplicit = (U256)value;
            Assert.AreEqual(value, primExplicit.Value);

            BigInteger primImplicit = new U256(value);
            Assert.AreEqual(value, primImplicit);

            var testArray = Utils.GetPublicKeyFrom("unixuHLc4UoAjwLpkQHUWy2NpT5LV4tUqJFnFVNyLaeqBfq22").Reverse().ToArray();

            var test = new U256();
            test.Create(testArray);

            Assert.AreEqual("88948098633472856107773808278376342488924045139856962685537580476255925753211", test.Value.ToString());
            Assert.IsTrue(test.Bytes.SequenceEqual(testArray));
        }

        [Test]
        public void PrimU256_WithNegativeNumber_ShouldFail()
        {
            var bigNumber = BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495") * (-1);
            Assert.Throws<InvalidOperationException>(() => new U256(bigNumber));
        }

        [Test]
        public void PrimI8Test()
        {
            sbyte value = -11;

            var prim = new I8();
            prim.Create("0xf5");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new I8(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            I8 primExplicit = (I8)value;
            Assert.AreEqual(value, primExplicit.Value);

            sbyte primImplicit = new I8(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimI16Test()
        {
            short value = -2571;

            var prim = new I16();
            prim.Create("0xf5f5");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new I16(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            I16 primExplicit = (I16)value;
            Assert.AreEqual(value, primExplicit.Value);

            short primImplicit = new I16(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimI32Test()
        {
            int value = -168430091;

            var prim = new I32();
            prim.Create("0xf5f5f5f5");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new I32(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            I32 primExplicit = (I32)value;
            Assert.AreEqual(value, primExplicit.Value);

            int primImplicit = new I32(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimI64Test()
        {
            long value = -723401728380766731;

            var prim = new I64();
            prim.Create("0xf5f5f5f5f5f5f5f5");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new I64(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            I64 primExplicit = (I64)value;
            Assert.AreEqual(value, primExplicit.Value);

            long primImplicit = new I64(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimI128Test()
        {
            var value = BigInteger.Parse("-13344406545919155429936259114971302411");

            var prim = new I128();
            prim.Create("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new I128(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            I128 primExplicit = (I128)value;
            Assert.AreEqual(value, primExplicit.Value);

            BigInteger primImplicit = new I128(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimI256Test()
        {
            var value = BigInteger.Parse("-4540866244600635114649842549360310111892940575123159374096375843447573711371");

            var prim = new I256();
            prim.Create("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
            Assert.AreEqual(value, prim.Value);

            var primCtor = new I256(value);
            Assert.AreEqual(prim.Value, primCtor.Value);

            I256 primExplicit = (I256)value;
            Assert.AreEqual(value, primExplicit.Value);

            BigInteger primImplicit = new I256(value);
            Assert.AreEqual(value, primImplicit);
        }

        [Test]
        public void PrimStrTest()
        {
            var valueStr = "banane";

            var primVec = new Str();
            primVec.Create(Utils.HexToByteArray("0x1862616e616e65"));
            for (int i = 0; i < valueStr.Length; i++)
            {
                Assert.AreEqual(valueStr[i], primVec.Value[i]);
            }

            var primCtor = new Str(valueStr);
            Assert.AreEqual(primVec.Value, primCtor.Value);
            Assert.AreEqual(primVec.Bytes, primCtor.Bytes);

            Str primExplicit = (Str)valueStr;
            Assert.AreEqual(valueStr, primExplicit.Value);

            string primImplicit = new Str(valueStr);
            Assert.AreEqual(valueStr, primImplicit);
        }
    }
}