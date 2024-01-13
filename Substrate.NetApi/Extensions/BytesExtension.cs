using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Substrate.NetApi.Extensions
{
    /// <summary>
    /// Bytes Extension
    /// </summary>
    public static class BytesExtension
    {
        private static readonly RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();

        /// <summary>
        /// Load a byte array with random bytes
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Populate(this byte[] data)
        {
            RandomGenerator.GetBytes(data);
            return data;
        }

        /// <summary>
        /// Convert bytes to hex
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bitLength"></param>
        /// <param name="atStart"></param>
        /// <returns></returns>
        public static byte[] BytesFixLength(this byte[] value, int bitLength = -1, bool atStart = false)
        {
            int byteLength = (bitLength == -1) ? value.Length : (int)Math.Ceiling(bitLength / 8.0);

            if (value.Length == byteLength)
            {
                return value;
            }

            if (value.Length > byteLength)
            {
                return value.Take(byteLength).ToArray();
            }

            byte[] result = new byte[byteLength];
            int copyIndex = atStart ? 0 : byteLength - value.Length;

            Array.Copy(value, 0, result, copyIndex, value.Length);

            return result;
        }
    }
}
