using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Substrate.NetApi
{
    /// <summary> An utilities. </summary>
    /// <remarks> 19.09.2020. </remarks>
    public class Utils
    {
        /// <summary>
        /// Different representations of a hex string.
        /// </summary>
        public enum HexStringFormat
        {
            /// <summary>
            /// Pure hex string without any separators.
            /// </summary>
            Pure,

            /// <summary>
            /// Hex string with dash separators.
            /// </summary>
            Dash,

            /// <summary>
            /// Hex string with 0x prefix.
            /// </summary>
            Prefixed
        }

        /// <summary>
        /// Convert bytes to the hexadecimal string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unimplemented hex string format '{format}'</exception>
        public static string Bytes2HexString(byte[] bytes, HexStringFormat format = HexStringFormat.Prefixed)
        {
            switch (format)
            {
                case HexStringFormat.Pure:
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);

                case HexStringFormat.Dash:
                    return BitConverter.ToString(bytes);

                case HexStringFormat.Prefixed:
                    return $"0x{BitConverter.ToString(bytes).Replace("-", string.Empty)}";

                default:
                    throw new Exception($"Unimplemented hex string format '{format}'");
            }
        }

        /// <summary>
        /// Strings the value array bytes array.
        /// </summary>
        /// <param name="valueArray">The value array.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Not valid string array for byte array conversion. Format should be [ 0-255, 0-255, ...]</exception>
        public static byte[] StringValueArrayBytesArray(string valueArray)
        {
            var strArray = valueArray
                .Replace("[", "")
                .Replace("]", "")
                .Replace(" ", "")
                .Split(',');

            var result = new byte[strArray.Length];

            for (var i = 0; i < strArray.Length; i++)
                if (byte.TryParse(strArray[i], out var parsedByte))
                    result[i] = parsedByte;
                else
                    throw new NotSupportedException(
                        "Not valid string array for byte array conversion. Format should be [ 0-255, 0-255, ...]");

            return result;
        }

        /// <summary>
        /// Converts hexadecimal string to byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <param name="evenLeftZeroPad">if set to <c>true</c> [even left zero pad].</param>
        /// <returns></returns>
        /// <exception cref="Exception">The binary key cannot have an odd number of digits</exception>
        public static byte[] HexToByteArray(string hex, bool evenLeftZeroPad = false)
        {
            if (hex.Equals("0x0")) return new byte[] { 0x00 };

            if (hex.Length % 2 == 1 && !evenLeftZeroPad)
                throw new NotSupportedException("The binary key cannot have an odd number of digits");

            if (hex.StartsWith("0x")) hex = hex.Substring(2);

            if (hex.Length % 2 != 0) hex = hex.PadLeft(hex.Length + 1, '0');

            var arr = new byte[hex.Length >> 1];

            for (var i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + GetHexVal(hex[(i << 1) + 1]));

            return arr;
        }

        /// <summary>
        /// Converts bytes to value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="littleEndian">if set to <c>true</c> [little endian].</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unhandled byte size {value.Length} for this method!</exception>
        public static object Bytes2Value(byte[] value, bool littleEndian = true)
        {
            if (!littleEndian) Array.Reverse(value);

            switch (value.Length)
            {
                case 2:
                    return BitConverter.ToUInt16(value, 0);

                case 4:
                    return BitConverter.ToUInt32(value, 0);

                case 8:
                    return BitConverter.ToUInt64(value, 0);

                default:
                    throw new NotSupportedException($"Unhandled byte size {value.Length} for this method!");
            }
        }

        /// <summary> Size prefixed byte array. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="list"> The list. </param>
        /// <returns> A byte[]. </returns>
        public static byte[] SizePrefixedByteArray(List<byte> list)
        {
            var result = new List<byte>();
            result.AddRange(new CompactInteger(list.Count).Encode());
            result.AddRange(list);
            return result.ToArray();
        }

        /// <summary> Value 2 bytes. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <param name="value">The value.</param>
        /// <param name="littleEndian">(Optional) True to little endian. </param>
        /// <returns> A byte[]. </returns>
        public static byte[] Value2Bytes(object value, bool littleEndian = true)
        {
            byte[] result;

            switch (value)
            {
                case ushort s:
                    result = BitConverter.GetBytes(s);
                    break;

                case uint s:
                    result = BitConverter.GetBytes(s);
                    break;

                case ulong s:
                    result = BitConverter.GetBytes(s);
                    break;

                default:
                    throw new NotSupportedException("Unhandled byte size for this method!");
            }

            if (!littleEndian) Array.Reverse(result);

            return result;
        }

        /// <summary> Gets hexadecimal value. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="hex"> The hexadecimal. </param>
        /// <returns> The hexadecimal value. </returns>
        public static int GetHexVal(char hex)
        {
            int val = hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : val < 97 ? 55 : 87);
        }

        /// <summary>
        /// Gets the public key from.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">
        /// Address checksum is wrong.
        /// </exception>
        public static byte[] GetPublicKeyFrom(string address)
        {
            return GetPublicKeyFrom(address, out _);
        }

        /// <summary>
        /// Gets the public key and network from.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        public static byte[] GetPublicKeyFrom(string address, out short network)
        {
            network = 42;
            var PUBLIC_KEY_LENGTH = 32;
            var PREFIX_SIZE = 0;
            var pubkByteList = new List<byte>();

            var bs58decoded = Base58Local.Decode(address);
            var len = bs58decoded.Length;

            byte[] ssPrefixed = { 0x53, 0x53, 0x35, 0x38, 0x50, 0x52, 0x45 };

            // 00000000b..=00111111b (0..=63 inclusive): Simple account/address/network identifier.
            if (len == 35)
            {
                PREFIX_SIZE = 1;
                // set network
                network = bs58decoded[0];
            }
            else
            // 01000000b..=01111111b (64..=127 inclusive)
            if (len == 36)
            {
                PREFIX_SIZE = 2;
                // set network
                byte b2up = (byte)((bs58decoded[0] << 2) & 0b1111_1100);
                byte b2lo = (byte)((bs58decoded[1] >> 6) & 0b0000_0011);
                byte b2 = (byte)(b2up | b2lo);
                byte b1 = (byte)(bs58decoded[1] & 0b0011_1111);
                network = (short)BitConverter.ToInt16(
                    new byte[] { b2, b1 }, 0); // big endian, for BitConverter
            }
            else
            {
                throw new NotSupportedException("Unsupported address size.");
            }

            pubkByteList.AddRange(ssPrefixed);
            pubkByteList.AddRange(bs58decoded.Take(PUBLIC_KEY_LENGTH + PREFIX_SIZE));

            var blake2bHashed = HashExtension.Blake2(pubkByteList.ToArray(), 512);
            if (bs58decoded[PUBLIC_KEY_LENGTH + PREFIX_SIZE] != blake2bHashed[0] ||
                bs58decoded[PUBLIC_KEY_LENGTH + PREFIX_SIZE + 1] != blake2bHashed[1])
            {
                throw new NotSupportedException("Address checksum is wrong.");
            }

            return bs58decoded.Skip(PREFIX_SIZE).Take(PUBLIC_KEY_LENGTH).ToArray();
        }

        /// <summary>
        /// Gets the address from.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string GetAddressFrom(byte[] bytes, short ss58Prefix = 42)
        {
            // https://docs.substrate.io/v3/advanced/ss58/

            var SR25519_PUBLIC_SIZE = 32;
            var PUBLIC_KEY_LENGTH = 32;
            var KEY_SIZE = 0;

            byte[] plainAddr;
            // 00000000b..=00111111b (0..=63 inclusive): Simple account/address/network identifier.
            // The byte can be interpreted directly as such an identifier.
            if (ss58Prefix < 64)
            {
                KEY_SIZE = 1;
                plainAddr = new byte[35];
                plainAddr[0] = (byte)ss58Prefix;
                bytes.CopyTo(plainAddr.AsMemory(1));
            }
            // 01000000b..=01111111b (64..=127 inclusive): Full address/address/network identifier.
            // The lower 6 bits of this byte should be treated as the upper 6 bits of a 14 bit identifier
            // value, with the lower 8 bits defined by the following byte. This works for all identifiers
            // up to 2**14 (16,383).
            else if (ss58Prefix < 16384)
            {
                KEY_SIZE = 2;
                plainAddr = new byte[36];

                // parity style
                var ident = ss58Prefix & 0b00111111_11111111; // clear first two bits
                var first = (byte)(((ident & 0b0000_0000_1111_1100) >> 2) | 0b0100_0000);
                var second = (byte)((ident >> 8) | (ident & 0b0000_0000_0000_0011) << 6);

                plainAddr[0] = first;
                plainAddr[1] = second;

                bytes.CopyTo(plainAddr.AsMemory(2));
            }
            else
            {
                throw new NotSupportedException("Unsupported prefix used, support only up to 16383!");
            }

            var ssPrefixed = new byte[SR25519_PUBLIC_SIZE + 7 + KEY_SIZE];
            var ssPrefixed1 = new byte[] { 0x53, 0x53, 0x35, 0x38, 0x50, 0x52, 0x45 };
            ssPrefixed1.CopyTo(ssPrefixed, 0);
            plainAddr.AsSpan(0, SR25519_PUBLIC_SIZE + KEY_SIZE).CopyTo(ssPrefixed.AsSpan(7));

            var blake2bHashed = HashExtension.Blake2(ssPrefixed, 0, SR25519_PUBLIC_SIZE + 7 + KEY_SIZE);
            plainAddr[0 + KEY_SIZE + PUBLIC_KEY_LENGTH] = blake2bHashed[0];
            plainAddr[1 + KEY_SIZE + PUBLIC_KEY_LENGTH] = blake2bHashed[1];

            return Base58Local.Encode(plainAddr);
        }

    }
}