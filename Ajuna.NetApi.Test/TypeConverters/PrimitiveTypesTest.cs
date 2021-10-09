using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Struct;
using Ajuna.NetApi.TypeConverters;

namespace Ajuna.NetApi.Test
{
    public class PrimitiveTypesTest
    {
        [Test]
        public void PrimBoolTest()
        {
            var primFalse = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            primFalse.Create("0x00");
            Assert.AreEqual(false, primFalse.Value);

            var primTrue = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            primTrue.Create("0x01");
            Assert.AreEqual(true, primTrue.Value);
        }

        [Test]
        public void PrimCharTest()
        {
            // str test
            var oneChar = 'b';
            var primChar = new Ajuna.NetApi.Model.Types.Primitive.PrimChar();
            primChar.Create(oneChar);
            Assert.AreEqual(oneChar, primChar.Value);

        }

        [Test]
        public void PrimU8Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.U8();
            prim.Create("0x45");
            Assert.AreEqual(69, prim.Value);
        }

        [Test]
        public void PrimU16Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.U16();
            prim.Create("0x2a00");
            Assert.AreEqual(42, prim.Value);
        }

        [Test]
        public void PrimU32Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.U32();
            prim.Create("0xffffff00");
            Assert.AreEqual(16777215, prim.Value);
        }

        [Test]
        public void PrimU64Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.U64();
            prim.Create("0xffffff00ffffff00");
            Assert.AreEqual(72057589759737855, prim.Value);
        }

        [Test]
        public void PrimU128Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.U128();
            prim.Create("0xffffff00ffffff00ffffff00ffffff00");
            Assert.AreEqual(BigInteger.Parse("1329227916866238350086128051511361535"), prim.Value);
        }

        [Test]
        public void PrimU256Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.U256();
            prim.Create("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00");
            Assert.AreEqual(BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495"), prim.Value);
        }

        [Test]
        public void PrimI8Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.I8();
            prim.Create("0xf5");
            Assert.AreEqual(-11, prim.Value);
        }

        [Test]
        public void PrimI16Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.I16();
            prim.Create("0xf5f5");
            Assert.AreEqual(-2571, prim.Value);
        }

        [Test]
        public void PrimI32Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.I32();
            prim.Create("0xf5f5f5f5");
            Assert.AreEqual(-168430091, prim.Value);
        }

        [Test]
        public void PrimI64Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.I64();
            prim.Create("0xf5f5f5f5f5f5f5f5");
            Assert.AreEqual(-723401728380766731, prim.Value);
        }

        [Test]
        public void PrimI128Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.I128();
            prim.Create("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
            Assert.AreEqual(BigInteger.Parse("-13344406545919155429936259114971302411"), prim.Value);
        }

        [Test]
        public void PrimI256Test()
        {
            var prim = new Ajuna.NetApi.Model.Types.Primitive.I256();
            prim.Create("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
            Assert.AreEqual(BigInteger.Parse("-4540866244600635114649842549360310111892940575123159374096375843447573711371"), prim.Value);
        }

        [Test]
        public void PrimVecTest()
        {
            // vec u16 test
            var vecUInt16 = new uint[] { 4, 8, 15, 16, 23, 42 };
            var primVec = new BaseVec<Ajuna.NetApi.Model.Types.Primitive.U16>();
            primVec.Create("0x18040008000f00100017002a00");
            for (int i = 0; i < vecUInt16.Length; i++)
            {
                Assert.AreEqual(vecUInt16[i], primVec.Value[i].Value);
            }
        }

        [Test]
        public void PrimStrTest()
        {
            // str test
            var vecChar = new char[] { 'b', 'a', 'n', 'a', 'n', 'e' };           
            var primVec = new Ajuna.NetApi.Model.Types.Primitive.Str();
            primVec.Create(Utils.HexToByteArray("0x1862616e616e65"));
            for (int i = 0; i < vecChar.Length; i++)
            {
                Assert.AreEqual(vecChar[i], primVec.Value.ToCharArray()[i]);
            }
        }
    }
}