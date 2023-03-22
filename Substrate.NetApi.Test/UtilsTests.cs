using System;
using NUnit.Framework;

namespace Substrate.NetApi.Test
{
    public class UtilsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPublicKeyAndNetworkFromTest()
        {
            var addresses = new string[] {
                "HNZata7iMYWmk5RvZRTiAsSDhV8366zq2YGb3tLH5Upf74F",
                "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY",
                "aUuBHS3LZKnPuxyDJYhteYPwGWg932LjHPtbBQKQBA55F4B1T",
                "bUNdEKVCnhNAZvnEWFNcL3T82nAWQduR63fgon1qbrba7AKfN" };

            foreach (var address in addresses)
            {
                var bytes = Utils.GetPublicKeyFrom(address, out short network);
                Assert.AreEqual("D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D",
                    BitConverter.ToString(bytes).Replace("-", ""));

                switch (address)
                {
                    case "HNZata7iMYWmk5RvZRTiAsSDhV8366zq2YGb3tLH5Upf74F":  // KUSAMA
                        Assert.AreEqual(2, network);
                        break;

                    case "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY": // SUBSTRATE
                        Assert.AreEqual(42, network);
                        break;

                    case "aUuBHS3LZKnPuxyDJYhteYPwGWg932LjHPtbBQKQBA55F4B1T": // AJUNA NETWORK
                        Assert.AreEqual(1328, network);
                        break;

                    case "bUNdEKVCnhNAZvnEWFNcL3T82nAWQduR63fgon1qbrba7AKfN": // BAJUN NETWORK
                        Assert.AreEqual(1337, network);
                        break;
                }
            }
        }

        [Test]
        public void GetPublicKeyFromExeceptionTest()
        {
            var addressToBig = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY" + "FFFF";

            var ex1 = Assert.Throws<NotSupportedException>(
                    () => Utils.GetPublicKeyFrom(addressToBig, out short network)
                );
            Assert.IsTrue(ex1.Message.Contains("Unsupported address size."));

            var addressToWrong1 = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQX";

            var ex2 = Assert.Throws<NotSupportedException>(
                    () => Utils.GetPublicKeyFrom(addressToWrong1, out short network)
                );
            Assert.IsTrue(ex2.Message.Contains("Address checksum is wrong."));

            var addressToWrong2 = "bUNdEKVCnhNAZvnEWFNcL3T82nAWQduR63fgon1qbrba7AKfM";

            var ex3 = Assert.Throws<NotSupportedException>(
                    () => Utils.GetPublicKeyFrom(addressToWrong2, out short network)
                );
            Assert.IsTrue(ex3.Message.Contains("Address checksum is wrong."));
        }

        [Test]
        public void GetAddressFromTest()
        {
            short[] prefixes = new short[] { 42, 2, 1337, 1328 };

            var publicKeyString = "0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d";
            var publickey = Utils.HexToByteArray(publicKeyString);

            foreach (var prefix in prefixes)
            {
                var address = Utils.GetAddressFrom(publickey, prefix);
                switch (prefix)
                {
                    case 2:  // KUSAMA
                        Assert.AreEqual("HNZata7iMYWmk5RvZRTiAsSDhV8366zq2YGb3tLH5Upf74F", address);
                        break;

                    case 42: // SUBSTRATE
                        Assert.AreEqual("5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY", address);
                        break;

                    case 1328: // AJUNA NETWORK
                        Assert.AreEqual("aUuBHS3LZKnPuxyDJYhteYPwGWg932LjHPtbBQKQBA55F4B1T", address);
                        break;

                    case 1337: // BAJUN NETWORK
                        Assert.AreEqual("bUNdEKVCnhNAZvnEWFNcL3T82nAWQduR63fgon1qbrba7AKfN", address);
                        break;
                }
            }
        }

        [Test]
        public void LittleEndianIntegerTest()
        {
            Assert.AreEqual(259, Utils.Bytes2Value(Utils.HexToByteArray("0x0301")));
            Assert.AreEqual("0x0301", Utils.Bytes2HexString(Utils.Value2Bytes((ushort)259)));
        }

        [Test]
        public void StringValueArrayBytesArrayTest()
        {
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03, 0x04 }, Utils.StringValueArrayBytesArray("[ 1, 2, 3, 4]"));
            Assert.AreEqual(new byte[] { 0x0C, 0x0D, 0x0E, 0x0F }, Utils.StringValueArrayBytesArray("12, 13, 14, 15"));
            Assert.AreEqual(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }, Utils.StringValueArrayBytesArray("255,255,255,255"));
        }

        [Test]
        public void StringValueArrayBytesArrayFailedTest()
        {
            Assert.Throws<Exception>(delegate { Utils.StringValueArrayBytesArray("Test"); });
        }

        [Test]
        public void Byte2ValueTest()
        {
            var ushortValue = (ushort)Utils.Bytes2Value(new byte[] { 0xFF, 0xFF });
            Assert.AreEqual(65535, ushortValue);

            var uintValue = (uint)Utils.Bytes2Value(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF });
            Assert.AreEqual(4294967295, uintValue);

            var ulongValue = (ulong)Utils.Bytes2Value(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
            Assert.AreEqual(18446744073709551615, ulongValue);

            Assert.AreEqual(0x1312, Utils.Bytes2Value(new byte[] { 0x13, 0x12 }, false));

            Assert.Throws<Exception>(delegate
            {
                Utils.Bytes2Value(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
            });
        }

        [Test]
        public void HexToByteArrayFailedTest()
        {
            Assert.Throws<Exception>(delegate { Utils.HexToByteArray("111"); });
        }

        [Test]
        public void HexToByteArrayZeroTest()
        {
            Assert.AreEqual(new byte[] { 0x00 }, Utils.HexToByteArray("0x0"));
        }

        [Test]
        public void HexToByteArrayUnevenTest()
        {
            Assert.AreEqual(new byte[] { 0x01, 0x11 }, Utils.HexToByteArray("0x111", true));
        }

        [Test]
        public void Value2BytesTest()
        {
            Assert.AreEqual(new byte[] { 0x12, 0x11 }, Utils.Value2Bytes((ushort)0x1112));
            Assert.AreEqual(new byte[] { 0x15, 0x14, 0x13, 0x12 }, Utils.Value2Bytes((uint)0x12131415));
            Assert.AreEqual(new byte[] { 0x15, 0x14, 0x13, 0x12, 0x11, 0x10, 0x09, 0x08 }, Utils.Value2Bytes((ulong)0x0809101112131415));
            Assert.AreEqual(new byte[] { 0x11, 0x12 }, Utils.Value2Bytes((ushort)0x1112, false));
            Assert.Throws<Exception>(delegate { Utils.Value2Bytes(1.4); });
        }

        [Test]
        public void Bytes2HexStringTest()
        {
            Assert.AreEqual("0x1213", Utils.Bytes2HexString(new byte[] { 0x12, 0x13 }));
            Assert.AreEqual("1213", Utils.Bytes2HexString(new byte[] { 0x12, 0x13 }, Utils.HexStringFormat.Pure));
            Assert.AreEqual("12-13", Utils.Bytes2HexString(new byte[] { 0x12, 0x13 }, Utils.HexStringFormat.Dash));
        }

    }
}