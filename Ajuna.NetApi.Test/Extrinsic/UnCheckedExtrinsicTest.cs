using System;
using NUnit.Framework;

namespace Ajuna.NetApi.Test.Extrinsic
{
    public class UnCheckedExtrinsicTest
    {
        private Random _random;


        [OneTimeSetUp]
        public void Setup()
        {
            _random = new Random();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Test()
        {
            Assert.True(true);
        }

    }
}