using System;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Era
    /// </summary>
    public class Era : IEncodable
    {
        /// <summary>
        /// Is Immortal
        /// </summary>
        public bool IsImmortal { get; }

        /// <summary>
        /// Period
        /// </summary>
        public ulong Period { get; }

        /// <summary>
        /// Phase
        /// </summary>
        public ulong Phase { get; }

        /// <summary>
        /// Era Start
        /// </summary>
        /// <param name="currentBlockNumber"></param>
        /// <returns></returns>
        public ulong EraStart(ulong currentBlockNumber) => IsImmortal ? 0 : (Math.Max(currentBlockNumber, Phase) - Phase) / Period * Period + Phase;

        /// <summary>
        /// Era End
        /// </summary>
        /// <param name="currentBlockNumber"></param>
        /// <returns></returns>
        public ulong EraEnd(ulong currentBlockNumber) => EraStart(currentBlockNumber) + Period;

        /// <summary>
        /// Initializes a new instance of the <see cref="Era"/> class.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <param name="phase">The phase.</param>
        /// <param name="isImmortal">if set to <c>true</c> [is immortal].</param>
        public Era(ulong period, ulong phase, bool isImmortal)
        {
            Period = period;
            Phase = phase;
            IsImmortal = isImmortal;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates the specified life time.
        /// </summary>
        /// <param name="lifeTime">The life time.</param>
        /// <param name="finalizedHeaderBlockNumber">The finalized header block number.</param>
        /// <returns></returns>
        public static Era Create(uint lifeTime, ulong finalizedHeaderBlockNumber)
        {
            if (lifeTime == 0)
            {
                return new Era(0, 0, true);
            }

            // NODE: { "IsImmortal":false,"Period":64,"Phase":49}
            // API: { "IsImmortal":false,"Period":64,"Phase":61}
            ulong period = (ulong)Math.Pow(2, Math.Round(Math.Log(lifeTime, 2)));
            period = Math.Max(period, 4);
            period = Math.Min(period, 65536);
            ulong phase = finalizedHeaderBlockNumber % period;
            var quantize_factor = Math.Max(period >> 12, 1);
            var quantized_phase = phase / quantize_factor * quantize_factor;

            return new Era(period, quantized_phase, false);
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            if (IsImmortal)
            {
                return new byte[] { 0x00 };
            }
            var quantizeFactor = Math.Max(1, Period / 4096);
            var lastBit = Period & (ulong)-(long)Period;
            var logOf2 = lastBit != 0 ? Math.Log(lastBit, 2) : 64;
            var low = (ushort)Math.Min(15, Math.Max(1, logOf2 - 1));
            var high = (ushort)(Phase / quantizeFactor << 4);
            var encoded = (ushort)(low | high);

            return BitConverter.GetBytes(encoded);
        }

        /// <summary>
        /// Decodes the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        /// <exception cref="Era">
        /// 0, 0, true
        /// or
        /// 0, 0, true
        /// </exception>
        public static Era Decode(byte[] bytes)
        {
            if (bytes.Length == 1 && bytes[0] == 0x00)
            {
                return new Era(0, 0, true);
            }
            else if (bytes.Length == 2)
            {
                var ul0 = (ulong)bytes[0];
                var ul1 = (ulong)bytes[1];
                var encoded = ul0 + (ul1 << 8);
                var period = 2UL << (int)(encoded % (1 << 4));
                var quantizeFactor = Math.Max(1, period >> 12);
                var phase = (encoded >> 4) * quantizeFactor;
                if (period < 4 || phase >= period)
                {
                    throw new ArgumentException($"{Utils.Bytes2HexString(new byte[] { bytes[0], bytes[1] })} is not a valid representation of Era.");
                }
                return new Era(period, phase, false);
            }
            else
            {
                throw new NotSupportedException("Invalid byte array to get era.");
            }
        }
    }
}