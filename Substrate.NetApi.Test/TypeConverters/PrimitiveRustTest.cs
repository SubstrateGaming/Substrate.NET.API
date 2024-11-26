using NUnit.Framework;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Numerics;

namespace Substrate.NetApi.Test
{
    [TestFixture]
    public class u256Tests
    {
        [Test]
        public void AdditionTest()
        {
            u256 a = u256.MaxValue;
            u256 b = u256.One;
            u256 result = a + b;
            Assert.AreEqual(u256.Zero, result); // Wrap-around behavior
        }

        [Test]
        public void SubtractionTest()
        {
            u256 a = u256.Zero;
            u256 b = u256.One;
            u256 result = a - b;
            Assert.AreEqual(u256.MaxValue, result); // Wrap-around behavior
        }

        [Test]
        public void MultiplicationTest()
        {
            u256 a = new u256(2, 0, 0, 0);
            u256 b = new u256(3, 0, 0, 0);
            u256 result = a * b;
            Assert.AreEqual(new u256(6, 0, 0, 0), result);
        }

        [Test]
        public void DivisionTest()
        {
            u256 a = new u256(10, 0, 0, 0);
            u256 b = new u256(2, 0, 0, 0);
            u256 result = a / b;
            Assert.AreEqual(new u256(5, 0, 0, 0), result);
        }

        [Test]
        public void ModuloTest()
        {
            u256 a = new u256(10, 0, 0, 0);
            u256 b = new u256(3, 0, 0, 0);
            u256 result = a % b;
            Assert.AreEqual(new u256(1, 0, 0, 0), result);
        }

        [Test]
        public void BitwiseOperationsTest()
        {
            u256 a = new u256(0x0F0F0F0F0F0F0F0FUL, 0, 0, 0);
            u256 b = new u256(0x00FF00FF00FF00FFUL, 0, 0, 0);

            u256 andResult = a & b;
            u256 orResult = a | b;
            u256 xorResult = a ^ b;
            u256 notResult = ~a;

            Assert.AreEqual(new u256(0x000F000F000F000FUL, 0, 0, 0), andResult);
            Assert.AreEqual(new u256(0x0FFF0FFF0FFF0FFFUL, 0, 0, 0), orResult);
            Assert.AreEqual(new u256(0x0FF00FF00FF00FF0UL, 0, 0, 0), xorResult);
            Assert.AreEqual(new u256(0xF0F0F0F0F0F0F0F0UL, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue), notResult);
        }

        [Test]
        public void ShiftOperationsTest()
        {
            u256 a = new u256(1, 0, 0, 0);
            u256 leftShift = a << 64;
            u256 rightShift = leftShift >> 64;

            Assert.AreEqual(new u256(0, 1, 0, 0), leftShift);
            Assert.AreEqual(a, rightShift);
        }

        [Test]
        public void ComparisonOperatorsTest()
        {
            u256 a = new u256(1, 0, 0, 0);
            u256 b = new u256(2, 0, 0, 0);

            Assert.IsTrue(a < b);
            Assert.IsTrue(b > a);
            Assert.IsTrue(a <= a);
            Assert.IsTrue(b >= a);
            Assert.IsTrue(a == a);
            Assert.IsTrue(a != b);
        }

        [Test]
        public void ToBigIntegerTest()
        {
            u256 a = new u256(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue);
            BigInteger bigInt = a.ToBigInteger();

            Assert.AreEqual(BigInteger.Pow(2, 256) - 1, bigInt);
        }

        [Test]
        public void FromBigIntegerTest()
        {
            BigInteger bigInt = BigInteger.Pow(2, 256) - 1;
            u256 a = u256.FromBigInteger(bigInt);

            Assert.AreEqual(u256.MaxValue, a);
        }

        [Test]
        public void ParseTest()
        {
            BigInteger expectedValue = BigInteger.Pow(2, 256) - 1;
            string value = expectedValue.ToString();
            u256 a = u256.Parse(value);

            Assert.AreEqual(expectedValue, a.ToBigInteger());
        }

        [Test]
        public void TryParseTest()
        {
            string value = "NotANumber";
            bool success = u256.TryParse(value, out u256 result);

            Assert.IsFalse(success);
            Assert.AreEqual(u256.Zero, result);
        }

        [Test]
        public void DivideByZeroTest()
        {
            u256 a = new u256(10, 0, 0, 0);
            u256 b = u256.Zero;

            Assert.Throws<DivideByZeroException>(() => { var result = a / b; });
            Assert.Throws<DivideByZeroException>(() => { var result = a % b; });
        }

        [Test]
        public void OverflowTest()
        {
            u256 a = u256.MaxValue;
            u256 b = u256.One;
            u256 result = a + b;

            Assert.AreEqual(u256.Zero, result);
        }

        [Test]
        public void ToStringTest()
        {
            u256 a = new u256(1234567890UL, 0, 0, 0);
            string str = a.ToString();

            Assert.AreEqual("1234567890", str);
        }

        [Test]
        public void EqualityTest()
        {
            u256 a = new u256(123, 456, 789, 101112);
            u256 b = new u256(123, 456, 789, 101112);
            u256 c = new u256(123, 456, 789, 0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsTrue(a == b);
            Assert.IsTrue(a != c);
        }

        [Test]
        public void HashCodeTest()
        {
            u256 a = new u256(123, 456, 789, 101112);
            u256 b = new u256(123, 456, 789, 101112);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }

    [TestFixture]
    public class i256Tests
    {
        [Test]
        public void AdditionTest()
        {
            i256 a = i256.MaxValue;
            i256 b = i256.One;
            Assert.Throws<OverflowException>(() => { var result = a + b; });
        }

        [Test]
        public void SubtractionTest()
        {
            i256 a = i256.MinValue;
            i256 b = i256.One;
            Assert.Throws<OverflowException>(() => { var result = a - b; });
        }

        [Test]
        public void MultiplicationTest()
        {
            i256 a = new i256(2, 0, 0, 0);
            i256 b = new i256(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue); // Represents -1 in two's complement
            i256 result = a * b;
            i256 expected = new i256(ulong.MaxValue - 1, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue); // -2 in two's complement
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DivisionTest()
        {
            i256 a = new i256(10, 0, 0, 0);
            i256 b = new i256(2, 0, 0, 0);
            i256 result = a / b;
            Assert.AreEqual(new i256(5, 0, 0, 0), result);
        }

        [Test]
        public void ModuloTest()
        {
            i256 a = new i256(10, 0, 0, 0);
            i256 b = new i256(3, 0, 0, 0);
            i256 result = a % b;
            Assert.AreEqual(new i256(1, 0, 0, 0), result);
        }

        [Test]
        public void BitwiseOperationsTest()
        {
            i256 a = new i256(0x0F0F0F0F0F0F0F0FUL, 0, 0, 0);
            i256 b = new i256(0x00FF00FF00FF00FFUL, 0, 0, 0);

            i256 andResult = a & b;
            i256 orResult = a | b;
            i256 xorResult = a ^ b;
            i256 notResult = ~a;

            Assert.AreEqual(new i256(0x000F000F000F000FUL, 0, 0, 0), andResult);
            Assert.AreEqual(new i256(0x0FFF0FFF0FFF0FFFUL, 0, 0, 0), orResult);
            Assert.AreEqual(new i256(0x0FF00FF00FF00FF0UL, 0, 0, 0), xorResult);
            Assert.AreEqual(new i256(0xF0F0F0F0F0F0F0F0UL, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue), notResult);
        }

        [Test]
        public void ShiftOperationsTest()
        {
            i256 a = new i256(1, 0, 0, 0);
            i256 leftShift = a << 64;
            i256 rightShift = leftShift >> 64;

            Assert.AreEqual(new i256(0, 1, 0, 0), leftShift);
            Assert.AreEqual(a, rightShift);
        }

        [Test]
        public void ComparisonOperatorsTest()
        {
            i256 a = new i256(1, 0, 0, 0);
            i256 b = new i256(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue);

            Assert.IsTrue(b < a);
            Assert.IsTrue(a > b);
            Assert.IsTrue(a >= a);
            Assert.IsTrue(b <= a);
            Assert.IsTrue(a != b);
        }

        [Test]
        public void ToBigIntegerTest()
        {
            i256 a = i256.MinValue;
            BigInteger bigInt = a.ToBigInteger();

            Assert.AreEqual(BigInteger.Pow(-2, 255), bigInt);
        }

        [Test]
        public void FromBigIntegerTest()
        {
            BigInteger bigInt = BigInteger.Pow(-2, 255);
            i256 a = i256.FromBigInteger(bigInt);

            Assert.AreEqual(i256.MinValue, a);
        }

        [Test]
        public void ParseTest()
        {
            string value = "-1234567890123456789012345678901234567890";
            i256 a = i256.Parse(value);

            Assert.AreEqual(value, a.ToString());
        }

        [Test]
        public void TryParseTest()
        {
            string value = "NotANumber";
            bool success = i256.TryParse(value, out i256 result);

            Assert.IsFalse(success);
            Assert.AreEqual(i256.Zero, result);
        }

        [Test]
        public void DivideByZeroTest()
        {
            i256 a = new i256(10, 0, 0, 0);
            i256 b = i256.Zero;

            Assert.Throws<DivideByZeroException>(() => { var result = a / b; });
            Assert.Throws<DivideByZeroException>(() => { var result = a % b; });
        }

        [Test]
        public void OverflowTest()
        {
            i256 a = i256.MaxValue;
            i256 b = i256.One;

            Assert.Throws<OverflowException>(() => { var result = a + b; });
        }

        [Test]
        public void ToStringTest()
        {
            i256 a = new i256(1234567890UL, 0, 0, 0);
            string str = a.ToString();

            Assert.AreEqual("1234567890", str);
        }

        [Test]
        public void EqualityTest()
        {
            i256 a = new i256(123, 456, 789, 101112);
            i256 b = new i256(123, 456, 789, 101112);
            i256 c = new i256(123, 456, 789, 0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsTrue(a == b);
            Assert.IsTrue(a != c);
        }

        [Test]
        public void HashCodeTest()
        {
            i256 a = new i256(123, 456, 789, 101112);
            i256 b = new i256(123, 456, 789, 101112);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }

    [TestFixture]
    public class u128Tests
    {
        [Test]
        public void AdditionTest()
        {
            u128 a = u128.MaxValue;
            u128 b = u128.One;
            u128 result = a + b;
            Assert.AreEqual(u128.Zero, result);
        }

        [Test]
        public void SubtractionTest()
        {
            u128 a = u128.Zero;
            u128 b = u128.One;
            u128 result = a - b;
            Assert.AreEqual(u128.MaxValue, result);
        }

        [Test]
        public void MultiplicationTest()
        {
            u128 a = new u128(2, 0);
            u128 b = new u128(3, 0);
            u128 result = a * b;
            Assert.AreEqual(new u128(6, 0), result);
        }

        [Test]
        public void DivisionTest()
        {
            u128 a = new u128(10, 0);
            u128 b = new u128(2, 0);
            u128 result = a / b;
            Assert.AreEqual(new u128(5, 0), result);
        }

        [Test]
        public void ModuloTest()
        {
            u128 a = new u128(10, 0);
            u128 b = new u128(3, 0);
            u128 result = a % b;
            Assert.AreEqual(new u128(1, 0), result);
        }

        [Test]
        public void BitwiseOperationsTest()
        {
            u128 a = new u128(0x0F0F0F0F0F0F0F0FUL, 0);
            u128 b = new u128(0x00FF00FF00FF00FFUL, 0);

            u128 andResult = a & b;
            u128 orResult = a | b;
            u128 xorResult = a ^ b;
            u128 notResult = ~a;

            Assert.AreEqual(new u128(0x000F000F000F000FUL, 0), andResult);
            Assert.AreEqual(new u128(0x0FFF0FFF0FFF0FFFUL, 0), orResult);
            Assert.AreEqual(new u128(0x0FF00FF00FF00FF0UL, 0), xorResult);
            Assert.AreEqual(new u128(0xF0F0F0F0F0F0F0F0UL, ulong.MaxValue), notResult);
        }

        [Test]
        public void ShiftOperationsTest()
        {
            u128 a = new u128(1, 0);
            u128 leftShift = a << 64;
            u128 rightShift = leftShift >> 64;

            Assert.AreEqual(new u128(0, 1), leftShift);
            Assert.AreEqual(a, rightShift);
        }

        [Test]
        public void ComparisonOperatorsTest()
        {
            u128 a = new u128(1, 0);
            u128 b = new u128(2, 0);

            Assert.IsTrue(a < b);
            Assert.IsTrue(b > a);
            Assert.IsTrue(a <= a);
            Assert.IsTrue(b >= a);
            Assert.IsTrue(a == a);
            Assert.IsTrue(a != b);
        }

        [Test]
        public void ToBigIntegerTest()
        {
            u128 a = u128.MaxValue;
            BigInteger bigInt = a.ToBigInteger();

            Assert.AreEqual(BigInteger.Pow(2, 128) - 1, bigInt);
        }

        [Test]
        public void FromBigIntegerTest()
        {
            BigInteger bigInt = BigInteger.Pow(2, 128) - 1;
            u128 a = u128.FromBigInteger(bigInt);

            Assert.AreEqual(u128.MaxValue, a);
        }

        [Test]
        public void ParseTest()
        {
            string value = (BigInteger.Pow(2, 64) + 12345).ToString();
            u128 a = u128.Parse(value);

            Assert.AreEqual(new u128(12345, 1), a);
        }

        [Test]
        public void TryParseTest()
        {
            string value = "NotANumber";
            bool success = u128.TryParse(value, out u128 result);

            Assert.IsFalse(success);
            Assert.AreEqual(u128.Zero, result);
        }

        [Test]
        public void DivideByZeroTest()
        {
            u128 a = new u128(10, 0);
            u128 b = u128.Zero;

            Assert.Throws<DivideByZeroException>(() => { var result = a / b; });
            Assert.Throws<DivideByZeroException>(() => { var result = a % b; });
        }

        [Test]
        public void OverflowTest()
        {
            u128 a = u128.MaxValue;
            u128 b = u128.One;
            u128 result = a + b;

            Assert.AreEqual(u128.Zero, result);
        }

        [Test]
        public void ToStringTest()
        {
            u128 a = new u128(1234567890UL, 0);
            string str = a.ToString();

            Assert.AreEqual("1234567890", str);
        }

        [Test]
        public void EqualityTest()
        {
            u128 a = new u128(123, 456);
            u128 b = new u128(123, 456);
            u128 c = new u128(123, 0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsTrue(a == b);
            Assert.IsTrue(a != c);
        }

        [Test]
        public void HashCodeTest()
        {
            u128 a = new u128(123, 456);
            u128 b = new u128(123, 456);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }

    [TestFixture]
    public class i128Tests
    {
        [Test]
        public void AdditionTest()
        {
            i128 a = i128.MaxValue;
            i128 b = i128.One;
            Assert.Throws<OverflowException>(() => { var result = a + b; });
        }

        [Test]
        public void SubtractionTest()
        {
            i128 a = i128.MinValue;
            i128 b = i128.One;
            Assert.Throws<OverflowException>(() => { var result = a - b; });
        }

        [Test]
        public void MultiplicationTest()
        {
            i128 a = new i128(2, 0);
            i128 b = new i128(ulong.MaxValue, ulong.MaxValue); // Represents -1 in two's complement
            i128 result = a * b;
            i128 expected = new i128(ulong.MaxValue - 1, ulong.MaxValue); // -2 in two's complement
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DivisionTest()
        {
            i128 a = new i128(10, 0);
            i128 b = new i128(2, 0);
            i128 result = a / b;
            Assert.AreEqual(new i128(5, 0), result);
        }

        [Test]
        public void ModuloTest()
        {
            i128 a = new i128(10, 0);
            i128 b = new i128(3, 0);
            i128 result = a % b;
            Assert.AreEqual(new i128(1, 0), result);
        }

        [Test]
        public void BitwiseOperationsTest()
        {
            i128 a = new i128(0x0F0F0F0F0F0F0F0FUL, 0);
            i128 b = new i128(0x00FF00FF00FF00FFUL, 0);

            i128 andResult = a & b;
            i128 orResult = a | b;
            i128 xorResult = a ^ b;
            i128 notResult = ~a;

            Assert.AreEqual(new i128(0x000F000F000F000FUL, 0), andResult);
            Assert.AreEqual(new i128(0x0FFF0FFF0FFF0FFFUL, 0), orResult);
            Assert.AreEqual(new i128(0x0FF00FF00FF00FF0UL, 0), xorResult);
            Assert.AreEqual(new i128(0xF0F0F0F0F0F0F0F0UL, ulong.MaxValue), notResult);
        }

        [Test]
        public void ShiftOperationsTest()
        {
            i128 a = new i128(1, 0);
            i128 leftShift = a << 64;
            i128 rightShift = leftShift >> 64;

            Assert.AreEqual(new i128(0, 1), leftShift);
            Assert.AreEqual(a, rightShift);
        }

        [Test]
        public void ComparisonOperatorsTest()
        {
            i128 a = new i128(1, 0);
            i128 b = new i128(ulong.MaxValue, ulong.MaxValue);

            Assert.IsTrue(b < a);
            Assert.IsTrue(a > b);
            Assert.IsTrue(a >= a);
            Assert.IsTrue(b <= a);
            Assert.IsTrue(a != b);
        }

        [Test]
        public void ToBigIntegerTest()
        {
            i128 a = i128.MinValue;
            BigInteger bigInt = a.ToBigInteger();

            Assert.AreEqual(BigInteger.Pow(-2, 127), bigInt);
        }

        [Test]
        public void FromBigIntegerTest()
        {
            BigInteger bigInt = BigInteger.Pow(-2, 127);
            i128 a = i128.FromBigInteger(bigInt);

            Assert.AreEqual(i128.MinValue, a);
        }

        [Test]
        public void ParseTest()
        {
            string value = "-170141183460469231731687303715884105728"; // Min value for i128
            i128 a = i128.Parse(value);

            Assert.AreEqual(i128.MinValue, a);
        }

        [Test]
        public void TryParseTest()
        {
            string value = "NotANumber";
            bool success = i128.TryParse(value, out i128 result);

            Assert.IsFalse(success);
            Assert.AreEqual(i128.Zero, result);
        }

        [Test]
        public void DivideByZeroTest()
        {
            i128 a = new i128(10, 0);
            i128 b = i128.Zero;

            Assert.Throws<DivideByZeroException>(() => { var result = a / b; });
            Assert.Throws<DivideByZeroException>(() => { var result = a % b; });
        }

        [Test]
        public void OverflowTest()
        {
            i128 a = i128.MaxValue;
            i128 b = i128.One;

            Assert.Throws<OverflowException>(() => { var result = a + b; });
        }

        [Test]
        public void ToStringTest()
        {
            i128 a = new i128(1234567890UL, 0);
            string str = a.ToString();

            Assert.AreEqual("1234567890", str);
        }

        [Test]
        public void EqualityTest()
        {
            i128 a = new i128(123, 456);
            i128 b = new i128(123, 456);
            i128 c = new i128(123, 0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsTrue(a == b);
            Assert.IsTrue(a != c);
        }

        [Test]
        public void HashCodeTest()
        {
            i128 a = new i128(123, 456);
            i128 b = new i128(123, 456);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}