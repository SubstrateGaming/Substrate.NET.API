using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ajuna.NetApi.Sign
{
    /// <summary>
    /// According to Polkadot JS common util (https://github.com/polkadot-js/common/blob/master/packages/util/src/u8a/wrap.ts)
    /// Message to be signed might be wrapped
    /// 
    /// TODO : @Darkfriend77 do you want to manage ethereum wrapping message ?
    /// </summary>
    public class WrapMessage
    {
        private const string U8A_WRAP_PREFIX_STR = "<Bytes>";
        private const string U8A_WRAP_POSTFIX_STR = "</Bytes>";
        private static byte[] U8A_WRAP_PREFIX { get; } = Encoding.UTF8.GetBytes(U8A_WRAP_PREFIX_STR);
        private static byte[] U8A_WRAP_POSTFIX { get; } = Encoding.UTF8.GetBytes(U8A_WRAP_POSTFIX_STR);

        private static int wrapLength = U8A_WRAP_PREFIX.Length + U8A_WRAP_POSTFIX.Length;

        /// <summary>
        /// Check if data is wrapped by <see cref="U8A_WRAP_PREFIX_STR"/> and <see cref="U8A_WRAP_POSTFIX_STR"/>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        public static bool IsWrapped(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException($"{nameof(data)}");

            return data.Length >= wrapLength &&
                (data.Take(U8A_WRAP_PREFIX.Length).SequenceEqual(U8A_WRAP_PREFIX) &&
                data.Skip(data.Length - U8A_WRAP_POSTFIX.Length).Take(U8A_WRAP_POSTFIX.Length).SequenceEqual(U8A_WRAP_POSTFIX));
        }
        public static bool IsWrapped(string data) => IsWrapped(Encoding.UTF8.GetBytes(data));

        /// <summary>
        /// Remove <see cref="U8A_WRAP_PREFIX_STR"/> and <see cref="U8A_WRAP_POSTFIX_STR"/> from given data.
        /// Return data unmodified if already unwrapped
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] Unwrap(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException($"{nameof(data)}");

            return IsWrapped(data) ?
                data
                    .Skip(U8A_WRAP_PREFIX.Length)
                    .Take(data.Length - wrapLength)
                    .ToArray() :
                data;
        }
        public static byte[] Unwrap(string data) => Unwrap(Encoding.UTF8.GetBytes(data));

        /// <summary>
        /// Wrap data with <see cref="U8A_WRAP_PREFIX_STR"/> and <see cref="U8A_WRAP_POSTFIX_STR"/>
        /// Return data unmodified if already wrapped 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] Wrap(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException($"{nameof(data)}");

            return IsWrapped(data) ? 
                data : 
                U8A_WRAP_PREFIX
                .Concat(data)
                .Concat(U8A_WRAP_POSTFIX)
                .ToArray();
        }
        public static byte[] Wrap(string data) => Wrap(Encoding.UTF8.GetBytes(data));
    }
}
