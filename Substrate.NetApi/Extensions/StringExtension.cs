using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Extensions
{
    /// <summary>
    /// String Extension
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert string to bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Convert string to hex
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsHex(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            if (value.ToLower().StartsWith("0x"))
                value = value.Remove(0, 2);

            return value.Length % 2 == 0 && IsHexCharacters(value);
        }

        /// <summary>
        /// Convert string to hex
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static bool IsHexCharacters(string input)
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

        /// <summary>
        /// Convert string to hex
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsHexDigit(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
        }
    }
}
