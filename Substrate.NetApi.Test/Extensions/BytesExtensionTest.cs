using NUnit.Framework;
using Substrate.NetApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NetApi.Test.Extensions
{
    public class BytesExtensionTest
    {
        [Test]
        public void BytesFixLength_WhenNoChangeNeeded_ReturnsOriginalArray()
        {
            byte[] originalBytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            int bitLength = originalBytes.Length * 8;

            byte[] result = originalBytes.BytesFixLength(bitLength);

            Assert.That(originalBytes, Is.EqualTo(result));
        }

        [Test]
        public void BytesFixLength_WhenShorter_WithAtStart_True_PrependsZeros()
        {
            byte[] originalBytes = new byte[] { 0x01, 0x02 };
            int bitLength = 32; // 4 bytes
            bool atStart = true;

            byte[] result = originalBytes.BytesFixLength(bitLength, atStart);

            byte[] expected = new byte[] { 0x01, 0x02, 0x00, 0x00 };
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void BytesFixLength_WhenShorter_WithAtStart_False_AppendsZeros()
        {
            byte[] originalBytes = new byte[] { 0x01, 0x02 };
            int bitLength = 32; // 4 bytes
            bool atStart = false;

            byte[] result = originalBytes.BytesFixLength(bitLength, atStart);

            byte[] expected = new byte[] { 0x00, 0x00, 0x01, 0x02 };
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void BytesFixLength_WhenLonger_TruncatesArray()
        {
            byte[] originalBytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
            int bitLength = 24; // 3 bytes

            byte[] result = originalBytes.BytesFixLength(bitLength);

            byte[] expected = new byte[] { 0x01, 0x02, 0x03 };
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
