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

    }
}