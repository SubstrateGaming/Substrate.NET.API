using System.Numerics;
using NUnit.Framework;
using Ajuna.NetApi.Model.Types.Base;

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
    }
}