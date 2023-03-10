using System;
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using NUnit.Framework;

namespace Ajuna.NetApi.Test
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
        }

        [Test]
        public void PrimCharTest()
        {
            // str test
            var oneChar = 'b';
            var primChar = new PrimChar();
            primChar.Create(oneChar);
            Assert.AreEqual(oneChar, primChar.Value);

            var primCharCtor = new PrimChar(oneChar);
            Assert.AreEqual(oneChar, primCharCtor.Value);
            Assert.AreEqual(primCharCtor.Bytes, primChar.Bytes);
        }

        [Test]
        public void PrimU8Test()
        {
            var prim = new U8();
            prim.Create("0x45");
            Assert.AreEqual(69, prim.Value);

            var primCtor = new U8(69);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimU16Test()
        {
            var prim = new U16();
            prim.Create("0x2a00");
            Assert.AreEqual(42, prim.Value);

            var primCtor = new U16(42);
            Assert.AreEqual(prim.Value, primCtor.Value);
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
            var prim = new U32();
            prim.Create("0xffffff00");
            Assert.AreEqual(16777215, prim.Value);

            var primCtor = new U32(16777215);
            Assert.AreEqual(prim.Value, primCtor.Value);
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
            var prim = new U64();
            prim.Create("0xffffff00ffffff00");
            Assert.AreEqual(72057589759737855, prim.Value);

            var primCtor = new U64(72057589759737855);
            Assert.AreEqual(prim.Value, primCtor.Value);
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
            var bigNum = BigInteger.Parse("1329227916866238350086128051511361535");
            var prim = new U128();
            prim.Create("0xffffff00ffffff00ffffff00ffffff00");
            Assert.AreEqual(bigNum, prim.Value);

            var primCtor = new U128(bigNum);
            Assert.AreEqual(prim.Value, primCtor.Value);
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
            var bigNumber = BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495");
            var prim = new U256();
            prim.Create("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00");
            Assert.AreEqual(bigNumber, prim.Value);

            var primCtor = new U256(bigNumber);
            Assert.AreEqual(prim.Value, primCtor.Value);

            // 0 is a valid input
            var primZero = new U256(0);
            Assert.That(primZero.Value, Is.EqualTo(BigInteger.Zero));
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
            var prim = new I8();
            prim.Create("0xf5");
            Assert.AreEqual(-11, prim.Value);

            var primCtor = new I8(-11);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimI16Test()
        {
            var prim = new I16();
            prim.Create("0xf5f5");
            Assert.AreEqual(-2571, prim.Value);

            var primCtor = new I16(-2571);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimI32Test()
        {
            var prim = new I32();
            prim.Create("0xf5f5f5f5");
            Assert.AreEqual(-168430091, prim.Value);

            var primCtor = new I32(-168430091);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimI64Test()
        {
            var prim = new I64();
            prim.Create("0xf5f5f5f5f5f5f5f5");
            Assert.AreEqual(-723401728380766731, prim.Value);

            var primCtor = new I64(-723401728380766731);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimI128Test()
        {
            var bigNumber = BigInteger.Parse("-13344406545919155429936259114971302411");
            var prim = new I128();
            prim.Create("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
            Assert.AreEqual(bigNumber, prim.Value);

            var primCtor = new I128(bigNumber);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimI256Test()
        {
            var veryveryveryveryBigNegativeNumber = BigInteger.Parse("-4540866244600635114649842549360310111892940575123159374096375843447573711371");
            var prim = new I256();
            prim.Create("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
            Assert.AreEqual(veryveryveryveryBigNegativeNumber, prim.Value);

            var primCtor = new I256(veryveryveryveryBigNegativeNumber);
            Assert.AreEqual(prim.Value, primCtor.Value);
        }

        [Test]
        public void PrimStrTest()
        {
            // str test
            var vecChar = new char[] { 'b', 'a', 'n', 'a', 'n', 'e' };
            var primVec = new Str();
            primVec.Create(Utils.HexToByteArray("0x1862616e616e65"));
            for (int i = 0; i < vecChar.Length; i++)
            {
                Assert.AreEqual(vecChar[i], primVec.Value.ToCharArray()[i]);
            }

            var primCtor = new Str(new string(vecChar));
            Assert.AreEqual(primVec.Value, primCtor.Value);
            Assert.AreEqual(primVec.Bytes, primCtor.Bytes);
        }
    }
}