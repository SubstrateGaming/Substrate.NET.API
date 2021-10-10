using NUnit.Framework;
using Ajuna.NetApi.Model.Meta;

namespace Ajuna.NetApi.Test
{
    public class RequestGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetStorageTest()
        {
            var result = RequestGenerator.GetStorage("Sudo", "Key", Storage.Type.Plain);
            Assert.AreEqual("0x5C0D1176A568C1F92944340DBFED9E9C530EBCA703C85910E7164CB7D1C9E47B", result);
        }

        [Test]
        public void GetKeyBytesTest()
        {
            var result = Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash("System", "Account"));
            Assert.AreEqual("0x26AA394EEA5630E07C48AE0C9558CEF7B99D880EC681799C0CF30E8886371DA9", result);
        }
    }
}