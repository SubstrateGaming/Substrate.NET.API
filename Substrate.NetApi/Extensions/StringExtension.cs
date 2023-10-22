using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Extensions
{
    public static class StringExtension
    {
        public static byte[] ToBytes(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static bool IsHex(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            if (value.ToLower().StartsWith("0x"))
                value = value.Remove(0, 2);

            return value.Length % 2 == 0 && IsHexCharacters(value);
        }

        private static bool IsHexCharacters(string input)
        {
            foreach (char c in input)
            {
                if (!IsHexDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsHexDigit(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
        }
    }
}
