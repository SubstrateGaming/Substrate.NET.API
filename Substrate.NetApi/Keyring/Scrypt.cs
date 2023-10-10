using Scrypt;
using Substrate.NetApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Substrate.NetApi.Keyring
{
    /// <summary>
    /// https://github.com/viniciuschiele/Scrypt/tree/master
    /// </summary>
    public static class Scrypt
    {
        /// <summary>
        /// https://github.com/polkadot-js/common/blob/master/packages/util-crypto/src/scrypt/fromU8a.ts
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static ScryptResult FromBytes(byte[] data)
        {
            var salt = data.SubArray(0, 32);
            BigInteger N = new BigInteger(data.SubArray(32 + 0, 32 + 4));
            BigInteger p = new BigInteger(data.SubArray(32 + 4, 32 + 8));
            BigInteger r = new BigInteger(data.SubArray(32 + 8, 32 + 12));

            if(N != ScryptParam.Default.IterationCount || p != ScryptParam.Default.ThreadCount || r != ScryptParam.Default.BlockSize)
                throw new InvalidOperationException("Invalid Scrypt params");

            return new ScryptResult(new ScryptParam(N, p, r), salt);
        }

        public static byte[] ToBytes(byte[] salt, ScryptParam param)
        {
            return salt
                .Concat(param.ToBytes())
                .ToArray();
        }

        /// <summary>
        /// Create a new scrypt encoding with random salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ScryptResult ScryptEncode(string password, ScryptParam param)
        {
            var randomBytes =  new byte[32].Populate();
            return ScryptEncode(password, randomBytes, param);
        }

        /// <summary>
        /// Encode our password with Scrypt algorithm
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ScryptResult ScryptEncode(string password, byte[] salt, ScryptParam param) {
            byte[] passwordBytes = password.ToBytes();
            
            passwordBytes = CryptSharp.Utility.SCrypt.ComputeDerivedKey(passwordBytes, salt, (int)param.IterationCount, (int)param.BlockSize, (int)param.ThreadCount, null, 64);

            return new ScryptResult(param, salt, passwordBytes);
        }
    }

    public class ScryptResult
    {
        public ScryptResult(ScryptParam param, byte[] salt)
        {
            Param = param;
            Salt = salt;
        }

        public ScryptResult(ScryptParam param, byte[] salt, byte[] password) : this(param, salt)
        {
            Password = password;
        }

        public ScryptParam Param { get; }
        public byte[] Salt { get; }
        public byte[] Password { get; }
    }

    public class ScryptParam
    {
        /// <summary>
        /// N
        /// </summary>
        public BigInteger IterationCount { get; }

        /// <summary>
        /// r
        /// </summary>
        public BigInteger ThreadCount { get; }

        /// <summary>
        /// p
        /// </summary>
        public BigInteger BlockSize { get; }


        public ScryptParam(BigInteger iterationCount, BigInteger threadCount, BigInteger blockSize)
        {
            this.IterationCount = iterationCount;
            this.ThreadCount = threadCount;
            this.BlockSize = blockSize;
        }

        /// <summary>
        /// https://github.com/polkadot-js/common/blob/master/packages/util-crypto/src/scrypt/defaults.ts#L6
        /// </summary>
        public static ScryptParam Default { get; set; } = new ScryptParam(1 << 15, 1, 8);

        public byte[] ToBytes()
        {
            return new byte[4] { 0, 128, 0, 0 }
            .Concat(new byte[4] { 1, 0, 0, 0 })
            .Concat(new byte[4] { 8, 0, 0, 0 })
            .ToArray();
        }
    }
}
