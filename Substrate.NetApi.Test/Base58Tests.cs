using System;
using NUnit.Framework;

namespace Substrate.NetApi.Test
{
    public class Base58Tests
    {
        private Tuple<string, byte[]>[] testCases;

        [SetUp]
        public void Setup()
        {
            testCases = new Tuple<string, byte[]>[]{
            Tuple.Create("", Array.Empty<byte>()),
            Tuple.Create("1112",new byte[]{0x00, 0x00, 0x00, 0x01}),
            Tuple.Create("2g",new byte[]{0x61}),
            Tuple.Create("a3gV",new byte[]{0x62,0x62,0x62}),
            Tuple.Create("aPEr",new byte[]{0x63,0x63,0x63}),
            Tuple.Create("2cFupjhnEsSn59qHXstmK2ffpLv2",new byte[]{0x73,0x69,0x6d,0x70,0x6c,0x79,0x20,0x61,0x20,0x6c,0x6f,0x6e,0x67,0x20,0x73,0x74,0x72,0x69,0x6e,0x67}),
            Tuple.Create("1NS17iag9jJgTHD1VXjvLCEnZuQ3rJDE9L",new byte[]{0x00,0xeb,0x15,0x23,0x1d,0xfc,0xeb,0x60,0x92,0x58,0x86,0xb6,0x7d,0x06,0x52,0x99,0x92,0x59,0x15,0xae,0xb1,0x72,0xc0,0x66,0x47}),
            Tuple.Create("ABnLTmg",new byte[]{0x51,0x6b,0x6f,0xcd,0x0f}),
            Tuple.Create("3SEo3LWLoPntC",new byte[]{0xbf,0x4f,0x89,0x00,0x1e,0x67,0x02,0x74,0xdd}),
            Tuple.Create("3EFU7m",new byte[]{0x57,0x2e,0x47,0x94}),
            Tuple.Create("EJDM8drfXA6uyA",new byte[]{0xec,0xac,0x89,0xca,0xd9,0x39,0x23,0xc0,0x23,0x21}),
            Tuple.Create("Rt5zm",new byte[]{0x10,0xc8,0x51,0x1e}),
            Tuple.Create("1111111111",new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00})
        };
        }

        [Test]
        public void Encode()
        {
            foreach (var tuple in testCases)
            {
                var bytes = tuple.Item2;
                var expectedText = tuple.Item1;
                var actualText = Base58Local.Encode(bytes);
                Assert.AreEqual(expectedText, actualText);
            }
        }

        [Test]
        public void Decode()
        {
            foreach (var tuple in testCases)
            {
                var text = tuple.Item1;
                var expectedBytes = tuple.Item2;
                var actualBytes = Base58Local.Decode(text);
                Assert.AreEqual(BitConverter.ToString(expectedBytes), BitConverter.ToString(actualBytes));
            }
        }
    }
}