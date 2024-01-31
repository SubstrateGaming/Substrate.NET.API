using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace Substrate.NetApi
{
    /// <summary>
    /// Base58 Functions
    /// </summary>
    public static class Base58Local
    {
        /// <summary>
        /// The alphabet used in the Base58 encoding.
        /// </summary>
        private const string AlphaNumerics = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        /// <summary>
        /// The size of a Base58 check sum in bytes.
        /// </summary>
        public const int CheckSumSizeInBytes = 4;

        /// <summary>
        /// Adds a check sum to the given data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] AddCheckSum(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            byte[] checkSum = GetCheckSum(data);

            var result = new byte[data.Length + checkSum.Length];

            data.CopyTo(result, 0);
            checkSum.CopyTo(result, data.Length);

            return result;
        }

        /// <summary>
        /// Verifies the check sum of the given data and removes the check sum bytes.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] VerifyAndRemoveCheckSum(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length < CheckSumSizeInBytes)
            {
                return null;
            }

            var result = new byte[data.Length - CheckSumSizeInBytes];
            Array.Copy(data, 0, result, 0, result.Length);

            var givenCheckSum = new byte[CheckSumSizeInBytes];
            Array.Copy(data, result.Length, givenCheckSum, 0, givenCheckSum.Length);

            byte[] correctCheckSum = GetCheckSum(result);

            return givenCheckSum.SequenceEqual(correctCheckSum) ? result : null;
        }

        /// <summary>
        /// Encodes the given data bytes as a Base58 string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encode(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var intData = new BigInteger(data.Reverse().Concat(new byte[] { 0 }).ToArray());

            string result = "";
            while (intData > 0)
            {
                int remainder = (int)(intData % 58);
                intData /= 58;
                result = AlphaNumerics[remainder] + result;
            }

            int leadingZeros = data.TakeWhile(b => b == 0).Count();

            return new string('1', leadingZeros) + result;
        }

        /// <summary>
        /// Encodes the given data bytes as a Base58 string with a check sum.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string EncodeWithCheckSum(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            return Encode(AddCheckSum(data));
        }

        /// <summary>
        /// Decodes the given Base58 string into the original data bytes.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static byte[] Decode(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            var intData = new BigInteger(0);
            for (int i = 0; i < str.Length; i++)
            {
                int digit = Array.IndexOf(AlphaNumerics.ToArray(), str[i]);
                if (digit == -1)
                {
                    throw new FormatException($"Invalid Base58 character `{str[i]}` at position {i}");
                }
                intData = intData * 58 + digit;
            }

            int leadingZeroCount = str.TakeWhile(c => c == '1').Count();

            var leadingZeros = Enumerable.Repeat((byte)0, leadingZeroCount);

            var bytesWithoutLeadingZeros =
                intData.ToByteArray()
                .Reverse()
                .SkipWhile(b => b == 0);

            var result = leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray();
            return result;
        }

        /// <summary>
        /// Decodes the given Base58 string with a check sum into the original data bytes.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static byte[] DecodeWithCheckSum(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            var dataWithCheckSum = Decode(str);
            var dataWithoutCheckSum = VerifyAndRemoveCheckSum(dataWithCheckSum);

            return dataWithoutCheckSum ?? throw new FormatException("Base58 checksum is invalid");
        }

        /// <summary>
        /// Get Check Sum
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static byte[] GetCheckSum(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(sha256.ComputeHash(data)).Take(CheckSumSizeInBytes).ToArray();
            }
        }
    }
}