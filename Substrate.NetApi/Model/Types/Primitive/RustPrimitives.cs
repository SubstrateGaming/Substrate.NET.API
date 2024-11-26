using System;
using System.Numerics;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// u256 primitive mimic type
    /// </summary>
    public readonly struct u256 : IComparable<u256>, IEquatable<u256>
    {
        private readonly ulong _low;
        private readonly ulong _midLow;
        private readonly ulong _midHigh;
        private readonly ulong _high;

        /// <summary>
        /// Zero value
        /// </summary>
        public static readonly u256 Zero = new u256(0, 0, 0, 0);

        /// <summary>
        /// One value
        /// </summary>
        public static readonly u256 One = new u256(1, 0, 0, 0);

        /// <summary>
        /// Max value
        /// </summary>
        public static readonly u256 MaxValue = new u256(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue);

        /// <summary>
        /// u256 Constructor
        /// </summary>
        public u256(ulong low, ulong mid1, ulong mid2, ulong high)
        {
            _low = low;
            _midLow = mid1;
            _midHigh = mid2;
            _high = high;
        }

        /// <summary>
        /// u256 Constructor from byte array (little-endian)
        /// </summary>
        public u256(byte[] bytes)
        {
            if (bytes.Length != 32)
            {
                throw new ArgumentException("Byte array must be 32 bytes to fit a u256.");
            }

            _low = BitConverter.ToUInt64(bytes, 0);
            _midLow = BitConverter.ToUInt64(bytes, 8);
            _midHigh = BitConverter.ToUInt64(bytes, 16);
            _high = BitConverter.ToUInt64(bytes, 24);
        }

        /// <summary>
        /// Convert to byte array (little-endian)
        /// </summary>
        public byte[] ToByteArray()
        {
            var bytes = new byte[32];
            BitConverter.GetBytes(_low).CopyTo(bytes, 0);
            BitConverter.GetBytes(_midLow).CopyTo(bytes, 8);
            BitConverter.GetBytes(_midHigh).CopyTo(bytes, 16);
            BitConverter.GetBytes(_high).CopyTo(bytes, 24);
            return bytes;
        }

        /// <summary>
        /// Addition operator
        /// </summary>
        public static u256 operator +(u256 a, u256 b)
        {
            ulong carry = 0;
            ulong low = AddWithCarry(a._low, b._low, ref carry);
            ulong midLow = AddWithCarry(a._midLow, b._midLow, ref carry);
            ulong midHigh = AddWithCarry(a._midHigh, b._midHigh, ref carry);
            ulong high = a._high + b._high + carry;
            return new u256(low, midLow, midHigh, high);
        }

        private static ulong AddWithCarry(ulong a, ulong b, ref ulong carry)
        {
            ulong tempSum = a + b + carry;
            carry = ((tempSum < a) || (carry == 1 && tempSum == a)) ? 1UL : 0UL;
            return tempSum;
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        public static u256 operator -(u256 a, u256 b)
        {
            ulong borrow = 0;
            ulong low = SubtractWithBorrow(a._low, b._low, ref borrow);
            ulong midLow = SubtractWithBorrow(a._midLow, b._midLow, ref borrow);
            ulong midHigh = SubtractWithBorrow(a._midHigh, b._midHigh, ref borrow);
            ulong high = a._high - b._high - borrow;
            return new u256(low, midLow, midHigh, high);
        }

        private static ulong SubtractWithBorrow(ulong a, ulong b, ref ulong borrow)
        {
            ulong tempDiff = a - b - borrow;
            borrow = (a < b + borrow) ? 1UL : 0UL;
            return tempDiff;
        }

        /// <summary>
        /// Multiplication operator
        /// </summary>
        public static u256 operator *(u256 a, u256 b)
        {
            // Use BigInteger for multiplication and wrap around
            BigInteger result = (a.ToBigInteger() * b.ToBigInteger()) & ((BigInteger.One << 256) - 1);
            return FromBigInteger(result);
        }

        /// <summary>
        /// Division operator (integer division)
        /// </summary>
        public static u256 operator /(u256 a, u256 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() / b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Modulo operator
        /// </summary>
        public static u256 operator %(u256 a, u256 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() % b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Bitwise AND operator
        /// </summary>
        public static u256 operator &(u256 a, u256 b)
        {
            return new u256(a._low & b._low, a._midLow & b._midLow, a._midHigh & b._midHigh, a._high & b._high);
        }

        /// <summary>
        /// Bitwise OR operator
        /// </summary>
        public static u256 operator |(u256 a, u256 b)
        {
            return new u256(a._low | b._low, a._midLow | b._midLow, a._midHigh | b._midHigh, a._high | b._high);
        }

        /// <summary>
        /// Bitwise XOR operator
        /// </summary>
        public static u256 operator ^(u256 a, u256 b)
        {
            return new u256(a._low ^ b._low, a._midLow ^ b._midLow, a._midHigh ^ b._midHigh, a._high ^ b._high);
        }

        /// <summary>
        /// Bitwise NOT operator
        /// </summary>
        public static u256 operator ~(u256 a)
        {
            return new u256(~a._low, ~a._midLow, ~a._midHigh, ~a._high);
        }

        /// <summary>
        /// Left shift operator
        /// </summary>
        public static u256 operator <<(u256 value, int shift)
        {
            shift &= 255; // Modulo 256
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._midLow, value._midHigh, value._high };
            ulong[] result = new ulong[4];

            int k = shift / 64;
            int s = shift % 64;

            for (int i = 3; i >= 0; i--)
            {
                if (i - k >= 0)
                {
                    result[i] = parts[i - k] << s;
                    if (s != 0 && i - k - 1 >= 0)
                    {
                        result[i] |= parts[i - k - 1] >> (64 - s);
                    }
                }
            }
            return new u256(result[0], result[1], result[2], result[3]);
        }

        /// <summary>
        /// Right shift operator
        /// </summary>
        public static u256 operator >>(u256 value, int shift)
        {
            shift &= 255; // Modulo 256
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._midLow, value._midHigh, value._high };
            ulong[] result = new ulong[4];

            int k = shift / 64;
            int s = shift % 64;

            for (int i = 0; i < 4; i++)
            {
                if (i + k < 4)
                {
                    result[i] = parts[i + k] >> s;
                    if (s != 0 && i + k + 1 < 4)
                    {
                        result[i] |= parts[i + k + 1] << (64 - s);
                    }
                }
            }
            return new u256(result[0], result[1], result[2], result[3]);
        }

        /// <summary>
        /// Comparison operators
        /// </summary>
        public static bool operator ==(u256 left, u256 right) => left.Equals(right);

        /// <summary>
        /// Unequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(u256 left, u256 right) => !left.Equals(right);

        /// <summary>
        /// Greater than
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(u256 left, u256 right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Less than
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(u256 left, u256 right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Greater than or equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(u256 left, u256 right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Smaller than or equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(u256 left, u256 right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Equals override
        /// </summary>
        public override bool Equals(object obj) => obj is u256 other && Equals(other);

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(u256 other) =>
            _low == other._low && _midLow == other._midLow && _midHigh == other._midHigh && _high == other._high;

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
#if NETSTANDARD2_0
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + _low.GetHashCode();
                hash = hash * 31 + _midLow.GetHashCode();
                hash = hash * 31 + _midHigh.GetHashCode();
                hash = hash * 31 + _high.GetHashCode();
                return hash;
            }
#else
            return HashCode.Combine(_low, _midLow, _midHigh, _high);
#endif
        }

        /// <summary>
        /// CompareTo implementation
        /// </summary>
        public int CompareTo(u256 other)
        {
            int cmp = _high.CompareTo(other._high);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = _midHigh.CompareTo(other._midHigh);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = _midLow.CompareTo(other._midLow);
            if (cmp != 0)
            {
                return cmp;
            }

            return _low.CompareTo(other._low);
        }

        /// <summary>
        /// ToString override
        /// </summary>
        public override string ToString()
        {
            // Use BigInteger for string representation
            return ToBigInteger().ToString();
        }

        /// <summary>
        /// Converts u256 to BigInteger
        /// </summary>
        public BigInteger ToBigInteger()
        {
            byte[] bytes = ToByteArray();

            // Check if the most significant bit is set
            if ((bytes[bytes.Length - 1] & 0x80) != 0)
            {
                // Append a zero byte to ensure positive interpretation
                byte[] extendedBytes = new byte[bytes.Length + 1];
                Array.Copy(bytes, extendedBytes, bytes.Length);
                bytes = extendedBytes;
            }

            return new BigInteger(bytes);
        }

        /// <summary>
        /// Creates u256 from BigInteger
        /// </summary>
        public static u256 FromBigInteger(BigInteger value)
        {
            if (value < BigInteger.Zero)
                throw new OverflowException("Value is out of range for u256.");

            byte[] bytes = value.ToByteArray();

            // Remove any leading zeros that may have been added
            if (bytes.Length > 32)
            {
                // Ensure that the extra bytes are all zeros
                for (int i = 32; i < bytes.Length; i++)
                {
                    if (bytes[i] != 0)
                        throw new OverflowException("Value is out of range for u256.");
                }
            }

            // Ensure array is exactly 32 bytes
            Array.Resize(ref bytes, 32);

            return new u256(bytes);
        }

        /// <summary>
        /// Parses a string into u256
        /// </summary>
        public static u256 Parse(string value)
        {
            BigInteger bigInt = BigInteger.Parse(value);
            return FromBigInteger(bigInt);
        }

        /// <summary>
        /// TryParse method
        /// </summary>
        public static bool TryParse(string value, out u256 result)
        {
            result = Zero;
            if (BigInteger.TryParse(value, out BigInteger bigInt))
            {
                if (bigInt >= BigInteger.Zero && bigInt <= MaxValue.ToBigInteger())
                {
                    result = FromBigInteger(bigInt);
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// i256 primitive mimic type
    /// </summary>
    public struct i256 : IComparable<i256>, IEquatable<i256>
    {
        private readonly ulong _low;
        private readonly ulong _midLow;
        private readonly ulong _midHigh;
        private readonly ulong _high;

        /// <summary>
        /// Zero value
        /// </summary>
        public static readonly i256 Zero = new i256(0, 0, 0, 0);

        /// <summary>
        /// One value
        /// </summary>
        public static readonly i256 One = new i256(1, 0, 0, 0);

        /// <summary>
        /// Min value (-2^255)
        /// </summary>
        public static readonly i256 MinValue = new i256(0, 0, 0, 0x8000000000000000UL);

        /// <summary>
        /// Max value (2^255 - 1)
        /// </summary>
        public static readonly i256 MaxValue = new i256(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, 0x7FFFFFFFFFFFFFFFUL);

        /// <summary>
        /// i256 Constructor
        /// </summary>
        public i256(ulong low, ulong mid1, ulong mid2, ulong high)
        {
            _low = low;
            _midLow = mid1;
            _midHigh = mid2;
            _high = high;
        }

        /// <summary>
        /// i256 Constructor from byte array (little-endian)
        /// </summary>
        public i256(byte[] bytes)
        {
            if (bytes.Length != 32)
            {
                throw new ArgumentException("Byte array must be 32 bytes to fit an i256.");
            }

            _low = BitConverter.ToUInt64(bytes, 0);
            _midLow = BitConverter.ToUInt64(bytes, 8);
            _midHigh = BitConverter.ToUInt64(bytes, 16);
            _high = BitConverter.ToUInt64(bytes, 24);
        }

        /// <summary>
        /// Convert to byte array (little-endian)
        /// </summary>
        public byte[] ToByteArray()
        {
            var bytes = new byte[32];
            BitConverter.GetBytes(_low).CopyTo(bytes, 0);
            BitConverter.GetBytes(_midLow).CopyTo(bytes, 8);
            BitConverter.GetBytes(_midHigh).CopyTo(bytes, 16);
            BitConverter.GetBytes(_high).CopyTo(bytes, 24);
            return bytes;
        }

        /// <summary>
        /// Addition operator
        /// </summary>
        public static i256 operator +(i256 a, i256 b)
        {
            BigInteger result = a.ToBigInteger() + b.ToBigInteger();
            if (result < MinValue.ToBigInteger() || result > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Addition overflow in i256.");
            }

            return FromBigInteger(result);
        }

        private static ulong AddWithCarry(ulong a, ulong b, ref ulong carry)
        {
            ulong sum = a + b + carry;
            carry = (sum < a || (carry == 1 && sum == a)) ? 1UL : 0UL;
            return sum;
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        public static i256 operator -(i256 a, i256 b)
        {
            BigInteger result = a.ToBigInteger() - b.ToBigInteger();
            if (result < MinValue.ToBigInteger() || result > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Subtraction overflow in i256.");
            }

            return FromBigInteger(result);
        }

        private static ulong SubtractWithBorrow(ulong a, ulong b, ref ulong borrow)
        {
            ulong diff = a - b - borrow;
            borrow = (a < b || (borrow == 1 && a == b)) ? 1UL : 0UL;
            return diff;
        }

        /// <summary>
        /// Multiplication operator
        /// </summary>
        public static i256 operator *(i256 a, i256 b)
        {
            BigInteger result = a.ToBigInteger() * b.ToBigInteger();
            if (result < MinValue.ToBigInteger() || result > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Multiplication overflow in i256.");
            }

            return FromBigInteger(result);
        }

        /// <summary>
        /// Division operator (integer division)
        /// </summary>
        public static i256 operator /(i256 a, i256 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() / b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Modulo operator
        /// </summary>
        public static i256 operator %(i256 a, i256 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() % b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Bitwise AND operator
        /// </summary>
        public static i256 operator &(i256 a, i256 b)
        {
            return new i256(a._low & b._low, a._midLow & b._midLow, a._midHigh & b._midHigh, a._high & b._high);
        }

        /// <summary>
        /// Bitwise OR operator
        /// </summary>
        public static i256 operator |(i256 a, i256 b)
        {
            return new i256(a._low | b._low, a._midLow | b._midLow, a._midHigh | b._midHigh, a._high | b._high);
        }

        /// <summary>
        /// Bitwise XOR operator
        /// </summary>
        public static i256 operator ^(i256 a, i256 b)
        {
            return new i256(a._low ^ b._low, a._midLow ^ b._midLow, a._midHigh ^ b._midHigh, a._high ^ b._high);
        }

        /// <summary>
        /// Bitwise NOT operator
        /// </summary>
        public static i256 operator ~(i256 a)
        {
            return new i256(~a._low, ~a._midLow, ~a._midHigh, ~a._high);
        }

        /// <summary>
        /// Left shift operator
        /// </summary>
        public static i256 operator <<(i256 value, int shift)
        {
            shift &= 255; // Modulo 256
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._midLow, value._midHigh, value._high };
            ulong[] result = new ulong[4];

            int k = shift / 64;
            int s = shift % 64;

            for (int i = 3; i >= 0; i--)
            {
                if (i - k >= 0)
                {
                    result[i] = parts[i - k] << s;
                    if (s != 0 && i - k - 1 >= 0)
                    {
                        result[i] |= parts[i - k - 1] >> (64 - s);
                    }
                }
            }
            return new i256(result[0], result[1], result[2], result[3]);
        }

        /// <summary>
        /// Right shift operator
        /// </summary>
        public static i256 operator >>(i256 value, int shift)
        {
            shift &= 255; // Modulo 256
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._midLow, value._midHigh, value._high };
            ulong[] result = new ulong[4];

            bool isNegative = (value._high & 0x8000000000000000UL) != 0;

            int k = shift / 64;
            int s = shift % 64;

            for (int i = 0; i < 4; i++)
            {
                if (i + k < 4)
                {
                    result[i] = parts[i + k] >> s;
                    if (s != 0 && i + k + 1 < 4)
                    {
                        result[i] |= parts[i + k + 1] << (64 - s);
                    }
                }
                else if (isNegative)
                {
                    result[i] = ulong.MaxValue;
                }
                else
                {
                    result[i] = 0;
                }
            }

            // Sign extension for arithmetic shift
            if (isNegative)
            {
                for (int i = 3 - k; i >= 0; i--)
                {
                    result[i] |= ulong.MaxValue << (64 - s);
                }
            }

            return new i256(result[0], result[1], result[2], result[3]);
        }

        /// <summary>
        /// Unary minus operator
        /// </summary>
        public static i256 operator -(i256 value)
        {
            return Zero - value;
        }

        /// <summary>
        /// Unary plus operator
        /// </summary>
        public static i256 operator +(i256 value)
        {
            return value;
        }

        /// <summary>
        /// Equality operators
        /// </summary>
        public static bool operator ==(i256 left, i256 right) => left.Equals(right);

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(i256 left, i256 right) => !left.Equals(right);

        /// <summary>
        /// Greater than
        /// </summary>
        public static bool operator <(i256 left, i256 right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Less than
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(i256 left, i256 right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Greater than or equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(i256 left, i256 right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Less than or equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(i256 left, i256 right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Equals override
        /// </summary>
        public override bool Equals(object obj) => obj is i256 other && Equals(other);

        public bool Equals(i256 other) =>
            _low == other._low && _midLow == other._midLow && _midHigh == other._midHigh && _high == other._high;

        public override int GetHashCode()
        {
#if NETSTANDARD2_0
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + _low.GetHashCode();
                hash = hash * 31 + _midLow.GetHashCode();
                hash = hash * 31 + _midHigh.GetHashCode();
                hash = hash * 31 + _high.GetHashCode();
                return hash;
            }
#else
            return HashCode.Combine(_low, _midLow, _midHigh, _high);
#endif
        }

        /// <summary>
        /// CompareTo implementation
        /// </summary>
        public int CompareTo(i256 other)
        {
            bool thisNegative = (_high & 0x8000000000000000UL) != 0;
            bool otherNegative = (other._high & 0x8000000000000000UL) != 0;

            if (thisNegative && !otherNegative)
            {
                return -1;
            }

            if (!thisNegative && otherNegative)
            {
                return 1;
            }

            int cmp = _high.CompareTo(other._high);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = _midHigh.CompareTo(other._midHigh);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = _midLow.CompareTo(other._midLow);
            if (cmp != 0)
            {
                return cmp;
            }

            return _low.CompareTo(other._low);
        }

        /// <summary>
        /// ToString override
        /// </summary>
        public override string ToString()
        {
            return ToBigInteger().ToString();
        }

        /// <summary>
        /// Converts i256 to BigInteger
        /// </summary>
        public BigInteger ToBigInteger()
        {
            byte[] bytes = ToByteArray();

            // Check if the number is negative
            bool isNegative = (_high & 0x8000000000000000UL) != 0;

            if (isNegative)
            {
                // Convert to two's complement representation
                var complement = new byte[bytes.Length + 1]; // Extra byte for sign
                for (int i = 0; i < bytes.Length; i++)
                {
                    complement[i] = (byte)~bytes[i];
                }
                // Add one
                BigInteger temp = new BigInteger(complement) + 1;
                // Make negative
                return -temp;
            }
            else
            {
                return new BigInteger(bytes);
            }
        }

        /// <summary>
        /// Creates i256 from BigInteger
        /// </summary>
        public static i256 FromBigInteger(BigInteger value)
        {
            if (value < MinValue.ToBigInteger() || value > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Value is out of range for i256.");
            }

            byte[] bytes = value.ToByteArray();

            // Ensure array is 32 bytes
            if (bytes.Length > 32)
            {
                throw new OverflowException("Value is out of range for i256.");
            }
            else if (bytes.Length < 32)
            {
                Array.Resize(ref bytes, 32);
                if (value.Sign < 0)
                {
                    // Fill with 0xFF for negative numbers (sign extension)
                    for (int i = bytes.Length - 1; i >= 0; i--)
                    {
                        if (bytes[i] != 0)
                        {
                            break;
                        }

                        bytes[i] = 0xFF;
                    }
                }
            }

            return new i256(bytes);
        }

        /// <summary>
        /// Parses a string into i256
        /// </summary>
        public static i256 Parse(string value)
        {
            BigInteger bigInt = BigInteger.Parse(value);
            return FromBigInteger(bigInt);
        }

        /// <summary>
        /// TryParse method
        /// </summary>
        public static bool TryParse(string value, out i256 result)
        {
            result = Zero;
            if (BigInteger.TryParse(value, out BigInteger bigInt))
            {
                if (bigInt >= MinValue.ToBigInteger() && bigInt <= MaxValue.ToBigInteger())
                {
                    result = FromBigInteger(bigInt);
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// u128 primitive mimic type
    /// </summary>
    public struct u128 : IComparable<u128>, IEquatable<u128>
    {
        private readonly ulong _low;
        private readonly ulong _high;

        /// <summary>
        /// Zero value
        /// </summary>
        public static readonly u128 Zero = new u128(0, 0);

        /// <summary>
        /// One value
        /// </summary>
        public static readonly u128 One = new u128(1, 0);

        /// <summary>
        /// Max value
        /// </summary>
        public static readonly u128 MaxValue = new u128(ulong.MaxValue, ulong.MaxValue);

        /// <summary>
        /// u128 Constructor
        /// </summary>
        public u128(ulong low, ulong high)
        {
            _low = low;
            _high = high;
        }

        /// <summary>
        /// u128 Constructor from byte array (little-endian)
        /// </summary>
        public u128(byte[] bytes)
        {
            if (bytes.Length != 16)
            {
                throw new ArgumentException("Byte array must be 16 bytes to fit a u128.");
            }

            _low = BitConverter.ToUInt64(bytes, 0);
            _high = BitConverter.ToUInt64(bytes, 8);
        }

        /// <summary>
        /// Convert to byte array (little-endian)
        /// </summary>
        public byte[] ToByteArray()
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(_low).CopyTo(bytes, 0);
            BitConverter.GetBytes(_high).CopyTo(bytes, 8);
            return bytes;
        }

        /// <summary>
        /// Addition operator
        /// </summary>
        public static u128 operator +(u128 a, u128 b)
        {
            ulong carry = 0;
            ulong low = AddWithCarry(a._low, b._low, ref carry);
            ulong high = a._high + b._high + carry;
            return new u128(low, high);
        }

        private static ulong AddWithCarry(ulong a, ulong b, ref ulong carry)
        {
            ulong tempSum = a + b + carry;
            carry = ((tempSum < a) || (carry == 1 && tempSum == a)) ? 1UL : 0UL;
            return tempSum;
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        public static u128 operator -(u128 a, u128 b)
        {
            ulong borrow = 0;
            ulong low = SubtractWithBorrow(a._low, b._low, ref borrow);
            ulong high = a._high - b._high - borrow;
            return new u128(low, high);
        }

        private static ulong SubtractWithBorrow(ulong a, ulong b, ref ulong borrow)
        {
            ulong tempDiff = a - b - borrow;
            borrow = (a < b + borrow) ? 1UL : 0UL;
            return tempDiff;
        }

        /// <summary>
        /// Multiplication operator
        /// </summary>
        public static u128 operator *(u128 a, u128 b)
        {
            // Perform multiplication using BigInteger and allow wrap-around
            BigInteger result = (a.ToBigInteger() * b.ToBigInteger()) & ((BigInteger.One << 128) - 1);
            return FromBigInteger(result);
        }

        /// <summary>
        /// Division operator (integer division)
        /// </summary>
        public static u128 operator /(u128 a, u128 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() / b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Modulo operator
        /// </summary>
        public static u128 operator %(u128 a, u128 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() % b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Bitwise AND operator
        /// </summary>
        public static u128 operator &(u128 a, u128 b)
        {
            return new u128(a._low & b._low, a._high & b._high);
        }

        /// <summary>
        /// Bitwise OR operator
        /// </summary>
        public static u128 operator |(u128 a, u128 b)
        {
            return new u128(a._low | b._low, a._high | b._high);
        }

        /// <summary>
        /// Bitwise XOR operator
        /// </summary>
        public static u128 operator ^(u128 a, u128 b)
        {
            return new u128(a._low ^ b._low, a._high ^ b._high);
        }

        /// <summary>
        /// Bitwise NOT operator
        /// </summary>
        public static u128 operator ~(u128 a)
        {
            return new u128(~a._low, ~a._high);
        }

        /// <summary>
        /// Left shift operator
        /// </summary>
        public static u128 operator <<(u128 value, int shift)
        {
            shift &= 127; // Modulo 128
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._high };
            ulong[] result = new ulong[2];

            int k = shift / 64;
            int s = shift % 64;

            if (k < 2)
            {
                result[1] = (k == 1 ? parts[0] : parts[1]) << s;
                if (s != 0 && k == 0)
                {
                    result[1] |= parts[0] >> (64 - s);
                }

                result[0] = k == 0 ? parts[0] << s : 0UL;
            }
            return new u128(result[0], result[1]);
        }

        /// <summary>
        /// Right shift operator
        /// </summary>
        public static u128 operator >>(u128 value, int shift)
        {
            shift &= 127; // Modulo 128
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._high };
            ulong[] result = new ulong[2];

            int k = shift / 64;
            int s = shift % 64;

            if (k < 2)
            {
                result[0] = (k == 1 ? parts[1] : parts[0]) >> s;
                if (s != 0 && k == 0)
                {
                    result[0] |= parts[1] << (64 - s);
                }

                result[1] = k == 0 ? parts[1] >> s : 0UL;
            }
            return new u128(result[0], result[1]);
        }

        /// <summary>
        /// Equality operators
        /// </summary>
        public static bool operator ==(u128 left, u128 right) => left.Equals(right);

        /// <summary>
        /// Unequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(u128 left, u128 right) => !left.Equals(right);

        /// <summary>
        /// Greater than
        /// </summary>
        public static bool operator <(u128 left, u128 right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Lesser than
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(u128 left, u128 right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Greater than or equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(u128 left, u128 right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Lesser than or equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(u128 left, u128 right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Equals override
        /// </summary>
        public override bool Equals(object obj) => obj is u128 other && Equals(other);

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(u128 other) => _low == other._low && _high == other._high;

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
#if NETSTANDARD2_0
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + _low.GetHashCode();
                hash = hash * 31 + _high.GetHashCode();
                return hash;
            }
#else
            return HashCode.Combine(_low, _high);
#endif
        }

        /// <summary>
        /// CompareTo implementation
        /// </summary>
        public int CompareTo(u128 other)
        {
            int cmp = _high.CompareTo(other._high);
            if (cmp != 0)
            {
                return cmp;
            }

            return _low.CompareTo(other._low);
        }

        /// <summary>
        /// ToString override
        /// </summary>
        public override string ToString()
        {
            return ToBigInteger().ToString();
        }

        /// <summary>
        /// Converts u128 to BigInteger
        /// </summary>
        public BigInteger ToBigInteger()
        {
            byte[] bytes = ToByteArray();

            // Check if the most significant bit is set
            if ((bytes[bytes.Length - 1] & 0x80) != 0)
            {
                // Append a zero byte to make it positive
                byte[] extendedBytes = new byte[bytes.Length + 1];
                Array.Copy(bytes, extendedBytes, bytes.Length);
                bytes = extendedBytes;
            }

            return new BigInteger(bytes);
        }

        /// <summary>
        /// Creates u128 from BigInteger
        /// </summary>
        public static u128 FromBigInteger(BigInteger value)
        {
            if (value < BigInteger.Zero)
                throw new OverflowException("Value is out of range for u128.");

            byte[] bytes = value.ToByteArray();

            // Trim leading zeros if any
            if (bytes.Length > 16)
            {
                for (int i = 16; i < bytes.Length; i++)
                {
                    if (bytes[i] != 0)
                        throw new OverflowException("Value is out of range for u128.");
                }
            }

            // Ensure array is exactly 16 bytes
            Array.Resize(ref bytes, 16);

            return new u128(bytes);
        }

        /// <summary>
        /// Parses a string into u128
        /// </summary>
        public static u128 Parse(string value)
        {
            BigInteger bigInt = BigInteger.Parse(value);
            return FromBigInteger(bigInt);
        }

        /// <summary>
        /// TryParse method
        /// </summary>
        public static bool TryParse(string value, out u128 result)
        {
            result = Zero;
            if (BigInteger.TryParse(value, out BigInteger bigInt))
            {
                if (bigInt >= BigInteger.Zero && bigInt <= MaxValue.ToBigInteger())
                {
                    result = FromBigInteger(bigInt);
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// i128 primitive mimic type
    /// </summary>
    public struct i128 : IComparable<i128>, IEquatable<i128>
    {
        private readonly ulong _low;
        private readonly ulong _high;

        /// <summary>
        /// Zero value
        /// </summary>
        public static readonly i128 Zero = new i128(0, 0);

        /// <summary>
        /// One value
        /// </summary>
        public static readonly i128 One = new i128(1, 0);

        /// <summary>
        /// Min value (-2^127)
        /// </summary>
        public static readonly i128 MinValue = new i128(0, 0x8000000000000000UL);

        /// <summary>
        /// Max value (2^127 - 1)
        /// </summary>
        public static readonly i128 MaxValue = new i128(ulong.MaxValue, 0x7FFFFFFFFFFFFFFFUL);

        /// <summary>
        /// i128 Constructor
        /// </summary>
        public i128(ulong low, ulong high)
        {
            _low = low;
            _high = high;
        }

        /// <summary>
        /// i128 Constructor from byte array (little-endian)
        /// </summary>
        public i128(byte[] bytes)
        {
            if (bytes.Length != 16)
            {
                throw new ArgumentException("Byte array must be 16 bytes to fit an i128.");
            }

            _low = BitConverter.ToUInt64(bytes, 0);
            _high = BitConverter.ToUInt64(bytes, 8);
        }

        /// <summary>
        /// Convert to byte array (little-endian)
        /// </summary>
        public byte[] ToByteArray()
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(_low).CopyTo(bytes, 0);
            BitConverter.GetBytes(_high).CopyTo(bytes, 8);
            return bytes;
        }

        /// <summary>
        /// Addition operator
        /// </summary>
        public static i128 operator +(i128 a, i128 b)
        {
            BigInteger result = a.ToBigInteger() + b.ToBigInteger();
            if (result < MinValue.ToBigInteger() || result > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Addition overflow in i128.");
            }

            return FromBigInteger(result);
        }

        private static ulong AddWithCarry(ulong a, ulong b, ref ulong carry)
        {
            ulong sum = a + b + carry;
            carry = (sum < a || (carry == 1 && sum == a)) ? 1UL : 0UL;
            return sum;
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        public static i128 operator -(i128 a, i128 b)
        {
            BigInteger result = a.ToBigInteger() - b.ToBigInteger();
            if (result < MinValue.ToBigInteger() || result > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Subtraction overflow in i128.");
            }

            return FromBigInteger(result);
        }

        private static ulong SubtractWithBorrow(ulong a, ulong b, ref ulong borrow)
        {
            ulong diff = a - b - borrow;
            borrow = (a < b || (borrow == 1 && a == b)) ? 1UL : 0UL;
            return diff;
        }

        /// <summary>
        /// Multiplication operator
        /// </summary>
        public static i128 operator *(i128 a, i128 b)
        {
            BigInteger result = a.ToBigInteger() * b.ToBigInteger();
            if (result < MinValue.ToBigInteger() || result > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Multiplication overflow in i128.");
            }

            return FromBigInteger(result);
        }

        /// <summary>
        /// Division operator (integer division)
        /// </summary>
        public static i128 operator /(i128 a, i128 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() / b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Modulo operator
        /// </summary>
        public static i128 operator %(i128 a, i128 b)
        {
            if (b == Zero)
            {
                throw new DivideByZeroException();
            }

            BigInteger result = a.ToBigInteger() % b.ToBigInteger();
            return FromBigInteger(result);
        }

        /// <summary>
        /// Bitwise AND operator
        /// </summary>
        public static i128 operator &(i128 a, i128 b)
        {
            return new i128(a._low & b._low, a._high & b._high);
        }

        /// <summary>
        /// Bitwise OR operator
        /// </summary>
        public static i128 operator |(i128 a, i128 b)
        {
            return new i128(a._low | b._low, a._high | b._high);
        }

        /// <summary>
        /// Bitwise XOR operator
        /// </summary>
        public static i128 operator ^(i128 a, i128 b)
        {
            return new i128(a._low ^ b._low, a._high ^ b._high);
        }

        /// <summary>
        /// Bitwise NOT operator
        /// </summary>
        public static i128 operator ~(i128 a)
        {
            return new i128(~a._low, ~a._high);
        }

        /// <summary>
        /// Left shift operator
        /// </summary>
        public static i128 operator <<(i128 value, int shift)
        {
            shift &= 127; // Modulo 128
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._high };
            ulong[] result = new ulong[2];

            int k = shift / 64;
            int s = shift % 64;

            if (k < 2)
            {
                result[1] = (k == 1 ? parts[0] : parts[1]) << s;
                if (s != 0 && k == 0)
                {
                    result[1] |= parts[0] >> (64 - s);
                }

                result[0] = k == 0 ? parts[0] << s : 0UL;
            }
            return new i128(result[0], result[1]);
        }

        /// <summary>
        /// Right shift operator
        /// </summary>
        public static i128 operator >>(i128 value, int shift)
        {
            shift &= 127; // Modulo 128
            if (shift == 0)
            {
                return value;
            }

            ulong[] parts = { value._low, value._high };
            ulong[] result = new ulong[2];

            bool isNegative = (value._high & 0x8000000000000000UL) != 0;

            int k = shift / 64;
            int s = shift % 64;

            if (k < 2)
            {
                result[0] = (k == 1 ? parts[1] : parts[0]) >> s;
                if (s != 0 && k == 0)
                {
                    result[0] |= parts[1] << (64 - s);
                }

                result[1] = k == 0 ? parts[1] >> s : (isNegative ? ulong.MaxValue : 0UL);
            }

            // Sign extension for arithmetic shift
            if (isNegative)
            {
                for (int i = 1 - k; i >= 0; i--)
                {
                    result[i] |= ulong.MaxValue << (64 - s);
                }
            }

            return new i128(result[0], result[1]);
        }

        /// <summary>
        /// Unary minus operator
        /// </summary>
        public static i128 operator -(i128 value)
        {
            return Zero - value;
        }

        /// <summary>
        /// Unary plus operator
        /// </summary>
        public static i128 operator +(i128 value)
        {
            return value;
        }

        /// <summary>
        /// Equality operators
        /// </summary>
        public static bool operator ==(i128 left, i128 right) => left.Equals(right);

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(i128 left, i128 right) => !left.Equals(right);

        /// <summary>
        /// Comparison operators
        /// </summary>
        public static bool operator <(i128 left, i128 right) => left.CompareTo(right) < 0;

        public static bool operator >(i128 left, i128 right) => left.CompareTo(right) > 0;

        public static bool operator <=(i128 left, i128 right) => left.CompareTo(right) <= 0;

        public static bool operator >=(i128 left, i128 right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Equals override
        /// </summary>
        public override bool Equals(object obj) => obj is i128 other && Equals(other);

        public bool Equals(i128 other) => _low == other._low && _high == other._high;

        public override int GetHashCode()
        {
#if NETSTANDARD2_0
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + _low.GetHashCode();
                hash = hash * 31 + _high.GetHashCode();
                return hash;
            }
#else
            return HashCode.Combine(_low, _high);
#endif
        }

        /// <summary>
        /// CompareTo implementation
        /// </summary>
        public int CompareTo(i128 other)
        {
            bool thisNegative = (_high & 0x8000000000000000UL) != 0;
            bool otherNegative = (other._high & 0x8000000000000000UL) != 0;

            if (thisNegative && !otherNegative)
            {
                return -1;
            }

            if (!thisNegative && otherNegative)
            {
                return 1;
            }

            int cmp = _high.CompareTo(other._high);
            if (cmp != 0)
            {
                return cmp;
            }

            return _low.CompareTo(other._low);
        }

        /// <summary>
        /// ToString override
        /// </summary>
        public override string ToString()
        {
            return ToBigInteger().ToString();
        }

        /// <summary>
        /// Converts i128 to BigInteger
        /// </summary>
        public BigInteger ToBigInteger()
        {
            byte[] bytes = ToByteArray();

            // Check if the number is negative
            bool isNegative = (_high & 0x8000000000000000UL) != 0;

            if (isNegative)
            {
                // Convert to two's complement representation
                var complement = new byte[bytes.Length + 1]; // Extra byte for sign
                for (int i = 0; i < bytes.Length; i++)
                {
                    complement[i] = (byte)~bytes[i];
                }
                // Add one
                BigInteger temp = new BigInteger(complement) + 1;
                // Make negative
                return -temp;
            }
            else
            {
                return new BigInteger(bytes);
            }
        }

        /// <summary>
        /// Creates i128 from BigInteger
        /// </summary>
        public static i128 FromBigInteger(BigInteger value)
        {
            if (value < MinValue.ToBigInteger() || value > MaxValue.ToBigInteger())
            {
                throw new OverflowException("Value is out of range for i128.");
            }

            byte[] bytes = value.ToByteArray();

            // Ensure array is 16 bytes
            if (bytes.Length > 16)
            {
                Array.Resize(ref bytes, 16);
            }
            else if (bytes.Length < 16)
            {
                Array.Resize(ref bytes, 16);
                if (value.Sign < 0)
                {
                    // Fill with 0xFF for negative numbers (sign extension)
                    for (int i = bytes.Length - 1; i >= 0; i--)
                    {
                        if (bytes[i] != 0)
                        {
                            break;
                        }

                        bytes[i] = 0xFF;
                    }
                }
            }

            return new i128(bytes);
        }

        /// <summary>
        /// Parses a string into i128
        /// </summary>
        public static i128 Parse(string value)
        {
            BigInteger bigInt = BigInteger.Parse(value);
            return FromBigInteger(bigInt);
        }

        /// <summary>
        /// TryParse method
        /// </summary>
        public static bool TryParse(string value, out i128 result)
        {
            result = Zero;
            if (BigInteger.TryParse(value, out BigInteger bigInt))
            {
                if (bigInt >= MinValue.ToBigInteger() && bigInt <= MaxValue.ToBigInteger())
                {
                    result = FromBigInteger(bigInt);
                    return true;
                }
            }
            return false;
        }
    }
}