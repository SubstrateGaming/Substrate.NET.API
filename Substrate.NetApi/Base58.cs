using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace Substrate.NetApi
{
    public static class Base58Local
    {
        private const string AlphaNumerics = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public const int CheckSumSizeInBytes = 4;

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

        public static string EncodeWithCheckSum(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            return Encode(AddCheckSum(data));
        }

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