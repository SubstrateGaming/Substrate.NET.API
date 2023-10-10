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
    }
}
