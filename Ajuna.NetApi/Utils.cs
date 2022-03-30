using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBase;
using Ajuna.NetApi.Model.Types.Base;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Parameters;

namespace Ajuna.NetApi
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
            Pure,
            Dash,
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
                    throw new Exception(
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
            if (hex.Equals("0x0")) return new byte[] {0x00};

            if (hex.Length % 2 == 1 && !evenLeftZeroPad)
                throw new Exception("The binary key cannot have an odd number of digits");

            if (hex.StartsWith("0x")) hex = hex.Substring(2);

            if (hex.Length % 2 != 0) hex = hex.PadLeft(hex.Length + 1, '0');

            var arr = new byte[hex.Length >> 1];

            for (var i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte) ((GetHexVal(hex[i << 1]) << 4) + GetHexVal(hex[(i << 1) + 1]));

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
                    throw new Exception($"Unhandled byte size {value.Length} for this method!");
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
        /// <param name="value">        The value. </param>
        /// <param name="littleEndian"> (Optional) True to little endian. </param>
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
                    throw new Exception("Unhandled byte size for this method!");
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
        /// or
        /// Address checksum is wrong.
        /// </exception>
        public static byte[] GetPublicKeyFrom(string address)
        {
            var PUBLIC_KEY_LENGTH = 32;

            var pubkByteList = new List<byte>();

            var bs58decoded = Base58.Bitcoin.Decode(address).ToArray();
            var len = bs58decoded.Length;

            if (len == 35)
            {
                byte[] ssPrefixed = {0x53, 0x53, 0x35, 0x38, 0x50, 0x52, 0x45};
                pubkByteList.AddRange(ssPrefixed);
                pubkByteList.AddRange(bs58decoded.Take(PUBLIC_KEY_LENGTH + 1));

                var blake2bHashed = HashExtension.Blake2(pubkByteList.ToArray(), 512);
                if (bs58decoded[PUBLIC_KEY_LENGTH + 1] != blake2bHashed[0] ||
                    bs58decoded[PUBLIC_KEY_LENGTH + 2] != blake2bHashed[1])
                    throw new ApplicationException("Address checksum is wrong.");

                return bs58decoded.Skip(1).Take(PUBLIC_KEY_LENGTH).ToArray();
            }

            throw new ApplicationException("Address checksum is wrong.");
        }

        /// <summary>
        /// Gets the address from.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string GetAddressFrom(byte[] bytes)
        {
            var SR25519_PUBLIC_SIZE = 32;
            var PUBLIC_KEY_LENGTH = 32;

            var plainAddr = Enumerable
                .Repeat((byte) 0x2A, 35)
                .ToArray();

            bytes.CopyTo(plainAddr.AsMemory(1));

            var ssPrefixed = new byte[SR25519_PUBLIC_SIZE + 8];
            var ssPrefixed1 = new byte[] {0x53, 0x53, 0x35, 0x38, 0x50, 0x52, 0x45};
            ssPrefixed1.CopyTo(ssPrefixed, 0);
            plainAddr.AsSpan(0, SR25519_PUBLIC_SIZE + 1).CopyTo(ssPrefixed.AsSpan(7));

            var blake2bHashed = HashExtension.Blake2(ssPrefixed, 0, SR25519_PUBLIC_SIZE + 8);
            plainAddr[1 + PUBLIC_KEY_LENGTH] = blake2bHashed[0];
            plainAddr[2 + PUBLIC_KEY_LENGTH] = blake2bHashed[1];

            var addrCh = Base58.Bitcoin.Encode(plainAddr).ToArray();

            return new string(addrCh);
        }

        public static byte[] RSAEncryptBouncy(byte[] dataToEncrypt, RsaKeyParameters rsaKeyParameters)
        {
            var encrypter = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new Sha256Digest(), null);
            encrypter.Init(true, rsaKeyParameters);
            var cipher = encrypter.ProcessBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            return cipher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataToEncrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, RSAEncryptionPadding OAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    if (OAEPPadding != null) {

                        encryptedData = RSA.Encrypt(DataToEncrypt, OAEPPadding);
                    } else
                    {
                        encryptedData = RSA.Encrypt(DataToEncrypt, false);
                    }
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"
        /// ></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, RSAEncryptionPadding OAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    
                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    if (OAEPPadding != null)
                    {

                        decryptedData = RSA.Decrypt(DataToDecrypt, OAEPPadding);
                    }
                    else
                    {
                        decryptedData = RSA.Decrypt(DataToDecrypt, false);
                    }

                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}