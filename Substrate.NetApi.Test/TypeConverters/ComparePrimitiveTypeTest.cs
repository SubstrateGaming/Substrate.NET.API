using NUnit.Framework;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NetApi.Test.TypeConverters
{
    public class ComparePrimitiveTypeTest
    {
        [Test]
        public void PrimU8OperationTest()
        {
            Assert.That(new U8(10) + new U8(20), Is.EqualTo(new U8(30)));
            Assert.That(new U8(20) - new U8(10), Is.EqualTo(new U8(10)));
            Assert.That(new U8(20) / new U8(10), Is.EqualTo(new U8(2)));
            Assert.That(new U8(20) * new U8(10), Is.EqualTo(new U8(200)));

            Assert.That(new U8(20) > new U8(10), Is.True);
            Assert.That(new U8(20) >= new U8(10), Is.True);
            Assert.That(new U8(20) >= new U8(20), Is.True);

            Assert.That(new U8(20) < new U8(10), Is.False);
            Assert.That(new U8(20) <= new U8(10), Is.False);
            Assert.That(new U8(20) <= new U8(20), Is.True);

            Assert.That(new U8(20) != new U8(20), Is.False);
            Assert.That(new U8(20) == new U8(20), Is.True);
            Assert.That(new U8(20) == new U8(10), Is.False);
            Assert.That(new U8(20) != new U8(10), Is.True);

            Assert.That(new U8(10).CompareTo(new U8(20)), Is.LessThan(0));
            Assert.That(new U8(20).CompareTo(new U8(20)), Is.EqualTo(0));
            Assert.That(new U8(20).CompareTo(new U8(15)), Is.GreaterThan(0));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new U8(10) - new U8(20);
            });


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new U8(10) / new U8(0);
            });
        }

        [Test]
        public void PrimU16OperationTest()
        {
            Assert.That(new U16(10) + new U16(20), Is.EqualTo(new U16(30)));
            Assert.That(new U16(20) - new U16(10), Is.EqualTo(new U16(10)));
            Assert.That(new U16(20) / new U16(10), Is.EqualTo(new U16(2)));
            Assert.That(new U16(20) * new U16(10), Is.EqualTo(new U16(200)));

            Assert.That(new U16(20) > new U16(10), Is.True);
            Assert.That(new U16(20) >= new U16(10), Is.True);
            Assert.That(new U16(20) >= new U16(20), Is.True);

            Assert.That(new U16(20) < new U16(10), Is.False);
            Assert.That(new U16(20) <= new U16(10), Is.False);
            Assert.That(new U16(20) <= new U16(20), Is.True);

            Assert.That(new U16(20) != new U16(20), Is.False);
            Assert.That(new U16(20) == new U16(20), Is.True);
            Assert.That(new U16(20) == new U16(10), Is.False);
            Assert.That(new U16(20) != new U16(10), Is.True);

            Assert.That(new U16(10).CompareTo(new U16(20)), Is.LessThan(0));
            Assert.That(new U16(20).CompareTo(new U16(20)), Is.EqualTo(0));
            Assert.That(new U16(20).CompareTo(new U16(15)), Is.GreaterThan(0));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new U16(10) - new U16(20);
            });


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new U16(10) / new U16(0);
            });
        }

        [Test]
        public void PrimU32OperationTest()
        {
            Assert.That(new U32(10) + new U32(20), Is.EqualTo(new U32(30)));
            Assert.That(new U32(20) - new U32(10), Is.EqualTo(new U32(10)));
            Assert.That(new U32(20) / new U32(10), Is.EqualTo(new U32(2)));
            Assert.That(new U32(20) * new U32(10), Is.EqualTo(new U32(200)));

            Assert.That(new U32(20) > new U32(10), Is.True);
            Assert.That(new U32(20) >= new U32(10), Is.True);
            Assert.That(new U32(20) >= new U32(20), Is.True);

            Assert.That(new U32(20) < new U32(10), Is.False);
            Assert.That(new U32(20) <= new U32(10), Is.False);
            Assert.That(new U32(20) <= new U32(20), Is.True);

            Assert.That(new U32(20) != new U32(20), Is.False);
            Assert.That(new U32(20) == new U32(20), Is.True);
            Assert.That(new U32(20) == new U32(10), Is.False);
            Assert.That(new U32(20) != new U32(10), Is.True);

            Assert.That(new U32(10).CompareTo(new U32(20)), Is.LessThan(0));
            Assert.That(new U32(20).CompareTo(new U32(20)), Is.EqualTo(0));
            Assert.That(new U32(20).CompareTo(new U32(15)), Is.GreaterThan(0));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new U32(10) - new U32(20);
            });


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new U32(10) / new U32(0);
            });            
        }

        [Test]
        public void PrimU64OperationTest()
        {
            Assert.That(new U64(10) + new U64(20), Is.EqualTo(new U64(30)));
            Assert.That(new U64(20) - new U64(10), Is.EqualTo(new U64(10)));
            Assert.That(new U64(20) / new U64(10), Is.EqualTo(new U64(2)));
            Assert.That(new U64(20) * new U64(10), Is.EqualTo(new U64(200)));

            Assert.That(new U64(20) > new U64(10), Is.True);
            Assert.That(new U64(20) >= new U64(10), Is.True);
            Assert.That(new U64(20) >= new U64(20), Is.True);

            Assert.That(new U64(20) < new U64(10), Is.False);
            Assert.That(new U64(20) <= new U64(10), Is.False);
            Assert.That(new U64(20) <= new U64(20), Is.True);

            Assert.That(new U64(20) != new U64(20), Is.False);
            Assert.That(new U64(20) == new U64(20), Is.True);
            Assert.That(new U64(20) == new U64(10), Is.False);
            Assert.That(new U64(20) != new U64(10), Is.True);

            Assert.That(new U64(10).CompareTo(new U64(20)), Is.LessThan(0));
            Assert.That(new U64(20).CompareTo(new U64(20)), Is.EqualTo(0));
            Assert.That(new U64(20).CompareTo(new U64(15)), Is.GreaterThan(0));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new U64(10) - new U64(20);
            });


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new U64(10) / new U64(0);
            });
        }

        [Test]
        public void PrimU128OperationTest()
        {
            Assert.That(new U128(10) + new U128(20), Is.EqualTo(new U128(30)));
            Assert.That(new U128(20) - new U128(10), Is.EqualTo(new U128(10)));
            Assert.That(new U128(20) / new U128(10), Is.EqualTo(new U128(2)));
            Assert.That(new U128(20) * new U128(10), Is.EqualTo(new U128(200)));

            Assert.That(new U128(20) > new U128(10), Is.True);
            Assert.That(new U128(20) >= new U128(10), Is.True);
            Assert.That(new U128(20) >= new U128(20), Is.True);

            Assert.That(new U128(20) < new U128(10), Is.False);
            Assert.That(new U128(20) <= new U128(10), Is.False);
            Assert.That(new U128(20) <= new U128(20), Is.True);

            Assert.That(new U128(20) != new U128(20), Is.False);
            Assert.That(new U128(20) == new U128(20), Is.True);
            Assert.That(new U128(20) == new U128(10), Is.False);
            Assert.That(new U128(20) != new U128(10), Is.True);

            Assert.That(new U128(10).CompareTo(new U128(20)), Is.LessThan(0));
            Assert.That(new U128(20).CompareTo(new U128(20)), Is.EqualTo(0));
            Assert.That(new U128(20).CompareTo(new U128(15)), Is.GreaterThan(0));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new U128(10) - new U128(20);
            });


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new U128(10) / new U128(0);
            });
        }

        [Test]
        public void PrimU256OperationTest()
        {
            Assert.That(new U256(10) + new U256(20), Is.EqualTo(new U256(30)));
            Assert.That(new U256(20) - new U256(10), Is.EqualTo(new U256(10)));
            Assert.That(new U256(20) / new U256(10), Is.EqualTo(new U256(2)));
            Assert.That(new U256(20) * new U256(10), Is.EqualTo(new U256(200)));

            Assert.That(new U256(20) > new U256(10), Is.True);
            Assert.That(new U256(20) >= new U256(10), Is.True);
            Assert.That(new U256(20) >= new U256(20), Is.True);

            Assert.That(new U256(20) < new U256(10), Is.False);
            Assert.That(new U256(20) <= new U256(10), Is.False);
            Assert.That(new U256(20) <= new U256(20), Is.True);

            Assert.That(new U256(20) != new U256(20), Is.False);
            Assert.That(new U256(20) == new U256(20), Is.True);
            Assert.That(new U256(20) == new U256(10), Is.False);
            Assert.That(new U256(20) != new U256(10), Is.True);

            Assert.That(new U256(10).CompareTo(new U256(20)), Is.LessThan(0));
            Assert.That(new U256(20).CompareTo(new U256(20)), Is.EqualTo(0));
            Assert.That(new U256(20).CompareTo(new U256(15)), Is.GreaterThan(0));

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new U256(10) - new U256(20);
            });


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new U256(10) / new U256(0);
            });
        }

        [Test]
        public void PrimI8OperationTest()
        {
            Assert.That(new I8(10) + new I8(20), Is.EqualTo(new I8(30)));
            Assert.That(new I8(20) - new I8(10), Is.EqualTo(new I8(10)));
            Assert.That(new I8(20) / new I8(10), Is.EqualTo(new I8(2)));
            Assert.That(new I8(10) * new I8(10), Is.EqualTo(new I8(100)));

            Assert.That(new I8(20) > new I8(10), Is.True);
            Assert.That(new I8(20) >= new I8(10), Is.True);
            Assert.That(new I8(20) >= new I8(20), Is.True);

            Assert.That(new I8(20) < new I8(10), Is.False);
            Assert.That(new I8(20) <= new I8(10), Is.False);
            Assert.That(new I8(20) <= new I8(20), Is.True);

            Assert.That(new I8(20) != new I8(20), Is.False);
            Assert.That(new I8(20) == new I8(20), Is.True);
            Assert.That(new I8(20) == new I8(10), Is.False);
            Assert.That(new I8(20) != new I8(10), Is.True);

            Assert.That(new I8(10) - new I8(20), Is.EqualTo(new I8(-10)));

            Assert.That(new I8(10).CompareTo(new I8(20)), Is.LessThan(0));
            Assert.That(new I8(-20).CompareTo(new I8(-10)), Is.LessThan(0));
            Assert.That(new I8(20).CompareTo(new I8(20)), Is.EqualTo(0));
            Assert.That(new I8(-20).CompareTo(new I8(-30)), Is.GreaterThan(0));
            Assert.That(new I8(20).CompareTo(new I8(15)), Is.GreaterThan(0));

            Assert.Throws<DivideByZeroException>(() =>
            {
               _ = new I8(10) / new I8(0);
            });
        }

        [Test]
        public void PrimI16OperationTest()
        {
            Assert.That(new I16(10) + new I16(20), Is.EqualTo(new I16(30)));
            Assert.That(new I16(20) - new I16(10), Is.EqualTo(new I16(10)));
            Assert.That(new I16(20) / new I16(10), Is.EqualTo(new I16(2)));
            Assert.That(new I16(20) * new I16(10), Is.EqualTo(new I16(200)));

            Assert.That(new I16(20) > new I16(10), Is.True);
            Assert.That(new I16(20) >= new I16(10), Is.True);
            Assert.That(new I16(20) >= new I16(20), Is.True);

            Assert.That(new I16(20) < new I16(10), Is.False);
            Assert.That(new I16(20) <= new I16(10), Is.False);
            Assert.That(new I16(20) <= new I16(20), Is.True);

            Assert.That(new I16(20) != new I16(20), Is.False);
            Assert.That(new I16(20) == new I16(20), Is.True);
            Assert.That(new I16(20) == new I16(10), Is.False);
            Assert.That(new I16(20) != new I16(10), Is.True);

            Assert.That(new I16(10) - new I16(20), Is.EqualTo(new I16(-10)));

            Assert.That(new I16(10).CompareTo(new I16(20)), Is.LessThan(0));
            Assert.That(new I16(-20).CompareTo(new I16(-10)), Is.LessThan(0));
            Assert.That(new I16(20).CompareTo(new I16(20)), Is.EqualTo(0));
            Assert.That(new I16(-20).CompareTo(new I16(-30)), Is.GreaterThan(0));
            Assert.That(new I16(20).CompareTo(new I16(15)), Is.GreaterThan(0));

            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new I16(10) / new I16(0);
            });
        }

        [Test]
        public void PrimI32OperationTest()
        {
            Assert.That(new I32(10) + new I32(20), Is.EqualTo(new I32(30)));
            Assert.That(new I32(20) - new I32(10), Is.EqualTo(new I32(10)));
            Assert.That(new I32(20) / new I32(10), Is.EqualTo(new I32(2)));
            Assert.That(new I32(20) * new I32(10), Is.EqualTo(new I32(200)));

            Assert.That(new I32(20) > new I32(10), Is.True);
            Assert.That(new I32(20) >= new I32(10), Is.True);
            Assert.That(new I32(20) >= new I32(20), Is.True);

            Assert.That(new I32(20) < new I32(10), Is.False);
            Assert.That(new I32(20) <= new I32(10), Is.False);
            Assert.That(new I32(20) <= new I32(20), Is.True);

            Assert.That(new I32(20) != new I32(20), Is.False);
            Assert.That(new I32(20) == new I32(20), Is.True);
            Assert.That(new I32(20) == new I32(10), Is.False);
            Assert.That(new I32(20) != new I32(10), Is.True);

            Assert.That(new I32(10) - new I32(20), Is.EqualTo(new I32(-10)));

            Assert.That(new I32(10).CompareTo(new I32(20)), Is.LessThan(0));
            Assert.That(new I32(-20).CompareTo(new I32(-10)), Is.LessThan(0));
            Assert.That(new I32(20).CompareTo(new I32(20)), Is.EqualTo(0));
            Assert.That(new I32(-20).CompareTo(new I32(-30)), Is.GreaterThan(0));
            Assert.That(new I32(20).CompareTo(new I32(15)), Is.GreaterThan(0));

            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new I32(10) / new I32(0);
            });
        }

        [Test]
        public void PrimI64OperationTest()
        {
            Assert.That(new I64(10) + new I64(20), Is.EqualTo(new I64(30)));
            Assert.That(new I64(20) - new I64(10), Is.EqualTo(new I64(10)));
            Assert.That(new I64(20) / new I64(10), Is.EqualTo(new I64(2)));
            Assert.That(new I64(20) * new I64(10), Is.EqualTo(new I64(200)));

            Assert.That(new I64(20) > new I64(10), Is.True);
            Assert.That(new I64(20) >= new I64(10), Is.True);
            Assert.That(new I64(20) >= new I64(20), Is.True);

            Assert.That(new I64(20) < new I64(10), Is.False);
            Assert.That(new I64(20) <= new I64(10), Is.False);
            Assert.That(new I64(20) <= new I64(20), Is.True);

            Assert.That(new I64(20) != new I64(20), Is.False);
            Assert.That(new I64(20) == new I64(20), Is.True);
            Assert.That(new I64(20) == new I64(10), Is.False);
            Assert.That(new I64(20) != new I64(10), Is.True);

            Assert.That(new I64(10) - new I64(20), Is.EqualTo(new I64(-10)));

            Assert.That(new I64(10).CompareTo(new I64(20)), Is.LessThan(0));
            Assert.That(new I64(-20).CompareTo(new I64(-10)), Is.LessThan(0));
            Assert.That(new I64(20).CompareTo(new I64(20)), Is.EqualTo(0));
            Assert.That(new I64(-20).CompareTo(new I64(-30)), Is.GreaterThan(0));
            Assert.That(new I64(20).CompareTo(new I64(15)), Is.GreaterThan(0));


            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new I64(10) / new I64(0);
            });
        }

        [Test]
        public void PrimI128OperationTest()
        {
            Assert.That(new I128(10) + new I128(20), Is.EqualTo(new I128(30)));
            Assert.That(new I128(20) - new I128(10), Is.EqualTo(new I128(10)));
            Assert.That(new I128(20) / new I128(10), Is.EqualTo(new I128(2)));
            Assert.That(new I128(20) * new I128(10), Is.EqualTo(new I128(200)));

            Assert.That(new I128(20) > new I128(10), Is.True);
            Assert.That(new I128(20) >= new I128(10), Is.True);
            Assert.That(new I128(20) >= new I128(20), Is.True);

            Assert.That(new I128(20) < new I128(10), Is.False);
            Assert.That(new I128(20) <= new I128(10), Is.False);
            Assert.That(new I128(20) <= new I128(20), Is.True);

            Assert.That(new I128(20) != new I128(20), Is.False);
            Assert.That(new I128(20) == new I128(20), Is.True);
            Assert.That(new I128(20) == new I128(10), Is.False);
            Assert.That(new I128(20) != new I128(10), Is.True);

            Assert.That(new I128(10) - new I128(20), Is.EqualTo(new I128(-10)));

            Assert.That(new I128(10).CompareTo(new I128(20)), Is.LessThan(0));
            Assert.That(new I128(-20).CompareTo(new I128(-10)), Is.LessThan(0));
            Assert.That(new I128(20).CompareTo(new I128(20)), Is.EqualTo(0));
            Assert.That(new I128(-20).CompareTo(new I128(-30)), Is.GreaterThan(0));
            Assert.That(new I128(20).CompareTo(new I128(15)), Is.GreaterThan(0));

            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new I128(10) / new I128(0);
            });
        }

        [Test]
        public void PrimI256OperationTest()
        {
            Assert.That(new I256(10) + new I256(20), Is.EqualTo(new I256(30)));
            Assert.That(new I256(20) - new I256(10), Is.EqualTo(new I256(10)));
            Assert.That(new I256(20) / new I256(10), Is.EqualTo(new I256(2)));
            Assert.That(new I256(20) * new I256(10), Is.EqualTo(new I256(200)));

            Assert.That(new I256(20) > new I256(10), Is.True);
            Assert.That(new I256(20) >= new I256(10), Is.True);
            Assert.That(new I256(20) >= new I256(20), Is.True);

            Assert.That(new I256(20) < new I256(10), Is.False);
            Assert.That(new I256(20) <= new I256(10), Is.False);
            Assert.That(new I256(20) <= new I256(20), Is.True);

            Assert.That(new I256(20) != new I256(20), Is.False);
            Assert.That(new I256(20) == new I256(20), Is.True);
            Assert.That(new I256(20) == new I256(10), Is.False);
            Assert.That(new I256(20) != new I256(10), Is.True);

            Assert.That(new I256(10) - new I256(20), Is.EqualTo(new I256(-10)));

            Assert.That(new I256(10).CompareTo(new I256(20)), Is.LessThan(0));
            Assert.That(new I256(-20).CompareTo(new I256(-10)), Is.LessThan(0));
            Assert.That(new I256(20).CompareTo(new I256(20)), Is.EqualTo(0));
            Assert.That(new I256(-20).CompareTo(new I256(-30)), Is.GreaterThan(0));
            Assert.That(new I256(20).CompareTo(new I256(15)), Is.GreaterThan(0));

            Assert.Throws<DivideByZeroException>(() =>
            {
                _ = new I256(10) / new I256(0);
            });
        }
    }
}
