using NUnit.Framework;
using Substrate.NetApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NetApi.Test.Extensions
{
    public class HexadecimalValidatorTests
    {
        [Test]
        [TestCase("", false)]
        [TestCase("1234567890ABCDEF", true)]
        [TestCase("0x1234567890ABCDEF", true)]
        [TestCase("0x1234567890ABCDEF", true)]
        [TestCase("1A2F3D", true)]
        [TestCase("abcdef", true)]
        [TestCase("0Xabcdef", true)]
        [TestCase("12G", false)]
        [TestCase("1X2", false)]
        [TestCase("  ", false)]
        [TestCase(null, false)]
        public void IsHexadecimal_ValidatingHexadecimalStrings(string input, bool expected)
        {
            bool result = input.IsHex();
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
