using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Extensions
{
    public static class BytesExtension
    {
        /// <summary>
        /// Load a byte array with random bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Populate(this byte[] value)
        {
            new Random().NextBytes(value);
            return value;
        }
    }
}
